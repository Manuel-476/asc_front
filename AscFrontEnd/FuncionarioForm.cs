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
            var client = new HttpClient();
            HttpResponseMessage response = null;

            List<FuncionarioPhoneDTO> phones = new List<FuncionarioPhoneDTO>();
            phones.Add(new FuncionarioPhoneDTO() { telefone=telText.ToString() });
            phones.Add(new FuncionarioPhoneDTO() { telefone = tel2Text.ToString() });

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
                empresaid = 1,
                paisId = 1,
                provinciaId = 1,
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
            response = await client.PostAsync($"https://localhost:7200/api/Funcionario/{1}", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                StaticProperty.user = null;
                MessageBox.Show("Funcionario Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                // Funcionario
                var responseFuncionario = await client.GetAsync($"https://localhost:7200/api/Funcionario/WithRelations");

                if (responseFuncionario.IsSuccessStatusCode)
                {
                    var contentFuncionario = await responseFuncionario.Content.ReadAsStringAsync();

                    StaticProperty.funcionarios = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(contentFuncionario);
                }
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
    }
}
