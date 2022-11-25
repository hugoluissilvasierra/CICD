using Microsoft.AspNetCore.Mvc;
using VentasAPI.DTOs.DtosInput;
using VentasAPI.DTOs.DtosOutput;
using VentasAPI.Servicios;
using VentasAPI.Utils;

namespace VentasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _productosService;

        public ProductosController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet(Name = "GetProductos")]
        public ActionResult GetAll()
        {
            var productos = _productosService.GetProductos();

            if (productos.Any())
                return Ok(productos);

            return StatusCode(StatusCodes.Status204NoContent);            
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Producto = _productosService.GetProducto(id);

                if (Producto == null)
                    return NotFound();

                return Ok(Producto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost(Name = "CrearProducto")]
        public IActionResult CrearProducto(ProductoDtoCrear producto)
        {
            try
            {
                var productoDtoOutput = _productosService.CrearProducto(producto);

                return StatusCode(StatusCodes.Status201Created, productoDtoOutput);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut(Name = "ModificarProducto")]
        public IActionResult ModificarProducto(ProductoDtoModificar productoDtoModificar)
        {
            try
            {
                _productosService.ModificarProducto(productoDtoModificar);

                return Ok("Modificado");
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult EliminarProducto(int id)
        {
            try
            {
                _productosService.EliminarProducto(id);

                return Ok("Eliminado");
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}