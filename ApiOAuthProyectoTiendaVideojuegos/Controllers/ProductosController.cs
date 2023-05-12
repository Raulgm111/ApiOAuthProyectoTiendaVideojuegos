using ApiOAuthProyectoTiendaVideojuegos.Extensions;
using ApiOAuthProyectoTiendaVideojuegos.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NugetProyectoTinedaVideojuegosAzure;

namespace ApiOAuthProyectoTiendaVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private RepositoryProductos repo;

        public ProductosController(RepositoryProductos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Producto>> GetProductosPS4()
        {
            return this.repo.GetProductosPS4();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Producto>> GetProductosPS5()
        {
            return this.repo.GetProductosPS5();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Producto>> GetTazas()
        {
            return this.repo.GetTazas();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Categoria>> GetCategorias()
        {
            return this.repo.GetCategorias();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<SubCategoria>> GetSubCategorias()
        {
            return this.repo.GetSubCategorias();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<List<Producto>> GetPorductosGrid(int id)
        {
            return this.repo.GetPorductosGrid(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Producto>> GetTodosProductos()
        {
            return this.repo.GetTodosProductos();
        }

        [HttpGet]
        [Route("[action]/{buscar}")]
        public ActionResult<List<Producto>> GetBuscadorProductos(string buscar)
        {
            return this.repo.GetBuscadorProductos(buscar);
        }

        [HttpGet]
        [Route("[action]/{idproducto}")]
        public ActionResult<Producto> DetallesProductos(int idproducto)
        {
            return this.repo.DetallesProductos(idproducto);
        }

        [HttpGet]
        [Route("[action]")]
        //[Authorize]
        public ActionResult<List<Producto>> BuscarProductoCarrito([FromQuery] List<int>? idproductoCarrito)
        {
            return this.repo.BuscarProductoCarrito(idproductoCarrito);
        }

        [HttpGet]
        [Route("[action]")]
        //[Authorize]
        public ActionResult<List<Producto>> BuscarProductoFavorito( [FromQuery] List<int> idproductoFav)
        {
            return this.repo.BuscarProductoFavorito(idproductoFav);
        }

        [HttpDelete]
        [Route("[action]/{idproducto}")]
        //[Authorize]
        public void DeleteProductos(int idproducto)
        {
            this.repo.DeleteProductos(idproducto);
        }

        [HttpPut]
        [Route("[action]")]
        //[Authorize]
        public void UpdatePorducto(Producto producto)
        {
            this.repo.UpdatePorducto(producto);
        }

    }
    }
