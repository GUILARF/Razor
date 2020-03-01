using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TestaConexao.Infra
{
    public class NHibernateHelper
    {
        private static ISessionFactory fabrica = CriaSessionFactory();
        private static ISessionFactory CriaSessionFactory()
        {
            Configuration cfg = RecuperarConfiguracao();
            return cfg.BuildSessionFactory();
        }

        public static Configuration RecuperarConfiguracao()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }
        public static void GeraSchema()
        {
            Configuration cfg = RecuperarConfiguracao();
            new SchemaExport(cfg).Create(true, true);
        }


        public static ISession AbreSession()
        {
            return fabrica.OpenSession();
        }

    }
}