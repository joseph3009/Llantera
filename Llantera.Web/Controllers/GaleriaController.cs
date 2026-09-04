using Llantera.Application.DTOs;
using Llantera.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Llantera.Web.Controllers
{
    public class GaleriaController : Controller
    {
        private readonly IServiceGaleria _serviceGaleria;

        public GaleriaController(IServiceGaleria serviceGaleria)
        {
            _serviceGaleria = serviceGaleria;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceGaleria.ListAsync();
            return View("Index", collection);
        }
    }
}
