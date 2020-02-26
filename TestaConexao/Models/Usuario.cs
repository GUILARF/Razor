using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestaConexao.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }

        
        public virtual String Nome { get; set; }

        
        public virtual Sexo Sexo { get; set; }

        
        public virtual String Email { get; set; }

        
        public virtual String Senha { get; set; }

        
        public virtual DateTime DataDeNascimento { get; set; }

        
        public virtual String Endereco { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual String Complemento { get; set; }

        
        public virtual String CEP { get; set; }

        public virtual string Observacoes { get; set; }

        public virtual bool RecebePromocoes { get; set; }
    }
}