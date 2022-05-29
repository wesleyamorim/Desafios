using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVendas.Domain.ItensVenda
{
  public class ItemVenda
  {
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public double ValorUnitario { get; set; }
    public double ValorTotal  => Quantidade * ValorUnitario;
  }
}
