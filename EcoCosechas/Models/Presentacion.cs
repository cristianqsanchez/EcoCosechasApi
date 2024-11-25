using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Presentacion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Cantidad { get; set; }

    public double? Descuento { get; set; }

    public int? ProductoId { get; set; }

    public string? Sku { get; set; }

    public string? Codigo { get; set; }

    public int? EmpresaId { get; set; }

    public bool Activa { get; set; }

    public virtual ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Producto? Producto { get; set; }
}
