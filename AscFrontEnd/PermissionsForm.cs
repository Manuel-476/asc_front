using System;
using System.CodeDom;
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
using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.Serie;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class PermissionsForm : Form
    {
        UserDTO _user;
        DataTable dt;
        DataTable dtSelected;
        Acao _acao;
        bool ok;

        int permissionId;
        int selectedId;

        public PermissionsForm(UserDTO user, Acao acao)
        {
            InitializeComponent();

            dt = new DataTable();

            _user = user;

            _acao = acao;

            ok = false;

            StaticProperty.relationUserPermissions = new List<RelationUserPermissionDTO>();
        }

        private void permissionGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                permissionId = int.Parse(permissionGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (_user == null)
                {
                    _user = new UserDTO();
                    _user.id = 0;
                }
                if (StaticProperty.relationUserPermissions.Where(x => x.permissionId == permissionId).Any())
                {
                    return;
                }

                StaticProperty.relationUserPermissions.Add(new RelationUserPermissionDTO() { userEntityId = _user.id, permissionId = permissionId, userId = 0, Id = 0 });


                dtSelected = new DataTable();
                dtSelected.Columns.Add("Id", typeof(int));
                dtSelected.Columns.Add("Descricao", typeof(string));

                if (StaticProperty.relationUserPermissions.Any())
                {
                    var permissions = StaticProperty.permissions.ToList();

                    foreach (var item in StaticProperty.relationUserPermissions)
                    {
                        if (permissions.Where(x => x.Id == item.permissionId).Any())
                        {
                            var permission = permissions.Where(x => x.Id == item.permissionId).First();
                            dtSelected.Rows.Add(item.permissionId, permission.descricao);

                        }
                    }

                    selecaoGridView.DataSource = dtSelected;

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        private void PermissionsForm_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Descricao", typeof(string));

            if (StaticProperty.permissions.Any())
            {
                foreach (var item in StaticProperty.permissions)
                {
                    dt.Rows.Add(item.Id, item.descricao);
                }

                permissionGridView.DataSource = dt;
            }

            btnEliminar.Enabled = false;

            if (_acao == Acao.Salvar)
            {
                btnOk.Text = "OK";
            }
            else if (_acao == Acao.Editar)
            {
                dtSelected = new DataTable();
                dtSelected.Columns.Add("Id", typeof(int));
                dtSelected.Columns.Add("Descricao", typeof(string));

                if (_user.userPermissions.Any())
                {
                    var permissions = StaticProperty.permissions.ToList();

                    foreach (var item in _user.userPermissions)
                    {
                        if (permissions.Where(x => x.Id == item.permissionId).Any())
                        {
                            var permission = permissions.Where(x => x.Id == item.permissionId).First();

                            StaticProperty.relationUserPermissions.Add(new RelationUserPermissionDTO() { Id = 0, permissionId = item.permissionId, userEntityId = _user.id });

                            dtSelected.Rows.Add(item.permissionId, permission.descricao);

                        }
                    }

                    selecaoGridView.DataSource = dtSelected;

                }

                btnOk.Text = "Salvar";
            }


        }

        private void selecaoGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedId = int.Parse(permissionGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (StaticProperty.relationUserPermissions.Where(x => x.permissionId == selectedId).Any())
            {
                var result = StaticProperty.relationUserPermissions.Where(x => x.permissionId == selectedId).First();

                StaticProperty.relationUserPermissions.Remove(result);

                dtSelected = new DataTable();
                dtSelected.Columns.Add("Id", typeof(int));
                dtSelected.Columns.Add("Descricao", typeof(string));

                if (StaticProperty.relationUserPermissions.Any())
                {
                    var permissions = StaticProperty.permissions.ToList();

                    foreach (var item in StaticProperty.relationUserPermissions)
                    {
                        if (permissions.Where(x => x.Id == item.permissionId).Any())
                        {
                            var permission = permissions.Where(x => x.Id == item.permissionId).First();
                            dtSelected.Rows.Add(item.permissionId, permission.descricao);

                        }
                    }

                    selecaoGridView.DataSource = dtSelected;

                    tudoCheck.Checked = false;
                }
                else
                {
                    MessageBox.Show("Impossivel concluir a ação", "Nenhuma Permissão foi selecionada", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                }
            }
        }



        private void PermissionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ok)
            {
                StaticProperty.relationUserPermissions.Clear();
            }
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {

            if (_acao == Acao.Salvar)
            {
                ok = true;

                this.Close();
            }
            else if (_acao == Acao.Editar)
            {
                List<UserPermissionsDTO> userPermissions = new List<UserPermissionsDTO>();

                var client = new HttpClient();
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
                    client.BaseAddress = new Uri("https://localhost:7200");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!StaticProperty.relationUserPermissions.Any())
                    {
                        return;
                    }

                    foreach (var item in StaticProperty.relationUserPermissions.ToList())
                    {
                        userPermissions.Add(StaticProperty.permissions.Where(x => x.Id == item.permissionId).First());
                    }

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(userPermissions);

                    // Envio dos dados para a API
                    HttpResponseMessage responsePermission = await client.PutAsync($"/api/Funcionario/User/Permissions/{_user.id}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responsePermission.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Feito com sucesso", "As permissões foram alteradas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro", "Alguma coisa correu mal ao tentar alterar as permissões", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao Activar Serie: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void tudoCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (tudoCheck.Checked)
            {
                dtSelected = new DataTable();
                dtSelected.Columns.Add("Id", typeof(int));
                dtSelected.Columns.Add("Descricao", typeof(string));

                StaticProperty.relationUserPermissions.Clear();
                
                StaticProperty.relationUserPermissions = new List<RelationUserPermissionDTO>();

                if (_user == null)
                {
                    _user = new UserDTO();
                    _user.id = 0;
                }

                if (StaticProperty.permissions.Any())
                {
                    foreach (var item in StaticProperty.permissions)
                    {
                        StaticProperty.relationUserPermissions.Add(new RelationUserPermissionDTO() { Id = 0, permissionId = item.Id, userEntityId = _user.id });

                        dtSelected.Rows.Add(item.Id, item.descricao);


                    }

                    selecaoGridView.DataSource = dtSelected;
                }

            }
        }
    }
}
