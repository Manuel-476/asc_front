using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class TelaLogin : Form
    {
        HttpClient client;
        string json = string.Empty;
        UserDTO user;
        UserDTO resultUser;
        public TelaLogin()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            resultUser = new UserDTO();
            InitializeComponent();
        }



        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { 
            user = new UserDTO() { user_name = nomeUsuariotxt.Text, password = senhaUsuariotxt.Text };

            if (!string.IsNullOrWhiteSpace(nomeUsuariotxt.Text.ToString()) && !string.IsNullOrWhiteSpace(senhaUsuariotxt.Text.ToString()))
            {
                json = JsonSerializer.Serialize(user);
                HttpResponseMessage response = await client.PostAsync($"https://localhost:7200/api/Funcionario/User/Login", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    UserResult userResult = Newtonsoft.Json.JsonConvert.DeserializeObject<UserResult>(content);

                    using (HttpClient client = new HttpClient())
                    {
                        // Adiciona o token JWT no cabeçalho
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userResult.token);

                        try
                        {
                            var responseFuncionario = await client.GetAsync($"https://localhost:7200/api/Funcionario/{userResult.user.funcionarioid}");
                            var contentFuncionario = await responseFuncionario.Content.ReadAsStringAsync();
                            var funcionario = Newtonsoft.Json.JsonConvert.DeserializeObject<FuncionarioDTO>(contentFuncionario);

                            if (responseFuncionario != null)
                            {
                                StaticProperty.funcionarioId = userResult.user.funcionarioid;
                                StaticProperty.empresaId = funcionario.empresaid;
                                StaticProperty.relationUserPermissions = userResult.user.userPermissions as List<RelationUserPermissionDTO>;
                            }

                        }
                        catch { return; }



                        this.Hide();
                        StaticProperty.token = userResult.token;
                        if (userResult.user.state == DTOs.Enums.Enums.OpcaoBinaria.Nao)
                        {
                            new UserForm("Alterar Credencias de Acesso", userResult.user.id).ShowDialog();
                        }
                        else
                        {
                            new CarregamentoForm(userResult.user).ShowDialog();
                        }

                    }
                }
                else
                {
                    return;
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                }
             }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao logar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            }
        }

        private async void senhaUsuariotxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                user = new UserDTO() { user_name = nomeUsuariotxt.Text, password = senhaUsuariotxt.Text };

                if (!string.IsNullOrWhiteSpace(nomeUsuariotxt.Text.ToString()) && !string.IsNullOrWhiteSpace(senhaUsuariotxt.Text.ToString()))
                {
                    json = JsonSerializer.Serialize(user);

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:7200/api/Funcionario/User/Login", new StringContent(json, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        UserResult userResult = Newtonsoft.Json.JsonConvert.DeserializeObject<UserResult>(content);

                        using (HttpClient client = new HttpClient())
                        {
                            // Adiciona o token JWT no cabeçalho
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userResult.token);

                            try
                            {
                                var responseFuncionario = await client.GetAsync($"https://localhost:7200/api/Funcionario/{userResult.user.funcionarioid}");
                                var contentFuncionario = await responseFuncionario.Content.ReadAsStringAsync();
                                var funcionario = Newtonsoft.Json.JsonConvert.DeserializeObject<FuncionarioDTO>(contentFuncionario);

                                if (responseFuncionario != null)
                                {
                                    StaticProperty.funcionarioId = userResult.user.funcionarioid;
                                    StaticProperty.empresaId = funcionario.empresaid;
                                    StaticProperty.relationUserPermissions = userResult.user.userPermissions as List<RelationUserPermissionDTO>;
                                }

                            }
                            catch { return; }



                            this.Hide();
                            StaticProperty.token = userResult.token;
                            if (userResult.user.state == DTOs.Enums.Enums.OpcaoBinaria.Nao)
                            {
                                new UserForm("Alterar Credencias de Acesso", userResult.user.id).ShowDialog();
                            }
                            else
                            {
                                new CarregamentoForm(userResult.user).ShowDialog();
                            }

                        }
                    }

                    else
                    {
                        return;
                        MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                    }
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"Erro ao logar",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Error);
            }
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {
            senhaUsuariotxt.PasswordChar = '*';
        }
    }
}
