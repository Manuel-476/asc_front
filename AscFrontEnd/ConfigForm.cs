using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.StaticsDto;

namespace AscFrontEnd
{
    public partial class ConfigForm : Form
    {
        UserDTO _user;
        public ConfigForm(UserDTO user)
        {
            InitializeComponent();

            _user = user;
        }

        private void imgLabel_Click(object sender, EventArgs e)
        {

        }

        private void senhaPicture_Click(object sender, EventArgs e)
        {
            new UserForm("Alterar Senha de Usuario",_user).ShowDialog();
        }

        private void stockPicture_Click(object sender, EventArgs e)
        {
            new ConfigStock().ShowDialog();
        }

        private void imgPicture_Click(object sender, EventArgs e)
        {
            new AlterarImagemForm().ShowDialog();
        }

        private void ipPicture_Click(object sender, EventArgs e)
        {
            new ConfigIpServerForm().ShowDialog();
        }

        private void saftPicture_Click(object sender, EventArgs e)
        {
            new GerarSaftForm().ShowDialog();
        }

        private void senhaPicture_MouseMove(object sender, MouseEventArgs e)
        {
            senhaPicture.BackColor = Color.DeepSkyBlue;
        }

        private void senhaPicture_MouseLeave(object sender, EventArgs e)
        {
            senhaPicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void stockPicture_MouseMove(object sender, MouseEventArgs e)
        {
            stockPicture.BackColor = Color.DeepSkyBlue;
        }

        private void stockPicture_MouseLeave(object sender, EventArgs e)
        {
            stockPicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void imgPicture_MouseMove(object sender, MouseEventArgs e)
        {
            imgPicture.BackColor = Color.DeepSkyBlue;
        }

        private void imgPicture_MouseLeave(object sender, EventArgs e)
        {
            imgPicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void ipPicture_MouseMove(object sender, MouseEventArgs e)
        {
            ipPicture.BackColor = Color.DeepSkyBlue;
        }

        private void ipPicture_MouseLeave(object sender, EventArgs e)
        {
            ipPicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void saftPicture_MouseLeave(object sender, EventArgs e)
        {
            saftPicture.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void saftPicture_MouseMove(object sender, MouseEventArgs e)
        {
            saftPicture.BackColor = Color.DeepSkyBlue;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            saftPicture.Enabled = false;
            ipPicture.Enabled = false;
            imgPicture.Enabled = false;

            if (!_user.nivel_acesso.Equals("Administrador"))
            {
                saftPicture.Enabled = true;
                imgPicture.Enabled = true;
            }
            else if (!_user.nivel_acesso.Equals("Administrador")) 
            {
                saftPicture.Enabled = true;
                ipPicture.Enabled = true;
                imgPicture.Enabled = true;
            }
        }
    }
}
