using PuntoVenta.Da.Repositories;
using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Negocio.Service
{
	public class ArticuloService : IArticuloService
	{
		private readonly IGenericRepository<Articulo> _articuloRepository;

		public ArticuloService(IGenericRepository<Articulo> articuloRepo)
		{
			_articuloRepository = articuloRepo;
		}


		public async Task<bool> Actualizar(Articulo modelo)
		{
			return await _articuloRepository.Actualizar(modelo);
		}

		public async Task<bool> Eliminar(int id)
		{
			return await _articuloRepository.Eliminar(id);
		}

		public async Task<bool> Insertar(Articulo modelo)
		{
			return await _articuloRepository.Insertar(modelo);
		}

		public async Task<Articulo> Obtener(int id)
		{
			return await _articuloRepository.Obtener(id);
		}

		public async Task<IQueryable<Articulo>> ObtenerTodos()
		{
			return await _articuloRepository.ObtenerTodos();
		}
	}
}
