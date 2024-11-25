using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Identificacion { get; set; }

    public string? Prefijo { get; set; }

    public int? Consecutivo { get; set; }

    public virtual ICollection<Categorium> Categoria { get; set; } = new List<Categorium>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual ICollection<Marca> Marcas { get; set; } = new List<Marca>();

    public virtual ICollection<Pai> Pais { get; set; } = new List<Pai>();

    public virtual ICollection<Presentacion> Presentacions { get; set; } = new List<Presentacion>();

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();

    public virtual ICollection<Sede> Sedes { get; set; } = new List<Sede>();

    public virtual ICollection<Unidad> Unidads { get; set; } = new List<Unidad>();
}
