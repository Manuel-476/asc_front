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
using static AscFrontEnd.DTOs.Enums.Enums;
using System.Text.Json;

namespace AscFrontEnd
{
    public partial class ArtigoEditar : Form
    {
        int _artigoId;
        ArtigoDTO _artigo;
        public ArtigoEditar(int artigoId)
        {
            InitializeComponent();
            _artigoId = artigoId;
        }

        private void ArtigoEditar_Load(object sender, EventArgs e)
        {
            _artigo = StaticProperty.artigos.Where(x => x.id == _artigoId).First();

            //carregar as combobox
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


            if (_artigo.mov_stock == DTOs.Enums.Enums.OpcaoBinaria.Sim) 
            {
                checkBox1.Checked = true;
            }
            else { checkBox1.Checked = false; }

            codigotxt.Text = _artigo.codigo.ToString();
            descricaotxt.Text = _artigo.descricao.ToString();
            precotxt.Text = _artigo.preco_unitario.ToString();
            codBarra.Text = _artigo.codigo_barra.ToString();
            numSerie.Text = _artigo.num_serie.ToString();
            if (checkBox1.Checked)
            {
                armazemCombo.Text = StaticProperty.armazens.Where(x => x.id == _artigo.armazemId).First().codigo;
                localCombo.Text = StaticProperty.locationStores.Where(x => x.id == StaticProperty.locationArtigos.Where(art => art.id == _artigo.localizacaoArtigoId).First().locationStoreId).First().codigo;
            }
            if(_artigo.familiaId > 0)
            {
                familiaCombo.Text = StaticProperty.familias.Where(x => x.id == _artigo.familiaId).First().codigo.ToString();
                subFamiliaCombo.Text = StaticProperty.subFamilias.Where(x => x.id == _artigo.subFamiliaId).First().codigo.ToString();
            }
            if (_artigo.marcaId > 0) 
            {
                marcaCombo.Text = StaticProperty.marcas.Where(x => x.id == _artigo.marcaId).First().codigo.ToString();
                modeloCombo.Text = StaticProperty.modelos.Where(x => x.id == _artigo.modeloId).First().codigo.ToString();
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int armazemId = StaticProperty.armazens.Where(arm => arm.codigo == armazemCombo.Text.ToString()).First().id;
            int localId = StaticProperty.locationStores.Where(arm => arm.codigo == localCombo.Text.ToString()).First().id;

            var artigo = new ArtigoDTO()
            {
                codigo = codigotxt.Text,
                armazemId = armazemId,
                descricao = descricaotxt.Text,
                familiaId = StaticProperty.familias.Where(x => x.codigo == familiaCombo.Text.ToString()).First().id,
                subFamiliaId = StaticProperty.subFamilias.Where(x => x.codigo == subFamiliaCombo.Text.ToString()).First().id,
                marcaId = StaticProperty.marcas.Where(x => x.codigo == marcaCombo.Text.ToString()).First().id,
                modeloId = StaticProperty.modelos.Where(x => x.codigo == modeloCombo.Text.ToString()).First().id,
                mov_stock = checkBox1.Checked ? OpcaoBinaria.Sim : OpcaoBinaria.Nao,
                mov_lote = checkBox1.Checked ? OpcaoBinaria.Sim : OpcaoBinaria.Nao,
                localizacaoArtigoId = localId,
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
            if(MessageBox.Show("Tens certeza que queres salvar estas alterações?","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Question)==DialogResult.OK)
            { 
                HttpResponseMessage response = await client.PutAsync($"https://localhost:7200/api/Artigo/{_artigoId}/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                   MessageBox.Show("Artigo Alterado Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

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
                  MessageBox.Show("Ocorreu um erro ao tentar Alterar", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
        }
    }
}

