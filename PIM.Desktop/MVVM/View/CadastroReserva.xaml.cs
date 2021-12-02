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
using System.Globalization;

namespace PIM.Desktop.MVVM.View
{
    /// <summary>
    /// Lógica interna para CadastroReserva.xaml
    /// </summary>
    public partial class CadastroReserva : Window
    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();
        private string formatted;
        private string formattedSaida;


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
            listBoxHospedes.Items.Add(txtId.Text + " " + txtNome.Text + " - " + txtCPF.Text);
            ReservaModel pessoa = new ReservaModel();
            //pessoa.hospedes.Add(txtId.Text);
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
            var valorQuarto = decimal.Parse(txtValorQuarto.Text, CultureInfo.InvariantCulture);

            DateTime? selectedDate = dtSaida.SelectedDate;

            if (selectedDate.HasValue)
            {
                formattedSaida = selectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
        }



        private void btnCancelar_Click_1(object sender, RoutedEventArgs e)
        {
            PaineldeReservas telaCadastroReservas = new PaineldeReservas();
            telaCadastroReservas.Show();
            this.Close();
        }

        private void btnSalvar_Click_2(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = dtEntrada.SelectedDate;

            if (selectedDate.HasValue)
            {
                formatted = selectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }


            ReservaModel reservas = new ReservaModel()
            {
                data_inicio = Convert.ToDateTime(formatted),
                data_checkout = Convert.ToDateTime(formattedSaida),
                data_final = Convert.ToDateTime(formattedSaida),
                valor_diarias = Convert.ToDecimal(txtValorQuarto.Text),
                valores_beneficios = (20),
                quarto_id = Convert.ToInt16(txtQuartoId.Text),
                pessoa_id = Convert.ToInt16(4),
            };

            this.SaveReservas(reservas);

            PaineldeReservas telaCadastroReservas = new PaineldeReservas();
            telaCadastroReservas.Show();
            this.Close();
        }
        private void SaveReservas(ReservaModel reservas)
        {
            client.PostAsJsonAsync(Url + "reservas", reservas);
        }
    }
}









