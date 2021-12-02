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
            InitializeComponent();
        }
        public class User
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string CPF{ get; set; }
            public int Numero { get; set; }
        }

        private void FiltrarDados(ListaHospedesModel filtro)
        {
            var response = client.GetStringAsync(Url + "dados_pessoas/" + filtro.CPF).Result;
            var pessoas = JsonConvert.DeserializeObject<ListaHospedesModel>(response);

            List<User> users = new List<User>();
            users.Add(new User() { Name = pessoas.Nome, CPF = pessoas.CPF, Numero = pessoas.Telefone_owner[0].numero });

            ToDo.ItemsSource = users;
        }

        private void btnPesquisar_Click_1(object sender, RoutedEventArgs e)
        {
            ListaHospedesModel filtro = new ListaHospedesModel()
            {
                CPF = Convert.ToString(txtFiltro.Text),
            };

            this.FiltrarDados(filtro);
        }
    }
}
