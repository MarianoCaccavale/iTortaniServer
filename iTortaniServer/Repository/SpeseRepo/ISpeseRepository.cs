using iTortaniServer.Models.Spese;

namespace iTortaniServer.Repository
{
    public interface ISpeseRepository
    {
        Task<IEnumerable<Spese>> GetAll();
        Task<Spese> Get(int id);
        Task<Spese> Create(Spese order);
        Task Update(Spese order);
        Task DeleteAll();
        Task Delete(int id);
        Task<IEnumerable<Spese>> searchOrder(string nomeCliente);
        Task<IEnumerable<Spese>> searchSpecificSpesa(string nomeCliente, string cellNumber);
        Task<IEnumerable<Spese>> searchSpeseByDate(DateTime date);
    }
}
