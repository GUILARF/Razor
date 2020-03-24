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
        private ISession session;
        private ProdutosDAO produtosdao;

        public ProdutosController(ProdutosDAO dao)
        {
            this.produtosdao = dao;
        }

        public ActionResult Index()
        {
            //ISession session = NHibernateHelper.AbreSession();
            //ProdutosDAO dao = new ProdutosDAO(session);
            IList<Produto> produtos = produtosdao.Lista();
            return View(produtos);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Produto produto)
        {
            if (produto.Categoria.Id == 0)
            {
                produto.Categoria = null;
            }

            session = NHibernateHelper.AbreSession();
            produtosdao = new ProdutosDAO(session);
            produtosdao.Adiciona(produto);
            return RedirectToAction("Visualiza", new { id = produto.Id });
        }

        public ActionResult Remove(int id)
        {
            produtosdao.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            //ISession session = NHibernateHelper.AbreSession();
            //ProdutosDAO dao = new ProdutosDAO(session);
            //Produto p = dao.BuscaPorId(id);
            Produto p = produtosdao.BuscaPorId(id);            
            //session.Close();
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
            IList<Produto> produtos = produtosdao.ProdutosComPrecoMaiorDoQue(preco);
            return View(produtos);

        }

        public ActionResult ProdutosDaCategoria(string nomeCategoria)
        {
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = produtosdao.ProdutosDaCategoria(nomeCategoria);
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoriaComPrecoMinimo(double? preco, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = produtosdao.ProdutosDaCategoriaComPrecoMaiorDoQue(preco, nomeCategoria);
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
            IList<Produto> produtos = produtosdao.ListaPaginada(paginaAtual);
            return View(produtos);
        }
    }
}
