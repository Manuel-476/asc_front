using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;
using Newtonsoft.Json.Linq;
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
    public partial class UserForm : Form
    {
        HttpClient client;
        string _tittle = string.Empty;

        UserDTO _user;

        public UserForm(UserDTO user)
        {

            InitializeComponent();


            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7200");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            _user = user;

        }

        public UserForm
        (string tittle, UserDTO user)
        {
            InitializeComponent();

            _tittle = tittle;
            _user = user;

            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7200");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO()
            {
                user_name = nomeText.Text,
                password = senha.Text,
                nivel_acesso = nivelAcesso.Text,
                userPermissions = StaticProperty.relationUserPermissions,
            };

            if (string.IsNullOrEmpty(_tittle))
            { 
                StaticProperty.user = user;
                this.Close();
            }
            else 
            {
                user.id = _user.id;

                string json = System.Text.Json.JsonSerializer.Serialize(user);

                var response = await client.PutAsync($"api/Funcionario/User/Update/{user}", new StringContent(json, Encoding.UTF8, "application/json"));
               
                if (response.IsSuccessStatusCode) 
                {
                    MessageBox.Show("Credencias Alterada", "Feito Com Sucesso", MessageBoxButtons.OK,MessageBoxIcon.Information);

                    new TelaLogin().ShowDialog();
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Ocorreu um erro ao tentar alterar as credencias", "Alguma coisa não correu bem", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_tittle)) 
            {
                titulo.Text = _tittle;
                infoLabel.Text = "É necessario alterar as tuas credencias para manter os teus dados em segurança\n" +
                                 "Garanta que só você tem acesso as suas credenciais!";

                nivelAcesso.Dispose();
                nivelAcessoLabel.Dispose();
                linkPermissions.Dispose();

            }
            if (_user.nivel_acesso.Equals("Tecnico"))
            {
                nivelAcesso.Items.Add("Tecnico");
            }
            nivelAcesso.Items.Add("Administrador");
            nivelAcesso.Items.Add("Gerente");
            nivelAcesso.Items.Add("Caixa");
        }

        private void linkPermissions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PermissionsForm(null,DTOs.Enums.Enums.Acao.Salvar).ShowDialog();
        }
    }
}
