using Llantera.Application.DTOs;
using Llantera.Application.Services.Implementations;
using Llantera.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Details(int id)
        {
            var @object = await _serviceServicios.FindByIdAsync(id);
            return View(@object);
        }

        // GET: ServiciosController/Create
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            var model = new ServiciosDTO();

            return View(model);
        }

        // POST: ServiciosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(
            ServiciosDTO dto,
            IFormFile? imagenFile)
        {
            try
            {
                if (imagenFile == null || imagenFile.Length == 0)
                {
                    ModelState.AddModelError(
                        "Imagen",
                        "Debe seleccionar una imagen."
                    );
                }

                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                using var ms = new MemoryStream();

                await imagenFile.CopyToAsync(ms);

                dto.Imagen = ms.ToArray();

                await _serviceServicios.AddAsync(dto);

                TempData["SuccessMessage"] =
                    "Servicio creado exitosamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Ocurrió un error al crear el servicio: " + ex.Message
                );

                return View(dto);
            }
        }

        // GET: ServiciosController/Edit/5
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id)
        {
            var obj = await _serviceServicios.FindByIdAsync(id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        // POST: ServiciosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(
            int id,
            ServiciosDTO dto,
            IFormFile? imagenFile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var servicioExistente =
                    await _serviceServicios.FindByIdAsync(id);

                if (servicioExistente == null)
                    return NotFound();

                if (imagenFile != null && imagenFile.Length > 0)
                {
                    using var ms = new MemoryStream();

                    await imagenFile.CopyToAsync(ms);

                    dto.Imagen = ms.ToArray();
                }
                else
                {
                    dto.Imagen = servicioExistente.Imagen;
                }

                await _serviceServicios.UpdateAsync(id, dto);

                TempData["SuccessMessage"] =
                    "Servicio actualizado exitosamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Ocurrió un error al actualizar el servicio: " + ex.Message
                );

                return View(dto);
            }
        }
    }
}
