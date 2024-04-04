using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TizzaAula;

namespace Repositorio
{
    public interface IRepoPromover
    {
        void Inserir(Promover promover);
        Promover BuscarPorId(int id);
        void SalvarEfetivacao();
    }

    public class RepoPromover : IRepoPromover
    {
        private DataContext _dataContext;

        public RepoPromover(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Promover promover)
        {
            _dataContext.Add(promover);
            _dataContext.SaveChanges();
        }

        public Promover BuscarPorId(int id)
        {
            var promover = _dataContext.Promover.Where(p => p.Id == id).FirstOrDefault();
            return promover;
        }

        public void SalvarEfetivacao()
        {
            _dataContext.SaveChanges();
        }
    }
}
