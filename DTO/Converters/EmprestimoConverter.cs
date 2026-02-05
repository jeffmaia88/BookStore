using BookStore.DTO.Emprestimos;
using BookStore.Entity;

namespace BookStore.DTO.Converters
{
    public class EmprestimoConverter
    {
        public static Emprestimo RequestToEntity(EmprestimoRequest request)
        {
            var emprestimo = new Emprestimo
            {
                DataDevolucaoPrevista = request.DataDevolucaoPrevista              
            };

            return emprestimo;
        }

        public static EmprestimoResponse EntityToResponse(Emprestimo emprestimo)
        {
            var response = new EmprestimoResponse
            {
                Codigo = emprestimo.Codigo,
                DataEmprestimo = emprestimo.DataEmprestimo,
                DataDevolucaoPrevista = emprestimo.DataDevolucaoPrevista,
                
            };

            return response;
        }

        public static List<EmprestimoResponse> EntityToResponseList(List<Emprestimo> emprestimos)
        {
            return emprestimos.Select(e => EntityToResponse(e)).ToList();
        }
    }
}
