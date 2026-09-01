using Llantera.Application.DTOs;
using Llantera.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Llantera.Web.Controllers
{
    public class ServiciosController : Controller
    {

        
        private readonly IServiceServicios _serviceServicios;

        public ServiciosController(IServiceServicios serviceServicios)
        {
            _serviceServicios = serviceServicios;
        }

        [HttpGet]
        // GET: UsuariosController
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceServicios.ListAsync();
            return View("Index", collection);
        }

        // GET: ServiciosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiciosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiciosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiciosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiciosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiciosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiciosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
