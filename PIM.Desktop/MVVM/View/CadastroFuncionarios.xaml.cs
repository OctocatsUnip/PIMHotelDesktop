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

namespace PIM.Desktop
{
    /// <summary>
    /// Lógica interna para CadastroFuncionarios.xaml
    /// </summary>
    public partial class CadastroFuncionarios : Window
    {
        private string Url = "http://localhost:5000/pessoa";
        private string formatted;
        HttpClient client = new HttpClient();

        public CadastroFuncionarios()
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
             new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();

            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = nascimento.SelectedDate;

            if (selectedDate.HasValue)
            {
                formatted = selectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            CadastroFuncionariosModel funcionario = new CadastroFuncionariosModel()
            {

                nome_pessoa = Convert.ToString(nome.Text),
                rg = Convert.ToString(rg.Text),
                cpf = Convert.ToString(cpf.Text),
                dt_nascimento = Convert.ToDateTime(formatted),
                sexo = Convert.ToString(sexo.Text),
                email = Convert.ToString(email.Text),

            };
            this.SaveCadastroFuncionario(funcionario);
        }

        private void SaveCadastroFuncionario(CadastroFuncionariosModel funcionario)
        {
            client.PostAsJsonAsync(Url, funcionario);
        }
    }
}
