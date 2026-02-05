using BookStore.DTO.Livros;
using BookStore.Relatorios.EmprestimoRelatorios;
using BookStore.Relatorios.LivrosRelatorios;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{

    [ApiController]
    [Route("v1/relatorios")]
    public class RelatorioController : ControllerBase
    {
        private readonly RelatorioEmprestimo _relatorioEmprestimo;
        private readonly RelatorioLivro _relatorioLivro;

        public RelatorioController(RelatorioEmprestimo Relatorioemprestimo, RelatorioLivro relatorioLivro)
        {
            _relatorioEmprestimo = Relatorioemprestimo;
            _relatorioLivro = relatorioLivro;

        }

        [HttpGet("livros/estoque")]
        public async Task<IActionResult> BaixoEstoque()
        {
            try
            {
                var response = await _relatorioLivro.BaixoEstoque();
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new LivroResult<LivroResponse>("05X04 - Falha Interna no Servidor"));

            }
        }

        [HttpGet("livros/acervo")]
        public async Task<IActionResult> AcervoGEral([FromRoute] int page = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                var response = await _relatorioLivro.AcervoGeral();
                var pagedLivros = response.OrderBy(l => l.Titulo).Skip(page * pageSize).Take(pageSize).ToList();

                return Ok(response);
            }
            catch
            {
                return StatusCode(500, new LivroResult<List<LivroResponse>>("05X04 - Falha Interna no Servidor"));
            }
        }
        [HttpGet("livros/indisponiveis")]
        public async Task<IActionResult> Indisponiveis()
        {
            var result = await _relatorioLivro.Indisponiveis();
            return Ok(result);
        }

        [HttpGet("emprestimos/periodo")]
        public async Task<IActionResult> EmprestimosPorPeriodo(
          [FromQuery] DateTime inicio,
          [FromQuery] DateTime fim)
        {
            var result = await _relatorioEmprestimo.EmprestimosPorPeriodo(inicio, fim);
            return Ok(result);
        }

    }
}
