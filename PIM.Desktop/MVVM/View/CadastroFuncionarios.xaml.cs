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
using PIM.Desktop.MVVM.View;


namespace PIM.Desktop
{
    /// <summary>
    /// Lógica interna para CadastroFuncionarios.xaml
    /// </summary>
    public partial class CadastroFuncionarios : Window
    {
        private string Url = "http://localhost:5000/pessoas";
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

        private int GetPessoas()
        {
            var response = client.GetStringAsync(Url).Result;

            var pessoas = JsonConvert.DeserializeObject<List<ReceberPessoa>>(response);

            var ultimoIndice = pessoas.Count;
            
            return pessoas[ultimoIndice - 1].id;


        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            Funcionario telaFuncionario = new Funcionario(this.GetPessoas());
            telaFuncionario.Show();
            this.Close();

        }


        private void btn_funcionario_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = nascimento.SelectedDate;

            if (selectedDate.HasValue)
            {
                formatted = selectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            CadastroFuncionariosModel funcionario = new CadastroFuncionariosModel()
            {

                nome = Convert.ToString(nome.Text),
                rg = Convert.ToString(rg.Text),
                cpf = Convert.ToString(cpf.Text),
                data_nascimento = Convert.ToDateTime(formatted),
                sexo = Convert.ToString(sexo.Text),

            };
            this.SaveCadastroFuncionario(funcionario);
        }

        private void SaveCadastroFuncionario(CadastroFuncionariosModel funcionario)
        {
            client.PostAsJsonAsync(Url, funcionario);
        }
    }
}
