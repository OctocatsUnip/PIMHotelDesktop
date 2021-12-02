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
                Data_Nascimento = Convert.ToDateTime(txtDtNascimento.Text),
                Sexo = Convert.ToString(txtSexo.Text),
                Telefone = Convert.ToString(txtTelefone.Text),
                Celular = Convert.ToString(txtCelular.Text),
                Endereco = Convert.ToString(txtEndereco.Text),
                Numero = Convert.ToInt16(txtNumero.Text),
                Bairro = Convert.ToString(txtBairro.Text),
                Cidade = Convert.ToString(txtCidade.Text),
                Estado = Convert.ToString(txtEstado.Text),
                CEP = Convert.ToInt16(txtCep.Text),
            };
        }
    }
}
