using iTortaniServer.Models.Spese;
using Microsoft.EntityFrameworkCore;

namespace iTortaniServer.Repository.SpeseRepo
{
    public class SpeseRepository : ISpeseRepository
    {

        private readonly SpeseContext _context;

        public SpeseRepository(SpeseContext context)
        {
            _context = context;
        }

        public async Task<Spese> Create(Spese spesa)
        {
            _context.Spese.Add(spesa);
            await _context.SaveChangesAsync();

            return spesa;
        }

        public async Task Delete(int id)
        {
            var spesaToDelete = await _context.Spese.FindAsync(id);
            if (spesaToDelete != null)
            {
                _context.Spese.Remove(spesaToDelete);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Spese> Get(int id)
        {
            return await _context.Spese.FindAsync(id);
        }

        public async Task<IEnumerable<Spese>> GetAll()
        {
            return await _context.Spese.ToListAsync();
        }

        public async Task<IEnumerable<Spese>> searchOrder(string nomeCliente)
        {
            LinkedList<Spese> result = new LinkedList<Spese>();
            List<Spese> list = await _context.Spese.ToListAsync();

            foreach (Spese spese in list)
            {
                if (spese.Cliente.ToLower().Contains(nomeCliente.ToLower()))
                {
                    result.AddLast(spese);
                }
            }

            return result;
        }

        public async Task Update(Spese spesa)
        {
            _context.Entry(spesa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
