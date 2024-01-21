using Day2_Demo3Table.Data;
using Day2_Demo3Table.IRepository;
using Day2_Demo3Table.Models;
using Day2_Demo3Table.Services;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Day2_Demo3Table.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo orderRepo;
        public OrderController(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetOrdersByUser(int userId)
        {
            try
            {
                var listOrder = await orderRepo.GetAllOrders(userId);
                return Ok(listOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostOrder(Order order)
        {
            try
            {
                var result = await orderRepo.AddOrder(order);
                return Ok("add order success: " + result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet("exportpdf/{orderId}")]
        public async Task<ActionResult> ExportOrderToPDF(int orderId)
        {
            try
            {
                // Generate the PDF content
                var pdfStream = await orderRepo.ExportPDFOrderDetails(orderId);

                // Set appropriate content type and content disposition headers
                Response.ContentType = MediaTypeNames.Application.Pdf;
                Response.Headers.Add("Content-Disposition", $"attachment; filename=Order_{orderId}.pdf");

                // Return the PDF as a file stream
                return File(pdfStream.ToArray(), "application/pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Details/{orderId}")]
        public async Task<ActionResult> GetOrderDetails(int orderId)
        {
            try
            {
                var order = await orderRepo.GetOrderDetails(orderId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
