﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaRazor.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual String Nome { get; set; }

        [Required]
        public virtual Sexo Sexo { get; set; }

        [Required, EmailAddress]
        public virtual String Email { get; set; }

        [Required, MinLength(3)]
        public virtual String Senha { get; set; }

        [Required]
        public virtual DateTime DataDeNascimento { get; set; }

        [Required]
        public virtual String Endereco { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual String Complemento { get; set; }

        [Required, RegularExpression("\\d{5}-\\d{3}")]
        public virtual String CEP { get; set; }

        public virtual string Observacoes { get; set; }

        public virtual bool RecebePromocoes { get; set; }
    }
}