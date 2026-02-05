using BookStore.DTO.Converters;
using BookStore.DTO.Emprestimos;
using BookStore.Entity;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class EmprestimoService
    {
        private readonly EmprestimoRepository _emprestimoRepository;
        private readonly EmprestimoItemRepository _emprestimoItemRepository;
        private readonly EstoqueService _estoqueService;

        public EmprestimoService(EmprestimoRepository emprestimoRepository, EmprestimoItemRepository emprestimoItemRepository, EstoqueService estoqueService)
        {
            _emprestimoRepository = emprestimoRepository;
            _emprestimoItemRepository = emprestimoItemRepository;
            _estoqueService = estoqueService;
        }

        #region CriarEmprestimo
        public async Task<EmprestimoResult<EmprestimoResponse>> CriarEmprestimo(EmprestimoRequest request)
        {
            
            var emprestimo = new Emprestimo
            {
                DataEmprestimo = DateTime.Now,
                DataDevolucaoPrevista = request.DataDevolucaoPrevista,
                
            };

           
            var ultimoCodigo = await _emprestimoRepository.GetUltimoCodigo();
            if (ultimoCodigo == 0)
            {
                emprestimo.Codigo = 1;
            }
            else
            {
                emprestimo.Codigo = ultimoCodigo + 1;
            }

            foreach (var livroId in request.LivrosIds)
            {
                var disponivel = await _estoqueService.VerificarDisponibilidade(livroId, 1);

                if (!disponivel)
                {
                    return new EmprestimoResult<EmprestimoResponse>(
                        "Estoque insuficiente para um ou mais livros"
                    );
                }

            }


            await _emprestimoRepository.Create(emprestimo);           
            

            foreach( var livroId in request.LivrosIds)
            {
                var item = new EmprestimoItem
                {
                    EmprestimoId = emprestimo.Id,
                    LivroId = livroId,
                    Quantidade = 1
                };

                await _emprestimoItemRepository.Create(item);
            };

            foreach (var livroId in request.LivrosIds)
            {
                await _estoqueService.AtualizarQuantidade(livroId, 1);
            }


            var response = EmprestimoConverter.EntityToResponse(emprestimo);
            return new EmprestimoResult<EmprestimoResponse>(response);
        }
        #endregion

        #region BuscarPorId
        public async Task<EmprestimoResult<EmprestimoResponse>> BuscarPorId(int id)
        {
            var emprestimo = await _emprestimoRepository.GetById(id);

            if (emprestimo == null)
            {
                return new EmprestimoResult<EmprestimoResponse>("06x01 - Empréstimo não encontrado");
            }

            var response = EmprestimoConverter.EntityToResponse(emprestimo);
            return new EmprestimoResult<EmprestimoResponse>(response);
        }
        #endregion

        #region BuscarPorCodigo
        public async Task<EmprestimoResult<EmprestimoResponse>> BuscarPorCodigo(int codigo)
        {
            var emprestimo = await _emprestimoRepository.GetByCodigo(codigo);

            if (emprestimo == null)
            {
                return new EmprestimoResult<EmprestimoResponse>("06x02 - Empréstimo não encontrado");
            }

            var response = EmprestimoConverter.EntityToResponse(emprestimo);
            return new EmprestimoResult<EmprestimoResponse>(response);
        }
        #endregion

        #region ListarTodos
        public async Task<List<EmprestimoResponse>> ListarTodos()
        {
            var emprestimos = await _emprestimoRepository.GetAll();
            return EmprestimoConverter.EntityToResponseList(emprestimos);
        }
        #endregion

        #region AtualizarEmprestimo
        public async Task<EmprestimoResult<EmprestimoResponse>> AtualizarEmprestimo(int id, EmprestimoRequest request)
        {
            var emprestimo = await _emprestimoRepository.GetById(id);

            if (emprestimo == null)
            {
                return new EmprestimoResult<EmprestimoResponse>("06x01 - Empréstimo não encontrado");
            }        

            
            await _emprestimoRepository.Update(emprestimo);

            var response = EmprestimoConverter.EntityToResponse(emprestimo);
            return new EmprestimoResult<EmprestimoResponse>(response);
        }
        #endregion

        #region ApagarEmprestimo
        public async Task<EmprestimoResult<string>> ApagarEmprestimo(int id)
        {
            var emprestimo = await _emprestimoRepository.GetById(id);

            if (emprestimo == null)
            {
                return new EmprestimoResult<string>("06x01 - Empréstimo não encontrado");
            }

            await _emprestimoRepository.Delete(emprestimo);

            return new EmprestimoResult<string>("Empréstimo deletado com sucesso!");
        }
        #endregion
    }
}
