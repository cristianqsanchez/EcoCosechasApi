using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Cotizacion
{
    public int Id { get; set; }

    public int? ProveedorId { get; set; }

    public int? ProductoId { get; set; }

    public double? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? Actualizacion { get; set; }

    public decimal? Unitario { get; set; }

    public string? Observaciones { get; set; }

    public int? EmpresaId { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Proveedor? Proveedor { get; set; }
}
