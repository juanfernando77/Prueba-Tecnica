using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class ArticuloTiendum
{
    public int ArticuloId { get; set; }

    public int TiendaId { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Articulo Articulo { get; set; } = null!;

    public virtual Tiendum Tienda { get; set; } = null!;
}
