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
        OpcaoBinaria regimeIva = OpcaoBinaria.Sim;
        string codigoIva = string.Empty;
        int localId;
        public Artigo()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try { 
            int armazemId  = StaticProperty.armazens.Where(arm=>arm.codigo == armazemCombo.Text.ToString()).First().id;

            

            
            var artigo = new ArtigoDTO()
            {
              codigo = codigotxt.Text,
              armazemId = armazemId,
              descricao = descricaotxt.Text,
              familiaId = StaticProperty.familias.Where(x => x.codigo == familiaCombo.Text.ToString()).Any() ? StaticProperty.familias.Where(x => x.codigo == familiaCombo.Text.ToString()).First().id : 0,
              subFamiliaId =  StaticProperty.subFamilias.Where(x => x.codigo == subFamiliaCombo.Text.ToString()).Any() ? StaticProperty.subFamilias.Where(x => x.codigo == subFamiliaCombo.Text.ToString()).First().id : 0,
              marcaId = StaticProperty.marcas.Where(x => x.codigo == marcaCombo.Text.ToString()).Any() ? StaticProperty.marcas.Where(x => x.codigo == marcaCombo.Text.ToString()).First().id : 0,
              modeloId = StaticProperty.modelos.Where(x => x.codigo == modeloCombo.Text.ToString()).Any() ? StaticProperty.modelos.Where(x => x.codigo == modeloCombo.Text.ToString()).First().id : 0,
              mov_stock = checkBox1.Checked?OpcaoBinaria.Sim:OpcaoBinaria.Nao,
              mov_lote = checkBox1.Checked?OpcaoBinaria.Sim:OpcaoBinaria.Nao,
              localizacaoArtigoId = localId,
              codigo_barra = codBarra.Text,
              num_serie = numSerie.Text,
              preco_unitario = float.Parse(precotxt.Text),
              unidadeCompra = comboUnCompra.Text,
              unidadeVenda = comboUnVenda.Text,
              regimeIva = regimeIva,
              codigoIva = codigoIva,
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
            catch(Exception ex) 
            {
                MessageBox.Show($"Ocorreu um erro ao tentar Salvar {ex.Message}", "Erro", MessageBoxButtons.RetryCancel);
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
            foreach (var item in StaticProperty.armazens.Where(arm => arm.empresaId == StaticProperty.empresaId).ToList())
            {
                armazemCombo.Items.Add(item.codigo);
            }
            foreach (var item in StaticProperty.familias.Where(fam => fam.empresaId == StaticProperty.empresaId).ToList())
            {
                familiaCombo.Items.Add(item.codigo);
            }
            foreach (var item in StaticProperty.subFamilias.Where(fam => fam.empresaId == StaticProperty.empresaId).ToList())
            {
                subFamiliaCombo.Items.Add(item.codigo);
            }
            foreach (var item in StaticProperty.modelos.Where(fam => fam.empresaId == StaticProperty.empresaId).ToList())
            {
                modeloCombo.Items.Add(item.codigo);
            }
            foreach (var item in StaticProperty.marcas.Where(fam => fam.empresaId == StaticProperty.empresaId).ToList())
            {
                marcaCombo.Items.Add(item.codigo);
            }
            foreach (var item in StaticProperty.ivas.Where(iva => iva.empresaId == 0 && iva.empresaId == StaticProperty.empresaId).ToList())
            {
                ivaCombo.Items.Add(item.valorIva);
            }
            foreach (var item in StaticProperty.unidades.Where(x => x.empresaId == 0 && x.empresaId == StaticProperty.empresaId).ToList())
            {
                comboUnCompra.Items.Add(item.codigo);
                comboUnVenda.Items.Add(item.codigo);
            }

            mencaoCombo.Enabled = false;
            descricaoIvaTxt.Text = "";

            regimeIvaCombo.Items.Add("Isento");
            regimeIvaCombo.Items.Add("Geral");
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
                if (!StaticProperty.locationArtigos.Where(x => x.locationStoreId == item.id && x.qtd == 0).Any() && StaticProperty.locationArtigos.Any()) 
                {
                    MessageBox.Show("Este armazem não tem localização disponível, todas localizações já armazenam artigos", "Sem Localização disponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (StaticProperty.locationArtigos.Where(x => x.locationStoreId == item.id && x.qtd == 0).Any() || !StaticProperty.locationArtigos.Any())
                {
                    localCombo.Items.Add(item.codigo);
                }
            }
        }

        private void regimeIvaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.Equals(regimeIvaCombo.SelectedItem.ToString(), "Geral", StringComparison.OrdinalIgnoreCase)) 
            {
                regimeIva = OpcaoBinaria.Sim;
                mencaoCombo.Enabled = false;
                mencaoCombo.Items.Clear();
                descricaoIvaTxt.Text = "";
            }
            else if (string.Equals(regimeIvaCombo.SelectedItem.ToString(), "Isento", StringComparison.OrdinalIgnoreCase)) 
            {
                regimeIva = OpcaoBinaria.Nao;
                mencaoCombo.Enabled = true;

                foreach(var motivo in StaticProperty.motivosIsencao) 
                {
                    mencaoCombo.Items.Add(motivo.mencao);
                }
               
            }
        }

        private void mencaoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mencaoCombo.SelectedItem.ToString()))
            {
                return;
            }
            else
            {
                if (StaticProperty.motivosIsencao.Where(x => x.mencao == mencaoCombo.SelectedItem.ToString()).Any())
                {
                    if (string.IsNullOrEmpty(StaticProperty.motivosIsencao.Where(x => x.mencao == mencaoCombo.SelectedItem.ToString()).First().descricao))
                    {
                        descricaoIvaTxt.Text = "";

                        this.codigoIva = StaticProperty.motivosIsencao.Where(x => x.mencao == mencaoCombo.SelectedItem.ToString()).First().codigo;

                        return; 
                    }

                    descricaoIvaTxt.Text = StaticProperty.motivosIsencao.Where(x => x.mencao == mencaoCombo.SelectedItem.ToString()).First().descricao;
                    this.codigoIva = StaticProperty.motivosIsencao.Where(x => x.mencao == mencaoCombo.SelectedItem.ToString()).First().codigo;
                }
            }
        }

        private void localCombo_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void localCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.localId = StaticProperty.locationStores.Where(arm => arm.codigo == localCombo.Text.ToString()).First().id;

            if (StaticProperty.locationArtigos.Where(x=>x.locationStoreId == this.localId).Any()) 
            {
                var local = StaticProperty.locationArtigos.Where(x => x.locationStoreId == this.localId).First(); 

                if(local.artigoId != 0) 
                {
                    MessageBox.Show("Esta localização já tem um artigo predefinido, se continuar substituirá o artigo predefinido pelo  novo artigo","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void armazemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
