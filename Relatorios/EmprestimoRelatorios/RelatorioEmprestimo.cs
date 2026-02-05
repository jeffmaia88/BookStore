using BookStore.DTO.Converters;
using BookStore.DTO.Emprestimos;
using BookStore.Repositories;

namespace BookStore.Relatorios.EmprestimoRelatorios
{
    public class RelatorioEmprestimo
    {
        private readonly EmprestimoRepository _emprestimoRepository;

        public RelatorioEmprestimo(EmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;

        }


        public async Task<List<EmprestimoResponse>> EmprestimosPorPeriodo(DateTime inicio, DateTime fim)
        {
            var emprestimos = await _emprestimoRepository.GetAll();

            var filtro = emprestimos.Where(e => e.DataEmprestimo >= inicio && e.DataEmprestimo <= fim).OrderBy(e => e.DataEmprestimo ).ToList();

            return EmprestimoConverter.EntityToResponseList(filtro);    
        }

    }
}
