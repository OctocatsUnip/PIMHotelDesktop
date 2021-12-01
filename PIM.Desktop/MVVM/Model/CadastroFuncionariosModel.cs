using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PIM.Desktop.MVVM.Model
{
    public class CadastroFuncionariosModel
    {
        
        public string nome { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string sexo { get; set; }
        public DateTime data_nascimento { get; set; }


    }
}
