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
using AscFrontEnd.DTOs.Cliente;
using System.IO;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Deposito;



namespace AscFrontEnd
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            List<ClientePhoneDTO> phone = new List<ClientePhoneDTO>() { new ClientePhoneDTO() { telefone = telefonetxt.Text } };
            List<ClienteFilialDTO> filias = new List<ClienteFilialDTO> { new ClienteFilialDTO() { email = emailText.Text,codigo=codigotxt
           .Text,localizacao=localTxt.Text,nif=nifText.Text,filialPhones=null,foto="string"} };

            var cliente = new ClienteDTO()
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
                clienteFiliais = filias
            };

            // Configuração do HttpClient
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(cliente);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync($"https://localhost:7200/api/Cliente/{1}", new StringContent(json, Encoding.UTF8, "application/json"));
         
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cliente Salvo Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                var responseCliente = await client.GetAsync($"https://localhost:7200/api/Cliente/ClientesByRelations");

                if (responseCliente.IsSuccessStatusCode)
                {
                    var contentCliente = await responseCliente.Content.ReadAsStringAsync();
                    StaticProperty.clientes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ClienteDTO>>(contentCliente);
                }

                // Depositos
                var responseBanco = await client.GetAsync($"https://localhost:7200/api/Deposito/Banco");

                if (responseBanco.IsSuccessStatusCode)
                {
                    var contentBanco = await responseBanco.Content.ReadAsStringAsync();
                    StaticProperty.bancos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BancoDTO>>(contentBanco);
                }

                var responseCaixa = await client.GetAsync($"https://localhost:7200/api/Deposito/Caixa");

                if (responseCaixa.IsSuccessStatusCode)
                {
                    var contentCaixa = await responseBanco.Content.ReadAsStringAsync();
                    StaticProperty.caixas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaixaDTO>>(contentCaixa);
                }
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

        private async void button1_Click(object sender, EventArgs e)
        {
            exportar exp = new exportar();
            exp.ShowDialog();
            //var client = new HttpClient();
            //var response = await client.GetAsync($"https://localhost:7200/api/Cliente/DownloadExcel");

            //if (response.IsSuccessStatusCode)
            //{
            //    using (var streamContent = await response.Content.ReadAsStreamAsync())
            //    {
            //        // Define o caminho onde o arquivo será salvo
            //        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download.xlsx"); // Altere o nome do arquivo conforme necessário

            //        // Salva o conteúdo da resposta em um arquivo local
            //        using (var fileStream = File.Create(filePath))
            //        {
            //            await streamContent.CopyToAsync(fileStream);
            //        }
            //        MessageBox.Show("Excel Gerado", "Feito Com Sucesso", MessageBoxButtons.OK);
            //    }
            }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
            button2.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(64,64,64);
            button1.ForeColor = Color.White;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientesTable cl = new ClientesTable();
            cl.ShowDialog();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            pessoaCombo.Items.Add("Singular");
            pessoaCombo.Items.Add("Colectiva");

            espacoFiscalCombo.Items.Add("Nacional");
            espacoFiscalCombo.Items.Add("Internacional");
        }
    }
    
}
