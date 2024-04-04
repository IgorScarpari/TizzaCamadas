using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class InserirPromoverDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVigencia { get; set; }
        public int CodigoPizzaria { get; set; }
        public Pizzaria Pizzaria { get; set; }
    }
}
