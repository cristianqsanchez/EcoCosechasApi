using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Sede
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? CodigoPostal { get; set; }

    public string? Correo { get; set; }

    public string? Whatsapp { get; set; }

    public int? CiudadId { get; set; }

    public int? EmpresaId { get; set; }

    public virtual Ciudad? Ciudad { get; set; }

    public virtual Empresa? Empresa { get; set; }
}
