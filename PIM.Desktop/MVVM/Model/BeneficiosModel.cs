using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIM.Desktop.MVVM.Model
{
    class BeneficiosModel
    {
        public int id { get; set; }
        public string beneficio { get; set; }
        public decimal valor_beneficios {get; set;}
        public override string ToString() => this.beneficio + " " + this.valor_beneficios;
    }
}
