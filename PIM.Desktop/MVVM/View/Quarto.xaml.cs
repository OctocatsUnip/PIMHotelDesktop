using Newtonsoft.Json;
using PIM.Desktop.MVVM.Model;
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

namespace PIM.Desktop.MVVM.View
{
    /// <summary>
    /// Interaction logic for Quarto.xaml
    /// </summary>
    public partial class Quarto : Window
    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();
        public Quarto()
        {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InfoQuarto telaQuarto = new InfoQuarto();
            telaQuarto.Show();
            this.Close();
        }
    }
}
