using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


namespace PIM.Desktop
{
    /// <summary>
    /// Lógica interna para PaineldeReservas.xaml
    /// </summary>
    public partial class PaineldeReservas : Window

    {
        private string Url = "http://localhost:5000/";
        HttpClient client = new HttpClient();


        public PaineldeReservas()
        { client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
