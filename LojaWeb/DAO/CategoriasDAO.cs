using LojaWeb.Entidades;
using LojaWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class CategoriasDAO
    {
        private ISession session;

        public CategoriasDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Categoria categoria)
        {
            session.Save(categoria);
            session.Close();

        }

        public void Remove(Categoria categoria)
        {
            session.Delete(categoria);
        }

        public void Atualiza(Categoria categoria)
        {
            this.session.Merge(categoria);
        }

        public Categoria BuscaPorId(int id)
        {
            return session.Get<Categoria>(id);
        }

        public IList<Categoria> Lista()
        {
            return new List<Categoria>();
        }

        public IList<Categoria> BuscaPorNome(string nome)
        {
            return new List<Categoria>();
        }

        public IList<ProdutosPorCategoria> ListaNumeroDeProdutosPorCategoria()
        {
            return new List<ProdutosPorCategoria>();
        }
    }

}