namespace BookStore.DTO.Livros
{
    public class LivroResult<T>
    {

        public LivroResult(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public LivroResult(T data)
        {
            Data = data;
        }

        public LivroResult(List<string> errors)
        {
            Errors = errors;
        }

        public LivroResult( string error)
        {
            Errors.Add(error);
        }



        public T? Data { get; private set; }
        public List<string> Errors { get; private set; } = new();





    }
}
