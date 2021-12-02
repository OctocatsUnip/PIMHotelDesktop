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

namespace PIM.Desktop.MVVM.View
{
    /// <summary>
    /// Lógica interna para Cargos.xaml
    /// </summary>
    public partial class Cargos : Window
    {
        private string Url = "http://localhost:5000/cargos";
        HttpClient client = new HttpClient();
        public Cargos()
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            CargosModel cargo = new CargosModel()
            {
                nome_cargo = Convert.ToString(nome.Text)
            };

            this.SaveCargo(cargo);

        }

        private void SaveCargo(CargosModel cargo)
        {
            client.PostAsJsonAsync(Url, cargo);
        }
    }
}
