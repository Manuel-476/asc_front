using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.StaticsDto;
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
    public partial class FornecedorListagem : Form
    {
        public FornecedorListagem()
        {
            InitializeComponent();
        }

        private async void FornecedorListagem_Load(object sender, EventArgs e)
        {


                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("nif", typeof(string));
                dt.Columns.Add("pessoa", typeof(string));
                dt.Columns.Add("localizacao", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.fornecedores.Where(f=>f.status == DTOs.Enums.Enums.Status.activo && f.id != 1 && f.empresaid == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                    tabelaFornecedor.DataSource = dt;
                }
            
        }


        private void tabelaFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkDesconhecido.Checked)
            {
                StaticProperty.entityId = 1;
                return;
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém o valor da célula clicada
                string id = tabelaFornecedor.Rows[e.RowIndex].Cells[0].Value.ToString();
                string nome = tabelaFornecedor.Rows[e.RowIndex].Cells[1].Value.ToString();

                StaticProperty.entityId = int.Parse(id);
                StaticProperty.nome = nome;
            }

            this.Close();
        }

        private async void pesqText_TextChanged(object sender, EventArgs e)
        {

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("nif", typeof(string));
                dt.Columns.Add("pessoa", typeof(string));
                dt.Columns.Add("localizacao", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.fornecedores)
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                    tabelaFornecedor.DataSource = dt;
                }
            
        }

        private void checkDesconhecido_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDesconhecido.Checked)
            {
                StaticProperty.entityId = 1;
            }
        }
    }
}
