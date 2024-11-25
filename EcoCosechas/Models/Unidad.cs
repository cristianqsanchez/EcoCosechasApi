using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Unidad
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? EmpresaId { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
