using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Api.Models
{
  public class VendaModel
  {
    public DateTime DataVenda { get; set; }
    public VendedorModel Vendedor { get; set; }
    public IEnumerable<ItemVendaModel> ItemVendas { get; set; }
  }
}
