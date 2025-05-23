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
            if (!ValidacaoForms.IsValidNif(nifText.Text.ToString())) 
            {
                MessageBox.Show("O nif introduzido nao e valido","Impossivel Concluir a acao",MessageBoxButtons.OK, MessageBoxIcon.Information);
                
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
                           logotipo = string.IsNullOrEmpty(logo) ? string.Empty:logo,
                           nif = nifText.Text,
                           bancos = StaticProperty.bancosEmpresa,
                           caixas = StaticProperty.caixasEmpresa,
                           status = DTOs.Enums.Enums.Status.activo,
                           foto = string.Empty,
                           bairro = bairroTxt.Text,
                           pronvicia = provinciaCombo.Text,
                           website = siteTxt.Text,
                           telefone = !string.IsNullOrEmpty(telText.Text.ToString()) ? telText.Text: string.Empty,
                       };



            // Conversão do objeto Film para JSON
            string json = System.Text.Json.JsonSerializer.Serialize(empresa);

            // Envio dos dados para a API
            response = await client.PostAsync($"https://localhost:7200/api/Empresa/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));

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
            catch(Exception ex) 
            {
                throw new Exception($"Erro ao salvar: {ex.Message}");
            }

            WindowsConfig.LimparFormulario(this);

            EmpresaForm_Load(this, EventArgs.Empty);
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
