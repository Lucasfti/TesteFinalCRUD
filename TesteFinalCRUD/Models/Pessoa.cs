//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TesteFinalCRUD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pessoa
    {
        public int idPessoa { get; set; }
        public string nmPessoa { get; set; }
        public string pessoaCPF { get; set; }
        public System.DateTime dtnascimento { get; set; }
        public int idSexo { get; set; }
    
        public virtual Sexo Sexo { get; set; }
    }
}
