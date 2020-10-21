using Microsoft.AspNetCore.Mvc;
using ProjetoFullStack.Models;

namespace ProjetoFullStack.Controllers
{
    public class UsuarioController: Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario usuario){
            UsuarioBanco ub = new UsuarioBanco();
            ub.Inserir(usuario);
            ViewBag.Mensagem="Usuario Cadastrado";
            return View();
        }
    }
}