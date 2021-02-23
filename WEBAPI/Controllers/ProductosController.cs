using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WEBAPI.Models;
using WEBAPI.Services;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly ProductService _productoService;
        public ProductosController(ProductService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var productList = await _productoService.ObtenerProductos();
            return Ok(productList);
        }

        [HttpGet]
        [Route("filtro/{modelo}")]
        public async Task<IActionResult> Filtro(string modelo)
        {
            var productList = await _productoService.ObtenerProductos(modelo);
            return Ok(productList);
        }
        [HttpGet]
        [Route("detalle/{id}")]
        public async Task <IActionResult> ObtenerProducto(int id)
        {
            var product = await _productoService.ObtenerProducto(id);
            return Ok(product);
        }

        [HttpPost]
        [Route("agregar")]
        public async Task<IActionResult> Agregar([FromBody] Producto producto)
        {
            var result = await _productoService.AgregarProducto(producto);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] Producto producto)
        {
            var result = await _productoService.ActualizarProducto(producto);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _productoService.EliminarProducto(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
