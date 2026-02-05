namespace BookStore.Entity
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucao { get; set; }  



    }
}
