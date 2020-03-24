using LojaWeb.DAO;
using LojaWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaWeb.Infra;
using NHibernate;

namespace LojaWeb.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/
        ISession session = NHibernateHelper.AbreSession();
        UsuariosDAO usuariosDao;

        public UsuariosController(UsuariosDAO usuariosDao)
        {
            this.usuariosDao = usuariosDao;
        }

        public ActionResult Index()
        {
            IList<PessoaFisica> usuarios = usuariosDao.Lista();
            return View(usuarios);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(PessoaFisica usuario)
        {
            usuariosDao.Adiciona(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            session.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Usuario usuario = usuariosDao.BuscaPorId(id);
            return View(usuario);
        }

        public ActionResult Atualiza(PessoaFisica usuario)
        {
            usuariosDao.Atualiza(usuario);
            return RedirectToAction("Index");
        }

    }
}
