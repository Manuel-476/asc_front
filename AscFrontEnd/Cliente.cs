﻿using AscFrontEnd.DTOs.Fornecedor;
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
            HttpResponseMessage response = await client.PostAsync("https://localhost:7200/api/Cliente", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cliente Salvo Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK); 
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
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7200/api/Cliente/DownloadExcel");

            if (response.IsSuccessStatusCode)
            {
                using (var streamContent = await response.Content.ReadAsStreamAsync())
                {
                    // Define o caminho onde o arquivo será salvo
                    var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download.xlsx"); // Altere o nome do arquivo conforme necessário

                    // Salva o conteúdo da resposta em um arquivo local
                    using (var fileStream = File.Create(filePath))
                    {
                        await streamContent.CopyToAsync(fileStream);
                    }
                    MessageBox.Show("Excel Gerado", "Feito Com Sucesso", MessageBoxButtons.OK);
                }
            }
        }
    }
}
