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
    public partial class OpcaoDialog : Form
    {
        public OpcaoDialog()
        {
            InitializeComponent();
        }

        private void familiaPicture_Click(object sender, EventArgs e)
        {
            FamiliaArtigo familia = new FamiliaArtigo();
            familia.ShowDialog();
        }

        private void subfamiliaPicture_Click(object sender, EventArgs e)
        {
            SubFamilaArtigo subfamilia = new SubFamilaArtigo();
            subfamilia.ShowDialog();
        }

        private void marcaPicture_Click(object sender, EventArgs e)
        {
            ModeloArtigo modelo = new ModeloArtigo();
            modelo.ShowDialog();
        }

        private void modeloPicture_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.ShowDialog();
        }

        private void familiaPicture_MouseMove(object sender, MouseEventArgs e)
        {
            familiaPicture.BackColor = Color.DeepSkyBlue;

        }

        private void familiaPicture_MouseLeave(object sender, EventArgs e)
        {
            familiaPicture.BackColor = Color.FromArgb(0,120,215);
        }

        private void subfamiliaPicture_MouseLeave(object sender, EventArgs e)
        {
            subfamiliaPicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void subfamiliaPicture_MouseMove(object sender, MouseEventArgs e)
        {
            subfamiliaPicture.BackColor = Color.DeepSkyBlue;
        }

        private void marcaPicture_MouseLeave(object sender, EventArgs e)
        {
            marcaPicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void marcaPicture_MouseMove(object sender, MouseEventArgs e)
        {
            marcaPicture.BackColor = Color.DeepSkyBlue;
        }

        private void modeloPicture_MouseMove(object sender, MouseEventArgs e)
        {
            modeloPicture.BackColor = Color.DeepSkyBlue;
        }

        private void modeloPicture_MouseLeave(object sender, EventArgs e)
        {
            modeloPicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void OpcaoDialog_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ivaPicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void ivaPicture_MouseMove(object sender, MouseEventArgs e)
        {
            ivaPicture.BackColor = Color.DeepSkyBlue;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            unidadePicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void unidadePicture_MouseMove(object sender, MouseEventArgs e)
        {
            unidadePicture.BackColor = Color.DeepSkyBlue;
        }

        private void ivaPicture_Click(object sender, EventArgs e)
        {
            new IvaForm().ShowDialog();
        }

        private void unidadePicture_Click(object sender, EventArgs e)
        {
            new UnidadeForm().ShowDialog();
        }
    }
}
