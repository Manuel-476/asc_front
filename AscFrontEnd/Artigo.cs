using AscFrontEnd.DTOs.Fornecedor;
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
using static AscFrontEnd.DTOs.Enums.Enums;
using AscFrontEnd.DTOs.StaticsDto;


namespace AscFrontEnd
{
    public partial class Artigo : Form
    {
        public Artigo()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            int armazemId  = StaticProperty.armazens.Where(arm=>arm.codigo == armazemCombo.Text.ToString()).First().id;
            int localId  = StaticProperty.locationStores.Where(arm => arm.codigo == localCombo.Text.ToString()).First().id;

            var artigo = new ArtigoDTO()
            {
              codigo = codigotxt.Text,
              armazemId = armazemId,
              descricao = descricaotxt.Text,
              familiaId = StaticProperty.familias.Where(x => x.codigo == familiaCombo.Text.ToString()).First().id,
              subFamiliaId = StaticProperty.subFamilias.Where(x => x.codigo == subFamiliaCombo.Text.ToString()).First().id,
              marcaId = StaticProperty.marcas.Where(x => x.codigo == marcaCombo.Text.ToString()).First().id,
              modeloId = StaticProperty.modelos.Where(x => x.codigo == modeloCombo.Text.ToString()).First().id,
              mov_stock = checkBox1.Checked?OpcaoBinaria.Sim:OpcaoBinaria.Nao,
              mov_lote = checkBox1.Checked?OpcaoBinaria.Sim:OpcaoBinaria.Nao,
              localizacaoArtigoId = localId,
              codigo_barra = codBarra.Text,
              num_serie = numSerie.Text,
              preco_unitario = float.Parse(precotxt.Text),
              unidadeCompra = comboUnCompra.Text,
              unidadeVenda = comboUnVenda.Text,
              empresaId = StaticProperty.empresaId,
            };

            // Configuração do HttpClient
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(artigo);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync($"https://localhost:7200/api/Artigo/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Artigo Salvo Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                // Artigo
                var responseArtigo = await client.GetAsync($"https://localhost:7200/api/Artigo");

                if (responseArtigo.IsSuccessStatusCode)
                {
                    var contentArtigo = await responseArtigo.Content.ReadAsStringAsync();
                    StaticProperty.artigos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ArtigoDTO>>(contentArtigo);
                }
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listagem_Click(object sender, EventArgs e)
        {
            ArtigoListagem artigoListagem = new ArtigoListagem();
            artigoListagem.ShowDialog();
        }

        private void createPicture_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpcaoDialog opcao = new OpcaoDialog();
            opcao.ShowDialog();
        }

        private void listagem_MouseMove(object sender, MouseEventArgs e)
        {
            listagem.BackColor = Color.White;
            listagem.ForeColor = Color.Black;
        }

        private void listagem_MouseLeave(object sender, EventArgs e)
        {
            listagem.BackColor = Color.FromArgb(64,64,64);
            listagem.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(64,64,64);
            button3.ForeColor = Color.White;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
        }

        private void Artigo_Load(object sender, EventArgs e)
        {
            foreach (var item in StaticProperty.armazens.Where(arm => arm.empresaId == 1).ToList())
            {
                armazemCombo.Items.Add(item.codigo);
            }
            foreach (var item in StaticProperty.familias.Where(fam => fam.empresaId == 1).ToList())
            {
                familiaCombo.Items.Add(item.codigo);
            }
            foreach (var item in StaticProperty.subFamilias.Where(fam => fam.empresaId == 1).ToList())
            {
                subFamiliaCombo.Items.Add(item.codigo);
            }
            foreach (var item in StaticProperty.modelos.Where(fam => fam.empresaId == 1).ToList())
            {
                modeloCombo.Items.Add(item.codigo);
            }
            foreach (var item in StaticProperty.marcas.Where(fam => fam.empresaId == 1).ToList())
            {
                marcaCombo.Items.Add(item.codigo);
            }

            comboUnCompra.Items.Add("Un"); comboUnVenda.Items.Add("Un");
            comboUnCompra.Items.Add("Kg"); comboUnVenda.Items.Add("Kg");
            comboUnCompra.Items.Add("Ltr"); comboUnVenda.Items.Add("Ltr");
            comboUnCompra.Items.Add("m"); comboUnVenda.Items.Add("m");
            comboUnCompra.Items.Add("Cx"); comboUnVenda.Items.Add("Cx");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) 
            {
                if(StaticProperty.armazens == null) 
                {
                    MessageBox.Show("Nenhum armazem foi cadastrado no sistema\n\nPrecisas cadastrar um armazem no sistema","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    return;
                }
            }
        }

        private void armazemCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            int armazemId = StaticProperty.armazens.Where(arm => arm.codigo == armazemCombo.Text && arm.empresaId == 1).First().id;
            foreach (var item in StaticProperty.locationStores.Where(fam => fam.armazemId == armazemId).ToList())
            {              
                localCombo.Items.Add(item.codigo);
            }
        }
    }
}
