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

        public class GetSpeseModel
        {
            public String accessToken { get; set; }
        }

        [HttpPost]
        [Route("get_spese")]
        public async Task<IEnumerable<Spese>> GetSpese(GetSpeseModel model)
        {
            return await _repository.GetAll();
        }

        public class GetSpesaModel
        {
            public String accessToken { get; set; }
            public int id { get; set; }
        }

        [HttpPost]
        [Route("get_spesa")]
        public async Task<ActionResult<Spese>> GetSpesa(GetSpesaModel model)
        {
            return await _repository.Get(model.id);
        }

        public class PostSpesaModel
        {
            public String accessToken { get; set; }
            public Spese spesa { get; set; }
        }

        [HttpPost]
        [Route("insert_spesa")]
        public async Task<ActionResult<Spese>> PostSpesa(PostSpesaModel model)
        {
            var newSpesa = await _repository.Create(model.spesa);
            return CreatedAtAction(nameof(GetSpesa), new { id = newSpesa.Id }, newSpesa);
        }

        public class PutSpesaModel
        {
            public String accessToken { get; set; }
            public Spese spesa { get; set; }
        }

        [HttpPost]
        [Route("update_spesa")]
        public async Task<ActionResult> PutSpesa(PutSpesaModel model)
        {
            await _repository.Update(model.spesa);

            return NoContent();
        }

        public class DeleteAllSpeseModel
        {
            public String accessToken { get; set; }
        }

        [HttpPost]
        [Route("delete_all")]
        public async Task<ActionResult> DeleteAllSpese(DeleteAllSpeseModel model)
        {
            await _repository.DeleteAll();
            return NoContent();
        }

        public class DeleteSpesaModel
        {
            public String accessToken { get; set; }
            public int id { get; set; }
        }

        [HttpPost]
        [Route("delete_spesa")]
        public async Task<ActionResult> DeleteSpesa(DeleteSpesaModel model)
        {
            var spesaToDelete = await _repository.Get(model.id);
            if (spesaToDelete == null)
            {
                return NotFound();
            }
            await _repository.Delete(model.id);
            return NoContent();
        }

        public class SearchSpesaModel
        {
            public String accessToken { get; set; }
            public String nomeCliente { get; set; } = "";
        }

        [HttpPost]
        [Route("search_spesa")]
        public async Task<IEnumerable<Spese>> searchSpesa(SearchSpesaModel model) {
            return await _repository.searchOrder(model.nomeCliente.ToLower());
        }

        public class SearchSpeseByDateModel
        {
            public String accessToken { get; set; }
            public String data { get; set; } = "";
        }

        [HttpPost]
        [Route("search_spese_by_date")]
        public async Task<IEnumerable<Spese>> searchSpeseByDate(SearchSpeseByDateModel model)
        {
            return await _repository.searchSpeseByDate(Convert.ToDateTime(model.data));
        }

    }
}
