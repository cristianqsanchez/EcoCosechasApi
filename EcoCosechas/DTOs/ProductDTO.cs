namespace EcoCosechas.DTOs;

public class ProductoDTO
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Subcategoria { get; set; }
    public string? Marca { get; set; }
    public string? Unidad { get; set; }
    public DateTime? Actualizacion { get; set; }
    public decimal Costo { get; set; }
    public double Utilidad { get; set; }
    public double? Precio { get; set; }
}
