using BookStore.DTO.Converters;
using BookStore.DTO.Livros;
using BookStore.Entity;
using BookStore.Repositories;
//using BookStore.DTO;

namespace BookStore.Services
{
    public class LivroService
    {
        private readonly LivroRepository _livroRepository;

        public LivroService(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        #region AdicionarLivro
        public async Task<LivroResult<LivroResponse>> AddLivros(LivroRequest request)
        {
            var livro = LivroConverter.RequestToEntity(request);

            await _livroRepository.Create(livro);

            var response = LivroConverter.LivroToResponse(livro);
            return new LivroResult<LivroResponse>(response);

        }

        #endregion

        #region BuscarporID
        public async Task<LivroResult<LivroResponse>> BuscarPorId(int id)
        {
            var livro = await _livroRepository.GetById(id);

            if (livro == null)
            {
                return new LivroResult<LivroResponse>("05X01 - Livro não encontrado");
            }

            var response = LivroConverter.LivroToResponse(livro);
            return new LivroResult<LivroResponse>(response);
        }

        #endregion

        #region ListarTodos
        public async Task<List<LivroResponse>> ListarTodos()
        {
            var livros = await _livroRepository.GetAll();

            return LivroConverter.LivroToResponseList(livros);

        }
        #endregion

        #region AtualizarLivro
        public async Task<LivroResult<LivroResponse>> AtualizarLivro(int id, LivroRequest livroRequest)
        {
            var busca = await _livroRepository.GetById(id);

            if(busca == null)
            {
                return new LivroResult<LivroResponse>("05x01 - Livro Não Encontrado");
            }

            busca.Titulo = livroRequest.Titulo;
            busca.Autor = livroRequest.Autor;
            busca.Isbn = livroRequest.Isbn;
            busca.AnoPublicacao = livroRequest.AnoPublicacao;
            busca.Editora = livroRequest.Editora;
            busca.Quantidade= livroRequest.Quantidade;
            busca.DataCadastro = livroRequest.DataCadastro;

            await _livroRepository.Update(busca);

            var response = LivroConverter.LivroToResponse(busca);
            return new LivroResult<LivroResponse>(response);
        }

        #endregion

        #region ApagarLivro
        public async Task<LivroResult<string>> ApagarLivro(int id)
        {
            var livro = await _livroRepository.GetById(id);

            if (livro == null)
            {
                return new LivroResult<string>("05x01 - Livro Nao Encontrado");
            }

            await _livroRepository.Delete(livro);
            var mensagem = "Livro Deletado com Sucesso!";

            return new LivroResult<string>(mensagem);


        }

        #endregion

    }
}


