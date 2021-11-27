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
    /// Lógica interna para CadastroQuarto.xaml
    /// </summary>
    public partial class CadastroQuarto : Window
    {
        private string Url = "http://localhost:5000/quarto";
        HttpClient client = new HttpClient();

        public CadastroQuarto()
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
            QuartosModel quarto = new QuartosModel()
            {
                Nome_quarto = Convert.ToString(room_name.Text),
                Valor_quarto = Convert.ToInt32(room_value.Text),
                Quantia_camas = Convert.ToInt32(beds.Text),
                Quantia_banheiros = Convert.ToInt32(bethrooms.Text),
                Img_quarto = Convert.ToInt32(path_img.Text),
                Descricao_quarto = Convert.ToString(room_description.Text)
            };

            this.SaveQuarto(quarto);
        }

        private void SaveQuarto(QuartosModel quartos)
        {
            client.PostAsJsonAsync(Url, quartos);
        }

        private void room_description_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
