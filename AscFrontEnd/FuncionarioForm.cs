using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;
using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Funcionario;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class FuncionarioForm : Form
    {
        int paisId;
        int naturalidadeId;
        int provinciaId;
        public FuncionarioForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            if (!ValidacaoForms.IsValidNif(numIdent.Text.ToString()))
            {
                MessageBox.Show("O numero do B.I introduzido nao e valido", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (!ValidacaoForms.IsValidEmail(email.Text.ToString()))
            {
                MessageBox.Show("O Email introduzido nao e valido", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (!string.IsNullOrEmpty(telText.Text.ToString()) && !ValidacaoForms.IsValidPhone(telText.Text.ToString()))
            {
                MessageBox.Show("O telefone introduzido nao e valido", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (!string.IsNullOrEmpty(tel2Text.Text.ToString()) && !ValidacaoForms.IsValidPhone(tel2Text.Text.ToString()))
            {
                MessageBox.Show("O telefone 2 introduzido nao e valido", "Impossivel Concluir a acao",  MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            HttpResponseMessage response = null;

            List<FuncionarioPhoneDTO> phones = new List<FuncionarioPhoneDTO>();
            phones.Add(new FuncionarioPhoneDTO() { telefone= !string.IsNullOrEmpty(telText.Text.ToString())?telText.Text.ToString():string.Empty });

            if (!string.IsNullOrWhiteSpace(tel2Text.Text.ToString()))
            {
                phones.Add(new FuncionarioPhoneDTO() { telefone = tel2Text.Text.ToString() });
            }

            FuncionarioDTO funcionario = new FuncionarioDTO()
            {
                Nome = nomeText.Text,
                data_nascimento = dateText.Value,
                genero = char.Parse(generoCombo.Text.ToString().Substring(0, 1)),
                codigo_postal = cPostalText.Text,
                localidade = localText.Text,
                morada = moradaText.Text,
                status = DTOs.Enums.Enums.Status.activo,
                users = StaticProperty.user,
                empresaid = StaticProperty.empresaId,
                paisId = paisId,
                provinciaId = provinciaId,
                phones = phones,
                email = email.Text,
                nif = numIdent.Text,
                foto = "empty"
            };
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = System.Text.Json.JsonSerializer.Serialize(funcionario);

            // Envio dos dados para a API
            response = await client.PostAsync($"https://localhost:7200/api/Funcionario/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                StaticProperty.user = null;
                MessageBox.Show("Funcionario Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                // Funcionario
                WindowsConfig.LimparFormulario(this);

                FuncionarioForm_Load(this, EventArgs.Empty);
            }
            else 
            {
                throw new Exception("Erro ao tentar salvar");
               
            }
        }

        private void credenciaisLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserForm form = new UserForm();
            form.ShowDialog();
        }

        private void funcionarioBtn_Click(object sender, EventArgs e)
        {
            FuncionarioListagem funcionario = new FuncionarioListagem();
            funcionario.ShowDialog();
        }

        private void FuncionarioForm_Load(object sender, EventArgs e)
        {
            foreach (var item in StaticProperty.paises) 
            {
                paisCombo.Items.Add(item.nome);
                naturalidadeCombo.Items.Add(item.nome);
            }

            generoCombo.Items.Add("M");
            generoCombo.Items.Add("F");
        }

        private void paisCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(paisCombo.Text.ToString()))
            {
                return;
            }

            string pais = paisCombo.SelectedItem.ToString();

            if (StaticProperty.paises.Where(x => x.nome == pais).Any())
            {
                var paisResult = StaticProperty.paises.Where(x => x.nome == pais).First();

                paisId = paisResult.id;

                foreach(var item in StaticProperty.provincias.Where(x => x.paisId == paisId)) 
                {
                    provinciaCombo.Items.Add(item.nome);
                }
            }
        }

        private void provinciaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(provinciaCombo.Text.ToString()))
            {
                return;
            }

            string provincia = provinciaCombo.SelectedItem.ToString();

            if (StaticProperty.provincias.Where(x => x.nome == provincia).Any())
            {
                provinciaId = StaticProperty.provincias.Where(x => x.nome == provincia).First().id;
            }
        }

        private void naturalidadeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(naturalidadeCombo.Text.ToString())) 
            {
                return;
            }

            string pais = naturalidadeCombo.SelectedItem.ToString();

            if (StaticProperty.paises.Where(x => x.nome == pais).Any())
            {
                naturalidadeId = StaticProperty.paises.Where(x => x.nome == pais).First().id;
            }
        }

        private void paisCombo_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
