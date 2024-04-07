using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almoxarifado.Controllers
{
    public class LogoutController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Logout()
        {
            // Limpar os dados da sessão
            _httpContextAccessor.HttpContext.Session.Clear();

            // Redirecionar para a página de login
            return RedirectToAction("Index", "Home");
        }
    }
}
