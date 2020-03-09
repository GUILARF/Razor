using LojaWeb.Entidades;
using LojaWeb.Infra;
using LojaWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaWeb.DAO;

namespace LojaWeb.Controllers
{
    public class CategoriasController : Controller
    {
        //
        // GET: /Categorias/

        public ActionResult Index()
        {
            IList<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Categoria categoria)
        {
            ISession session = NHibernateHelper.AbreSession();
            CategoriasDAO dao = new CategoriasDAO(session);
            dao.Adiciona(categoria);
            return RedirectToAction("Visualiza", new { id = categoria.Id });
        }

        public ActionResult Remove(int id)
        {
     
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            ISession session = NHibernateHelper.AbreSession();
            CategoriasDAO dao = new CategoriasDAO(session);
            Categoria categoria = dao.BuscaPorId(id);
            return View(categoria);
        }

        public ActionResult Atualiza(Categoria categoria)
        {
            ISession session = NHibernateHelper.AbreSession();
            CategoriasDAO dao = new CategoriasDAO(session);
            dao.Atualiza(categoria);
            return View("Visualiza", categoria);
        }

        public ActionResult CategoriasEProdutos()
        {
            IList<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult BuscaPorNome(string nome)
        {
            ViewBag.Nome = nome;

            IList<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult NumeroDeProdutosPorCategoria()
        {
            IList<ProdutosPorCategoria> produtosPorCategoria = new List<ProdutosPorCategoria>();
            return View(produtosPorCategoria);
        }
    }
}
