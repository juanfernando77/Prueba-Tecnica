using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Direccion { get; set; }

    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; } = new List<ClienteArticulo>();
}
