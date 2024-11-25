using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Favorito
{
    public int Id { get; set; }

    public int? SucursalId { get; set; }

    public int? PresentacionId { get; set; }

    public virtual Presentacion? Presentacion { get; set; }

    public virtual Sucursal? Sucursal { get; set; }
}
