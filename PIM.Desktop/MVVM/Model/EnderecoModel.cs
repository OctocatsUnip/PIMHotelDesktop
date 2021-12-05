using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIM.Desktop.MVVM.Model
{
    public class EnderecoModel
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CEP{ get; set; }
    }
}
