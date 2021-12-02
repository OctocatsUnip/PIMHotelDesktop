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
using System.Net.Http;
using Newtonsoft.Json;
using PIM.Desktop.MVVM.Model;

namespace PIM.Desktop.MVVM.View
{
    /// <summary>
    /// Lógica interna para DescricaoReserva.xaml
    /// </summary>
    public partial class DescricaoReserva : Window
    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();
        public DescricaoReserva()
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent(); 
        }

        private void GetReserva()
        {
            var response = client.GetStringAsync(Url + "reservas").Result;
            var reserva = JsonConvert.DeserializeObject<List<ReservaModel>>(response);
            listBoxQuartos.ItemsSource = reserva;
            listBoxHospedes.ItemsSource = reserva;

        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            PaineldeReservas telaReservas = new PaineldeReservas();
            telaReservas.Show();
            this.Close();
        }
    }
}