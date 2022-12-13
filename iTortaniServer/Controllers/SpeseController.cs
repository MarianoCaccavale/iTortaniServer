using iTortaniServer.Models.Spese;
using iTortaniServer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace iTortaniServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeseController : ControllerBase
    {

        private readonly ISpeseRepository _repository;

        public SpeseController(ISpeseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Spese>> GetOrders()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Spese>> GetSpesa(int id)
        {
            return await _repository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Spese>> PostOrder([FromBody] Spese spesa)
        {
            var newSpesa = await _repository.Create(spesa);
            return CreatedAtAction(nameof(GetOrders), new { id = newSpesa.Id }, newSpesa);
        }

        [HttpPut]
        public async Task<ActionResult> PutOrder(int id, [FromBody] Spese spesa)
        {
            if (id != spesa.Id)
            {
                return BadRequest();
            }

            await _repository.Update(spesa);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            await _repository.DeleteAll();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSpesa(int id)
        {
            var spesaToDelete = await _repository.Get(id);
            if (spesaToDelete == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }

        [HttpGet("search/{nomeCliente}")]
        public async Task<IEnumerable<Spese>> searchOrder(string nomeCliente = "") {
            return await _repository.searchOrder(nomeCliente.ToLower());
        }

        [HttpGet("search/{nomeCliente}&{cellNumber}")]
        public async Task<IEnumerable<Spese>> searchSpecificSpesa(string nomeClient = "", string cellNumber = "")
        {
            return await _repository.searchSpecificSpesa(nomeClient, cellNumber);
        }

        [HttpGet("search/{data}")]
        public async Task<IEnumerable<Spese>> searchSpeseByDate(string data = "")
        {
            return await _repository.searchSpeseByDate(Convert.ToDateTime(data));
        }

    }
}
