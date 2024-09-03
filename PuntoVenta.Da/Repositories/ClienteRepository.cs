using PuntoVenta.Da.DataContext;
using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Da.Repositories
{
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        private readonly PuntoVentaContext _dbcontext;
        public ClienteRepository(PuntoVentaContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Actualizar(Cliente modelo)
        {
            _dbcontext.Clientes.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Cliente modelo = _dbcontext.Clientes.First(c => c.ClienteId == id);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Cliente modelo)
        {
            _dbcontext.Clientes.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _dbcontext.Clientes.FindAsync(id);
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            IQueryable<Cliente> queryArticuloSQL = _dbcontext.Clientes;
            return queryArticuloSQL;
        }
    }
}
