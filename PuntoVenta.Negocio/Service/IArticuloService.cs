using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Negocio.Service
{
	public interface IArticuloService
	{
		Task<bool> Insertar(Articulo entity);
		Task<bool> Actualizar(Articulo entity);
		Task<bool> Eliminar(int id);
		Task<Articulo> Obtener(int id);
		Task<IQueryable<Articulo>> ObtenerTodos();
	}
}
