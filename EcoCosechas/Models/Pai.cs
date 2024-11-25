using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Pai
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? EmpresaId { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Estado> Estados { get; set; } = new List<Estado>();
}
