using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Detalle
{
    public int Id { get; set; }

    public int? PresentacionId { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public int? Entregado { get; set; }

    public int? PedidoId { get; set; }

    public virtual Pedido? Pedido { get; set; }

    public virtual Presentacion? Presentacion { get; set; }
}
