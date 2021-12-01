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
    /// Lógica interna para DescricaoHospede.xaml
    /// </summary>
    public partial class DescricaoHospede : Window
    {
        public DescricaoHospede()
        {
            InitializeComponent();
        }

        private void MostrarDados()
        {
            ListaHospedesModel usuarioFuncionario = new ListaHospedesModel()
            {
                Nome = Convert.ToString(txtNome.Text),
                RG = Convert.ToString(txtRg.Text),
                CPF = Convert.ToString(txtCpf.Text),
                //Data_Nascimento = Convert.ToString(txtDtNascimento.Text),
                //Sexo = Convert.ToString(txt.Text),
                Telefone = Convert.ToString(txtTelefone.Text),
                //Tipo_Telefone = Convert.ToString(txt.Text),
                Endereco = Convert.ToString(txtEndereco.Text),
                Numero = Convert.ToString(txtNumero.Text),
                Bairro = Convert.ToString(txtBairro.Text),
                //Cidade = Convert.ToString(txt.Text),
                //Estado = Convert.ToString(txt.Text),
                //CEP = Convert.ToString(txtCep.Text),
            };

        }
    }
}
