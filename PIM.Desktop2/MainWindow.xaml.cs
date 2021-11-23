using PIM.Desktop.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PIM.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Url = "http://localhost:5000/quarto";
        HttpClient client = new HttpClient();

        public MainWindow()
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
        }

        private async void submit_Click(object sender, RoutedEventArgs e)
        {
            //string Nome_Quarto = room_name.Text;
            //

            //string Nome_do_quarto = room_name.Text;

            var quarto = new QuartosModel()
            {
                Nome_quarto = Convert.ToString(room_name.Text),
                Valor_quarto = Convert.ToInt32(room_value.Text),
                Quantia_camas = Convert.ToInt32(beds.Text),
                Quantia_banheiros = Convert.ToInt32(bethrooms.Text),
                Img_quarto = Convert.ToInt32(path_img.Text)
            };

            this.SaveQuarto(quarto);
        }

        private async void SaveQuarto(QuartosModel quartos)
        {
            await client.PostAsJsonAsync(Url, quartos);
        }
    }
}
