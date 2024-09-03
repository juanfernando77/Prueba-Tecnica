using PuntoVenta.Da.DataContext;
using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Da.Repositories
{
	public class PuntoVentaRepository : IGenericRepository<Articulo>
	{
		private readonly PuntoVentaContext _dbcontext;
        public PuntoVentaRepository(PuntoVentaContext context)
        {
			_dbcontext = context;	
        }


        public async Task<bool> Actualizar(Articulo modelo)
		{
			_dbcontext.Articulos.Update(modelo);
			await _dbcontext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Eliminar(int id)
		{
			Articulo modelo = _dbcontext.Articulos.First(c => c.ArticuloId == id);
			await _dbcontext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Insertar(Articulo modelo)
		{
			_dbcontext.Articulos.Add(modelo);
			await _dbcontext.SaveChangesAsync();
			return true;
		}

		public async Task<Articulo> Obtener(int id)
		{
			return await _dbcontext.Articulos.FindAsync(id);
		}

		public async Task<IQueryable<Articulo>> ObtenerTodos()
		{
			IQueryable<Articulo> queryArticuloSQL = _dbcontext.Articulos;
			return queryArticuloSQL;
		}
	}
}
