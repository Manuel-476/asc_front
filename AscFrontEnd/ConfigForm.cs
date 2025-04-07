using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.DTOs.StaticsDto;

namespace AscFrontEnd
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void imgLabel_Click(object sender, EventArgs e)
        {

        }

        private void senhaPicture_Click(object sender, EventArgs e)
        {
            new UserForm("Alterar Senha de Usuario",StaticProperty.userId).ShowDialog();
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
    }
}
