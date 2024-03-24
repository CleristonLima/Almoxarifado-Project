using Almoxarifado.Conexao;
using Almoxarifado.Models.CadastroUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almoxarifado.Controllers
{
    public class LoginController : Controller
    {
        private readonly InternetService _internetService;

        public LoginController(InternetService internetService)
        {
            _internetService = internetService;
        }

        public IActionResult MenuPrincipal(Login login)
        {
            // Verificar a conexão com a internet
            if (!_internetService.VerificarConexaoInternet())
            {
                // Retornar uma view com uma mensagem de erro se a conexão com a internet não estiver disponível
                TempData["Erro"] = "Não foi possível estabelecer conexão com a internet! Favor verificar a conexão";
                //return RedirectToAction("Index", "Login");
            }

            // Verificar se o modelo é válido
            if (ModelState.IsValid)
            {
                // Autenticar o usuário
                if (login.Authenticate())
                {
                    // Armazenar o login na sessão
                    HttpContext.Session.SetString("UsuarioLogado", login.LoginName);
                    HttpContext.Session.SetString("Senha", login.PasswordLogin);
                    HttpContext.Session.SetString("Autorizado", "Ok");
                }
                else
                {
                    // Adicionar uma mensagem de erro à TempData se a autenticação falhar
                    TempData["Erro"] = "Usuário ou senha inválidos!";
                    return RedirectToAction("Index", "Home"); // Redirecionar para a página de login
                }
            }

            // Redirecionar para a página principal após o login bem-sucedido
            return View("MenuPrincipal", "Login");
        }
    }
}
