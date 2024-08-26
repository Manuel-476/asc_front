using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Enums;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
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
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class LiquidaDivida : Form
    {
        int _docId;
        Entidade _entidade;
        string documento;
        public LiquidaDivida(int docId, Entidade entidade)
        {
            InitializeComponent();
            _docId = docId;
            this._entidade = entidade;
        }

        private async void LiquidaDivida_Load(object sender, EventArgs e)
        {
            string codigo = string.Empty;
            float divida = 0, regulado = 0;
            var client = new HttpClient();

            if (StaticProperty.series == null)
            {
                MessageBox.Show("Nenhuma Serie Foi Criada", "Precisa de uma Serie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_entidade == Entidade.fornecedor) 
            {
                codigo = "np";
               
                var vftResult = StaticProperty.vfts.Where(vft => vft.id == _docId).First();
                var result = StaticProperty.vfts.Where(vft => vft.fornecedorId == vftResult.fornecedorId).ToList();

                foreach (var item in result)
                {
                    if (item.pago == Enums.OpcaoBinaria.Nao)
                    {
                        divida += item.vftArtigo.Sum(d => d.preco * d.qtd);
                        regulado += StaticProperty.nps.Where(np => np.vftId == item.id).Sum(np => np.quantia);
                    }
                }
                entidadeLabel.Text = StaticProperty.fornecedores.Where(f => f.id == vftResult.fornecedorId).First().nome_fantasia;
                dividaLabel.Text = $"Divida: {divida}";
                liquidado.Text = $"Liquidado: {liquidado}";

            }
            if (_entidade == Entidade.cliente)
            {
                codigo = "re";
                var ftResult = StaticProperty.fts.Where(ft => ft.id == _docId).First();
                var result = StaticProperty.fts.Where(ft => ft.clienteId == ftResult.clienteId).ToList();


                foreach (var item in result)
                {
                    if (item.pago == Enums.OpcaoBinaria.Nao)
                    {
                        divida += item.ftArtigo.Sum(d => d.preco * d.qtd);
                        regulado += StaticProperty.recibos.Where(re => re.ftId == item.id).Sum(np => np.quantia);
                    }
                }
                entidadeLabel.Text = StaticProperty.clientes.Where(f => f.id == ftResult.clienteId).First().nome_fantasia;
                dividaLabel.Text = $"Divida: {divida}";
                liquidado.Text = $"Liquidado: {liquidado}";
            }

            var response = await client.GetAsync($"https://localhost:7200/api/serie/codigoDocumento/{codigo}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string dados = content.ToString();

                documentoLabel.Text = dados.ToString();
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string json = string.Empty;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            if (_entidade == Entidade.fornecedor)
            {

                var np = new NpDTO()
                {
                    documento = documentoLabel.Text.ToString(),
                    created = DateTime.UtcNow.Date,
                    quantia = float.Parse(valorTxt.Text),
                    vftId = _docId
                };

                // Conversão do objeto Film para JSON
                json = System.Text.Json.JsonSerializer.Serialize(np);

                // Envio dos dados para a API
                await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Np/{1}", new StringContent(json, Encoding.UTF8, "application/json"));
            }
            if (_entidade == Entidade.cliente)
            {

                var re = new ReciboDTO()
                {
                    documento = documentoLabel.Text.ToString(),
                    created = DateTime.UtcNow.Date,
                    quantia = float.Parse(valorTxt.Text),
                    ftId = _docId
                };

                // Conversão do objeto Film para JSON
                json = System.Text.Json.JsonSerializer.Serialize(re);

                // Envio dos dados para a API
                await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Re/{1}", new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }
    }
}
