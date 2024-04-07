using Almoxarifado.Conexao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almoxarifado.Controllers
{
    public class AdminController : Controller
    {
        private InternetService _internetService;

        public AdminController(InternetService internetService)
        {
            _internetService = internetService;

        }

        public IActionResult Index()
        {
            if (!_internetService.VerificarConexaoInternet())
            {
                return BadRequest("Não foi possível estabelecer conexão com a internet! Favor verificar a conexão");
            }

            return View();
        }

        public IActionResult Voltar()
        {
            return View("MenuPrincipal");
        }
    }
}
