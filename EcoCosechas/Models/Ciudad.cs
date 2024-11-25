using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Ciudad
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? EstadoId { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();

    public virtual ICollection<Sede> Sedes { get; set; } = new List<Sede>();

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
