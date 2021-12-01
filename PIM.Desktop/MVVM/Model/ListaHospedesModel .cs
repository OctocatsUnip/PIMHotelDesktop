using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIM.Desktop.MVVM.Model
{
    class ListaHospedesModel
    {
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public int Tipo_Telefone { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CEP { get; set; }
    }
}
