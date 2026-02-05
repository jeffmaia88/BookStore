using BookStore.DTO.Livros;
using BookStore.Entity;

namespace BookStore.DTO.Converters
{
    public class LivroConverter
    {

        public static Livro RequestToEntity (LivroRequest livroRequest)
        {
            var livro = new Livro
            {
                Titulo = livroRequest.Titulo,
                Autor = livroRequest.Autor,
                Isbn = livroRequest.Isbn,
                Editora = livroRequest.Editora,
                AnoPublicacao = livroRequest.AnoPublicacao,
                Quantidade = livroRequest.Quantidade,
                DataCadastro = DateTime.Now
            };
         
            return livro;
           

        }


        public static LivroResponse LivroToResponse (Livro livro)
        {
            var livroResponse = new LivroResponse();
            
            livroResponse.Id = livro.Id;
            livroResponse.Titulo = livro.Titulo;
            livroResponse.Autor = livro.Autor;
            livroResponse.Isbn = livro.Isbn;
            livroResponse.AnoPublicacao = livro.AnoPublicacao;
            livroResponse.Editora = livro.Editora;
            livroResponse.Quantidade = livro.Quantidade;
            livroResponse.DataCadastro = livro.DataCadastro;

            return livroResponse;

        }


        public static List<LivroResponse> LivroToResponseList(List<Livro> livros)
        {
            return livros.Select(livro => LivroToResponse(livro)).ToList();
        }



    }
}
