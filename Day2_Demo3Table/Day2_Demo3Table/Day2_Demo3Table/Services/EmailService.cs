using Day2_Demo3Table.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Demo3Table.Services
{
    public class EmailService
    {
        public async Task SendEmailConfirmationAsync(string toEmail, int orderId, List<OrderDetail> orderDetails)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("tran thien nhan", "pipclupnomad@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = "Order Confirmation";

            var builder = new BodyBuilder();

            // Your template HTML with a table for order details
            StringBuilder template = new StringBuilder();
            template.AppendLine("<html>");
            template.AppendLine("<head>");
            template.AppendLine("<style>");
            // CSS inline để làm cho cột rộng ra hơn
            template.AppendLine("table { width: 100%; border-collapse: collapse; }");
            template.AppendLine("th, td { padding: 10px; text-align: left; }");
            template.AppendLine("th { background-color: #f2f2f2; }");
            template.AppendLine("</style>");
            template.AppendLine("</head>");
            template.AppendLine("<body>");
            template.AppendLine("<h2>Order Confirmation</h2>");
            template.AppendLine("<p>Thank you for your order. Below is the summary of your order:</p>");
            template.AppendLine("<table border='1'>");
            template.AppendLine("<tr>");
            template.AppendLine("<th style='width: 40%;'>Product</th>");
            template.AppendLine("<th style='width: 20%;'>Quantity</th>");
            template.AppendLine("<th style='width: 20%;'>Price</th>");
            template.AppendLine("<th style='width: 20%;'>Total</th>");
            template.AppendLine("</tr>");

            decimal grandTotal = 0; // Biến để tích lũy tổng giá trị

            foreach (var detail in orderDetails)
            {
                template.AppendLine("<tr>");
                template.AppendLine($"<td>{detail.Product?.Name}</td>");
                template.AppendLine($"<td>{detail.Quantity}</td>");
                template.AppendLine($"<td>${detail.Product?.Price}.00</td>");
                template.AppendLine($"<td>${detail.Product?.Price * detail.Quantity}.00</td>");
                template.AppendLine("</tr>");

                // Cập nhật tổng giá trị
                grandTotal += detail.Product?.Price * detail.Quantity ?? 0;
            }

            // Thêm dòng hiển thị tổng giá trị
            template.AppendLine("<tr>");
            template.AppendLine("<td colspan='3' style='text-align: right;'>Total must pay:</td>");
            template.AppendLine($"<td>${grandTotal}.00</td>");
            template.AppendLine("</tr>");

            template.AppendLine("</table>");
            template.AppendLine("</body>");
            template.AppendLine("</html>");

            builder.HtmlBody = template.ToString();

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("pipclupnomad@gmail.com", "gujv vlgk njad ghlt");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }

    }
}
