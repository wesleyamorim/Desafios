using ApiVenda.Tests.Fixtures;
using ApiVendas.Aplication.VendaService;
using ApiVendas.Domain.Vendas;
using Moq;
using Moq.AutoMock;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace ApiVenda.Tests.Steps
{
  [Binding]
  public class IncluirVendaSteps
  {
    private readonly Mock<IVendaService> _iVendaService;
    private readonly ScenarioContext _scenarioContext;
    private readonly VendaServices _vendaServices;

    public IncluirVendaSteps(ScenarioContext scenarioContext)
    {
      var autoMocker = new AutoMocker();

      _iVendaService = autoMocker.GetMock<IVendaService>();
      _vendaServices = autoMocker.CreateInstance<VendaServices>();
      _scenarioContext = scenarioContext;

      VendaTestFixture.Create(ref _scenarioContext);
    }

    [Given(@"que o vendedor inclua uma venda com os dados corretos")]
    public void DadoQueOVendedorIncluaUmaVendaComOsDadosCorretos()
    {
    }

    [When(@"ele informar todos os dados corretos")]
    public void QuandoEleInformarTodosOsDadosCorretos()
    {
      var vendaValida = _scenarioContext["VendaValida"];
      _iVendaService.Setup(a => a.PostVenda(It.IsAny<Venda>())).Returns((Venda)vendaValida);
    }

    [Then(@"valida se foi gerado a venda com sucesso")]
    public void EntaoValidaSeFoiGeradoAVendaComSucesso()
    {
      var vendaOutput = _vendaServices.PostVenda((Venda)_scenarioContext["VendaValida"]);

      Assert.True(vendaOutput.ItemVendas.Select(c => c.Descricao == "Item 1 Teste").FirstOrDefault());
    }
  }
}
