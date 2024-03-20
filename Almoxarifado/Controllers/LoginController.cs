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

        public IActionResult MenuPrincipal(Login model)
        {
            // Verificar a conexão com a internet
            if (!_internetService.VerificarConexaoInternet())
            {
                // Retornar uma view com uma mensagem de erro se a conexão com a internet não estiver disponível
                TempData["Erro"] = "Não foi possível estabelecer conexão com a internet! Favor verificar a conexão";
                return RedirectToAction("Index", "Login");
            }

            // Verificar se o modelo é válido
            if (ModelState.IsValid)
            {
                // Autenticar o usuário
                if (model.Authenticate())
                {
                    // Armazenar o login na sessão
                    HttpContext.Session.SetString("UsuarioLogado", model.LoginName);
                    HttpContext.Session.SetString("Senha", model.PasswordLogin);
                    HttpContext.Session.SetString("Autorizado", "Ok");

                    // Redirecionar para a página principal após o login bem-sucedido
                    return RedirectToAction("MenuPrincipal", "Login");
                }
                else
                {
                    // Adicionar uma mensagem de erro à TempData se a autenticação falhar
                    TempData["Erro"] = "Usuário ou senha inválidos";
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                // Retornar uma view com uma mensagem de erro se o modelo não for válido
                TempData["Erro"] = "Dados de login inválidos";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
