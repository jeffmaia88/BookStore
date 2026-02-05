using Microsoft.AspNetCore.Mvc;
using BookStore.Services;
using BookStore.DTO;
using BookStore.Extensions;
using System.Threading.Tasks;
using BookStore.DTO.Livros;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("v1/livros")]
    public class LivroController : ControllerBase
    {

       private readonly LivroService _livroService;

        public LivroController(LivroService livroService)
        {
            _livroService = livroService;

        }

        #region HTTPPOST
        [HttpPost]        
        public async Task<IActionResult> CreateLivro([FromBody] LivroRequest livro)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new LivroResult<LivroResponse>(ModelState.GetErrors()));
            }

            try
            {
                var response = await _livroService.AddLivros(livro);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new LivroResult<LivroResponse>("05X04 - Falha Interna no Servidor"));

            }


        }
        #endregion

        #region HTTPGETID

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new LivroResult<LivroResponse>("05x02 - ID Inválido"));

            try
            {
                var result = await _livroService.BuscarPorId(id);
                if (result.Data == null)
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, new LivroResult<LivroResponse>("05X04 - Falha Interna do Servidor"));
            }

        }

        #endregion

        #region HTTPGETALL
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int page = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                var Livros = await _livroService.ListarTodos();
                var pagedLivros = Livros.OrderBy(l => l.Titulo).Skip(page * pageSize).Take(pageSize).ToList();

                return Ok(new LivroResult<List<LivroResponse>>(pagedLivros));
            }
            catch
            {
                return StatusCode(500, new LivroResult<List<LivroResponse>>("05X04 - Falha Interna no Servidor"));
            }
        }
        #endregion

        #region HTTPPUT
        [HttpPut("{id:int}")]

        public async Task<IActionResult>Update([FromRoute] int id, [FromBody] LivroRequest livroRequest)
        {
            if (id <= 0)
            {
                return BadRequest(new LivroResult<LivroResponse>("05X02 - ID Inválido"));
            }

            if (!ModelState.IsValid)
                return BadRequest(new LivroResult<LivroResponse>(ModelState.GetErrors()));

            try
            {
                var response= await _livroService.AtualizarLivro(id, livroRequest);

                return Ok(response);

            }
            catch
            {
                return StatusCode(500, new LivroResult<LivroResponse>("05x04 - Falha Interna do Servidor"));
            }          

        }
        #endregion

        #region HTTPDELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLivro([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new LivroResult<LivroResponse>("05X02 - ID Inválido"));
            }

            try
            {
                var response = await _livroService.ApagarLivro(id);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new LivroResult<LivroResponse>("05x04 - Falha Interna no Servidor"));
            }

        }
        #endregion
    }
}
