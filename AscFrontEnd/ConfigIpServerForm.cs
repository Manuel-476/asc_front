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
    public partial class ConfigIpServerForm : Form
    {
        public ConfigIpServerForm()
        {
            InitializeComponent();
        }

        private void ConfigIpServerForm_Load(object sender, EventArgs e)
        {
            descricaoLabel.Text = "Defina o ip do servidor e a porta para acessar\nExemplo: 192.168.0.1:80";
        }
    }
}
