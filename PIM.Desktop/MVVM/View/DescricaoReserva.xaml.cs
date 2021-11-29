using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PIM.Desktop.MVVM.View
{
    /// <summary>
    /// Lógica interna para DescricaoReserva.xaml
    /// </summary>
    public partial class DescricaoReserva : Window
    {
        public DescricaoReserva()
        {
            InitializeComponent();
            List<Hospede> listaHospedes = new List<Hospede>();
            listaHospedes.Add(new Hospede()
            {
                Nome = "Homer Simpson",
                Telefone = "3322-1100",
                Status = "Pagante"
            });

            listaHospedes.Add(new Hospede()
            {
                Nome = "Bruce Waine",
                Telefone = "9988-7766",
                Status = "Hospede"
            });

            listaHospedes.Add(new Hospede()
            {
                Nome = "Tony Stark",
                Telefone = "5544-3322",
                Status = "Hospede"
            });
            this.listBoxHospedes.ItemsSource = listaHospedes;

            List<Beneficio> listaBeneficio = new List<Beneficio>();
            listaBeneficio.Add(new Beneficio()
            {
                NomeBeneficio = "Café da Manhã",
                ValorBeneficio = "R$ 100,00",
            });

            listaBeneficio.Add(new Beneficio()
            {
                NomeBeneficio = "Almoço",
                ValorBeneficio = "R$ 50,00",
            });

            listaBeneficio.Add(new Beneficio()
            {
                NomeBeneficio = "Jantar",
                ValorBeneficio = "R$ 40,00",
            });
            this.listBoxBeneficios.ItemsSource = listaBeneficio;
        }
    }

    public class Hospede
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Status { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
    }
    public class Beneficio
    {
        public string NomeBeneficio { get; set; }
        public string ValorBeneficio { get; set; }

    }
    public class Quarto
    {
        public string NomeQuarto { get; set; }
        public string Camas { get; set; }
        public string Banheiros { get; set; }
    }
}
