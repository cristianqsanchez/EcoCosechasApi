using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Categorium
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public bool? Activa { get; set; }

    public string? Oferta { get; set; }

    public string? Descripcion { get; set; }

    public int? EmpresaId { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Subcategorium> Subcategoria { get; set; } = new List<Subcategorium>();
}
