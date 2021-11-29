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
using Newtonsoft.Json;

namespace PIM.Desktop.MVVM.View
{
    /// <summary>
    /// Lógica interna para CadastroReserva.xaml
    /// </summary>
    public partial class CadastroReserva : Window
    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();
        
        public CadastroReserva()
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();


        }

        private void btnCriar_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void btnBuscarPessoa_Click(object sender, RoutedEventArgs e)
        {
            var pessoa = this.GetPessoaCpf(txtCPF.Text);
            txtNome.Text = pessoa.nome_pessoa;
        }
        private PessoaModel GetPessoaCpf(string cpf)
        {
            var response = client.GetStringAsync(Url + "pessoa/" + cpf).Result;
            var pessoa = JsonConvert.DeserializeObject<PessoaModel>(response);

            return pessoa;
        }


        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            listBoxHospedes.Items.Add(txtNome.Text + " - " + txtCPF.Text);
        }




        private void GetQuartoBanheiro(int Quantia_banheiros, int Quantia_Camas)
        {
            var response = client.GetStringAsync(Url + "quarto/" + Quantia_banheiros + "," + Quantia_Camas).Result;
            var banheiro = JsonConvert.DeserializeObject<List<QuartosModel>>(response);
            listBoxQuartos.ItemsSource = banheiro;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           this.GetQuartoBanheiro(Int16.Parse(txtBanheiro.Text), Int16.Parse(txtCamas.Text));


        }


        private void GetBeneficios()
        {

            var response = client.GetStringAsync(Url + "beneficios").Result;
            var beneficios = JsonConvert.DeserializeObject<List<BeneficiosModel>>(response);

            listBoxBeneficios.ItemsSource = beneficios;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.GetBeneficios();
        }
    }
}



