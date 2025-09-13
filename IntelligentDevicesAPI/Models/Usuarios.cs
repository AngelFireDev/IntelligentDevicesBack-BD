public class Usuarios
{
    public int Id { get; set; }
    public string TipoDocumento { get; set; } = string.Empty;
    public int NumeroDocumento { get; set; }
    public string Nombres { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Clave { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}
