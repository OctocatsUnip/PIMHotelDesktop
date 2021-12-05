using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PIM.Desktop.MVVM.Model;
using Newtonsoft.Json;

namespace PIM.Desktop
{
    /// <summary>
    /// Lógica interna para PaineldeReservas.xaml
    /// </summary>
    public partial class PaineldeReservas : Window

    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();

        public object JsonConvert { get; private set; }

        public PaineldeReservas()
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            ReservaModel dados = new ReservaModel();
            InitializeComponent();
            ListaReservas(dados);
        }

        public class User
        {
            public int Id { get; set; }
            public DateTime DataIncio { get; set; }
            public DateTime DataFim { get; set; }
            public DateTime Checkout { get; set; }
            public decimal ValorDiaria { get; set; }
            public int Quarto { get; set; }
        }

        private void ListaReservas(ReservaModel dados)
        {
            var response = client.GetStringAsync(Url + "reservas").Result;
            var reservas = JsonConvert.DeserializeObject<List<ReservaModel>>(response);

            List<User> users = new List<User>();

            foreach (var line in reservas)
            {

                users.Add(new User() { Id = line.id, DataIncio = line.data_inicio, DataFim = line.data_final, Checkout = line.data_checkout, ValorDiaria = line.valor_diarias, Quarto = line.quarto_id });

            };

            ToDo.ItemsSource = users;
        }

    }

}
