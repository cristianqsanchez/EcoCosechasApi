using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Whatsapp { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Puesto { get; set; }

    public string? Bodega { get; set; }

    public int? CiudadId { get; set; }

    public int? EmpresaId { get; set; }

    public virtual Ciudad? Ciudad { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual Empresa? Empresa { get; set; }
}
