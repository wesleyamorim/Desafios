using ApiVendas.Api.Models;
using ApiVendas.Domain.ItensVenda;
using ApiVendas.Domain.Vendas;
using ApiVendas.Domain.Vendedores;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Api.Mapper
{
  public class AutoMapperConfigure : Profile
  {
    public AutoMapperConfigure()
    {
      CreateMap<VendaModel, Venda>().ReverseMap();
      CreateMap<VendedorModel, Vendedor>().ReverseMap();
      CreateMap<ItemVendaModel, ItemVenda>().ReverseMap();
    }
  }
}
