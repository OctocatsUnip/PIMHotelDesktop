using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIM.Desktop.MVVM.Model
{
    class PessoaModel
    {
        public int id { get; set; }
        public string nome_pessoa { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public DateTime dt_nascimento { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
    }
}
