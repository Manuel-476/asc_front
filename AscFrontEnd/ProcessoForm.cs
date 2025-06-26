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
    public partial class ProcessoForm : Form
    {
        public ProcessoForm()
        {
            StaticProperty.percentual = 0;
            InitializeComponent();
            timer1.Start();

        }

        private void ProcessoForm_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = StaticProperty.percentual;
        }

        private void ProcessoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            StaticProperty.percentual = 0;
        }
    }
}
