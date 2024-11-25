using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Item
{
    public int Id { get; set; }

    public int? PresentacionId { get; set; }

    public double? Cantidad { get; set; }

    public int? ListaId { get; set; }

    public virtual Listum? Lista { get; set; }

    public virtual Presentacion? Presentacion { get; set; }
}
