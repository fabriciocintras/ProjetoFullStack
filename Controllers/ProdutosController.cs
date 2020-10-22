using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFullStack.Models;

namespace ProjetoFullStack.Controllers
{
    public class ProdutosController:Controller
    {
       public IActionResult Cadastro()
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null)
                return RedirectToAction("Login","Usuario");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Produtos produto){
             if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","Usuario");
            ProdutosBanco pbanco = new ProdutosBanco();
            int id = (int)HttpContext.Session.GetInt32("idUsuario");
            pbanco.Inserir(produto,id);
            return View();
        }
        public IActionResult Listar()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","usuario");

            ProdutosBanco pb = new ProdutosBanco();
            List<Produtos> listar = pb.BuscarTodos();
            return View(listar);
        }
    }
}