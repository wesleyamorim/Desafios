using ApiVendas.Api.Models;
using ApiVendas.Domain.ItensVenda;
using ApiVendas.Domain.Vendas;
using ApiVendas.Domain.Vendedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ApiVenda.Tests.Fixtures
{
  public static class VendaTestFixture
  {
    public static Venda GeraVendaValida()
    {
      return new Venda()
      {
        DataVenda = DateTime.Now,
        Vendedor = new Vendedor()
        {
          Cpf = "1234566789",
          Nome = "Vendedor Teste 1",
          Email = "vendedorTeste@email.com",
          Telefone = "31999999291"
        },
        ItemVendas = new List<ItemVenda>()
        {
          new ItemVenda()
          {
            Descricao = "Item 1 Teste",
            Quantidade = 10,
            ValorUnitario = 10
          }
        }
      };
    }

    public static void Create(ref ScenarioContext context)
    {
      context["VendaValida"] = GeraVendaValida();
    }
  }
}
