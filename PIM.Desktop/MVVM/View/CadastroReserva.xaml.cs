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
using System.Collections;

namespace PIM.Desktop.MVVM.View
{
    /// <summary>
    /// Lógica interna para CadastroReserva.xaml
    /// </summary>
    public partial class CadastroReserva : Window
    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();
        ArrayList ids = new ArrayList();
        

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
            var pessoas = this.GetPessoaCpf(txtCPF.Text);
            txtNome.Text = pessoas.nome;
            txtId.Text = pessoas.id.ToString();
        }
        private PessoaModel GetPessoaCpf(string cpf)
        {
            var response = client.GetStringAsync(Url + "pessoas/" + cpf).Result;
            var pessoas = JsonConvert.DeserializeObject<PessoaModel>(response);

            return pessoas;
        }


        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            listBoxHospedes.Items.Add(txtId.Text+ " "+ txtNome.Text + " - " + txtCPF.Text);
            ids.Add(txtId);
        }

        


        private void GetQuartoBanheiro(int Quantia_banheiros, int Quantia_Camas)
        {
            var response = client.GetStringAsync(Url + "quartos/" + Quantia_banheiros + "," + Quantia_Camas).Result;
            var banheiro = JsonConvert.DeserializeObject<List<QuartosModel>>(response);
            listBoxQuartos.ItemsSource = banheiro;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.GetQuartoBanheiro(Int16.Parse(txtBanheiro.Text), Int16.Parse(txtCamas.Text));
        }
        private void btnSelecionarQuarto_Click(object sender, RoutedEventArgs e)
        {
        }

        private void GetBeneficios()
        {
            var response = client.GetStringAsync(Url + "beneficio").Result;
            var beneficios = JsonConvert.DeserializeObject<List<BeneficiosModel>>(response);

            listBoxBeneficios.ItemsSource = beneficios;

        }
        private void btnCarregarBeneficios_Click(object sender, RoutedEventArgs e)
        {
            this.GetBeneficios();
        }

        private void btnInserirBeneficio_Click(object sender, RoutedEventArgs e)
        {
            lbBeneficiosQuarto.Items.Add(txtBeneficioSelecionado.Text);
            ListBoxItem item = ((sender as ListBox).SelectedItem as ListBoxItem);
            

        }

        
    }
}



