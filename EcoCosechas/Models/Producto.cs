using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? SubcategoriaId { get; set; }

    public int? MarcaId { get; set; }

    public int? UnidadId { get; set; }

    public DateTime? Actualizacion { get; set; }

    public decimal Costo { get; set; }

    public double Utilidad { get; set; }

    public double? Precio { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual Marca? Marca { get; set; }

    public virtual ICollection<Presentacion> Presentacions { get; set; } = new List<Presentacion>();

    public virtual Subcategorium? Subcategoria { get; set; }

    public virtual Unidad? Unidad { get; set; }
}
