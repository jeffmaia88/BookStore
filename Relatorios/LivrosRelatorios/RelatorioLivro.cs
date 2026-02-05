using BookStore.DTO.Converters;
using BookStore.DTO.Livros;
using BookStore.Repositories;

namespace BookStore.Relatorios.LivrosRelatorios
{
    public class RelatorioLivro
    {
        private readonly LivroRepository _livroRepository;

        public RelatorioLivro(LivroRepository livroRepository)
        {
            
        }

        #region Relatorio de Baixo Estoque
        public async Task<List<LivroResponse>> BaixoEstoque()
        {
            var livros = await _livroRepository.GetAll();

            var baixoEstoque = livros.Where(l => l.Quantidade < 2).ToList();

            return LivroConverter.LivroToResponseList(baixoEstoque);

        }

        #endregion

        #region Acervo Geral
        public async Task<List<LivroResponse>> AcervoGeral()
        { 
            var acervo = await _livroRepository.GetAll();
            return LivroConverter.LivroToResponseList(acervo);

        }
        #endregion

        #region Indisponiveis
        public async Task<List<LivroResponse>> Indisponiveis()
        {
            var livros = await _livroRepository.GetAll();
            return LivroConverter.LivroToResponseList(
                livros.Where(l => l.Quantidade == 0).ToList()
            );
        }
        #endregion



    }
}
