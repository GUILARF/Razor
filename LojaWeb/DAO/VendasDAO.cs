using LojaWeb.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.DAO
{
    public class VendasDAO
    {
        ISession session;
        public VendasDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Venda venda)
        {

        }

        public IList<Venda> Lista()
        {
            IQuery query = session.CreateQuery("from Venda v");
            return query.List<Venda>();
        }

        public void GravaVenda(Venda venda)
        {
            session.Save(venda);
        }
    }
}