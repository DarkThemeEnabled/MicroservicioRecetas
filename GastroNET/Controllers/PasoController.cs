using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace GastroNET.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PasoController : Controller
    {
        private readonly IPasoService _pasosService;

        public PasoController(IPasoService pasosService)
        {
            _pasosService = pasosService;
        }
        [HttpPost("/CreatePaso")]

        [ProducesResponseType(typeof(PasoResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> CreatePaso(PasoRequest request)
        {
            try
            {
                var result = await _pasosService.CreatePaso(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (Conflict ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 409 };
            }
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(PasoResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetPasosByRecetaId(Guid id)
        {
            try
            {
                var result = await _pasosService.GetPasoByRecetaId(id);
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

        [HttpGet("{Receta Id}")]
        [ProducesResponseType(typeof(PasoResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetPasoById(int id)
        {
            try
            {
                var result = await _pasosService.GetPasoById(id);
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