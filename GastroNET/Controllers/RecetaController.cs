using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace GastroNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaController : Controller
    {

        private readonly IRecetaService _service;
        public RecetaController(IRecetaService service)
        {
            _service = service;
        }

        [HttpPost]

        [ProducesResponseType(typeof(RecetaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
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
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
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

        //Buscador principal de TODO
        //[HttpGet]
        //[ProducesResponseType(typeof(List<RecetaResponse>), 200)]
        //[ProducesResponseType(typeof(BadRequest), 400)]
        //[ProducesResponseType(typeof(BadRequest), 404)]
        //public async Task<IActionResult> GetReceta()
        //{
        //    try
        //    {
        //        var result = await _service.GetListRecetas();
        //        return new JsonResult(result) { StatusCode = 200 };
        //    }
        //    catch (ExceptionSintaxError ex)
        //    {
        //        return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
        //    }
        //    catch (ExceptionNotFound ex)
        //    {
        //        return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
        //    }
        //}

        //Acá iría el controller que busca por cualquier filtro falopa
        //Nota: No se puede tener dos metodos HTTP del el mismo tipo (Get en este caso). y falta meterle las excepciones.
        //Nota 2: Si todos los valores que se ingresan son null entonces devuelve todas las recetas, como si fuera el buscador principal de todo.
        [HttpGet]
        [ProducesResponseType(typeof(List<RecetaResponse>), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetByFilters(string? titulo, string? dificultad, string? categoria, string? ingrediente)
        {
            try
            {
                var result = await _service.RecetasFilter(titulo, dificultad, categoria, ingrediente);
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
