using TestaConexao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate;
using TestaConexao.Models;
using TestaConexao.DAO;

namespace TestaConexao
{
    class Program
    {
        static void Main(string[] args)
        {
            //NHibernateHelper.GeraSchema();
            //Console.ReadLine();

            //Configuration cfg = NHibernateHelper.RecuperarConfiguracao();
            //ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            //ISession session = sessionFactory.OpenSession();
            Usuario novoUsuario = new Usuario();
            novoUsuario.Nome = "Guilherme";

            ISession session = NHibernateHelper.AbreSession();
            UsuariosDAO usuariosDAO = new UsuariosDAO(session);
            usuariosDAO.Adiciona(novoUsuario);

            ITransaction transacao = session.BeginTransaction();
            session.Save(novoUsuario);
            transacao.Commit(); 
            session.Close();



            //ITransaction Transacao = session.BeginTransaction();
            // Nesse ponto o Usuario tem a propriedade nome com o valor Guilherme.
            Usuario UsuarioDoBanco = session.Get<Usuario>(1);

            UsuarioDoBanco.Nome = "Guilherme R. Ferreira";
            Console.WriteLine("No commit, o NHibernate detecta que o Usuario foi modificado e " +
                                                            "executa um Update no banco de dados");
            transacao.Commit();



            //ITransaction Transacao = session.BeginTransaction();
            Usuario usuario = session.Get<Usuario>(1);
            session.Delete(usuario);
            transacao.Commit();

            Usuario usuarioantigo = session.Get<Usuario>(1);
            session.Close();

            Console.Read();

        }
    }
}
