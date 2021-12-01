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
        public ListaHospedes()
        {
            InitializeComponent();

            List<User> users = new List<User>();
            users.Add(new User() { Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() {Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            ToDo.ItemsSource = users;
        }
        public class User
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public DateTime Birthday { get; set; }
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            var response = client.GetStringAsync(Url + "pessoas/" + cpf).Result;
            var pessoas = JsonConvert.DeserializeObject<PessoaModel>(response);

            //this.SaveUsuario(usuarioFuncionario);
        }
    }
}
