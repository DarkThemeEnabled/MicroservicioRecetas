using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GastroNET.Controllers
{
    public class PasosController : Controller
    {
        private readonly IPasosService _pasosService;
        
        public PasosController(IPasosService pasosService)
        {
            _pasosService = pasosService;
        }

    }
}
