using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.DTOs.Compra;
using AscFrontEnd.DTOs.Venda;
using System.Windows.Forms.DataVisualization.Charting;
using static AscFrontEnd.DTOs.Enums.Enums;
using AscFrontEnd.Application;
using EAscFrontEnd;
using AscFrontEnd.DTOs;
using static System.Windows.Forms.AxHost;
using System.Globalization;


namespace AscFrontEnd
{
    public partial class DashBoardForm : Form
    {
        List<VendaDTO> _vendas;
        List<CompraDTO> _compras;
        IEnumerable<Balance> _balance;
        Title title;
        Consulta _consulta;
        public DashBoardForm(Consulta consulta)
        {
            InitializeComponent();
            
            _consulta = consulta;
            chartTotal.MouseClick += chartTotal_MouseClick;

            if (_consulta == Consulta.compra)
            {
                _compras = new List<CompraDTO>();
            }
            else if (_consulta == Consulta.venda)
            {
                _vendas = new List<VendaDTO>();
            }
            else 
            {
                return;
            }

            _balance = new List<Balance>();

            title = new Title();

            title.Font = new Font("Arial", 16, FontStyle.Bold);
            title.ForeColor = Color.White;
            title.Text = "Painel";

            chartTotal.ChartAreas["ChartArea1"].AxisX.Title = $"Data: ";
            chartTotal.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chartTotal.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Black;

            chartTotal.ChartAreas["ChartArea1"].AxisY.Title = $"Total: ";
            chartTotal.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("arial", 12, FontStyle.Bold);
            chartTotal.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Black;

            chartTotal.Titles.Add(title);
            chartTotal.ForeColor = Color.Black;

            //chartTotal.Series.Add("vendas");

            chartTotal.Series["Series1"].ChartType = SeriesChartType.Column;
            chartTotal.Series["Series1"].BorderWidth = 4;
            chartTotal.Series["Series1"].LabelForeColor = Color.Black;
            chartTotal.Series["Series1"].LabelBackColor = Color.Black;



            chartTotal.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
            chartTotal.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;


            chartTotal.Series["Series1"].Points.Clear();
        }



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGeral.Checked) 
            {
                ChangeDatePickerState(false);

                dateInicio_ValueChanged(this, EventArgs.Empty);
            }
        }

        private async void DashBoardForm_Load(object sender, EventArgs e)
        {
            radioGeral.Checked = true;

            ChangeDatePickerState(false);     

            if (_consulta == Consulta.venda)
            {
                chartTotal.Series["Series1"].LegendText = "Vendas";
                _vendas = await new Requisicoes().GetVendas();

                // Obtém os anos únicos e calcula o total por ano
                _balance = _vendas.Where(x => x.documento == "FR" || x.documento == "FT")
                    .GroupBy(v => v.data.Year.ToString())
                    .Select(g => 
                        new Balance
                        {
                            Data = g.Key,
                            total = g.Sum(vnd => vnd.artigoVendas.Sum(v => v.preco * v.qtd))
                        }
                    );

                // Limpa pontos anteriores
                chartTotal.Series["Series1"].Points.Clear();

                if (_balance.Any())
                {
                    foreach (var item in _balance)
                    {
                        chartTotal.Series["Series1"].Points.AddXY(item.Data, item.total);
                    }
                }
                else
                {
                    chartTotal.Series["Series1"].Points.AddXY(DateTime.Now.Year, 0f);
                }

                tituloLabel.Text = "Ganhos e Proveitos";


                var valorMensal = _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data.Month == DateTime.Now.Month).Any() ?
                                  _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data.Month == DateTime.Now.Month).Sum(x => x.artigoVendas.Sum(a => a.preco * a.qtd)) : 0f;


                // Calcula o total da semana atual
                var valorSemanal = _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") &&
                                                      CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.data, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) ==
                                                      CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                                          .Any() ?
                                          _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") &&
                                                          CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.data, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) ==
                                                          CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                                                  .Sum(x => x.artigoVendas.Sum(a => a.preco * a.qtd)) : 0f;

                labelMensal.Text = $"{valorMensal:F2}";
                labelSemanal.Text = $"{valorSemanal:F2}";

                //interactividade das cores
                labelMensal.ForeColor = valorMensal <= 0 ?  Color.Red :  Color.Green;
                labelSemanal.ForeColor = valorSemanal <= 0 ? Color.Red : Color.Green;

                // Configura o ToolTip para exibir ano e total ao passar o mouse
                chartTotal.Series["Series1"].ToolTip = "Ano: #AXISLABEL\nTotal: #VALY{F2}";

                chartTotal.ChartAreas[0].AxisY.Title = "Total de Vendas";
            }
            else if (_consulta == Consulta.compra)
            {
                chartTotal.Series["Series1"].LegendText = "Compras";
                _compras = await new Requisicoes().GetCompras();

                // Obtém os anos únicos e calcula o total por ano
                _balance = _compras.Where(x => x.documento == "VFR" || x.documento == "VFT")
                    .GroupBy(c => c.data.Year.ToString())
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(cmp => cmp.artigoCompras.Sum(v => v.preco * v.qtd))
                    });

                // Limpa pontos anteriores
                chartTotal.Series["Series1"].Points.Clear();

                if (_balance.Any())
                {
                    foreach (var item in _balance)
                    {
                        chartTotal.Series["Series1"].Points.AddXY(item.Data, item.total);
                    }
                }
                else 
                {
                    chartTotal.Series["Series1"].Points.AddXY(DateTime.Now.Year.ToString(), 0f);
                }

                // Configura o ToolTip para exibir ano e total ao passar o mouse
                chartTotal.Series["Series1"].ToolTip = "Ano: #AXISLABEL\nTotal: #VALY{F2}";

                chartTotal.ChartAreas[0].AxisY.Title = "Total de Compras";

                tituloLabel.Text = "Custos e Perdas";


                var valorMensal = _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data.Month == DateTime.Now.Month).Any() ?
                                  _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data.Month == DateTime.Now.Month).Sum(x => x.artigoCompras.Sum(a => a.preco * a.qtd)) : 0f;


                // Calcula o total da semana atual
                var valorSemanal = _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") &&
                                                      CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.data, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) ==
                                                      CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                                          .Any() ?
                                          _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") &&
                                                          CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.data, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) ==
                                                          CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                                                  .Sum(x => x.artigoCompras.Sum(a => a.preco * a.qtd)) : 0f;

                labelMensal.Text = $"{valorMensal:F2}";
                labelSemanal.Text = $"{valorSemanal:F2}";

                //interactividade das cores
                labelMensal.ForeColor = valorMensal <= 0 ? Color.Red : Color.Green;
                labelSemanal.ForeColor = valorSemanal <= 0 ? Color.Red : Color.Green;
            }
            var valorAnual = _balance.Where(x => x.Data == DateTime.Now.Year.ToString()).Any() ?
                             _balance.Where(x => x.Data == DateTime.Now.Year.ToString()).First().total : 0f;

            labelAnual.Text = $"{valorAnual:F2}";

            labelAnual.ForeColor = valorAnual <= 0 ? Color.Red : Color.Green;

            // Ajustes opcionais de visualização
            chartTotal.ChartAreas[0].AxisX.Title = "Ano";
            chartTotal.ChartAreas[0].AxisX.Interval = 1;
        }

        private async void dateInicio_ValueChanged(object sender, EventArgs e)
        {
            chartTotal.Series["Series1"].Points.Clear();
            if (_consulta == Consulta.venda)
            {
                chartTotal.Series["Series1"].LegendText = "Vendas";
                _vendas = await new Requisicoes().GetVendas();

                // Obtém os anos únicos e calcula o total por data
                if(dateFinal.Value.Date != DateTime.Now.Date) 
                {
                    _balance = radioData.Checked ?
                    _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data >= dateInicio.Value && x.data <= dateFinal.Value)
                    .GroupBy(v => v.data.ToString("MMMM-yyyy")) // Agrupa por data
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(vnd => vnd.artigoVendas.Sum(v => v.preco * v.qtd))
                    }) : _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data >= dateInicio.Value && x.data <= dateFinal.Value)
                    .GroupBy(v => v.data.Year.ToString()) // Agrupa por data
                    .Select(g => new Balance
                    {
                      Data = g.Key,
                      total = g.Sum(vnd => vnd.artigoVendas.Sum(v => v.preco * v.qtd))
                    });
                }
                else 
                {
                    _balance = radioData.Checked ?
                    _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data >= dateInicio.Value)
                    .GroupBy(v => v.data.ToString("MMMM-yyyy")) // Agrupa por data
                    .Select(g => new Balance
                    {
                       Data = g.Key,
                       total = g.Sum(vnd => vnd.artigoVendas.Sum(v => v.preco * v.qtd))
                    }) : _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data >= dateInicio.Value)
                    .GroupBy(v => v.data.Year.ToString()) // Agrupa por data
                    .Select(g => new Balance
                    {
                      Data = g.Key,
                      total = g.Sum(vnd => vnd.artigoVendas.Sum(v => v.preco * v.qtd))
                     });
                }


                if (_balance.Any())
                {
                    foreach (var item in _balance)
                    {
                        chartTotal.Series["Series1"].Points.AddXY(item.Data, item.total);
                    }
                }
                else
                {
                    chartTotal.Series["Series1"].Points.AddXY(DateTime.Now.Year, 0f);
                }


                chartTotal.Series["Series1"].ToolTip = "Ano: #AXISLABEL\nTotal: #VALY{F2}";
                chartTotal.ChartAreas[0].AxisY.Title = "Total de Vendas";
            }
            else if (_consulta == Consulta.compra)
            {
                chartTotal.Series["Series1"].LegendText = "Compras";
                _compras = await new Requisicoes().GetCompras();

                if (dateFinal.Value.Date != DateTime.Now.Date)
                {
                    // Obtém os anos únicos e calcula o total por ano
                    _balance = radioData.Checked ?
                    _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data >= dateInicio.Value && x.data <= dateFinal.Value)
                    .GroupBy(c => c.data.ToString("MMMM")) // Agrupa por ano
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(cmp => cmp.artigoCompras.Sum(v => v.preco * v.qtd))
                    }) : _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data >= dateInicio.Value && x.data <= dateFinal.Value)
                    .GroupBy(c => c.data.Year.ToString()) // Agrupa por ano
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(cmp => cmp.artigoCompras.Sum(v => v.preco * v.qtd))
                    });
                }
                else
                {
                    // Obtém os anos únicos e calcula o total por ano
                    _balance = radioData.Checked ?
                    _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data >= dateInicio.Value)
                    .GroupBy(c => c.data.ToString("MMMM")) // Agrupa por ano
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(cmp => cmp.artigoCompras.Sum(v => v.preco * v.qtd))
                    }) : _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data >= dateInicio.Value)
                    .GroupBy(c => c.data.Year.ToString()) // Agrupa por ano
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(cmp => cmp.artigoCompras.Sum(v => v.preco * v.qtd))
                    });
                }
                if (_balance.Any())
                {
                    foreach (var item in _balance)
                    {
                        chartTotal.Series["Series1"].Points.AddXY(item.Data, item.total);
                    }
                }
                else
                {
                    chartTotal.Series["Series1"].Points.AddXY(DateTime.Now.Year, 0f);
                }


                chartTotal.Series["Series1"].ToolTip = "Ano: #AXISLABEL\nTotal: #VALY{F2}";
                chartTotal.ChartAreas[0].AxisY.Title = "Total de Compras";
            }
            // Ajustes opcionais de visualização
            chartTotal.ChartAreas[0].AxisX.Title = radioData.Checked ? "Mes": "Ano";
            chartTotal.ChartAreas[0].AxisX.Interval = 1; //
        }

        private void radioData_CheckedChanged(object sender, EventArgs e)
        {
            if(radioData.Checked)
            {
                ChangeDatePickerState(true);

                dateInicio_ValueChanged(this, EventArgs.Empty);
            }
        }

        private void radioAno_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAno.Checked) 
            {
                ChangeDatePickerState(true);

                dateInicio_ValueChanged(this, EventArgs.Empty);
            }
        }



        private void chartTotal_MouseClick(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var result = chart.HitTest(e.X, e.Y); // Verifica o que foi clicado

            // Verifica se o clique foi em um ponto de dados
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var dataPoint = result.Series.Points[result.PointIndex];
                string ano = dataPoint.AxisLabel; // O valor do eixo X (Ano)
                double valorTotal = dataPoint.YValues[0]; // O valor do eixo Y (Total)

                // Exibe uma mensagem com o valor total da vela clicada
                MessageBox.Show($"Ano: {ano}\nTotal: {valorTotal:F2}", "Detalhes da Vela");
            }
        }
        private void ChangeDatePickerState(bool state)
        {
            if (state)
            {
                dateInicio.Enabled = true;
                dateFinal.Enabled = true;
            }
            else
            {
                dateInicio.Enabled = false;
                dateFinal.Enabled = false;
            }
        }

        private async void dateFinal_ValueChanged(object sender, EventArgs e)
        {
            chartTotal.Series["Series1"].Points.Clear();
            if (_consulta == Consulta.venda)
            {
                chartTotal.Series["Series1"].LegendText = "Vendas";
                _vendas = await new Requisicoes().GetVendas();

                // Obtém os anos únicos e calcula o total por data
                if (dateInicio.Value.Date != DateTime.Now.Date)
                {
                    _balance = radioData.Checked ?
                    _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data >= dateInicio.Value && x.data <= dateFinal.Value)
                    .GroupBy(v => v.data.ToString("MMMM-yyyy")) // Agrupa por data
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(vnd => vnd.artigoVendas.Sum(v => v.preco * v.qtd))
                    }) : _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data >= dateInicio.Value && x.data <= dateFinal.Value)
                    .GroupBy(v => v.data.Year.ToString()) // Agrupa por data
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(vnd => vnd.artigoVendas.Sum(v => v.preco * v.qtd))
                    });
                }
                else
                {
                    _balance = radioData.Checked ?
                    _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data <= dateFinal.Value)
                    .GroupBy(v => v.data.ToString("MMMM-yyyy")) // Agrupa por data
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(vnd => vnd.artigoVendas.Sum(v => v.preco * v.qtd))
                    }) : _vendas.Where(x => (x.documento == "FR" || x.documento == "FT") && x.data <= dateFinal.Value)
                    .GroupBy(v => v.data.Year.ToString()) // Agrupa por data
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(vnd => vnd.artigoVendas.Sum(v => v.preco * v.qtd))
                    });
                }


                if (_balance.Any())
                {
                    foreach (var item in _balance)
                    {
                        chartTotal.Series["Series1"].Points.AddXY(item.Data, item.total);
                    }
                }
                else
                {
                    chartTotal.Series["Series1"].Points.AddXY(DateTime.Now.Year, 0f);
                }


                chartTotal.Series["Series1"].ToolTip = "Ano: #AXISLABEL\nTotal: #VALY{F2}";
                chartTotal.ChartAreas[0].AxisY.Title = "Total de Vendas";
            }
            else if (_consulta == Consulta.compra)
            {
                chartTotal.Series["Series1"].LegendText = "Compras";
                _compras = await new Requisicoes().GetCompras();

                if (dateInicio.Value.Date != DateTime.Now.Date)
                {
                    // Obtém os anos únicos e calcula o total por ano
                    _balance = radioData.Checked ?
                    _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data >= dateInicio.Value && x.data <= dateFinal.Value)
                    .GroupBy(c => c.data.ToString("MMMM")) // Agrupa por ano
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(cmp => cmp.artigoCompras.Sum(v => v.preco * v.qtd))
                    }) : _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data >= dateInicio.Value && x.data <= dateFinal.Value)
                    .GroupBy(c => c.data.Year.ToString()) // Agrupa por ano
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(cmp => cmp.artigoCompras.Sum(v => v.preco * v.qtd))
                    });
                }
                else
                {
                    // Obtém os anos únicos e calcula o total por ano
                    _balance = radioData.Checked ?
                    _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data <= dateFinal.Value)
                    .GroupBy(c => c.data.ToString("MMMM")) // Agrupa por ano
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(cmp => cmp.artigoCompras.Sum(v => v.preco * v.qtd))
                    }) : _compras.Where(x => (x.documento == "VFR" || x.documento == "VFT") && x.data <= dateFinal.Value)
                    .GroupBy(c => c.data.Year.ToString()) // Agrupa por ano
                    .Select(g => new Balance
                    {
                        Data = g.Key,
                        total = g.Sum(cmp => cmp.artigoCompras.Sum(v => v.preco * v.qtd))
                    });
                }
                if (_balance.Any())
                {
                    foreach (var item in _balance)
                    {
                        chartTotal.Series["Series1"].Points.AddXY(item.Data, item.total);
                    }
                }
                else
                {
                    chartTotal.Series["Series1"].Points.AddXY(DateTime.Now.Year, 0f);
                }


                chartTotal.Series["Series1"].ToolTip = "Ano: #AXISLABEL\nTotal: #VALY{F2}";
                chartTotal.ChartAreas[0].AxisY.Title = "Total de Compras";
            }
            // Ajustes opcionais de visualização
            chartTotal.ChartAreas[0].AxisX.Title = radioData.Checked ? "Mes" : "Ano";
            chartTotal.ChartAreas[0].AxisX.Interval = 1; //
        }
    }


    class Balance 
    {
        public string Data { get; set; }
        public float total { get; set; }
    }
}

