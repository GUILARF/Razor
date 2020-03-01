using log4net;
using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        //
        // GET: /Produtos/

        public ActionResult Index()
        {

            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Produto produto)
        {
            ISession session = NHibernateHelper.AbreSession();
            ProdutosDAO dao = new ProdutosDAO(session);
            dao.Adiciona(produto);
            return RedirectToAction("Visualiza", new { id = produto.Id });
        }

        public ActionResult Remove(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            ISession session = NHibernateHelper.AbreSession();
            ProdutosDAO dao = new ProdutosDAO(session);
            Produto p = dao.BuscaPorId(id);
            session.Close();
            return View(p);
        }

        public ActionResult Atualiza(Produto produto)
        {
            ISession session = NHibernateHelper.AbreSession();
            ProdutosDAO dao = new ProdutosDAO(session);
            dao.Atualiza(produto);
            session.Close();
            return RedirectToAction("Index");
        }

        public ActionResult ProdutosComPrecoMinimo(double? preco)
        {
            ViewBag.Preco = preco;
            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoria(string nomeCategoria)
        {
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoriaComPrecoMinimo(double? preco, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }

        public ActionResult BuscaDinamica(double? preco, string nome, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.Nome = nome;
            ViewBag.NomeCategoria = nomeCategoria;

            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }
        public ActionResult ListaPaginada(int? pagina)
        {
            int paginaAtual = pagina.GetValueOrDefault(1);
            ViewBag.Pagina = paginaAtual;
            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }
    }
}
