using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace GastroNET.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DificultadController : Controller
    {
        private readonly IDificultadService _service;


        public DificultadController(IDificultadService service)
        {
            _service = service;
        }

        [HttpGet("/GetListDificultad")]

        public async Task<IActionResult> GetListDificultad()
        {
            try
            {
                var result = await _service.GetListDificultad();
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }


        }
}
