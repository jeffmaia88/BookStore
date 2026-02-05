namespace BookStore.DTO.Emprestimos
{
    public class EmprestimoResult<T>
    {
        public EmprestimoResult(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public EmprestimoResult(T data)
        {
            Data = data;
        }

        public EmprestimoResult(List<string> errors)
        {
            Errors = errors;
        }

        public EmprestimoResult(string error)
        {
            Errors.Add(error);
        }

        public T? Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}
