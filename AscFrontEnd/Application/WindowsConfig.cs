using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd.Application
{
    public class WindowsConfig
    {
        public static void LimparFormulario(Form form)
        {
            foreach (Control controle in form.Controls)
            {
                if (controle is TextBox)
                {
                    ((TextBox)controle).Clear(); // Limpa TextBox
                }
                else if (controle is ComboBox)
                {
                    ((ComboBox)controle).SelectedIndex = -1; // Reseta ComboBox
                }
                else if (controle is CheckBox)
                {
                    ((CheckBox)controle).Checked = false; // Desmarca CheckBox
                }
                else if (controle is RadioButton)
                {
                    ((RadioButton)controle).Checked = false; // Desmarca RadioButton
                }
                else if (controle is ListBox)
                {
                    ((ListBox)controle).Items.Clear(); // Limpa ListBox
                }
                else if (controle is DataGridView)
                {
                    ((DataGridView)controle).DataSource = null; // Limpa DataGridView
                }
                // Adicione outros tipos de controles conforme necessário
            }
        }
    }
}
