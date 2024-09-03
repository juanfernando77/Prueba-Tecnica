using Microsoft.AspNetCore.Mvc;
using PuntoVenta.AppWeb.Models;
using PuntoVenta.AppWeb.Models.ViewModels;
using PuntoVenta.Models;
using PuntoVenta.Negocio.Service;
using System.Diagnostics;

namespace PuntoVenta.AppWeb.Controllers
{
	public class HomeController : Controller
	{
		//private readonly ILogger<HomeController> _logger;
		private readonly IArticuloService _articuloService;
        private readonly IClienteService _clienteService;


        public HomeController(IArticuloService articuloService, IClienteService clienteService)
		{
			_articuloService = articuloService;
            _clienteService = clienteService;

        }

        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Lista()
		{
			IQueryable<Articulo> queryArticuloSQL = await _articuloService.ObtenerTodos();

			List<VMArticulo> lista = queryArticuloSQL.Select(c => new VMArticulo(){
					ArticuloId = c.ArticuloId,
					Codigo = c.Codigo,
					Descripcion = c.Descripcion,
					Precio = c.Precio,
					Imagen = c.Imagen,
					Stock = c.Stock,
				}).ToList();
			return StatusCode(StatusCodes.Status200OK, lista);
		}

      

        [HttpPost]
		public async Task<IActionResult> Insertar ([FromBody]VMArticulo modelo)
		{
            //Articulo nuevoModelo = new Articulo()
            //{
            //	//ArticuloId=modelo.ArticuloId,
            //	Codigo=modelo.Codigo,
            //	Descripcion=modelo.Descripcion,
            //	Precio = modelo.Precio,
            //	Imagen = modelo.Imagen,
            //	Stock = modelo.Stock,
            //};

            if (modelo == null)
            {
                return BadRequest("El modelo no puede ser null");
            }

            Articulo nuevoModelo = new Articulo()
            {
                Codigo = modelo.Codigo,
                Descripcion = modelo.Descripcion,
                Precio = modelo.Precio,
                Imagen = modelo.Imagen,
                Stock = modelo.Stock,
            };


            bool respuesta = await _articuloService.Insertar(nuevoModelo);
		
			return StatusCode(StatusCodes.Status200OK, new { valor = respuesta});
		}
              

        [HttpPut]
		public async Task<IActionResult> Actualizar([FromBody] VMArticulo modelo)
		{
            if (modelo == null)
            {
                return BadRequest("El modelo no puede ser null");
            }
            Articulo nuevoModelo = new Articulo()
			{
				ArticuloId = modelo.ArticuloId,
				Codigo = modelo.Codigo,
				Descripcion = modelo.Descripcion,
				Precio = modelo.Precio,
				Imagen = modelo.Imagen,
				Stock = modelo.Stock,
			};

			bool respuesta = await _articuloService.Actualizar(nuevoModelo);

			return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
		}

        [HttpPut]
        public async Task<IActionResult> ActualizarCliente([FromBody] VMCliente modelo)
        {
            if (modelo == null)
            {
                return BadRequest("El modelo no puede ser null");
            }
            Cliente nuevoModelo = new Cliente()
            {
                Nombre = modelo.Nombre,
                Apellidos = modelo.Apellidos,
                Direccion = modelo.Direccion
            };

            bool respuesta = await _clienteService.Actualizar(nuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
		public async Task<IActionResult> Eliminar(int id)
		{
			
			bool respuesta = await _articuloService.Eliminar(id);

			return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


        [HttpGet]
        public async Task<IActionResult> ListaCliente()
        {
            IQueryable<Cliente> queryArticuloSQL = await _clienteService.ObtenerTodos();

            List<VMCliente> lista = queryArticuloSQL.Select(c => new VMCliente()
            {
                Nombre = c.Nombre,
                Apellidos = c.Apellidos,
                Direccion = c.Direccion
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> InsertarCliente([FromBody] VMCliente modelo)
        {

            if (modelo == null)
            {
                return BadRequest("El modelo no puede ser null");
            }

            Cliente nuevoModelo = new Cliente()
            {
                Nombre = modelo.Nombre,
                Apellidos = modelo.Apellidos,
                Direccion = modelo.Direccion
            };


            bool respuesta = await _clienteService.Insertar(nuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
    }


}
