using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Api.Models
{
  public class ItemVendaModel
  {
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public double ValorUnitario { get; set; }
  }
}
