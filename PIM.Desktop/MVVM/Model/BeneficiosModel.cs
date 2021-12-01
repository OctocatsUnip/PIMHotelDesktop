using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIM.Desktop.MVVM.Model
{
    class BeneficiosModel
    {
        public int id { get; set; }
        public string nome_beneficio { get; set; }
        public decimal valor_beneficio {get; set;}
        public override string ToString() => this.nome_beneficio + " R$ " + this.valor_beneficio;
    }
}
