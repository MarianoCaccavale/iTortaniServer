using iTortaniServer.Models;

namespace iTortaniServer.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> Get(int id); 
        Task<Order> Create(Order order);
        Task Update(Order order);
        Task DeleteAll();
        Task Delete(int id);
        Task<IEnumerable<Order>> searchOrder(string nomeCliente);
        Task<IEnumerable<Order>> searchSpecificOrder(string nomeCliente, string cellNumber);
        Task<IEnumerable<Order>> searchOrdersByDate(DateTime date);

    }
}
