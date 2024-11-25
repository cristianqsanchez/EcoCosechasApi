using System;
using System.Collections.Generic;

namespace EcoCosechas.Models;

public partial class Sucursal
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? CodigoPostal { get; set; }

    public string? Correo { get; set; }

    public string? Whatsapp { get; set; }

    public string? Contacto { get; set; }

    public string? Cargo { get; set; }

    public string? Observaciones { get; set; }

    public int? CiudadId { get; set; }

    public int? ClienteId { get; set; }

    public virtual ICollection<AspNetUser> AspNetUsers { get; set; } = new List<AspNetUser>();

    public virtual Ciudad? Ciudad { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual ICollection<Listum> Lista { get; set; } = new List<Listum>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
