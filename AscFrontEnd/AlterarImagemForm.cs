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
    public partial class AlterarImagemForm : Form
    {
        public AlterarImagemForm()
        {
            InitializeComponent();
        }

        private void AlterarImagemForm_Load(object sender, EventArgs e)
        {
            imgPathLabel.Text = "Nenhuma imagem selecionada";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "*|.jpeg|.jpg";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                imgPathLabel.Text = fileDialog.FileName;
            }
        }

        private void imgPathLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
