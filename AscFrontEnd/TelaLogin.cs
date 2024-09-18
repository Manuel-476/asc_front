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
        public TelaLogin()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            InitializeComponent();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            user = new UserDTO() { user_name = nomeUsuariotxt.Text, password = senhaUsuariotxt.Text};

            if(!string.IsNullOrWhiteSpace(nomeUsuariotxt.Text.ToString()) && !string.IsNullOrWhiteSpace(senhaUsuariotxt.Text.ToString()))
            {
                json = JsonSerializer.Serialize(user);
                HttpResponseMessage response = await client.PostAsync($"https://localhost:7200/api/Funcionario/User/Login", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    string token = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(content);

                    using (HttpClient client = new HttpClient())
                    {
                        // Adiciona o token JWT no cabeçalho
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        HttpResponseMessage responseUsers = await client.GetAsync($"https://localhost:7200/api/Funcionario/User/GetUsers");

                        if (responseUsers.IsSuccessStatusCode)
                        {
                            var contentUser = await responseUsers.Content.ReadAsStringAsync();
                            List<UserDTO> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDTO>>(contentUser);

                            try
                            {
                                if (!string.IsNullOrWhiteSpace(users.Where(u => u.user_name == user.user_name && u.password == user.password).First().user_name))
                                {
                                    var result = users.Where(u => u.user_name == user.user_name && u.password == user.password).First();
                                    var responseFuncionario = await client.GetAsync($"https://localhost:7200/api/Funcionario/{result.id}");
                                    var contentFuncionario = await responseFuncionario.Content.ReadAsStringAsync();
                                    var funcionario = Newtonsoft.Json.JsonConvert.DeserializeObject<FuncionarioDTO>(contentFuncionario);

                                    if (responseFuncionario != null)
                                    {
                                        StaticProperty.funcionarioId = result.funcionarioid;
                                        StaticProperty.empresaId = funcionario.empresaid;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            catch { return; }



                            this.Hide();
                            StaticProperty.token = token;
                            new CarregamentoForm().ShowDialog();
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private async void senhaUsuariotxt_TextChanged(object sender, EventArgs e)
        {
           user = new UserDTO() { user_name = nomeUsuariotxt.Text, password = senhaUsuariotxt.Text };

            if (!string.IsNullOrWhiteSpace(nomeUsuariotxt.Text.ToString()) && !string.IsNullOrWhiteSpace(senhaUsuariotxt.Text.ToString()))
            {
                json = JsonSerializer.Serialize(user);
                HttpResponseMessage response = await client.PostAsync($"https://localhost:7200/api/Funcionario/User/Login", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    string token = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(content);

                    using (HttpClient client = new HttpClient())
                    {
                        // Adiciona o token JWT no cabeçalho
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        HttpResponseMessage responseUsers = await client.GetAsync($"https://localhost:7200/api/Funcionario/User/GetUsers");

                        if (responseUsers.IsSuccessStatusCode)
                        {
                            var contentUser = await responseUsers.Content.ReadAsStringAsync();
                            List<UserDTO> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDTO>>(contentUser);

                            try
                            {
                                if (!string.IsNullOrWhiteSpace(users.Where(u => u.user_name == user.user_name && u.password == user.password).First().user_name))
                                {
                                    var result = users.Where(u => u.user_name == user.user_name && u.password == user.password).First();
                                    var responseFuncionario = await client.GetAsync($"https://localhost:7200/api/Funcionario/{result.id}");
                                    var contentFuncionario = await responseFuncionario.Content.ReadAsStringAsync();
                                    var funcionario = Newtonsoft.Json.JsonConvert.DeserializeObject<FuncionarioDTO>(contentFuncionario);

                                    if (responseFuncionario != null)
                                    {
                                        StaticProperty.funcionarioId = result.funcionarioid;
                                        StaticProperty.empresaId = funcionario.empresaid;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            catch { return; }



                            this.Hide();
                            StaticProperty.token = token;
                            new CarregamentoForm().ShowDialog();
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

        private void TelaLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
