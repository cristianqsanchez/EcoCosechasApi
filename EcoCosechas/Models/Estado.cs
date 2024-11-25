using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Estado
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? PaisId { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual Pai? Pais { get; set; }
}
