using AscFrontEnd.DTOs.StaticsDto;
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
using AscFrontEnd.Application.Validacao;
using AscFrontEnd.Application;
using System.IO;

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

            if (logoFile.ShowDialog() == DialogResult.OK)
            {
                logo = logoFile.FileName;
                var pathLogo = Path.GetFileName(logo);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ValidacaoForms.IsValidNif(nifText.Text.ToString()))
            {
                MessageBox.Show("O nif introduzido nao e valido", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (!ValidacaoForms.IsValidEmail(emailText.Text.ToString()))
            {
                MessageBox.Show("O Email introduzido nao e valido", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (!string.IsNullOrEmpty(telText.Text.ToString()) && !ValidacaoForms.IsValidPhone(telText.Text.ToString()))
            {
                MessageBox.Show("O telefone introduzido nao e valido", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            HttpResponseMessage response = null;
            try
            {
                client.BaseAddress = new Uri("https://localhost:7200/");
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
                    logotipo = string.IsNullOrEmpty(logo) ? string.Empty : logo,
                    nif = nifText.Text,
                    bancos = StaticProperty.bancosEmpresa,
                    caixas = StaticProperty.caixasEmpresa,
                    status = DTOs.Enums.Enums.Status.activo,
                    foto = string.Empty,
                    bairro = bairroTxt.Text,
                    pronvicia = provinciaCombo.Text,
                    website = siteTxt.Text,
                    telefone = !string.IsNullOrEmpty(telText.Text.ToString()) ? telText.Text : string.Empty,
                };


                using (var content = new MultipartFormDataContent())
                {
                    /* var empresaJson = System.Text.Json.JsonSerializer.Serialize(empresa);
                     var empresaContent = new StringContent(empresaJson, System.Text.Encoding.UTF8, "application/json");
                     content.Add(empresaContent, "empresa");*/

                    content.Add(new StringContent(empresa.nome_fantasia ?? ""), "nome_fantasia");
                    content.Add(new StringContent(empresa.razao_social ?? ""), "razao_social");
                    content.Add(new StringContent(empresa.ramo_actividade ?? ""), "ramo_actividade");
                    content.Add(new StringContent(empresa.descricao ?? ""), "descricao");
                    content.Add(new StringContent(empresa.email ?? ""), "email");
                    content.Add(new StringContent(empresa.endereco ?? ""), "endereco");
                    content.Add(new StringContent(empresa.nif ?? ""), "nif");
                    content.Add(new StringContent(empresa.status.ToString()), "status");
                    content.Add(new StringContent(empresa.foto ?? ""), "foto");
                    content.Add(new StringContent(empresa.bairro ?? ""), "bairro");
                    content.Add(new StringContent(empresa.pronvicia ?? ""), "pronvicia");
                    content.Add(new StringContent(empresa.website ?? ""), "website");
                    content.Add(new StringContent(empresa.telefone ?? ""), "telefone");

                    // Para listas (bancos e caixas), você pode serializar como JSON se o backend aceitar isso
                    content.Add(new StringContent(System.Text.Json.JsonSerializer.Serialize(empresa.bancos)), "bancos");
                    content.Add(new StringContent(System.Text.Json.JsonSerializer.Serialize(empresa.caixas)), "caixas");


                    if (!string.IsNullOrEmpty(logo) && File.Exists(logo))
                    {
                        var fileBytes = File.ReadAllBytes(logo);
                        var fileContent = new ByteArrayContent(fileBytes);

                        string extension = Path.GetExtension(logo).ToLower();
                        string contentType = string.Empty;
                        switch (extension)
                        {
                            case ".jpeg":
                            case ".jpg": contentType = "image/jpeg"; break;
                            case ".png": contentType = "image/png"; break;
                            case ".bmp": contentType = "image/bmp"; break;
                            default:
                                MessageBox.Show("Formato de arquivo não suportado. Use JPG, PNG, BMP", "Erro no Formato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }

                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                        var logoResult = Path.GetFileName(logo);
                        content.Add(fileContent, "imagem", Path.GetFileName(logo));
                    }

                    response = await client.PostAsync($"api/Empresa/{StaticProperty.funcionarioId}", content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        StaticProperty.bancosEmpresa = null;
                        StaticProperty.caixasEmpresa = null;

                        MessageBox.Show("Empresa Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                        var result = await response.Content.ReadAsStringAsync();

                        StaticProperty.empresaId = int.Parse(result);

                        FuncionarioForm form = new FuncionarioForm();
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
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
