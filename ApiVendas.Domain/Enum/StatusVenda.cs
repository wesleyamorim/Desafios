using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVendas.Domain.Enum
{
  public enum StatusVenda
  {
    AguardandoPagamento = 0,
    PagamentoAprovado = 1,
    Cancelada = 2,
    EnviadoTransportadora = 3,
    Entregue = 4
  }
}
