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
    /// Lógica interna para UsuarioFuncionario.xaml
    /// </summary>
    public partial class UsuarioFuncionario : Window
    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();

        public UsuarioFuncionario()
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UsuarioFuncionarioModel usuarioFuncionario = new UsuarioFuncionarioModel()
            {
                CPF = Convert.ToString(cpf.Text),
                Usuario = Convert.ToString(user_name.Text),
                Senha = Convert.ToString(password.Password)
            };

            this.SaveUsuario(usuarioFuncionario);
        }
        private void SaveUsuario(UsuarioFuncionarioModel usuarioFuncionario)
        {
            string cpf = usuarioFuncionario.CPF;
            string usuario = usuarioFuncionario.Usuario;
            string senha = usuarioFuncionario.Senha;

            if (cpf == "" || usuario == "" || senha == "")
            {
                MessageBox.Show("Há campos que precisam ser preenchidos!");
                return;
            }

            var response = client.GetStringAsync(Url + "pessoa/" + cpf).Result;
            var pessoa = JsonConvert.DeserializeObject<UsuarioFuncionarioModel>(response);

            if (pessoa == null)
            {
                MessageBox.Show("Não há nenhuma pessoa vinculada a esse CPF");
                return;
            }
            MessageBox.Show("Foi");
        }
    }
}
