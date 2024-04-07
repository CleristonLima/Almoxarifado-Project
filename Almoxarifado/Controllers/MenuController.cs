using Almoxarifado.Conexao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almoxarifado.Controllers
{
    public class MenuController : Controller
    {
        private InternetService _internetService;
         public MenuController(InternetService internetService)
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

        public IActionResult Administration()
        {
            if (!_internetService.VerificarConexaoInternet())
            {
                return BadRequest("Não foi possível estabelecer conexão com a internet! Favor verificar a conexão");
            }

            return View("~/Views/Administrator/Administration.cshtml");
        }

        public IActionResult HR()
        {
            if (!_internetService.VerificarConexaoInternet())
            {
                return BadRequest("Não foi possível estabelecer conexão com a internet! Favor verificar a conexão");
            }

            return View("~/Views/HR/HumanResource.cshtml");
        }

        public IActionResult Machines()
        {
            if (!_internetService.VerificarConexaoInternet())
            {
                return BadRequest("Não foi possível estabelecer conexão com a internet! Favor verificar a conexão");
            }

            return View("~/Views/Machines/Machines.cshtml");
        }

        public IActionResult Vehicles()
        {
            if (!_internetService.VerificarConexaoInternet())
            {
                return BadRequest("Não foi possível estabelecer conexão com a internet! Favor verificar a conexão");
            }

            return View("~/Views/Vehicles/Vehicles.cshtml");
        }

        public IActionResult Tools()
        {
            if (!_internetService.VerificarConexaoInternet())
            {
                return BadRequest("Não foi possível estabelecer conexão com a internet! Favor verificar a conexão");
            }

            return View("~/Views/Tools/Tools.cshtml");
        }

    }
}
