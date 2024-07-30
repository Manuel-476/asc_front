using AscFrontEnd.DTOs.StaticsDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class ArmazemListagem : Form
    {
        public ArmazemListagem()
        {
            InitializeComponent();
        }

        private void ArmazemListagem_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("descricao", typeof(string));
            dt.Columns.Add("P. Unitario", typeof(string));
            dt.Columns.Add("mov. Stock", typeof(string));
            dt.Columns.Add("mov. Lote", typeof(string));


            // Adicionando linhas ao DataTable
            foreach (var item in StaticProperty.armazens.Where(arm => arm.empresaId == 1))
            {
                dt.Rows.Add(item.id, item.codigo, item.descricao);

                dataGridView1.DataSource = dt;
            }
        }

        private void editarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            editarPicture.BackColor = Color.Gray;
        }

        private void editarPicture_MouseLeave(object sender, EventArgs e)
        {
            editarPicture.BackColor= Color.White;
        }

        private void eliminarPicture_MouseLeave(object sender, EventArgs e)
        {
            editarPicture.BackColor = Color.White;
        }

        private void eliminarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            eliminarPicture.BackColor = Color.Gray;
        }
    }
}
