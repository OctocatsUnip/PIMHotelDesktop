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
    /// Lógica interna para CadastroReserva.xaml
    /// </summary>
    public partial class CadastroReserva : Window
    {
        public CadastroReserva()
        {
            InitializeComponent();
            List<Hospede> listaHospedes = new List<Hospede>();
            listaHospedes.Add(new Hospede()
            {
                Nome = "Homer Simpson",
                Telefone = "3322-1100",
                CPF = "112.432.123-9"
            });

            listaHospedes.Add(new Hospede()
            {
                Nome = "Bruce Waine",
                Telefone = "9988-7766",
                CPF = "112.432.123-9"
            });

            listaHospedes.Add(new Hospede()
            {
                Nome = "Tony Stark",
                Telefone = "5544-3322",
                CPF = "112.432.123-9"
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


            List<Quarto> listaQuarto = new List<Quarto>();
            listaQuarto.Add(new Quarto()
            {
                NomeQuarto = "Familia",
                Camas = "3",
                Banheiros = "1"
            });

            listaQuarto.Add(new Quarto()
            {
                NomeQuarto = "Simples",
                Camas = "1",
                Banheiros = "1"
            });

            listaQuarto.Add(new Quarto()
            {
                NomeQuarto = "Luxo",
                Camas = "4",
                Banheiros = "2"
            });
            this.listBoxQuartos.ItemsSource = listaQuarto;
        }
    }
}
