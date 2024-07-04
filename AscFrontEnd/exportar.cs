using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class exportar : Form
    {
        public exportar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void excelPicture_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();

            var response = await client.GetAsync($"https://localhost:7200/api/Venda/Fr/DownloadExcel");

            if (response.IsSuccessStatusCode)
            {
               using (var streamContent = await response.Content.ReadAsStreamAsync())
               {
                    // Define o caminho onde o arquivo será salvo

                    // Altere o nome do arquivo conforme necessário
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() ,"Download.xlsx");

                    // Salva o conteúdo da resposta em um arquivo local
                    using (var fileStream = File.Create(filePath))
                    {
                        await streamContent.CopyToAsync(fileStream);
                    }

                    MessageBox.Show("Excel Gerado", "Feito Com Sucesso", MessageBoxButtons.OK);
                }
            }
        }

        private void pdfPicture_MouseMove(object sender, MouseEventArgs e)
        {
            pdfPicture.BackColor = Color.Gray;
        }

        private void pdfPicture_MouseLeave(object sender, EventArgs e)
        {
            pdfPicture.BackColor = Color.Transparent;
        }

        private void excelPicture_MouseLeave(object sender, EventArgs e)
        {
            excelPicture.BackColor = Color.Transparent;
        }

        private void excelPicture_MouseMove(object sender, MouseEventArgs e)
        {
            excelPicture.BackColor = Color.Gray;
        }
    }
}
