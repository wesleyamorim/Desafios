using ApiVendas.Api.Models;
using ApiVendas.Domain.Enum;
using ApiVendas.Domain.Vendas;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class VendaController : ControllerBase
  {
    private readonly IVendaService _vendaService;
    private readonly IMapper _mapper;

    public VendaController(IVendaService vendaService, IMapper mapper)
    {
      _vendaService = vendaService;
      _mapper = mapper;
    }
    [HttpGet("id")]
    public Venda GetVenda(Guid IdVenda)
    {
      return _vendaService.GetVenda(IdVenda);
    }

    [HttpGet]
    public List<Venda> GetAllVendas()
    {
      return _vendaService.GetAllVendas();
    }

    [HttpPost]
    public IActionResult PostVenda(VendaModel venda)
    {
      var vendaMapper = _mapper.Map<Venda>(venda);
      

      return Ok(_vendaService.PostVenda(vendaMapper));
    }

    [HttpPatch]
    public IActionResult AlteraVenda([FromQuery]Guid idVenda, StatusVenda novoStatusVenda)
    {
      _vendaService.AtualizaStatusVenda(idVenda, novoStatusVenda);
      return Ok();
    }
  }
}
