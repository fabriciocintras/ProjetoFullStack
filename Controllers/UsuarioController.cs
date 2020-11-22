using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFullStack.Models;

namespace ProjetoFullStack.Controllers
{
    public class UsuarioController: Controller
    {
        public IActionResult Cadastro()
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null || HttpContext.Session.GetInt32("tipoUsuario")!= 0 )
                return RedirectToAction("Login");
            return View();
        }
        public IActionResult cadastroCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult cadastroCliente(Usuario u)
        {
            UsuarioBanco ub = new UsuarioBanco();
            ub.Inserir(u);
            ViewBag.Mensagem="Usuario Cadastrado com Sucesso!";
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario usuario){
            UsuarioBanco ub = new UsuarioBanco();
            ub.Inserir(usuario);
            ViewBag.Mensagem="Usuario Cadastrado com exito!";
            return View();
        }
        public IActionResult Listar()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login");
            UsuarioBanco ub = new UsuarioBanco();
            List<Usuario> listar = ub.Query();
            return View(listar);
        }
     
        public IActionResult Editar(int Id)
        {
            UsuarioBanco ub = new UsuarioBanco();
            Usuario usuario = ub.ConsultaPorId(Id);
            return View();
        }
        public IActionResult ListarColab()
        { 
            UsuarioBanco ub = new UsuarioBanco();
            List<Usuario> listar = ub.Query();
            return View(listar);
        }
        public IActionResult Gravar(Usuario usuario)
        {
            UsuarioBanco ub = new UsuarioBanco();
            ub.Atualizar(usuario);
            return RedirectToAction("Listar");
        }
        public IActionResult Remover(int Id)
        {
            UsuarioBanco ub = new UsuarioBanco();
            ub.Remover(Id);
            return RedirectToAction("Listar");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            UsuarioBanco ub = new UsuarioBanco();
            Usuario usuario = ub.QueryLogin(user);
            if(usuario != null)
            {
                HttpContext.Session.SetInt32("idUsuario", usuario.Id);
                HttpContext.Session.SetString("nomeUsuario", usuario.Nome);
                HttpContext.Session.SetInt32("tipoUsuario", usuario.Tipo);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Mensagem = "Falha Login!";
                return View();
            }

        }
        [HttpPost]
        public IActionResult LoginCliente(Usuario user)
        {
            UsuarioBanco ub = new UsuarioBanco();
            Usuario usuario = ub.QueryLogin(user);
            if(usuario != null)
            {
                HttpContext.Session.SetInt32("idUsuario", usuario.Id);
                HttpContext.Session.SetString("nomeUsuario", usuario.Nome);
                 HttpContext.Session.SetInt32("tipoUsuario", usuario.Tipo);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Mensagem = "Falha Login!";
                return View();
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
