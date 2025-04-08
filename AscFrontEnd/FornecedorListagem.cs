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
        bool _multi = false;
        List<int> _fornecedorIds;
        public FornecedorListagem()
        {
            InitializeComponent();
        }
        public FornecedorListagem(bool multi, List<int> fornecedorIds)
        {
            InitializeComponent();

            _multi = multi;

            _fornecedorIds = fornecedorIds ?? new List<int>();
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

            if (_multi)
            {
                tabelaFornecedor.MultiSelect = true;
                checkDesconhecido.Visible = false;

                // Adiciona linhas ao DataTable
                foreach (var item in StaticProperty.fornecedores.Where(f => f.status == DTOs.Enums.Enums.Status.activo && f.id != 1 && f.empresaid == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                }
                    tabelaFornecedor.DataSource = dt;
                // Define o DataSource do DataGridView (fora do loop)
            

                // Seleciona automaticamente as linhas cujos IDs estão em _artigoIds
                if (_fornecedorIds != null && _fornecedorIds.Any())
                {
                    foreach (DataGridViewRow row in tabelaFornecedor.Rows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value); // Pega o valor da coluna "id"
                        if (_fornecedorIds.Contains(id))
                        {
                            row.Selected = true; // Seleciona a linha
                        }
                    }
                }

                // Opcional: Garante que o DataGridView permita seleção múltipla
            }
            else
            {
                tabelaFornecedor.MultiSelect = false;

                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.fornecedores.Where(f => f.status == DTOs.Enums.Enums.Status.activo && f.id != 1 && f.empresaid == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                }
                    tabelaFornecedor.DataSource = dt;

                if (StaticProperty.entityId == 1)
                {
                    checkDesconhecido.Checked = true;
                }
                else
                {
                    checkDesconhecido.Checked = false;
                }
            }

        }


        private void tabelaFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = string.Empty;
                string nome = string.Empty;

                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    id = tabelaFornecedor.Rows[e.RowIndex].Cells[0].Value.ToString();
                    nome = tabelaFornecedor.Rows[e.RowIndex].Cells[1].Value.ToString();
                }

                if (!_multi)
                {
                    if (checkDesconhecido.Checked)
                    {
                        checkDesconhecido.Checked = false;
                    }

                    StaticProperty.entityId = int.Parse(id);
                    StaticProperty.nome = nome;

                    this.Close();
                }
                else
                {
                    if (!_fornecedorIds.Contains(int.Parse(id)))
                    {
                        _fornecedorIds.Add(int.Parse(id));
                    }
                    else
                    {
                        _fornecedorIds.Remove(int.Parse(id));
                    }
                }
            }
            catch { return; }
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

        public List<int> GetFornecedorIdList()
        {
            return _fornecedorIds;
        }
    }
}
