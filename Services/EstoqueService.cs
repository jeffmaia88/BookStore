using BookStore.DTO.Livros;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class EstoqueService
    {
        private readonly LivroRepository _livroRepository;


        public EstoqueService(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;

        }

        public async Task<bool> VerificarDisponibilidade(int livroId, int quantidade)
        {
            var livro = await _livroRepository.GetById(livroId);
            if (livro == null)
            {
               throw new Exception("Livro não encontrado.");
            }
            
            return livro.Quantidade >= quantidade;
        }



        public async Task<bool> AtualizarQuantidade(int livroId, int quantidade)
        {
            var livro = await _livroRepository.GetById(livroId);

            if (livro == null)
                throw new Exception("Livro não encontrado");

            if (livro.Quantidade < quantidade)
                return false;

            livro.Quantidade -= quantidade;

            await _livroRepository.Update(livro);

            return true;
        }


    }
}
