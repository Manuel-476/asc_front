using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.DTOs.Compra;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Venda;
using ERP_Buyer.Application.DTOs.Documentos;
using Newtonsoft.Json;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class RelatorioFiltros : Form
    {
        OpcaoBinaria _financeira;
        Consulta _consulta;

        private readonly HttpClient _httpClient;
        List<VendaDTO> _vendas;
        List<CompraDTO> _compras;

        List<string> _documentos;
        List<int> _entidadeIds;
        List<int> _artigoIds;
        List<int> _armazemIds;
        
        public RelatorioFiltros(OpcaoBinaria financeira, Consulta consulta)
        {
            InitializeComponent();

            _financeira = financeira;
            _consulta = consulta;

            _documentos = new List<string>();
            _entidadeIds = new List<int>();
            _artigoIds = new List<int>();
            _armazemIds = new List<int>();
            _compras = new List<CompraDTO>();
            _vendas = new List<VendaDTO>();

            _httpClient = new HttpClient();
            // Defina a URL base da sua API
            _httpClient.BaseAddress = new Uri("https://localhost:7200");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RelatorioFiltros_Load(object sender, EventArgs e)
        {
            if (_financeira == OpcaoBinaria.Sim)
            {
                btnArmazem.Visible = false;
               // btnArtigo.Visible = false;
            }
            else 
            {
                btnEntidade.Visible = false;
                documentoCombo.Enabled = false;
            }


            if (_consulta == Consulta.venda)
            {
                documentoCombo.Items.Add("FR");
                documentoCombo.Items.Add("FT");
                documentoCombo.Items.Add("PP");
                documentoCombo.Items.Add("ECL");
                documentoCombo.Items.Add("NC");
                documentoCombo.Items.Add("GT");
                documentoCombo.Items.Add("GR");
            }
            else if (_consulta == Consulta.compra)
            {
                documentoCombo.Items.Add("VFR");
                documentoCombo.Items.Add("VFT");
                documentoCombo.Items.Add("PCO");
                documentoCombo.Items.Add("COT");
                documentoCombo.Items.Add("ECF");
                documentoCombo.Items.Add("VNC");
                documentoCombo.Items.Add("VGT");
                documentoCombo.Items.Add("VGR");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var doc = documentoCombo.SelectedItem.ToString();

            if (!_documentos.Contains(doc))
            {
                _documentos.Add(doc);
            }
            else 
            {
                _documentos.Remove(doc);
            }

            documentoList.Text = "";

            foreach (var item in _documentos)
            {
                documentoList.Text += $"{item}\n";
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            if (_consulta == Consulta.venda)
            {
                var dialog = new ClienteListagem(true);
                dialog.ShowDialog();

                _entidadeIds = dialog.GetClienteIdList();

                foreach (var item in dialog.GetClienteIdList())
                {
                    entidadeList.Text += $"{StaticProperty.clientes.Where(x => x.id == item).First().nome_fantasia}\n";
                };
            }
            else 
            {
                var dialog = new FornecedorListagem(true);
                dialog.ShowDialog();

                _entidadeIds = dialog.GetFornecedorIdList();

                foreach (var item in dialog.GetFornecedorIdList())
                {
                    entidadeList.Text += $"{StaticProperty.fornecedores.Where(x => x.id == item).First().nome_fantasia}\n";
                };
            }
        }

        private void btnArmazem_Click(object sender, EventArgs e)
        {
           var dialog = new ArmazemListagem(true);
           dialog.ShowDialog();

            armazemList.Text = "";

            _armazemIds = dialog.GetArmazemIdList();

           foreach (var item in dialog.GetArmazemIdList())
           {
                armazemList.Text += $"{StaticProperty.armazens.Where(x => x.id == item).First().descricao}\n";
           }
        }

        private void btnArtigo_Click(object sender, EventArgs e)
        {
            var dialog = new ArtigoListagem(true);

            dialog.ShowDialog();

            _artigoIds = dialog.GetArtigoIdList();

            artigoList.Text = "";

            foreach (var item in dialog.GetArtigoIdList())
            {
                artigoList.Text += $"{StaticProperty.artigos.Where(x => x.id == item).First().descricao}\n";    
            }
        }

        private async void btnImprimir_Click(object sender, EventArgs e)
        {

                DateTime dateStart = dataInicioCombo.Value; // Pegue do DateTimePicker
                DateTime dateEnd = dataFinalCombo.Value; // Pegue do DateTimePicker

                // Construa a query string


            if (_consulta == Consulta.venda)
            {
                string queryString = $"?clienteId={string.Join("&clienteId=", _entidadeIds)}" +
                   $"&documento={string.Join("&documento=", _documentos)}" +
                   $"&artigoId={string.Join("&artigoId=", _artigoIds)}";

                // Monte a URL completa
                string url = $"api/Relatorio/Venda/{dateStart:yyyy-MM-dd}/{dateEnd:yyyy-MM-dd}{queryString}";

                // Faça a requisição GET
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Verifique se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Leia o conteúdo da resposta
                    var resultado = await response.Content.ReadAsStringAsync();

                    _vendas = JsonConvert.DeserializeObject<List<VendaDTO>>(resultado);
                  
                }
            }
            if (_consulta == Consulta.compra)
            {
                string queryString = $"?clienteId={string.Join("&fornecedorId=", _entidadeIds)}" +
                   $"&documento={string.Join("&documento=", _documentos)}" +
                   $"&artigoId={string.Join("&artigoId=", _artigoIds)}";

                // Monte a URL completa
                string url = $"api/Relatorio/Compra/{dateStart:yyyy-MM-dd}/{dateEnd:yyyy-MM-dd}{queryString}";

                // Faça a requisição GET
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Verifique se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Leia o conteúdo da resposta
                    var resultado = await response.Content.ReadAsStringAsync();

                    _compras = JsonConvert.DeserializeObject<List<CompraDTO>>(resultado);

                }
            }
        }
    }
}
