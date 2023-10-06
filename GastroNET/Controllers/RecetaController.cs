using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Application.UseCases.SPasos;
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

        [HttpGet]
        [ProducesResponseType(typeof(List<RecetaResponse>), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public async Task<IActionResult> GetListReceta()
        {
            try
            {
               var result= await _service.GetListRecetas();
               return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost]

        [ProducesResponseType(typeof(RecetaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> CreateReceta(RecetaRequest request)
        {
            try
            {
                var result = await _service.CreateReceta(request);
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

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(RecetaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> UpdateReceta(Guid Id, RecetaRequest receta)
        {
            try
            {
                var result = await _service.UpdateReceta(receta, Id);
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
            catch (Conflict ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 409 };
            }
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(RecetaDeleteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> DeleteReceta(Guid Id)
        {
            try
            {
                var result = await _service.DeleteReceta(Id);
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
            catch (Conflict ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 409 };
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PasoResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetRecetaById(Guid id)
        {
            try
            {
                var result = await _service.GetRecetaById(id);
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
