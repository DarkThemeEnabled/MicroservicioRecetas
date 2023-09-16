using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace GastroNET.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PasosController : Controller
    {
        private readonly IPasosService _pasosService;
        
        public PasosController(IPasosService pasosService)
        {
            _pasosService = pasosService;
        }
        [HttpPost("/CreatePaso")]
        
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(PasoResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult>CreatePaso(PasoRequest request)
        {
            try
            {
                var result = await _pasosService.CreatePaso(request);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

    }
}
