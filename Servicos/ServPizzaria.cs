using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServPizzaria
    {
        void Inserir(InserirPizzariaDTO inserirPizzariaDTO);
        List<Pizzaria> BuscarTodos();
        void Remover(int id);
        void AtualizarInforamacaoDaPromocao(int id, DateTime dataVigencia, decimal valorPromocao);
    }

    public class ServPizzaria : IServPizzaria
    {
        private IRepoPizzaria _repoPizzaria;
        
        public ServPizzaria(IRepoPizzaria repoPizzaria)
        {
            _repoPizzaria = repoPizzaria;
        }

        public void Inserir(InserirPizzariaDTO inserirPizzariaDTO)
        {
            var pizzaria = new Pizzaria();

            pizzaria.Nome = inserirPizzariaDTO.Nome;
            pizzaria.Telefone = inserirPizzariaDTO.Telefone;
            pizzaria.Endereco = inserirPizzariaDTO.Endereco;
            pizzaria.Responsavel = inserirPizzariaDTO.Responsavel;

            ValidacoesAntesDeInserir(pizzaria);

            _repoPizzaria.Inserir(pizzaria);
        }

        public void ValidacoesAntesDeInserir(Pizzaria pizzaria)
        {
            if(pizzaria.Nome.Length < 40)
            {
                throw new Exception("Nome inválido. Deve possuir no mínimo 40 caracteres");
            }
        }

        public List<Pizzaria> BuscarTodos()
        {
            var pizzarias = _repoPizzaria.BuscarTodos();
            return pizzarias;
        }

        public void Remover(int id)
        {
            var pizzaria = _repoPizzaria.BuscarTodos().Where(p => p.Id == id).FirstOrDefault();
            _repoPizzaria.Remover(pizzaria);
        }

        public void AtualizarInforamacaoDaPromocao(int id, DateTime dataVigencia, decimal valorPromocao)
        {
            var pizzaria = _repoPizzaria.BuscarTodos().Where(p => p.Id == id).FirstOrDefault();
            pizzaria.DataVigenciaPromover = dataVigencia;
            pizzaria.ValorPromover = valorPromocao;
        }
    }
}
