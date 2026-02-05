namespace BookStore.DTO.Emprestimos
{
    public class EmprestimoResponse
    {
        public int Codigo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
