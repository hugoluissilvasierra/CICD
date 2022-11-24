using Microsoft.AspNetCore.Mvc;
using VentasAPI.DTOs.DtosInput;
using VentasAPI.DTOs.DtosOutput;
using VentasAPI.Servicios;
using VentasAPI.Utils;

namespace VentasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet(Name = "GetClientes")]
        public IActionResult GetAll()
        {
            var clientes = _clientesService.GetClientes();

            if (clientes.Any())
                return Ok(clientes);

            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Cliente = _clientesService.GetCliente(id);

                if (Cliente == null)
                    return NotFound();

                return Ok(Cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost(Name = "CrearCliente")]
        public IActionResult CrearCliente(ClienteDtoCrear cliente)
        {
            try
            {
                var clienteDtoOutput = _clientesService.CrearCliente(cliente);

                return StatusCode(StatusCodes.Status201Created, clienteDtoOutput);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut(Name = "ModificarCliente")]
        public IActionResult ModificarCliente(ClienteDtoModificar clienteDtoModificar)
        {
            try
            {
                _clientesService.ModificarCliente(clienteDtoModificar);

                return Ok("Cliente Modificado  !!!!");
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
        public IActionResult EliminarCliente(int id)
        {
            try
            {
                _clientesService.EliminarCliente(id);

                return Ok("Cliente Eliminado");
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