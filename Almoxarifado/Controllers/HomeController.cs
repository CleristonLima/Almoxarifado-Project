using Almoxarifado.Conexao;
using Almoxarifado.Models;
using Almoxarifado.Models.CadastroUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Almoxarifado.Controllers
{
    public class HomeController : Controller
    {
        private readonly InternetService _internetService;

        public HomeController(InternetService internetService)
        {
            _internetService = internetService;
        }

        public IActionResult Index()
        {
            if (_internetService.VerificarConexaoInternet())
            {
                return View();
            }
            else
            {
                return BadRequest("Não foi possível estabelecer conexão com a internet! Favor verificar a conexão");
            }
        }
    }
}
