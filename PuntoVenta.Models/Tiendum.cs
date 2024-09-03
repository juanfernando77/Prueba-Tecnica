using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class Tiendum
{
    public int TiendaId { get; set; }

    public string Sucursal { get; set; } = null!;

    public string? Direccion { get; set; }

    public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; } = new List<ArticuloTiendum>();
}
