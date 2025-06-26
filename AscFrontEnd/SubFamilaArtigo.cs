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
using AscFrontEnd.DTOs.StaticsDto;
using Newtonsoft.Json;
using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;

namespace AscFrontEnd
{
    public partial class SubFamilaArtigo : Form
    {
        Requisicoes _requisicoes;
        HttpClient client;
        public SubFamilaArtigo()
        {
            InitializeComponent();

            _requisicoes = new Requisicoes();

            // Configuração do HttpClient
           client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void balvarBtn_Click(object sender, EventArgs e)
        {
            if (OutrasValidacoes.SubfamiliaCodigoExiste(codigotxt.Text.ToString()))
            {
                return;
            }
            string codigo = codigotxt.Text;
            string descricao = descricaotxt.Text;

            var subFamilia = new SubFamiliaDTO()
            {
                codigo = codigo,
                descricao = descricao,
                empresaId = StaticProperty.empresaId
            };



            // Conversão do objeto Film para JSON
            string json = System.Text.Json.JsonSerializer.Serialize(subFamilia);

            // Envio dos dados para a API
            var response = await client.PostAsync("api/Artigo/SubFamilia", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("SubFamilia Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                // Actualizar propridade estatica subfamilias
                // Sub-Familia
                await _requisicoes.GetSubFamilias();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }

            WindowsConfig.LimparFormulario(this);
        }

        private void SubFamilaArtigo_Load(object sender, EventArgs e)
        {

        }
    }
}
