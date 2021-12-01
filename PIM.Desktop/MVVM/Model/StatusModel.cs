using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIM.Desktop.MVVM.Model
{
    class StatusModel
    {
        public int id { get; set; }
        public string nome_status { get; set; }      
        
        public QuartosModel quartos { get; set; }
    }
}
