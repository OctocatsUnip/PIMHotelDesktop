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
    /// Lógica interna para Beneficios.xaml
    /// </summary>
    public partial class Beneficios : Window
    {
        private string Url = "http://localhost:5000/beneficio";
        HttpClient client = new HttpClient();

        public Beneficios()
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

            BeneficiosModel beneficio = new BeneficiosModel()
            {
                nome_beneficio = Convert.ToString(descricao.Text),
                valor_beneficio = Convert.ToDecimal(preco.Text),
              
                
            };

            this.SaveBeneficio(beneficio);
        }

        private void SaveBeneficio(BeneficiosModel beneficio)
        {
            client.PostAsJsonAsync(Url, beneficio);
        }


    }
}
