using Microsoft.AspNetCore.Mvc;
using BookStore.Services;
using BookStore.DTO;
using BookStore.Extensions;
using System.Threading.Tasks;
using BookStore.DTO.Emprestimos;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("v1/emprestimos")]
    public class EmprestimoController : ControllerBase
    {
        private readonly EmprestimoService _emprestimoService;

        public EmprestimoController(EmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        #region HTTPPOST
        [HttpPost]
        public async Task<IActionResult> CreateEmprestimo([FromBody] EmprestimoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new EmprestimoResult<EmprestimoResponse>(ModelState.GetErrors()));
            }

            try
            {
                var response = await _emprestimoService.CriarEmprestimo(request);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new EmprestimoResult<EmprestimoResponse>("06X04 - Falha Interna no Servidor"));
            }
        }
        #endregion

        #region HTTPGETID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new EmprestimoResult<EmprestimoResponse>("06X02 - ID Inválido"));

            try
            {
                var result = await _emprestimoService.BuscarPorId(id);

                if (result.Data == null)
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, new EmprestimoResult<EmprestimoResponse>("06X04 - Falha Interna do Servidor"));
            }
        }
        #endregion

        #region HTTPGETBYCODIGO
        [HttpGet("codigo/{codigo}")]
        public async Task<IActionResult> GetByCodigo([FromRoute] int codigo)
        {
            if (codigo <= 0)
                return BadRequest(new EmprestimoResult<EmprestimoResponse>("06X03 - Código Inválido"));

            try
            {
                var result = await _emprestimoService.BuscarPorCodigo(codigo);

                if (result.Data == null)
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, new EmprestimoResult<EmprestimoResponse>("06X04 - Falha Interna do Servidor"));
            }
        }
        #endregion

        #region HTTPGETALL
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int page = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                var emprestimos = await _emprestimoService.ListarTodos();
                var paged = emprestimos
                    .OrderBy(e => e.Codigo)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                return Ok(new EmprestimoResult<List<EmprestimoResponse>>(paged));
            }
            catch
            {
                return StatusCode(500, new EmprestimoResult<List<EmprestimoResponse>>("06X04 - Falha Interna no Servidor"));
            }
        }
        #endregion

        #region HTTPPUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EmprestimoRequest request)
        {
            if (id <= 0)
            {
                return BadRequest(new EmprestimoResult<EmprestimoResponse>("06X02 - ID Inválido"));
            }

            if (!ModelState.IsValid)
                return BadRequest(new EmprestimoResult<EmprestimoResponse>(ModelState.GetErrors()));

            try
            {
                var response = await _emprestimoService.AtualizarEmprestimo(id, request);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new EmprestimoResult<EmprestimoResponse>("06X04 - Falha Interna do Servidor"));
            }
        }
        #endregion

        #region HTTPDELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmprestimo([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new EmprestimoResult<EmprestimoResponse>("06X02 - ID Inválido"));
            }

            try
            {
                var response = await _emprestimoService.ApagarEmprestimo(id);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new EmprestimoResult<EmprestimoResponse>("06X04 - Falha Interna no Servidor"));
            }
        }
        #endregion
    }
}
