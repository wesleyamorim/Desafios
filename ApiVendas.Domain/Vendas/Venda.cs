using ApiVendas.Domain.Enum;
using ApiVendas.Domain.ItensVenda;
using ApiVendas.Domain.Vendedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVendas.Domain.Vendas
{
  public class Venda
  {
    public Guid IdVenda { get; set; }
    public DateTime DataVenda { get; set; }
    public Vendedor Vendedor { get; set; }
    public IEnumerable<ItemVenda> ItemVendas { get; set; }
    public StatusVenda StatusVenda { get; set; }

  }
}
