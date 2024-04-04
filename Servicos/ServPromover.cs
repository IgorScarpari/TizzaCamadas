using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServPromover
    {
        void Inserir(InserirPromoverDTO inserirPromoverDTO);
        void Efetivar(int id);
    }

    public class ServPromover : IServPromover
    {
        private IRepoPromover _repoPromover;
        private IServPizzaria _servPizzaria;

        public ServPromover(IRepoPromover repoPromover, IServPizzaria servPizzaria)
        {
            _repoPromover = repoPromover;
            _servPizzaria = servPizzaria;
        }

        public void Inserir(InserirPromoverDTO inserirPromoverDTO)
        {
            var promover = new Promover();

            promover.Descricao = inserirPromoverDTO.Descricao;
            promover.DataVigencia = inserirPromoverDTO.DataVigencia;
            promover.CodigoPizzaria = inserirPromoverDTO.CodigoPizzaria;
            promover.Valor = inserirPromoverDTO.Valor;

            _repoPromover.Inserir(promover);
        }

        public void Efetivar(int id)
        {
            var promover = _repoPromover.BuscarPorId(id);
            promover.Status = EnumStatusPromover.Efetivado;

            _servPizzaria.AtualizarInforamacaoDaPromocao(promover.CodigoPizzaria, promover.DataVigencia, promover.Valor);

            _repoPromover.SalvarEfetivacao();
        }
    }
}
