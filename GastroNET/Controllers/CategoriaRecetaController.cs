using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace GastroNET.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriaRecetaController : Controller
    {
        private readonly ICategoriaRecetaService _service;

        public CategoriaRecetaController(ICategoriaRecetaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CategoriaRecetaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]

        public async Task<IActionResult> GetListCategoriaRecetas()
        {
            try
            {
                var result = await _service.GetCategoriasReceta();
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriaRecetaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]

        public async Task<IActionResult> GetCategoriaRecetaById(int id)
        {
            try
            {
                var result = await _service.GetCategoriaRecetaById(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }
    }
}

