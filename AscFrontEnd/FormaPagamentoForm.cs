﻿using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class FormaPagamentoForm : Form
    {
        HttpClient httpClient;
        Requisicoes _requisicoes;
        public FormaPagamentoForm()
        {
            InitializeComponent();
            _requisicoes = new Requisicoes();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (OutrasValidacoes.FormaPagamentoCodigoExiste(codigoTxt.Text.ToString()))
            {
                return;
            }

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            httpClient.BaseAddress = new Uri("http://localhost:7200/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string json = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(codigoTxt.Text.ToString()) || string.IsNullOrWhiteSpace(descricaoTxt.Text.ToString()))
                {
                    MessageBox.Show("Todos os campos precisam ser premchido os campos","Impossivel concluir a acao",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    return;
                }
                var formaPagamento = new FormaPagamentoDTO()
                {
                    codigo = codigoTxt.Text.ToString(),
                    descricao = descricaoTxt.Text.ToString(),
                    empresaId = StaticProperty.empresaId
                };

                json = System.Text.Json.JsonSerializer.Serialize(formaPagamento);



                var resposta = await httpClient.PostAsync("api/Deposito/FormaPagamento", new StringContent(json, Encoding.UTF8, "application/json"));

                if (resposta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Salvo Com Sucesso", "Nova Forma de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await _requisicoes.GetFormaPagamento();
                }
                else
                {
                    MessageBox.Show("Ocorreu um Erro", "Erro ao Salvar Forma de Pagamento", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }

                WindowsConfig.LimparFormulario(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro ao Salvar Forma de Pagamento", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private  void FormaPagamentoForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
