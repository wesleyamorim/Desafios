using ApiVendas.Domain.Enum;
using ApiVendas.Domain.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVendas.Aplication.VendaService
{
  public class VendaServices : IVendaService
  {
    private List<Venda> _vendas = new List<Venda>();

    public Venda GetVenda(Guid idVenda)
    {
      if (idVenda == null || idVenda == new Guid())
        throw new ArgumentNullException("o Id da Venda não pode ser nulo");

      var venda = _vendas.FirstOrDefault(c => c.IdVenda == idVenda);

      return venda;
    }

    public List<Venda> GetAllVendas()
    {
      return _vendas;
    }

    public Venda PostVenda(Venda venda)
    {
      venda.IdVenda = Guid.NewGuid();
      venda.Vendedor.Id = Guid.NewGuid();
      venda.StatusVenda = StatusVenda.AguardandoPagamento;

      foreach (var item in venda.ItemVendas)
      {
        item.Id = Guid.NewGuid();
      }

      if (venda.Vendedor == null)
        throw new ArgumentException("A venda deve possuir um vendedor!");

      if (venda.ItemVendas.Count() <= 0)
        throw new ArgumentException("A venda deve possuir pelo menos um Item!");

      _vendas.Add(venda);

      return GetVenda(venda.IdVenda);
    }


    public void AtualizaStatusVenda(Guid idVenda, StatusVenda statusVenda)
    {
      var venda = GetVenda(idVenda);

      if (venda == null)
        throw new Exception("Venda não localizada");

      string statusIncorreto = "A venda não pode ser atualizada para esse status";

      switch (statusVenda)
      {
        case StatusVenda.AguardandoPagamento:
          throw new Exception(statusIncorreto);
          break;
        case StatusVenda.PagamentoAprovado:
          if (venda.StatusVenda == StatusVenda.AguardandoPagamento)
              venda.StatusVenda = statusVenda;
          else
            throw new Exception(statusIncorreto);
          break;
        case StatusVenda.Cancelada:
          if (venda.StatusVenda == StatusVenda.AguardandoPagamento || venda.StatusVenda == StatusVenda.PagamentoAprovado)
              venda.StatusVenda = statusVenda;
          else
            throw new Exception(statusIncorreto);
          break;
        case StatusVenda.EnviadoTransportadora:
          if (venda.StatusVenda == StatusVenda.PagamentoAprovado)
              venda.StatusVenda = statusVenda;
          else
            throw new Exception(statusIncorreto);
          break;
        case StatusVenda.Entregue:
          if (venda.StatusVenda == StatusVenda.EnviadoTransportadora)
              venda.StatusVenda = statusVenda;
          else
            throw new Exception(statusIncorreto);
          break;
        default:
          break;
      }
    }
  }
}
