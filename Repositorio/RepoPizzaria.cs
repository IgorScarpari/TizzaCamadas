using Entidades;
using TizzaAula;

namespace Repositorio
{
    public interface IRepoPizzaria
    {
        void Inserir(Pizzaria pizzaria);
        List<Pizzaria> BuscarTodos();
        void Remover(Pizzaria pizzaria);
    }

    public class RepoPizzaria : IRepoPizzaria
    {
        private DataContext _dataContext;

        public RepoPizzaria(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Pizzaria pizzaria)
        {
            _dataContext.Add(pizzaria);
            _dataContext.SaveChanges();
        }

        public List<Pizzaria> BuscarTodos()
        {
            var pizzarias = _dataContext.Pizzaria.ToList();
            return pizzarias;
        }

        public void Remover(Pizzaria pizzaria)
        {
            _dataContext.Remove(pizzaria);
            _dataContext.SaveChanges();
        }
    }
}
