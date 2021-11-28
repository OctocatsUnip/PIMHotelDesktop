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
            this.GetPessoa();
        }

        private void GetPessoa()
        {

            var response = client.GetStringAsync(Url + "pessoa").Result;
            var pessoa = JsonConvert.DeserializeObject<List<PessoaModel>>(response);

            listBoxHospedes.ItemsSource = pessoa;
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
            var pessoa = this.GetPessoaCpf(txtCPF.Text);
            List<PessoaModel> listaPessoas = new List<PessoaModel>();
            listaPessoas.Add(new PessoaModel()
            {
                nome_pessoa = pessoa.nome_pessoa,
                cpf = pessoa.cpf,
            });
            listBoxHospedes.Items.Add(listaPessoas);

        }
    }
}



