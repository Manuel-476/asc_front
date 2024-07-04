using AscFrontEnd.DTOs.Fornecedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AscFrontEnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void cadastrarBtn_Click(object sender, EventArgs e)
        {
            List<FornecedorPhoneDTO> phone = new List<FornecedorPhoneDTO>() { new FornecedorPhoneDTO() { telefone = telefonetxt.Text} };
            List<FornecedorFilialDTO> filias = new List<FornecedorFilialDTO> { new FornecedorFilialDTO() { email = emailText.Text,codigo=codigotxt
           .Text,localizacao=localTxt.Text,nif=nifText.Text,fornFilialPhones=null,foto="string"} };
            var fornecedor = new FornecedorDTO()
            {
                nome_fantasia = nomeFantasiatxt.Text,
                razao_social = razaoSocialtxt.Text,
                localizacao = localizacaotxt.Text,
                email = emailText.Text,
                espaco_fiscal = espacoFiscalCombo.Text,
                pessoa = pessoaCombo.Text,
                nif = nifText.Text,
                phones = phone,
                foto = "string",
                fornecedorFiliais = filias
            };

            // Configuração do HttpClient
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(fornecedor);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync("https://localhost:7200/api/Fornecedor", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Dados enviados com sucesso.");
            }
            else
            {
                Console.WriteLine($"Erro ao enviar dados: {response.StatusCode}");
            }
        }

        private void adicionarBtn_Click(object sender, EventArgs e)
        {

        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            List<FornecedorPhoneDTO> phone = new List<FornecedorPhoneDTO>() { new FornecedorPhoneDTO() { telefone = telefonetxt.Text } };
            List<FornecedorFilialDTO> filias = new List<FornecedorFilialDTO> { new FornecedorFilialDTO() { email = emailText.Text,codigo=codigotxt
           .Text,localizacao=localTxt.Text,nif=nifText.Text,fornFilialPhones=null,foto="string"} };
            var fornecedor = new FornecedorDTO()
            {
                nome_fantasia = nomeFantasiatxt.Text,
                razao_social = razaoSocialtxt.Text,
                localizacao = localizacaotxt.Text,
                email = emailText.Text,
                espaco_fiscal = espacoFiscalCombo.Text,
                pessoa = pessoaCombo.Text,
                nif = nifText.Text,
                phones = phone,
                foto = "string",
                fornecedorFiliais = filias
            };

            // Configuração do HttpClient
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(fornecedor);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync("https://localhost:7200/api/Fornecedor", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Fornecedor Salvo Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
                
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(64,64,64);
            button2.ForeColor = Color.White;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }
    }
}
