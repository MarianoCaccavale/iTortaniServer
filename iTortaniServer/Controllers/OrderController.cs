using iTortaniServer.Models;
using iTortaniServer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace iTortaniServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        public class GetOrdersModel
        {
            public String accessToken { get; set; }
        }

        [HttpPost]
        [Route("get_orders")]
        public async Task<IEnumerable<Order>> GetOrders(GetOrdersModel model)
        {
            return await _repository.GetAll();
        }

        public class GetOrderModel
        {
            public String accessToken { get; set; }
            public int id { get; set; }
        }

        [HttpPost]
        [Route("get_order")]
        public async Task<ActionResult<Order>> GetOrder(GetOrderModel model)
        {
            return await _repository.Get(model.id);
        }

        public class PostOrderModel
        {
            public String accessToken { get; set; }
            public Order order { get; set; }
        }

        [HttpPost]
        [Route("insert_order")]
        public async Task<ActionResult<Order>> PostOrder(PostOrderModel model)
        {
            var newOrder = await _repository.Create(model.order);
            return CreatedAtAction(nameof(GetOrders), new { id = newOrder.Id}, newOrder);
        }

        public class PutOrderModel
        {
            public String accessToken { get; set; }
            public Order order { get; set; }
        }

        [HttpPost]
        [Route("update_order")]
        public async Task<ActionResult> PutOrder(PutOrderModel model)
        {
            await _repository.Update(model.order);
            return NoContent();
        }

        public class DeleteAllModel
        {
            public String accessToken { get; set; }
        }

        [HttpPost]
        [Route("delete_all")]
        public async Task<ActionResult> DeleteAll(DeleteAllModel model)
        {
            await _repository.DeleteAll();
            return NoContent();
        }

        public class DeleteOrderModel
        {
            public String accessToken { get; set; }
            public int id { get; set; }
        }

        [HttpPost]
        [Route("delete_order")]
        public async Task<ActionResult> DeleteOrder(DeleteOrderModel model)
        {
            var orderToDelete = await _repository.Get(model.id);
            if (orderToDelete == null)
            {
                return NotFound();
            }
            await _repository.Delete(model.id);
            return NoContent();
        }

        public class SearchOrderModel
        {
            public String accessToken { get; set; }
            public String nomeCliente { get; set; } = "";
        }

        [HttpPost]
        [Route("search_order")]
        public async Task<IEnumerable<Order>> SearchOrder(SearchOrderModel model)
        {
            return await _repository.searchOrder(model.nomeCliente.ToLower());
        }

        public class SearchOrderByDateModel
        {
            public String accessToken { get; set; }
            public String data { get; set; }
        }

        [HttpPost]
        [Route("search_order_by_date")]
        public async Task<IEnumerable<Order>> SearchOrdersByDate(SearchOrderByDateModel model)
        {
            return await _repository.searchOrdersByDate(Convert.ToDateTime(model.data));
        }
    }
}