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

namespace PIM.Desktop
{
    /// <summary>
    /// Lógica interna para ListaHospedes.xaml
    /// </summary>
    public partial class ListaHospedes : Window
    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();
        public ListaHospedes()
        {
            ListaHospedesModel dados = new ListaHospedesModel();
            InitializeComponent();
            ListaTodos();
        }

        public class User
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string CPF{ get; set; }
            public int Numero { get; set; }
        }

        private void ListaTodos()
        {
            var response = client.GetStringAsync(Url + "lista_dados_pessoas").Result;
            var pessoas = JsonConvert.DeserializeObject<List<ListaHospedesModel>>(response);

            List<User> users = new List<User>();

            foreach (var line in pessoas)
            {
                try
                {
                    var numero = line.Telefone_owner[0].numero;
                    users.Add(new User() { Id = line.ID, Nome = line.Nome, CPF = line.CPF, Numero = numero });
                }
                catch
                {
                    var numero = 0;
                    users.Add(new User() { Id = line.ID, Nome = line.Nome, CPF = line.CPF, Numero = numero });
                }
            };

            ToDo.ItemsSource = users;
        }

        private void FiltrarDados(ListaHospedesModel filtro)
        {
            if (filtro.CPF == "")
            {
                MessageBox.Show("O filtro não foi preenchido!!");
                return;
            }
            var response = client.GetStringAsync(Url + "dados_pessoas/" + filtro.CPF).Result;
            var pessoas = JsonConvert.DeserializeObject<List<ListaHospedesModel>>(response);

            List<User> users = new List<User>();

            foreach (var line in pessoas)
            {
                try 
                {
                    var numero = line.Telefone_owner[0].numero;
                    users.Add(new User() { Id = line.ID, Nome = line.Nome, CPF = line.CPF, Numero = numero });
                } 
                catch
                {
                    var numero = 0;
                    users.Add(new User() { Id = line.ID, Nome = line.Nome, CPF = line.CPF, Numero = numero });
                }
            };

            ToDo.ItemsSource = users;
        }

        private void MaisDetalhes(ListaHospedesModel filtro)
        {
            if (filtro.CPF == "")
            {
                MessageBox.Show("O filtro não foi preenchido!!");
                return;
            }

            var response = client.GetStringAsync(Url + "dados_pessoas_detalhes/" + filtro.CPF).Result;
            var pessoas = JsonConvert.DeserializeObject<ListaHospedesModel>(response);

            DescricaoHospede telaDescricaoHospede = new DescricaoHospede();
            telaDescricaoHospede.MostrarDados(pessoas);
            telaDescricaoHospede.Show();
            this.Close();
        }

        private void btnPesquisar_Click_1(object sender, RoutedEventArgs e)
        {
            ListaHospedesModel filtro = new ListaHospedesModel()
            {
                CPF = Convert.ToString(txtFiltro.Text),
            };

            this.FiltrarDados(filtro);
        }

        private void btnPesquisar_Detalhes_1(object sender, RoutedEventArgs e)
        {
            ListaHospedesModel filtro = new ListaHospedesModel()
            {
                CPF = Convert.ToString(txtFiltro.Text),
            };

            this.MaisDetalhes(filtro);
        }

    }
}
