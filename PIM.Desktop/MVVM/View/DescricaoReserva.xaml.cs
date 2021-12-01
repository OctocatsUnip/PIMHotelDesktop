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

        private void GetBeneficios()
        {
            var response = client.GetStringAsync(Url + "beneficio").Result;
            var beneficio = JsonConvert.DeserializeObject<List<BeneficiosModel>>(response);

            listBoxBeneficios.ItemsSource = beneficio;

        }
        private void btnCarregarBeneficios_Click(object sender, RoutedEventArgs e)
        {
            this.GetBeneficios();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            var pessoas = this.GetPessoaCpf(txtCPF.Text);
            txtNome.Text = pessoas.nome;
        }
        private PessoaModel GetPessoaCpf(string cpf)
        {
            var response = client.GetStringAsync(Url + "pessoas/" + cpf).Result;
            var pessoas = JsonConvert.DeserializeObject<PessoaModel>(response);

            return pessoas;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                lbBeneficiosQuarto.Items.Add(txtBeneficioSelecionado.Text);
            }
        }

        private void GetStatus()
        {
            var response = client.GetStringAsync(Url + "status").Result;
            var status = JsonConvert.DeserializeObject<List<StatusModel>>(response);
            //cbStatus.ItemsSource = status;

        }
    }
}