using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GastroNET.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecetaController : Controller
    {

        private readonly IRecetaService _service;
        public RecetaController(IRecetaService service)
        {
            _service = service;
        }
        //Referencia de ENDPOINT

        //[HttpGet]
        //[ProducesResponseType(typeof(List<MercaderiaGetResponse>), 200)]
        //[ProducesResponseType(typeof(BadRequest), 400)]
        //[ProducesResponseType(typeof(MercaderiaResponse), 201)]
        //[ProducesResponseType(typeof(BadRequest), 409)]
        //[ProducesResponseType(typeof(BadRequest), 404)]

        ////public async Task<IActionResult> GetMercaderiaByfilter(int? tipo, string? nombre, string? orden)
        //{
        //    try
        //    {
        //        var result = await _service.GetMercaderiaByFilter(tipo, nombre, orden);
        //        return new JsonResult(result) { StatusCode = 200 };
        //    }
        //    catch (ExceptionSintaxError ex)
        //    {
        //        return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
        //    }
        //}
    }

}
