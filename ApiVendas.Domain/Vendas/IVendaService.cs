using ApiVendas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVendas.Domain.Vendas
{
  public interface IVendaService
  {
    Venda GetVenda(Guid idVenda);
    List<Venda> GetAllVendas();
    void PostVenda(Venda venda);

    void AtualizaStatusVenda(Guid idVenda, StatusVenda statusVenda);
  }
}
