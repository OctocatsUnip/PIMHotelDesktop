using Newtonsoft.Json;
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

namespace PIM.Desktop.MVVM.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();
        public Home()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
            GetQuartos();
        }


        private void GetQuartos()
        {
            var response = client.GetStringAsync(Url + "quartos_status").Result;
            var quartos = JsonConvert.DeserializeObject<List<QuartosModel>>(response);

            listBoxQuartos.ItemsSource = quartos;

        }

        private void GetPessoas()
        {
            var response = client.GetStringAsync(Url + "pessoas").Result;
            var pessoas = JsonConvert.DeserializeObject<List<PessoaModel>>(response);

            listBoxPessoa.ItemsSource = pessoas;

        }
    }
}
