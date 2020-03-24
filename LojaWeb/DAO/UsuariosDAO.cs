using LojaWeb.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class UsuariosDAO
    {
        private ISession session;

        public UsuariosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(PessoaFisica usuario)
        {
            session.Save(usuario);
        }

        public void Remove(PessoaFisica usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(usuario);
            transacao.Commit();
        }

        public void Atualiza(PessoaFisica usuario)
        {
            session.Merge(usuario);
        }

        public Usuario BuscaPorId(int id)
        {
            return session.Get<PessoaFisica>(id);
        }

        public IList<PessoaFisica> Lista()
        {
            IQuery query = session.CreateQuery("from Usuario");
            query.SetCacheable(true);
            return query.List<PessoaFisica>();
        }
    }
}