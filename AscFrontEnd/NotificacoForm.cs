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
    public partial class NotificacoForm : Form
    {
        List<string> _notifications;
        public NotificacoForm(List<string> notifications)
        {
            InitializeComponent();

            _notifications = notifications;
        }

        private void NotificacoForm_Load(object sender, EventArgs e)
        {
            if (_notifications != null)
            {
                foreach (var item in _notifications)
                {
                    notificacaoList.Items.Add(item);
                }
            }
        }
    }
}
