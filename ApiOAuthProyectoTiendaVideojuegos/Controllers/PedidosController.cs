using ApiOAuthProyectoTiendaVideojuegos.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetProyectoTinedaVideojuegosAzure;

namespace ApiOAuthProyectoTiendaVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private RepositoryProductos repo;

        public PedidosController(RepositoryProductos repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]/{idCliente}/{precioTotal}")]
        public void AgregarPedido([FromQuery] List<Producto> productos, int idCliente, int precioTotal, [FromQuery] List<int> cantidad)
        {
            this.repo.AgregarPedido(productos, idCliente, precioTotal, cantidad);
        }

        [HttpGet]
        [Route("[action]/{idcliente}")]
        public ActionResult<List<DetallesPedido>> MostrarPedidos(int idcliente)
        {
            return this.repo.MostrarPedidos(idcliente);
        }
    }
}
