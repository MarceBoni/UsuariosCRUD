using Microsoft.AspNetCore.Mvc;
using PruebaUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaUsuarios.Controllers
{
    public class LoginController : Controller
    {
        private readonly TestCrudContext _context;

        public LoginController(TestCrudContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] Usuario ad)
        {

            var user = _context.Usuarios.FirstOrDefault(e => e.Email == ad.Email && e.Contraseña == ad.Contraseña);

            if (User != null)
            {
                if(user.IdTipoUsuario == 1)
                {
                    return RedirectToAction("Index", "Usuarios");
                }
                else
                {
                    return RedirectToAction("Privacy", "Home");
                }
                
            }
            else
            {
                TempData["msg"] = "No encontramos tus datos";
               
            }

            TempData["msg"] = "Llena los campos para poder iniciar sesión!";
            return View();
        }
    }
}
