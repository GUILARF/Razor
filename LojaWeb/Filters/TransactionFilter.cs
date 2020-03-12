using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Filters
{
    public class TransactionFilter : ActionFilterAttribute
    {
        private ISession session;
        public TransactionFilter(ISession session)
        {
            this.session = session;
        }
        public override void OnActionExecuting(ActionExecutingContext contexto)
        {
            session.BeginTransaction();
        }
        public override void OnActionExecuted(ActionExecutedContext contexto)
        {
            if (contexto.Exception == null)
            {
                session.Transaction.Commit();
            }
            else
            {
                session.Transaction.Rollback();
            }
            session.Close();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                session.Transaction.Rollback();
                session.Close();
            }
        }
        
    }
}