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
using PIM.Desktop.MVVM.Model;


namespace PIM.Desktop.MVVM.View
{
    /// <summary>
    /// Lógica interna para Funcionario.xaml
    /// </summary>
    public partial class Funcionario : Window
    {
        private int id_pessoa;

        private string Url = "http://localhost:5000/funcionario/";
        private string formatted;
        HttpClient client = new HttpClient();
        public Funcionario(int id)
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
             new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            id_pessoa = id;

            InitializeComponent();
        }

        private void SaveFuncionario(FuncionariosModel funcionario)
        {
            client.PostAsJsonAsync(Url + id_pessoa, funcionario);
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            FuncionariosModel funcionario = new FuncionariosModel()
            {
                salario = Convert.ToDecimal(salario.Text),
            };

            this.SaveFuncionario(funcionario);
            this.Close();
        }
    }
}
