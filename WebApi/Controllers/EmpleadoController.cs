using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bussisnes;
using Models;
using System.Data.SqlClient;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoBSSN _empleadoData; // instancia de EmpleadoBSSN para llamar a los metodos
        private readonly ILogger<EmpleadoController> _logger; // instancia de logging para verificar errores

        public EmpleadoController(EmpleadoBSSN empleadoData, ILogger<EmpleadoController> logger)
        {
            _empleadoData = empleadoData;
            _logger = logger;
        }
        
        [HttpGet("listarEmpleado")]
        public async Task<IActionResult> Lista()
        {
            try
            {
                List<Empleado> lista = await _empleadoData.Lista();
                if (lista == null)
                {
                    _logger.LogWarning("No se encontraron empleados.");
                    return NotFound();
                }
                return Ok(lista);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error en la base de datos.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inesperado: {ex.Message}");
            }
        }
        [HttpPost("nuevoE")]
        public async Task<IActionResult> Crear([FromBody] Empleado objeto)
        {
            try
            {
                bool respuesta = await _empleadoData.Crear(objeto);

                if( respuesta == false)
                {
                    _logger.LogWarning("No se pudo crear el objeto");
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error en la base de datos");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inesperado: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inesperado: {ex.Message}");
            }
        }
        [HttpPut("editarE")]
        public async Task<IActionResult> Editar([FromBody] Empleado objeto)
        {
            try
            {
                bool respuesta = await _empleadoData.Editar(objeto);
                if(respuesta == false)
                {
                    _logger.LogWarning("No se pudo editar el objeto");
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error en la base de datos");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inesperado: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inesperado: {ex.Message}");
            }
        }
        [HttpDelete("eliminarE{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                bool respuesta = await _empleadoData.Eliminar(id);
                if (respuesta == false)
                {
                    _logger.LogWarning("No se pudo editar el objeto");
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error en la base de datos");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inesperado: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inesperado: {ex.Message}");
            }
        }
    }
}
