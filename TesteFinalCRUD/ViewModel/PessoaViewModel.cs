using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteFinalCRUD.ViewModel
{
    public class PessoaViewModel
    {
        public int idPessoa { get; set; }

        [Display( Name = "Nome:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo NOME é obrigatório.")]
        public string nmPessoa { get; set; }

        [Display(Name = "CPF:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo CPF é obrigatório.")]
        public string pessoaCPF { get; set; }

        public string descricaoSexo { get; set; }

        [Display(Name = "Data de nascimento:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo DATA DE NASCIMENTO é obrigatório.")]
        public string dtnascimento { get; set; }

        [Display(Name = "Sexo:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo SEXO é obrigatório.")]
        public int idSexo { get; set; }
    }
}