using iTortaniServer.Models;

namespace iTortaniServer.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> Get(int id); 
        Task<Order> Create(Order order);
        Task Update(Order order);
        Task Delete(int id);
        Task<IEnumerable<Order>> searchOrder(string nomeCliente);

    }
}
