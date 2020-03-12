using LojaWeb.Entidades;
using LojaWeb.Models;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            IQuery query = session.CreateQuery("from Categoria c join fetch c.Produtos order by ");
            //Paginação é feita com os dois itens abaixo
            query.SetFirstResult(10);
            query.SetMaxResults(10);
            return query.List<Categoria>();
        }

        public IList<Categoria> BuscaPorNome(string nome)
        {
            //return session.Get;
            IQuery query = session.CreateQuery("from Categoria c where c.Nome like '%:nomecategoria%'");
            query.SetParameter("nomecategoria", nome);
            return query.List<Categoria>();
        }

        public IList<ProdutosPorCategoria> ListaNumeroDeProdutosPorCategoria()
        {
            IQuery query = session.CreateQuery("select c.Nome, count(*) from Categoria c group by c.Nome");
            query.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoria>());
            return query.List<ProdutosPorCategoria>();
        }



    }

}