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

   /* [HttpPost]
        public IActionResult Autenticar(Login model)
        {
            // Verificar se o modelo é válido
            if (ModelState.IsValid)
            {
                // Criar uma instância de Login com os dados fornecidos
                var login = new Login
                {
                    LoginName = model.LoginName,
                    PasswordLogin = model.PasswordLogin
                };

                // Autenticar o usuário
                if (login.Authenticate())
                {
                    // Redirecionar para a página principal após o login bem-sucedido
                    return RedirectToAction("MenuPrincipal", "Login");
                }
                else
                {
                    // Adicionar uma mensagem de erro ao ModelState se a autenticação falhar
                    ModelState.AddModelError("", "Usuário ou senha incorretos.");
                }
            }

            // Se houver erros de validação ou se o login falhar, retornar a view de login com os erros
            return View("Login");
        }*/
    }
}
