using iTortaniServer.Models.Spese;

namespace iTortaniServer.Repository
{
    public interface ISpeseRepository
    {
        Task<IEnumerable<Spese>> GetAll();
        Task<Spese> Get(int id);
        Task<Spese> Create(Spese order);
        Task Update(Spese order);
        Task Delete(int id);
        Task<IEnumerable<Spese>> searchOrder(string nomeCliente);
    }
}
