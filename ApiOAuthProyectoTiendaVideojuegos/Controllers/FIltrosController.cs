using ApiOAuthProyectoTiendaVideojuegos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetProyectoTinedaVideojuegosAzure;

namespace ApiOAuthProyectoTiendaVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FIltrosController : ControllerBase
    {
        private RepositoryProductos repo;

        public FIltrosController(RepositoryProductos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Producto>> FiltrarPorPlataforma([FromQuery] List<string> plataformas)
        {
            return this.repo.FiltrarPorPlataforma(plataformas);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Producto>> FiltrarPorGenero([FromQuery] List<string> generos)
        {
            return this.repo.FiltrarPorGenero(generos);
        }

        [HttpGet]
        [Route("[action]/{precioMinimo}/{precioMaximo}")]
        public ActionResult<List<Producto>> FiltrarPorPrecio(int? precioMinimo, int? precioMaximo)
        {
            return this.repo.FiltrarPorPrecio(precioMinimo, precioMaximo);
        }
    }
}
