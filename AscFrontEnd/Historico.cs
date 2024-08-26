using AscFrontEnd.DTOs.Actividades;
using AscFrontEnd.DTOs.StaticsDto;
using Newtonsoft.Json;
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

namespace AscFrontEnd
{
    public partial class Historico : Form
    {
        DataTable dt;
        HttpClient client;
        string documento = string.Empty;
        public Historico()
        {
            InitializeComponent();
          
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
        }

        private async void Historico_Load(object sender, EventArgs e)
        {
            radioVenda.Checked = true;

            // Actividade
            var responseAct = await client.GetAsync($"https://localhost:7200/api/Actividade/WithRelations");

            if (responseAct.IsSuccessStatusCode)
            {
                var contentAct = await responseAct.Content.ReadAsStringAsync();
                StaticProperty.actividades = JsonConvert.DeserializeObject<List<ActividadeDTO>>(contentAct);
            }
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Funcionario", typeof(string));
            dt.Columns.Add("Data", typeof(DateTime));

            foreach (var item in StaticProperty.actividades.Where(x => StaticProperty.funcionarios.Where(f => f.Id == x.funcionarioId).First().empresaid == StaticProperty.empresaId &&
                                                                (x.actividade == DTOs.Enums.Enums.Actividade.vendaFR || x.actividade == DTOs.Enums.Enums.Actividade.vendaFT
                                                                 || x.actividade == DTOs.Enums.Enums.Actividade.vendaGT || x.actividade == DTOs.Enums.Enums.Actividade.vendaNC)))
            {
                if (item.actividade == DTOs.Enums.Enums.Actividade.vendaFR) { documento = StaticProperty.frs.Where(x => x.id == item.acaoId).First().documento.ToString(); }
                else if (item.actividade == DTOs.Enums.Enums.Actividade.vendaFT) { documento = StaticProperty.fts.Where(x => x.id == item.acaoId).First().documento.ToString(); }
                else if (item.actividade == DTOs.Enums.Enums.Actividade.vendaGT) { documento = StaticProperty.gts.Where(x => x.id == item.acaoId).First().documento.ToString(); }
                else if (item.actividade == DTOs.Enums.Enums.Actividade.vendaNC) { documento = StaticProperty.ncs.Where(x => x.id == item.acaoId).First().documento.ToString(); }

                dt.Rows.Add(item.id, documento, StaticProperty.funcionarios.Where(x=>x.Id == item.funcionarioId).First().Nome, item.data);
            }

            historicoTable.DataSource = dt;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVenda.Checked)
            {
                dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Funcionario", typeof(string));
                dt.Columns.Add("Data", typeof(DateTime));

                foreach (var item in StaticProperty.actividades.Where(x => StaticProperty.funcionarios.Where(f=>f.Id == x.funcionarioId).First().empresaid == StaticProperty.empresaId &&
                                                                    (x.actividade == DTOs.Enums.Enums.Actividade.vendaFR || x.actividade == DTOs.Enums.Enums.Actividade.vendaFT
                                                                     || x.actividade == DTOs.Enums.Enums.Actividade.vendaGT || x.actividade == DTOs.Enums.Enums.Actividade.vendaNC)))
                {
                    if (item.actividade == DTOs.Enums.Enums.Actividade.vendaFR) { documento = StaticProperty.frs.Where(x => x.id == item.acaoId).First().documento.ToString(); }
                    else if (item.actividade == DTOs.Enums.Enums.Actividade.vendaFT) { documento = StaticProperty.fts.Where(x => x.id == item.acaoId).First().documento.ToString(); }
                    else if (item.actividade == DTOs.Enums.Enums.Actividade.vendaGT) { documento = StaticProperty.gts.Where(x => x.id == item.acaoId).First().documento.ToString(); }
                    else if (item.actividade == DTOs.Enums.Enums.Actividade.vendaNC) { documento = StaticProperty.ncs.Where(x => x.id == item.acaoId).First().documento.ToString(); }

                    dt.Rows.Add(item.id, documento, StaticProperty.funcionarios.Where(x => x.Id == item.funcionarioId).First().Nome, item.data);
                }

                historicoTable.DataSource = dt;
            }
        }

        private void radioCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCompra.Checked)
            {
                dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Funcionario", typeof(string));
                dt.Columns.Add("Data", typeof(DateTime));

                foreach (var item in StaticProperty.actividades.Where(x => StaticProperty.funcionarios.Where(f => f.Id == x.funcionarioId).First().empresaid == StaticProperty.empresaId &&
                                                                    (x.actividade == DTOs.Enums.Enums.Actividade.compraVFR || x.actividade == DTOs.Enums.Enums.Actividade.compraVFT
                                                                     || x.actividade == DTOs.Enums.Enums.Actividade.compraVGT || x.actividade == DTOs.Enums.Enums.Actividade.compraVNC)))
                {
                    if (item.actividade == DTOs.Enums.Enums.Actividade.compraVFR) { documento = StaticProperty.vfrs.Where(x => x.id == item.acaoId).First().documento.ToString(); }
                    else if (item.actividade == DTOs.Enums.Enums.Actividade.compraVFT) { documento = StaticProperty.vfts.Where(x => x.id == item.acaoId).First().documento.ToString(); }
                    else if (item.actividade == DTOs.Enums.Enums.Actividade.compraVGT) { documento = StaticProperty.vgts.Where(x => x.id == item.acaoId).First().documento.ToString(); }
                    else if (item.actividade == DTOs.Enums.Enums.Actividade.compraVNC) { documento = StaticProperty.vncs.Where(x => x.id == item.acaoId).First().documento.ToString(); }

                    dt.Rows.Add(item.id, documento, StaticProperty.funcionarios.Where(x => x.Id == item.funcionarioId).First().Nome, item.data);
                }

                historicoTable.DataSource = dt;
            }
        }
    }
}
