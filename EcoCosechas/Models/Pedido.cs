using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public string? Numero { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? Cancelado { get; set; }

    public DateTime? Enviado { get; set; }

    public DateTime? Entrega { get; set; }

    public DateTime? Entregado { get; set; }

    public int? SucursalId { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? Total { get; set; }

    public int? Items { get; set; }

    public int? Cantidad { get; set; }

    public virtual ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();

    public virtual Sucursal? Sucursal { get; set; }
}
