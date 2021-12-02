using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PIM.Desktop.MVVM.Model
{
    public class BeneficiosModel
    {
        public int id { get; set; }
        public string nome_beneficio { get; set; }
        public decimal valor_beneficio {get; set;}
        public override string ToString() => this.nome_beneficio + " R$ " + this.valor_beneficio;
    }
}
