﻿using AscFrontEnd.DTOs.StaticsDto;
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
using AscFrontEnd.DTOs.Empresa;

namespace AscFrontEnd
{
    public partial class EmpresaForm : Form
    {
        string logo;
        public EmpresaForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog logoFile = new OpenFileDialog();
            
            if(logoFile.ShowDialog() == DialogResult.OK) 
            {
                logo = logoFile.FileName;   
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            HttpResponseMessage response = null;
            try { 
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            EmpresaDTO empresa = new EmpresaDTO() 
                       {
                           nome_fantasia = nomeText.Text,
                           razao_social = razaoText.Text,
                           ramo_actividade = actText.Text,
                           descricao = descText.Text,
                           email = emailText.Text,
                           endereco = enderecoText.Text,
                           logotipo = logo,
                           nif = nifText.Text,
                           bancos = StaticProperty.bancos,
                           caixas = StaticProperty.caixas,
                           status = DTOs.Enums.Enums.Status.activo,
                           foto = string.Empty,
                           bairro = bairroTxt.Text,
                           pronvicia = provinciaCombo.Text,
                           website = siteTxt.Text,
                           telefone = telText.Text,
                       };

            // Conversão do objeto Film para JSON
            string json = System.Text.Json.JsonSerializer.Serialize(empresa);

            // Envio dos dados para a API
            response = await client.PostAsync($"https://localhost:7200/api/Empresa/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                StaticProperty.bancos = null;
                StaticProperty.caixas = null;

                MessageBox.Show("Empresa Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                var result = await response.Content.ReadAsStringAsync();

                StaticProperty.empresaId = int.Parse(result);

                FuncionarioForm form = new FuncionarioForm();
                form.ShowDialog();
            }
            }
            catch(Exception ex) 
            {
                throw new Exception($"Erro ao salvar: {ex.Message}");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            BancoForm banco = new BancoForm();  
            banco.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CaixaForm caixa = new CaixaForm();
            caixa.ShowDialog();
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = Color.Gray;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackColor = Color.Gray;
        }

        private void EmpresaForm_Load(object sender, EventArgs e)
        {
            foreach (var item in StaticProperty.provincias)
            {
                provinciaCombo.Items.Add(item.nome);
            }
        }
    }
}
