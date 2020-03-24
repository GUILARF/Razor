using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Models
{
    public class ProdutoCategoria
    {
        public virtual int Id { get; set; }
        public virtual string NomeProduto { get; set; }
        public virtual string NomeCategoria { get; set; }
        public virtual double Preco { get; set; }
        


    }
}