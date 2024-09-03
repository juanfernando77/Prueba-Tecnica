using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Negocio.Service
{
    public interface IClienteService
    {
        Task<bool> Insertar(Cliente entity);
        Task<bool> Actualizar(Cliente entity);
        Task<bool> Eliminar(int id);
        Task<Cliente> Obtener(int id);
        Task<IQueryable<Cliente>> ObtenerTodos();
    }
}
