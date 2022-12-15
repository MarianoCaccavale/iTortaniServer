using iTortaniServer.Models;
using Microsoft.EntityFrameworkCore;

namespace iTortaniServer.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        public async Task<Order> Create(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task DeleteAll()
        {
            _context.Orders.ExecuteDelete();
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var orderToDelete = await _context.Orders.FindAsync(id);
            if (orderToDelete != null) {
                _context.Orders.Remove(orderToDelete);
            }

            await _context.SaveChangesAsync();

        }

        public async Task<Order> Get(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> searchOrder(string nomeCliente)
        {
            LinkedList<Order> result = new LinkedList<Order>();
            List<Order> list =  await _context.Orders.ToListAsync();

            foreach (Order order in list)
            {
                if (order.Cliente.ToLower().Contains(nomeCliente.ToLower()))
                {
                    result.AddLast(order);
                }
            }

            return result;

        }

        public async Task<IEnumerable<Order>> searchSpecificOrder(string nomeCliente, string cellNumber)
        {
            LinkedList<Order> result = new LinkedList<Order>();
            List<Order> list = await _context.Orders.ToListAsync();

            foreach (Order order in list)
            {
                if (order.Cliente.ToLower().Contains(nomeCliente.ToLower()))
                {
                    result.AddLast(order);
                }
                else if(order.CellNum.ToString().ToLower().Contains(cellNumber.ToLower())){
                    result.AddLast(order);
                }
            }

            return result;
        }

        public async Task<IEnumerable<Order>> searchOrdersByDate(DateTime date)
        {
            LinkedList<Order> result = new LinkedList<Order>();
            List<Order> list = await _context.Orders.ToListAsync();

            foreach (Order order in list)
            {
                if (order.DataRitiro.Year.Equals(date.Year) && 
                    order.DataRitiro.Month.Equals(date.Month) && 
                    order.DataRitiro.Day.Equals(date.Day))
                {
                    result.AddLast(order);
                }
            }

            return result;
        }

        public async Task Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
