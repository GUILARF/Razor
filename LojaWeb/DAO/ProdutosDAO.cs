using LojaWeb.Entidades;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class ProdutosDAO
    {
        private ISession session;

        public ProdutosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Produto produto)
        {            
            session.Save(produto);            
            session.Close();
        }

        public void Remove(Produto produto)
        {
           
            session.Delete(produto);
           
        }

        public void Atualiza(Produto produto)
        {
            
            this.session.Merge(produto);
           
        }

        public Produto BuscaPorId(int id)
        {
            return session.Get<Produto>(id);
        }

        public IList<Produto> Busca()
        {
            //string hql = "from Produto p order by p.Nome where p.Preco > ?";
            //IQuery query = session.CreateQuery(hql);
            //query.SetParameter(0, 10.0);

            //ou 

            //string hql = "from Produto p order by p.Nome where p.Preco > :minimo";
            //IQuery query = session.CreateQuery(hql);
            //query.SetParameter("minimo", 10.0);


            // Para listar as categorias de produtos
            //string hql = "from Produto p where p.Categoria.Nome = :categoria and p.Preco > :minimo"

            //----------------------------------------------------------------------------------------------------
            //Listar usando função de agrupamento
            //string hql = "select p.Categoria as Categoria, count(p) as NumeroDeProdutos from Produto p group by p.Categoria";
            //IQuery q = session.CreateQuery(hql);
            //IList<Object[]> resultados = q.List<Object[]>();
            //IList<ProdutosPorCategoria> relatorio = new List<ProdutosPorCategoria>();
            //foreach (Object[] resultad in resultados)
            //{
            //    ProdutosPorCategoria p = new ProdutosPorCategoria();
            //    p.Categoria = (Categoria)resultad[0];
            //    p.NumeroDeProdutos = (long)resultad[1];
            //    relatorio.Add(p);
            //}

            //OU 

            //string hql = "select p.Categoria as Categoria, count(p) as NumeroDeProdutos from Produto p group by p.Categoria";
            //IQuery q = session.CreateQuery(hql);
            //q.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoria>());
            //IList<ProdutosPorCategoria> resultado = q.List<ProdutosPorCategoria>();
            //----------------------------------------------------------------------------------------------------


            string hql = "from Produto p order by p.Nome";
            IQuery query = session.CreateQuery(hql);
            IList<Produto> produtos = query.List<Produto>();
            return produtos;
        }


        public IList<Produto> Lista()
        {
            IQuery query = session.CreateQuery("from Produto p order by p.Nome");
            return query.List<Produto>();            
        }

        public IList<Produto> ProdutosComPrecoMaiorDoQue(double? preco)
        {
            IQuery query = session.CreateQuery("from Produtos p where p.Preco > :valor");
            query.SetParameter("valor", preco.GetValueOrDefault(0.0));
            return query.List<Produto>();
            
        }

        public IList<Produto> ProdutosDaCategoria(string nomeCategoria)
        {
            IQuery query = session.CreateQuery("from Produtos p where p.Categoria.Nome = :nome");
            query.SetParameter("nome", nomeCategoria);
            return query.List<Produto>();
        }

        public IList<Produto> ProdutosDaCategoriaComPrecoMaiorDoQue(double? preco, string nomeCategoria)
        {
            IQuery query = session.CreateQuery("from Produtos p where p.Categoria.Nome = :nome and p.Preco > :valor");
            query.SetParameter("nome", nomeCategoria);
            query.SetParameter("valor", preco.GetValueOrDefault(0.0));
            return query.List<Produto>();
        }

        public IList<Produto> ListaPaginada(int paginaAtual)
        {
            IQuery query = session.CreateQuery("from Produto p order by p.Nome order by p.Nome");
            //Limita número de resultados por página para 10
            int resultadosPorPagina = 10;
            query.SetMaxResults(resultadosPorPagina);
            query.SetFirstResult(resultadosPorPagina * (paginaAtual));
            return query.List<Produto>();
        }

        public IList<Produto> BuscaPorPrecoCategoriaENome(double? preco, string nomeCategoria, string nome)
        {
            ICriteria criteria = session.CreateCriteria<Produto>();
            if (preco != null)
            {
                criteria.Add(Restrictions.Gt("Preco", preco.Value));
            }
            if (!string.IsNullOrEmpty(nomeCategoria))
            {
                ICriteria criteriaCategoria = criteria.CreateCriteria("Categoria");
                criteriaCategoria.Add(Restrictions.Eq("Nome", nomeCategoria));
            }
            if (!string.IsNullOrEmpty(nome))
            {
                criteria.Add(Restrictions.Eq("Nome", nome));
            }
            return criteria.List<Produto>();
        }


        public IList<Produto> BuscaPorNomePrecoMinimoECategoria(string nome,
        double? precoMinimo, string nomeCategoria)
        {
            ICriteria criteria = session.CreateCriteria<Produto>();
            if (nome != null)
            {
                criteria.Add(Restrictions.Eq("Nome", nome));
            }
            if (precoMinimo > 0.0)
            {
                criteria.Add(Restrictions.Ge("Preco", precoMinimo));
            }
            if (nomeCategoria != null)
            {
                ICriteria criteriaCategoria = criteria.CreateCriteria("Categoria");
                criteriaCategoria.Add(Restrictions.Eq("Nome", nomeCategoria));
            }
            return criteria.List<Produto>();
        }



       
    }
}