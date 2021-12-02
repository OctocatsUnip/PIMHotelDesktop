using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIM.Desktop.MVVM.Model
{
    class ReservaModel
    {
        public int id { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_checkout { get; set; }
        public decimal valor_diarias { get; set; }
        public int quarto_id { get; set; }
        public int valores_beneficios { get; set; }
        public int pessoa_id { get; set; }
        public DateTime data_final { get; set; } 
    }
}
