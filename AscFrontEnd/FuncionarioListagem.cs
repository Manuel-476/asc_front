﻿using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
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
using System.Text.Json;
using Color = System.Drawing.Color;

namespace AscFrontEnd
{
    public partial class FuncionarioListagem : Form
    {
        public int id;
        public FuncionarioListagem()
        {
            InitializeComponent();
        }

        private void editarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            editarPicture.BackColor = Color.Gray;
        }

        private void editarPicture_MouseLeave(object sender, EventArgs e)
        {
            editarPicture.BackColor = Color.Transparent;
        }

        private void eliminarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            eliminarPicture.BackColor = Color.Gray;
        }

        private void eliminarPicture_MouseLeave(object sender, EventArgs e)
        {
            eliminarPicture.BackColor = Color.Transparent;
        }

        private void FuncionarioListagem_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("nif", typeof(string));
            dt.Columns.Add("pessoa", typeof(string));
            dt.Columns.Add("localizacao", typeof(string));
            dt.Columns.Add("Data Nascimento", typeof(string));

            // Adicionando linhas ao DataTable
            foreach (var item in StaticProperty.funcionarios.Where(f => f.status == DTOs.Enums.Enums.Status.activo).ToList())
            {
                dt.Rows.Add(item.Id, item.Nome, item.email, item.nif, item.morada, item.data_nascimento);

                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private async void eliminarPicture_Click(object sender, EventArgs e)
        {
            string nome = StaticProperty.funcionarios.Where(f => f.Id == id).First().Nome;
            if (MessageBox.Show($"Tens certeza que pretendes desativar {nome}", "Atencao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try 
                { 
                   var client = new HttpClient();
                   client.BaseAddress = new Uri("https://sua-api.com/");
                   client.DefaultRequestHeaders.Accept.Clear();
                   client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                   // Conversão do objeto Film para JSON
                   string json = JsonSerializer.Serialize(id);

                   // Envio dos dados para a API
                   HttpResponseMessage response = await client.PutAsync($"https://localhost:7200/api/Funcionario/disable/{id}", new StringContent(json, Encoding.UTF8, "application/json"));

                   if (response.IsSuccessStatusCode)
                   {
                    MessageBox.Show("Funcionario foi desativado com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                   }
                }
                catch(Exception ex) 
                {
                    MessageBox.Show($"Erro ao desactivar funcionario: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            { 
                return;
            }
        }
    }
}