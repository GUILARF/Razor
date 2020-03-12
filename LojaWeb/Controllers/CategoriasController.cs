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
        ISession session = NHibernateHelper.AbreSession();
        private CategoriasDAO dao;

        public CategoriasController(CategoriasDAO dao)
        {
            this.dao = dao;
        }

        public ActionResult Index()
        {
            IList<Categoria> categorias = dao.Lista();
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
            return RedirectToAction("Visualiza", categoria);
        }

        public ActionResult Remove(int id)
        {

            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(Categoria categoria)
        {
            ISession session = NHibernateHelper.AbreSession();
            CategoriasDAO dao = new CategoriasDAO(session);
            Categoria categorias = dao.BuscaPorId(categoria.Id);
            return View(categorias);
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
            IList<Categoria> categorias = dao.Lista();
            return View(categorias);
        }

        public ActionResult BuscaPorNome(string nome)
        {
            IList<Categoria> categorias = dao.BuscaPorNome(nome);
            return View(categorias);
        }

        public ActionResult NumeroDeProdutosPorCategoria()
        {
            IList<ProdutosPorCategoria> produtosPorCategoria = dao.ListaNumeroDeProdutosPorCategoria();
            return View(produtosPorCategoria);
        }


    }
}
