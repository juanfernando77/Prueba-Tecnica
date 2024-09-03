namespace PuntoVenta.AppWeb.Models.ViewModels
{
    public class VMCliente
    {
        public int ClienteId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Direccion { get; set; }

    }
}