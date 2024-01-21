using Day2_Demo3Table.Data;
using Day2_Demo3Table.IRepository;
using Day2_Demo3Table.Models;
using Day2_Demo3Table.ModelStatic;
using Day2_Demo3Table.Services;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.Net.Mail;

namespace Day2_Demo3Table.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly DatabaseContext db;
        private readonly EmailService emailService;

        public OrderRepo(DatabaseContext db, EmailService emailService)
        {
            this.db = db;
            this.emailService = emailService;
        }

        public async Task<int> AddOrder(Order order)
        {
            //tạo transaction
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    //lấy listcart của user dựa vào userId
                    var listCart = await db.Carts.Where(c => c.UserId == order.UserId).ToListAsync();
                    order.Details = new List<OrderDetail>();

                    if (listCart == null || listCart.Count == 0)
                    {
                        transaction.Commit();
                        return 0;
                    }

                    //lấy listcart gán Orderdetail của order
                    foreach (var cart in listCart)
                    {
                        OrderDetail detail = new OrderDetail();
                        detail.ProductId = cart.ProductId;
                        detail.Quantity = cart.Quantity;
                        order.Details.Add(detail);
                    }

                    db.Orders.Add(order);

                    foreach (var cart in listCart)
                    {
                        db.Carts.Remove(cart);
                    }

                    var result = await db.SaveChangesAsync();
                    var userid = UserStatic.userId;

                    var user = await db.Users.SingleOrDefaultAsync(u => u.Id == userid);
                    var userEmail = user.Email;
                    var orderDetailList = await db.OrderDetails.Include(od => od.Product).Include(od => od.Order).Where(od => od.OrderId == order.Id).ToListAsync();    

                    // Gửi email xác nhận đơn hàng
                    await emailService.SendEmailConfirmationAsync(userEmail, order.Id, orderDetailList);

                    transaction.Commit(); //dừng transaction
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrders(int userId)
        {
            return await db.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task<Order> GetOrderDetails(int orderId)
        {
            var result = await db.Orders.Include(c => c.Details).ThenInclude(od => od.Product).SingleOrDefaultAsync(o => o.Id == orderId);
            return result;
        }

        public async Task<MemoryStream> ExportPDFOrderDetails(int orderId)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new PdfWriter(memoryStream))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        // Fetch order details efficiently
                        var order = await GetOrderDetails(orderId);

                        // Create document structure
                        Document document = new Document(pdf);

                        // Add header elements
                        Paragraph headerParagraph = new Paragraph("Order Details");
                        headerParagraph.SetFontSize(16);
                        headerParagraph.SetTextAlignment(TextAlignment.CENTER);
                        document.Add(headerParagraph);
                        document.Add(new Paragraph("---"));

                        // Add order information
                        Table table = new Table(new float[] { 150, 300 });
                        table.AddCell("Order ID:").AddCell(order.Id.ToString());
                        table.AddCell("Order Date:").AddCell(order.OrderDate.ToString("yyyy-MM-dd HH:mm"));
                        table.AddCell("Address:").AddCell(order.Address);
                        table.AddCell("Phone:").AddCell(order.Phone);
                        document.Add(table);

                        // Add order details table
                        table = new Table(new float[] { 100, 150, 100, 150 });
                        table.AddCell("Product Name");
                        table.AddCell("Quantity");
                        table.AddCell("Price");
                        table.AddCell("Total");

                        decimal grandTotal = 0; // Biến để lưu tổng tiền

                        foreach (var detail in order.Details)
                        {
                            table.AddCell(detail.Product.Name);
                            table.AddCell(detail.Quantity.ToString());
                            table.AddCell(detail.Product.Price.ToString("C")); // Assuming a decimal Price property
                            var totalPrice = detail.Product.Price * detail.Quantity;
                            table.AddCell(totalPrice.ToString("C"));

                            grandTotal += totalPrice; // Cập nhật tổng tiền
                        }

                        // Add total row at the end
                        table.AddCell("").AddCell("").AddCell("Grand Total:").AddCell(grandTotal.ToString("C"));

                        document.Add(table);

                        // Close and return PDF
                        document.Close();
                        return memoryStream;
                    }
                }
            }
        }
        public async Task<DateTime?> GetOrderDate(int orderId)
        {
            var order = await db.Orders.SingleOrDefaultAsync(o => o.Id == orderId);

            if (order != null)
            {
                var orderDate = order.OrderDate;
                return orderDate;
            }
            return null;
        }
    }
}
