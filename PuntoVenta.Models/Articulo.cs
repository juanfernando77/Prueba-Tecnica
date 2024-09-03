using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class Articulo
{
    public int ArticuloId { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public byte[]? Imagen { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; } = new List<ArticuloTiendum>();

    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; } = new List<ClienteArticulo>();
}
