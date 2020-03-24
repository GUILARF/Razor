using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class VendasController : Controller
    {
        ISession session;
        VendasDAO vendasDao;
        UsuariosDAO usuariosDao;
        ProdutosDAO produtosDao;
        

        public VendasController(VendasDAO vendasDao, UsuariosDAO usuariosDao, ProdutosDAO produtosDao)
        {
            this.vendasDao = vendasDao;
            this.usuariosDao = usuariosDao;
            this.produtosDao = produtosDao;
        }
        
        public ActionResult Index()
        {
            IList<Venda> vendas = vendasDao.Lista();
            return View(vendas);
        }
        public ActionResult ListaProdutos()
        {
            IList<Produto> produtos = produtosDao.Lista();
            ViewBag.ProdutosNoCarrinho = this.Carrinho.Produtos.Count;
            return View(produtos);
        }
        public ActionResult AdicionaProduto(int produtoId)
        {
            Produto produto = produtosDao.BuscaPorId(produtoId);
            this.Carrinho.Adiciona(produto);
            return RedirectToAction("ListaProdutos");
        }
        public ActionResult FechaPedido()
        {
            IList<Produto> produtos = this.Carrinho.Produtos;
            IList<PessoaFisica> usuarios = usuariosDao.Lista() ;
            ViewBag.Usuarios = usuarios;
            return View(produtos);
        }
        public ActionResult CompletaPedido(int usuarioId)
        {
            Usuario usuario = usuariosDao.BuscaPorId(usuarioId);
            Venda venda = this.Carrinho.CriaVenda(usuario);
            // grava venda
            vendasDao.GravaVenda(venda);
            this.Carrinho = new Carrinho();
            return RedirectToAction("Index");
        }
        public ActionResult LimpaCarrinho()
        {
            this.Carrinho = new Carrinho();
            return RedirectToAction("ListaProdutos");
        }

        // O Valor da propriedade Carrinho é armazenado na sessão
        private Carrinho Carrinho
        {
            get
            {
                Carrinho atual = Session["Carrinho"] as Carrinho;
                if (atual == null)
                {
                    atual = new Carrinho();
                    Session["Carrinho"] = atual;
                }
                return atual;
            }
            set
            {
                Session["Carrinho"] = value;
            }
        }

        
    }
}
