using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Subcategorium
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public bool? Activa { get; set; }

    public int? CategoriaId { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
