﻿using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.InkML;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;

namespace AscFrontEnd
{
    public partial class CaixaCadastroForm : Form
    {
        List<CaixaDTO> caixas;
        DataTable dt;
        List<int> idCaixa;
        public CaixaCadastroForm()
        {
            InitializeComponent();
            caixas = new List<CaixaDTO>();
        
            idCaixa = new List<int>();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (OutrasValidacoes.CaixaCodigoExiste(codigoText.Text))
            {
                return;
            }

            if (caixas.Any() && caixas.Where(x => x.codigo == codigoText.Text).Any())
            {
                MessageBox.Show("Já adicionaste um caixa com este código", "O código já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrEmpty(codigoText.Text.ToString()))
            {
                MessageBox.Show("O campo do código está vázio", "Impossível Concluir a ação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (string.IsNullOrEmpty(descText.Text.ToString()))
            {
                MessageBox.Show("O campo do descrição está vázio", "Impossível Concluir a ação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            int id = caixaTable.Rows.Count;
            dt.Rows.Clear();
            caixaTable.DataSource = dt;

            caixas.Add(new CaixaDTO
            {
                codigo = codigoText.Text,
                descricao = descText.Text.ToString(),
                status = DTOs.Enums.Enums.Status.activo,
                empresaId = StaticProperty.empresaId
            });

            foreach (var caixa in caixas)
            {

                dt.Rows.Add(id, caixa.codigo.ToString(), caixa.descricao.ToString());

                caixaTable.DataSource = dt;
            }
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            foreach (var item in this.caixas)
            {
                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(item);

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PostAsync($"api/Deposito/Caixa", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Caixa Salvo Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                    var responseCaixa = await client.GetAsync($"api/Deposito/Caixa");

                    if (responseCaixa.IsSuccessStatusCode)
                    {
                        var contentCaixa = await responseCaixa.Content.ReadAsStringAsync();
                        StaticProperty.caixas = JsonConvert.DeserializeObject<List<CaixaDTO>>(contentCaixa);

                    }
                }
                else { MessageBox.Show("Erro ao salvar Caixa", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); }
            }

            WindowsConfig.LimparFormulario(this);

            caixaTable.DataSource = null;

            CaixaCadastroForm_Load(this, EventArgs.Empty);
        }
        private void CaixaCadastroForm_Load(object sender, EventArgs e)
        {
            dt = new DataTable();

            eliminarPicture.Enabled = false;
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Descricao", typeof(string));

            caixaTable.DataSource = dt;
        }

        private void eliminarPicture_Click(object sender, EventArgs e)
        {
            var selectedRows = caixaTable.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row != null && row.Index >= 0) // Verifica se a linha está válida
                {
                    int id = int.Parse(row.Cells[0].Value?.ToString()); // Substitua 0 pelo índice da coluna desejada
                                                                        // Ou faça algo mais útil com o valor
                    idCaixa.Add(id);
                }
            }

            foreach (int id in idCaixa)
            {
                var result = caixas.Where(c => c.id == id).First();

                int index = caixas.IndexOf(result);

                caixas.RemoveAt(index);
            }

            dt.Rows.Clear();
            caixaTable.DataSource = dt;


            foreach (var caixa in caixas)
            {

                dt.Rows.Add(caixa.id, caixa.codigo.ToString(), caixa.descricao.ToString());

                caixaTable.DataSource = dt;
            }
            idCaixa.Clear();
        }
    }
}
