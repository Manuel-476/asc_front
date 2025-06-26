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
using AscFrontEnd.Application.Validacao;
using System.Globalization;
using AscFrontEnd.Application;
using AscFrontEnd.DTOs.Funcionario;


namespace AscFrontEnd
{
    public partial class Artigo : Form
    {
        OpcaoBinaria regimeIva = OpcaoBinaria.Sim;
        string codigoIva = string.Empty;
        int localId;
        int armazemId = 0;

        UserDTO _user;

        public Artigo(UserDTO user)
        {
            InitializeComponent();

            _user = user;

            precotxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            precotxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try {
                int armazemId = 0;
                if (OutrasValidacoes.ArtigoCodigoExiste(codigotxt.Text.ToString()))
                {
                    return;
                }
                if (movStockCheck.Checked)
                {
                    if (StaticProperty.armazens.Where(arm => arm.codigo == armazemCombo.Text.ToString()).Any())
                    {
                        armazemId = StaticProperty.armazens.Where(arm => arm.codigo == armazemCombo.Text.ToString()).First().id;
                    }

                    if (string.IsNullOrEmpty(localCombo.SelectedItem.ToString()))
                    {
                        MessageBox.Show("A localizaçao do artigo no armazem precisa ser selecionada", "Sem Localização disponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                if (string.IsNullOrEmpty(comboUnVenda.Text.ToString()) || string.IsNullOrEmpty(comboUnCompra.Text.ToString()))
                {
                    MessageBox.Show("Alguma unidade faltou ser selecionada", "Verifica as unidade do artigo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(regimeIvaCombo.Text.ToString()))
                {
                    MessageBox.Show("Nenhum regime do iva foi selecionado", "Selecione um regime", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.Equals(regimeIvaCombo.SelectedItem.ToString(), "Geral", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(ivaCombo.Text))
                    {
                        MessageBox.Show("Quando o regime é geral o Iva precisa ser definido obrigatoriamente ", "Defina o valor do Iva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

            ArtigoDTO artigo = new ArtigoDTO()
            {
              codigo = codigotxt.Text,
              armazemId = armazemId,
              descricao = descricaotxt.Text,
              familiaId = StaticProperty.familias.Where(x => x.codigo == familiaCombo.Text.ToString()).Any() ? StaticProperty.familias.Where(x => x.codigo == familiaCombo.Text.ToString()).First().id : 0,
              subFamiliaId =  StaticProperty.subFamilias.Where(x => x.codigo == subFamiliaCombo.Text.ToString()).Any() ? StaticProperty.subFamilias.Where(x => x.codigo == subFamiliaCombo.Text.ToString()).First().id : 0,
              marcaId = StaticProperty.marcas.Where(x => x.codigo == marcaCombo.Text.ToString()).Any() ? StaticProperty.marcas.Where(x => x.codigo == marcaCombo.Text.ToString()).First().id : 0,
              modeloId = StaticProperty.modelos.Where(x => x.codigo == modeloCombo.Text.ToString()).Any() ? StaticProperty.modelos.Where(x => x.codigo == modeloCombo.Text.ToString()).First().id : 0,
              mov_stock = movStockCheck.Checked?OpcaoBinaria.Sim:OpcaoBinaria.Nao,
              mov_lote = movStockCheck.Checked?OpcaoBinaria.Sim:OpcaoBinaria.Nao,
              localizacaoArtigoId = localId,
              codigo_barra = codBarra.Text,
              num_serie = numSerie.Text,
              preco_unitario = !string.IsNullOrEmpty(precotxt.Text.ToString()) ? float.Parse(precotxt.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) : 0f,
              unidadeCompra = comboUnCompra.SelectedItem.ToString(),
              unidadeVenda = comboUnVenda.SelectedItem.ToString(),
              regimeIva = regimeIva,
              codigoIva = codigoIva,
              iva = string.IsNullOrEmpty(ivaCombo.Text)?0:float.Parse(ivaCombo.Text),
              empresaId = StaticProperty.empresaId,
            };

            // Configuração do HttpClient
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(artigo);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync($"api/Artigo/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Artigo Salvo Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                // Artigo
                var responseArtigo = await client.GetAsync($"api/Artigo");

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

            WindowsConfig.LimparFormulario(this);

            await Actualizar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listagem_Click(object sender, EventArgs e)
        {
            ArtigoListagem artigoListagem = new ArtigoListagem(_user);
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
            if (StaticProperty.armazens !=null) 
            {
                foreach (var item in StaticProperty.armazens.Where(arm => arm.empresaId == StaticProperty.empresaId).ToList())
                {
                    armazemCombo.Items.Add(item.codigo);
                } 
            }
            if (StaticProperty.familias != null)
            {
                foreach (var item in StaticProperty.familias.Where(fam => fam.empresaId == StaticProperty.empresaId).ToList())
                {
                    familiaCombo.Items.Add(item.codigo);
                }
            }
            if (StaticProperty.subFamilias != null)
            {
                foreach (var item in StaticProperty.subFamilias.Where(fam => fam.empresaId == StaticProperty.empresaId).ToList())
                {
                    subFamiliaCombo.Items.Add(item.codigo);
                }
            }
            if (StaticProperty.modelos != null)
            {
                foreach (var item in StaticProperty.modelos.Where(fam => fam.empresaId == StaticProperty.empresaId).ToList())
                {
                    modeloCombo.Items.Add(item.codigo);
                }
            }
            if (StaticProperty.marcas != null)
            {
                foreach (var item in StaticProperty.marcas.Where(fam => fam.empresaId == StaticProperty.empresaId).ToList())
                {
                    marcaCombo.Items.Add(item.codigo);
                }
            }
            if (StaticProperty.ivas != null)
            {
                foreach (var item in StaticProperty.ivas.Where(iva => iva.empresaId == 0 || iva.empresaId == StaticProperty.empresaId).ToList())
                {
                    ivaCombo.Items.Add(item.valorIva);
                }
            }
            if (StaticProperty.unidades != null)
            {
                foreach (var item in StaticProperty.unidades.Where(x => x.empresaId == 0 || x.empresaId == StaticProperty.empresaId).ToList())
                {
                    comboUnCompra.Items.Add(item.codigo);
                    comboUnVenda.Items.Add(item.codigo);
                }
            }
            mencaoCombo.Enabled = false;
            ivaCombo.Enabled = false;

            descricaoIvaTxt.Text = "";

            regimeIvaCombo.Items.Add("Isento");
            regimeIvaCombo.Items.Add("Geral");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (movStockCheck.Checked) 
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
            if (string.IsNullOrEmpty(armazemCombo.Text.ToString())) 
            {
                return;
            }

            string result = string.Empty;

            armazemId = StaticProperty.armazens.Where(arm => arm.codigo == armazemCombo.SelectedItem && arm.empresaId == StaticProperty.empresaId).Any()
                       ? StaticProperty.armazens.Where(arm => arm.codigo == armazemCombo.SelectedItem && arm.empresaId == StaticProperty.empresaId).First().id : 0;

            localCombo.Items.Clear();

            if (StaticProperty.locationStores != null && StaticProperty.locationArtigos != null)
            {
                foreach (var item in StaticProperty.locationStores.Where(fam => fam.armazemId == armazemId).ToList())
                {
                    if (!StaticProperty.locationArtigos.Where(x => x.locationStoreId == item.id && x.qtd == 0).Any() && StaticProperty.locationArtigos.Any() && StaticProperty.locationArtigos.Where(x => x.locationStoreId == item.id).Any())
                    {
                        result = "Este armazem não tem localização disponível todas localizações já armazenam artigos";
                    }
                    else if (StaticProperty.locationArtigos.Where(x => x.locationStoreId == item.id && x.qtd == 0).Any() || !StaticProperty.locationArtigos.Any() || !StaticProperty.locationArtigos.Where(x => x.locationStoreId == item.id).Any())
                    {
                        localCombo.Items.Add(item.codigo);
                        result = string.Empty;
                    }
                }
                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result, "Sem Localização disponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void regimeIvaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(regimeIvaCombo.Text.ToString())) 
            {
                return;
            }
            if (string.Equals(regimeIvaCombo.SelectedItem.ToString(), "Geral", StringComparison.OrdinalIgnoreCase)) 
            {
                regimeIva = OpcaoBinaria.Sim;
                mencaoCombo.Enabled = false;
                ivaCombo.Enabled = true;
                mencaoCombo.Items.Clear();
                descricaoIvaTxt.Text = "";
            }
            else if (string.Equals(regimeIvaCombo.SelectedItem.ToString(), "Isento", StringComparison.OrdinalIgnoreCase)) 
            {
                regimeIva = OpcaoBinaria.Nao;
                mencaoCombo.Enabled = true;
                ivaCombo.Enabled = false;

                foreach(var motivo in StaticProperty.motivosIsencao) 
                {
                    mencaoCombo.Items.Add(motivo.mencao);
                }
               
            }
        }

        private void mencaoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mencaoCombo.Text.ToString()))
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
            if (string.IsNullOrEmpty(localCombo.Text.ToString())) 
            {
                return;
            }

            this.localId = StaticProperty.locationStores.Where(arm => arm.codigo == localCombo.Text.ToString() && arm.armazemId == armazemId).First().id;

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

        private void familiaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await Actualizar();
        }

        public async Task Actualizar()
        {
            await new Requisicoes().SystemRefresh();

            armazemCombo.Items.Clear();
            localCombo.Items.Clear();
            familiaCombo.Items.Clear();
            subFamiliaCombo.Items.Clear();
            modeloCombo.Items.Clear();
            marcaCombo.Items.Clear();
            ivaCombo.Items.Clear();
            comboUnVenda.Items.Clear();
            comboUnCompra.Items.Clear();
            regimeIvaCombo.Items.Clear();

            Artigo_Load(this, EventArgs.Empty);
        }

        private void btnActualizar_MouseMove(object sender, MouseEventArgs e)
        {
            btnActualizar.BackColor = Color.White;
            btnActualizar.ForeColor = Color.Black;
        }

        private void btnActualizar_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
            button3.ForeColor = Color.White;
        }
    }
}
