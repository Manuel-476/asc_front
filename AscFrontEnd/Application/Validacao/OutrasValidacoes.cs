using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.Files;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using static AscFrontEnd.DTOs.Enums.Enums;
using AscFrontEnd.DTOs.Funcionario;

namespace AscFrontEnd.Application.Validacao
{
    public class OutrasValidacoes
    {

        public static bool SerieExist(UserDTO user)
        {
            bool result = true;
            if (StaticProperty.series != null)
            {
                if (!StaticProperty.series.Where(x => x.status == OpcaoBinaria.Sim && x.EmpresaId == StaticProperty.empresaId).Any())
                {
                    result = false;
                    if (user.nivel_acesso.Equals("Tecnico") || user.nivel_acesso.Equals("Administrador"))
                    {
                        if (MessageBox.Show("Nenhuma serie foi criada\nDeseja criar uma serie?", "Imposivel concluir a acao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            new SerieForm().ShowDialog();
                        }
                        else
                        {
                            return result;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma serie foi criada\nDeseja criar uma serie?", "Imposivel concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return result;
        }

        public static bool ArtigoCodigoExiste(string codigo)
        {
            if (StaticProperty.artigos != null)
            {
                if (StaticProperty.artigos.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já existe um artigo com este codigo!", "O codigo do Artigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return true;
                }
            }
            return false;
        }
        public static bool FamiliaCodigoExiste(string codigo)
        {
            if (StaticProperty.familias != null)
            {
                if (StaticProperty.familias.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já foi cadastrada uma família com este codigo!", "O codigo  já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return true;
                }
            }
            return false;
        }
        public static bool SubfamiliaCodigoExiste(string codigo)
        {
            if (StaticProperty.subFamilias != null)
            {
                if (StaticProperty.subFamilias.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já foi cadastrada uma sub-família com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return true;
                }
            }
            return false;
        }
        public static bool MarcaCodigoExiste(string codigo)
        {
            if (StaticProperty.marcas != null)
            {
                if (StaticProperty.marcas.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já foi cadastrada uma marca com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return true;
                }
            }
            return false;
        }
        public static bool ModeloCodigoExiste(string codigo)
        {
            if (StaticProperty.modelos != null)
            {
                if (StaticProperty.modelos.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já foi cadastrada um modelos com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }
        public static bool UnidadeCodigoExiste(string codigo)
        {
            if (StaticProperty.unidades != null)
            {
                if (StaticProperty.unidades.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já foi cadastrada uma unidade com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }
        public static bool ArmazemCodigoExiste(string codigo)
        {
            if (StaticProperty.armazens != null)
            {
                if (StaticProperty.armazens.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já foi cadastrada um armazém com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }
        public static bool LocalizacaoCodigoExiste(string codigo)
        {
            if (StaticProperty.locationStores != null)
            {
                if (StaticProperty.armazens != null)
                {
                    foreach (var store in StaticProperty.armazens.Where(a => a.empresaId == StaticProperty.empresaId))
                    {
                        if (StaticProperty.locationStores.Where(x => x.armazemId == StaticProperty.empresaId && x.codigo == codigo).Any())
                        {
                            MessageBox.Show("Já foi cadastrada uma localização com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool FormaPagamentoCodigoExiste(string codigo)
        {
            if (StaticProperty.formasPagamento != null)
            {
                if (StaticProperty.formasPagamento.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já foi cadastrada uma forma de pagamento com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return true;
                }

            }
            return false;
        }
        public static bool CaixaCodigoExiste(string codigo)
        {
            if (StaticProperty.caixas != null)
            {
                if (StaticProperty.caixas.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já foi cadastrada um caixa com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }

            }
            return false;
        }
        public static bool BancoCodigoExiste(string codigo)
        {
            if (StaticProperty.bancos != null)
            {
                if (StaticProperty.bancos.Where(x => x.empresaId == StaticProperty.empresaId && x.codigo == codigo).Any())
                {
                    MessageBox.Show("Já foi cadastrada um banco com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }

            }
            return false;
        }
        public static bool ClienteCodigoExiste(string codigo, int clienteId)
        {
            if (StaticProperty.clienteFiliais != null)
            {
                if (StaticProperty.clientes != null)
                {
                    foreach(var cl in StaticProperty.clientes.Where(x => x.id == clienteId).ToList())
                    {
                        if (cl.clienteFiliais != null) 
                        {
                            foreach (var fcl in cl.clienteFiliais)
                            {
                                if (fcl.codigo == codigo)
                                {
                                    MessageBox.Show("Já foi cadastrada uma filial com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return true;
                                }
                            } 
                        }
                    }
                }
            }
            return false;
        }
        public static bool FornecedorCodigoExiste(string codigo, int fornId)
        {
            if (StaticProperty.fornFilais != null)
            {
                if (StaticProperty.fornecedores != null)
                {
                    foreach (var f in StaticProperty.fornecedores.Where(x => x.id == fornId).ToList())
                    {
                        if (f.fornecedorFiliais != null)
                        {
                            foreach (var fcl in f.fornecedorFiliais)
                            {
                                if (fcl.codigo == codigo)
                                {
                                    MessageBox.Show("Já foi cadastrada uma filial com este codigo!", "O codigo já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
