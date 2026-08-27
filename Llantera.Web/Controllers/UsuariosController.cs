using Llantera.Application.DTOs;
using Llantera.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Llantera.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IServiceUsuarios _serviceUsuario;
        private readonly IServiceRol _serviceRol;

        public UsuariosController(IServiceUsuarios serviceUsuario, IServiceRol serviceRol)
        {
            _serviceUsuario = serviceUsuario;
            _serviceRol = serviceRol;
        }

        [HttpGet]
        // GET: UsuariosController
       //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceUsuario.ListAsync();
            return View(collection);
        }

        // GET: UsuariosController/Details/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Details(int id)
        {
            var @object = await _serviceUsuario.FindByIdAsync(id);
            return View(@object);
        }

        [HttpGet]
        // GET: UsuariosController/Create
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create()
        {
            var roles = await _serviceRol.ListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Descripcion");

            var model = new UsuariosDTO();
            return View(model);
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(UsuariosDTO dto, int id)
        {
            // Eliminar validaciones de propiedades de navegación
            ModelState.Remove(nameof(dto.IdrolNavigation));

            if (await _serviceUsuario.ExisteCorreoAsync(dto.Correo, id))
            {
                ModelState.AddModelError("Correo", "El correo del usuario ya existe. Este debe ser único.");
                TempData["ErrorMessage"] = "No se pudo completar. El correo ya está en uso por otro usuario.";

                // Recargar roles para la vista
                var roles = await _serviceRol.ListAsync();
                ViewBag.Roles = new SelectList(roles, "Id", "Descripcion", dto.Idrol);

                return View(dto);
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Por favor, revisa los campos y vuelve a intentarlo.";
                // Recargar roles para la vista
                var roles = await _serviceRol.ListAsync();
                ViewBag.Roles = new SelectList(roles, "Id", "Descripcion", dto.Idrol);

                return View(dto);
            }

            await _serviceUsuario.AddAsync(dto);

            TempData["SuccessMessage"] = "Usuario creado con éxito";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        // GET: UsuariosController/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _serviceUsuario.FindByIdAsync(id);
            if (usuario == null) return NotFound();

            var roles = await _serviceRol.ListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Descripcion", usuario.Idrol);

            return View(usuario);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, UsuariosDTO dto)
        {
            var usuarioExistente = await _serviceUsuario.FindByIdAsync(id);
            if (usuarioExistente == null) return NotFound();

            // Eliminar validaciones de propiedades de navegación
            ModelState.Remove(nameof(dto.IdrolNavigation));

            // Contraseña opcional en edición
            if (string.IsNullOrEmpty(dto.Contrasenna))
            {
                ModelState.Remove(nameof(dto.Contrasenna));
                dto.Contrasenna = usuarioExistente.Contrasenna; // Mantener la actual
            }

            // Mantener el rol actual si no se envía uno válido
            if (dto.Idrol == 0)
                dto.Idrol = usuarioExistente.Idrol;

            // Validar correo duplicado (permitir el del propio usuario)
            if (await _serviceUsuario.ExisteCorreoAsync(dto.Correo, id))
            {
                ModelState.AddModelError("Correo", "El correo del usuario ya existe. Este debe ser único.");
                TempData["ErrorMessage"] = "No se pudo actualizar. El correo ya está en uso por otro usuario.";

                // Recargar roles para la vista
                var roles = await _serviceRol.ListAsync();
                ViewBag.Roles = new SelectList(roles, "Id", "Descripcion", dto.Idrol);

                return View(dto);
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Por favor, revisa los campos y vuelve a intentarlo.";
                // Recargar roles para la vista
                var roles = await _serviceRol.ListAsync();
                ViewBag.Roles = new SelectList(roles, "Id", "Descripcion", dto.Idrol);

                return View(dto);
            }

            await _serviceUsuario.UpdateAsync(id, dto);

            TempData["SuccessMessage"] = "Usuario actualizado con éxito";
            return RedirectToAction("Index");
        }
    }
}
