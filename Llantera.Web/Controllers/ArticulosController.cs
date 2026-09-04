using Llantera.Application.DTOs;
using Llantera.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Llantera.Web.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly IServiceArticulos _serviceArticulos;

        public ArticulosController(IServiceArticulos serviceArticulos)
        {
            _serviceArticulos = serviceArticulos;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceArticulos.ListAsync();
            return View("Index", collection);
        }

        // Additional actions (Details/Create/Edit/Delete) can be added later
    }
}
