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
using PIM.Desktop.MVVM.Model;
using System.Net.Http;

namespace PIM.Desktop
{
    /// <summary>
    /// Lógica interna para Servicos.xaml
    /// </summary>
    public partial class Servicos : Window
    {
        private string Url = "http://localhost:5000/lista_pedidos_servicos";
        HttpClient client = new HttpClient();

        public Servicos()
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ServicosModel servico = new ServicosModel()
            {
                Nome_servico = Convert.ToString(service_name.Text),
            };
            this.SaveServico(servico);
        }

        private void SaveServico(ServicosModel servico)
        {
            client.PostAsJsonAsync(Url, servico);
        }
    }
}
