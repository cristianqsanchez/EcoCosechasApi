using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Compra
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public int? ProductoId { get; set; }

    public int? UnidadId { get; set; }

    public decimal? Costo { get; set; }

    public double? Cantidad { get; set; }

    public int? ProveedorId { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Proveedor? Proveedor { get; set; }

    public virtual Unidad? Unidad { get; set; }
}
