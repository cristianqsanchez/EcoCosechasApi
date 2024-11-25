using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Listum
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? SucursalId { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Sucursal? Sucursal { get; set; }
}
