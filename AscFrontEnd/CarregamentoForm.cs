using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using AscFrontEnd.DTOs.Venda;
using EAscFrontEnd;
using ERP_Buyer.Application.DTOs.Documentos;
using ERP_Seller.Application.DTOs.Documentos;
using Newtonsoft.Json;
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

namespace AscFrontEnd
{
    public partial class CarregamentoForm : Form
    {
        public CarregamentoForm()
        {
            InitializeComponent();
        }

        private async void CarregamentoForm_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();

            var responseVft = await client.GetAsync($"https://localhost:7200/api/Compra/VftByRelations");

            if (responseVft.IsSuccessStatusCode)
            {
                var contentVft = await responseVft.Content.ReadAsStringAsync();
                StaticProperty.vfts = JsonConvert.DeserializeObject<List<VftDTO>>(contentVft);
            }

            var responseVfr = await client.GetAsync($"https://localhost:7200/api/Compra/VfrByRelations");

            if (responseVfr.IsSuccessStatusCode)
            {
                var contentVfr = await responseVft.Content.ReadAsStringAsync();
                StaticProperty.vfrs = JsonConvert.DeserializeObject<List<VfrDTO>>(contentVfr);
            }

            var responseVgt = await client.GetAsync($"https://localhost:7200/api/Compra/VgtByRelations");

            if (responseVgt.IsSuccessStatusCode)
            {
                var contentVgt = await responseVgt.Content.ReadAsStringAsync();
                StaticProperty.vgts = JsonConvert.DeserializeObject<List<VgtDTO>>(contentVgt);
            }

            var responsePco = await client.GetAsync($"https://localhost:7200/api/Compra/PcoByRelations");

            if (responsePco.IsSuccessStatusCode)
            {
                var contentPco = await responsePco.Content.ReadAsStringAsync();
                StaticProperty.pcos = JsonConvert.DeserializeObject<List<PedidoCotacaoDTO>>(contentPco);
            }

            var responseCot = await client.GetAsync($"https://localhost:7200/api/Compra/CotByRelations");

            if (responseCot.IsSuccessStatusCode)
            {
                var contentCot = await responseCot.Content.ReadAsStringAsync();
                StaticProperty.cots = JsonConvert.DeserializeObject<List<CotacaoDTO>>(contentCot);
            }

            var responseEcf = await client.GetAsync($"https://localhost:7200/api/Compra/EcfByRelations");

            if (responseEcf.IsSuccessStatusCode)
            {
                var contentEcf = await responseEcf.Content.ReadAsStringAsync();
                StaticProperty.ecfs = JsonConvert.DeserializeObject<List<EncomendaFornecedorDTO>>(contentEcf);
            }

            var responseVnc = await client.GetAsync($"https://localhost:7200/api/Compra/VncByRelations");

            if (responseVnc.IsSuccessStatusCode)
            {
                var contentVnc = await responseVnc.Content.ReadAsStringAsync();
                StaticProperty.vncs = JsonConvert.DeserializeObject<List<VncDTO>>(contentVnc);
            }

            var responseVnd = await client.GetAsync($"https://localhost:7200/api/Compra/VndByRelations");

            if (responseVnd.IsSuccessStatusCode)
            {
                var contentVnd = await responseVnd.Content.ReadAsStringAsync();
                StaticProperty.vnds = JsonConvert.DeserializeObject<List<VndDTO>>(contentVnd);
            }

            // Venda
            var responseFr = await client.GetAsync($"https://localhost:7200/api/Venda/FrByRelations");

            if (responseFr.IsSuccessStatusCode)
            {
                var contentFr = await responseFr.Content.ReadAsStringAsync();
                StaticProperty.frs = JsonConvert.DeserializeObject<List<FrDTO>>(contentFr);
            }

            var responseFt = await client.GetAsync($"https://localhost:7200/api/Venda/FtByRelations");

            if (responseFt.IsSuccessStatusCode)
            {
                var contentFt = await responseFt.Content.ReadAsStringAsync();
                StaticProperty.fts = JsonConvert.DeserializeObject<List<FtDTO>>(contentFt);
            }

            var responseEcl = await client.GetAsync($"https://localhost:7200/api/Venda/EclByRelations");

            if (responseEcl.IsSuccessStatusCode)
            {
                var contentEcl = await responseEcl.Content.ReadAsStringAsync();
                StaticProperty.ecls = JsonConvert.DeserializeObject<List<EncomendaClienteDTO>>(contentEcl);
            }

            var responseFp = await client.GetAsync($"https://localhost:7200/api/Venda/FpByRelations");

            if (responseFp.IsSuccessStatusCode)
            {
                var contentFp = await responseFp.Content.ReadAsStringAsync();
                StaticProperty.fps = JsonConvert.DeserializeObject<List<FaturaProformaDTO>>(contentFp);
            }

            var responseNc = await client.GetAsync($"https://localhost:7200/api/Venda/NcByRelations");

            if (responseNc.IsSuccessStatusCode)
            {
                var contentNc = await responseNc.Content.ReadAsStringAsync();
                StaticProperty.ncs = JsonConvert.DeserializeObject<List<NcDTO>>(contentNc);
            }

            var responseNd = await client.GetAsync($"https://localhost:7200/api/Venda/NdByRelations");

            if (responseNd.IsSuccessStatusCode)
            {
                var contentNd = await responseNd.Content.ReadAsStringAsync();
                StaticProperty.nds = JsonConvert.DeserializeObject<List<NdDTO>>(contentNd);
            }

            // Cliente
            var responseCliente = await client.GetAsync($"https://localhost:7200/api/Cliente/ClientesByRelations");

            if (responseCliente.IsSuccessStatusCode)
            {
                var contentCliente = await responseCliente.Content.ReadAsStringAsync();
                StaticProperty.clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(contentCliente);
            }

            // Fornecedor
            var responseFornecedor = await client.GetAsync($"https://localhost:7200/api/Fornecedor/FornecedoresByRelations");

            if (responseFornecedor.IsSuccessStatusCode)
            {
                var contentFornecedor = await responseCliente.Content.ReadAsStringAsync();
                StaticProperty.fornecedores = JsonConvert.DeserializeObject<List<FornecedorDTO>>(contentFornecedor);
            }

            // Artigo
            var responseArtigo = await client.GetAsync($"https://localhost:7200/api/Com/ArtigoByRelations");

            if (responseArtigo.IsSuccessStatusCode)
            {
                var contentArtigo = await responseCliente.Content.ReadAsStringAsync();
                StaticProperty.artigos = JsonConvert.DeserializeObject<List<ArtigoDTO>>(contentArtigo);
            }

            // Amazem
            var responseArmazem = await client.GetAsync($"https://localhost:7200/api/Armazem/ArmazensByRelations");

            if (responseArmazem.IsSuccessStatusCode)
            {
                var contentArmazem = await responseArmazem.Content.ReadAsStringAsync();
                StaticProperty.armazens = JsonConvert.DeserializeObject<List<ArmazemDTO>>(contentArmazem);
            }

            // Nota Pagamento
          /*  var responseNp = await client.GetAsync($"https://localhost:7200/api/Armazem/ArmazensByRelations");

            if (responseArmazem.IsSuccessStatusCode)
            {
                var contentArmazem = await responseArmazem.Content.ReadAsStringAsync();
                StaticProperty.armazens = JsonConvert.DeserializeObject<List<ArmazemDTO>>(contentArmazem);
            }*/
        }
    }
}
