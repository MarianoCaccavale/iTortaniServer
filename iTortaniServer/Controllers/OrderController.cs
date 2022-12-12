﻿using iTortaniServer.Models;
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

        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return await _repository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromBody] Order order)
        {
            var newOrder = await _repository.Create(order);
            return CreatedAtAction(nameof(GetOrders), new { id = newOrder.Id}, newOrder);
        }

        [HttpPut]
        public async Task<ActionResult> PutOrder(int id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            await _repository.Update(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var orderToDelete = await _repository.Get(id);
            if (orderToDelete == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }

        [HttpGet("search/{nomeCliente}")]
        public async Task<IEnumerable<Order>> searchOrder(string nomeCliente)
        {
            return await _repository.searchOrder(nomeCliente.ToLower());
        }
    }
}