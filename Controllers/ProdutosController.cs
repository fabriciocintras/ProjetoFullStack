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
            if(HttpContext.Session.GetInt32("idUsuario")== null || HttpContext.Session.GetInt32("tipoUsuario") !=0)
                return RedirectToAction("Login","Usuario");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Produtos produto){
            ProdutosBanco pbanco = new ProdutosBanco();
            int id = (int)HttpContext.Session.GetInt32("idUsuario");
            pbanco.Inserir(produto,id);
            ViewBag.Mensagem="Produto Cadastrado com exito!";
            return View();
        }
        public IActionResult Listar()
        {
            if(HttpContext.Session.GetInt32("idUsuario")==null)
                return RedirectToAction("Login","Usuario");

            ProdutosBanco pb = new ProdutosBanco();
            List<Produtos> listar = pb.BuscarTodos();
            return View(listar);
        }
        public IActionResult ListarColab()
        {
           ProdutosBanco pb = new ProdutosBanco();
            List<Produtos> listar = pb.BuscarTodos();
            return View(listar);
        }

        public IActionResult Editar(int Id)
        {
            ProdutosBanco pb = new ProdutosBanco();
            Produtos produto = pb.ConsultaPorId(Id);
            return View();
        }
        public IActionResult Gravar(Produtos produto)
        {
            ProdutosBanco pb = new ProdutosBanco();
            pb.Atualizar(produto);
            return RedirectToAction("Listar");
        }
        public IActionResult Remover(int Id)
        {
            ProdutosBanco pb = new ProdutosBanco();
            pb.Remover(Id);
            return RedirectToAction("Listar");
        }

    }
}