﻿namespace PuntoVenta.AppWeb.Models.ViewModels
{
	public class VMArticulo
	{
		public int ArticuloId { get; set; }

		public string Codigo { get; set; } = null!;

		public string? Descripcion { get; set; }

		public decimal Precio { get; set; }

		public byte[]? Imagen { get; set; }

		public int Stock { get; set; }
	}
}
