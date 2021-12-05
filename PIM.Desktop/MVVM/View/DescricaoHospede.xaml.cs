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
            ListaHospedesModel listaHospedesModel = new ListaHospedesModel();
        }

        public void MostrarDados(ListaHospedesModel pessoas)
        {
            txtNome.Text = pessoas.Nome;
            txtRg.Text = pessoas.RG;
            txtCpf.Text = pessoas.CPF;
            txtDtNascimento.Text = Convert.ToString(pessoas.Data_Nascimento);
            txtSexo.Text = pessoas.Sexo;
            txtTelefone.Text = Convert.ToString(pessoas.Telefone_owner[0].numero);
            txtCelular.Text = Convert.ToString(pessoas.Telefone_owner[1].numero);
            txtEndereco.Text = pessoas.Endereco_owner.Logradouro;
            txtNumero.Text = Convert.ToString(pessoas.Endereco_owner.Numero);
            txtBairro.Text = pessoas.Endereco_owner.Bairro;
            txtCidade.Text = pessoas.Endereco_owner.Cidade;
            txtEstado.Text = pessoas.Endereco_owner.Estado;
            txtCep.Text = Convert.ToString(pessoas.Endereco_owner.CEP);
        }
    }
}
