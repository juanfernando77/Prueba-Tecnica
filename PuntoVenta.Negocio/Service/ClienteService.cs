using PuntoVenta.Da.Repositories;
using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Negocio.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public ClienteService(IGenericRepository<Cliente> clienteRepo)
        {
            _clienteRepository = clienteRepo;
        }


        public async Task<bool> Actualizar(Cliente modelo)
        {
            return await _clienteRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _clienteRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(Cliente modelo)
        {
            return await _clienteRepository.Insertar(modelo);
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _clienteRepository.Obtener(id);
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            return await _clienteRepository.ObtenerTodos();
        }
    }
}
