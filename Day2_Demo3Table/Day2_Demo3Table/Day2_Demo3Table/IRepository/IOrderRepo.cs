using Day2_Demo3Table.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day2_Demo3Table.IRepository
{
    public interface IOrderRepo
    {
        Task<int> AddOrder(Order order);
        Task<IEnumerable<Order>> GetAllOrders(int userId);
        Task<Order> GetOrderDetails(int orderId);
        Task<MemoryStream> ExportPDFOrderDetails(int orderId);
        Task<DateTime?> GetOrderDate(int orderId);
    }
}
