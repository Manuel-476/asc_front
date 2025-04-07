namespace AscFrontEnd
{
    partial class DashBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFinal = new System.Windows.Forms.DateTimePicker();
            this.radioData = new System.Windows.Forms.RadioButton();
            this.radioAno = new System.Windows.Forms.RadioButton();
            this.radioGeral = new System.Windows.Forms.RadioButton();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelAnual = new System.Windows.Forms.Label();
            this.labelMensal = new System.Windows.Forms.Label();
            this.labelSemanal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotal)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartTotal
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTotal.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTotal.Legends.Add(legend2);
            this.chartTotal.Location = new System.Drawing.Point(12, 141);
            this.chartTotal.Name = "chartTotal";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTotal.Series.Add(series2);
            this.chartTotal.Size = new System.Drawing.Size(672, 369);
            this.chartTotal.TabIndex = 0;
            this.chartTotal.Text = "Grafico";
            this.chartTotal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartTotal_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 115);
            this.panel1.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(30, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 37);
            this.label8.TabIndex = 17;
            this.label8.Text = "DashBoard";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // dateInicio
            // 
            this.dateInicio.Location = new System.Drawing.Point(703, 237);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(200, 20);
            this.dateInicio.TabIndex = 30;
            this.dateInicio.ValueChanged += new System.EventHandler(this.dateInicio_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(700, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "Data inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(700, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "Data Final:";
            // 
            // dateFinal
            // 
            this.dateFinal.Location = new System.Drawing.Point(703, 306);
            this.dateFinal.Name = "dateFinal";
            this.dateFinal.Size = new System.Drawing.Size(200, 20);
            this.dateFinal.TabIndex = 32;
            this.dateFinal.ValueChanged += new System.EventHandler(this.dateFinal_ValueChanged);
            // 
            // radioData
            // 
            this.radioData.AutoSize = true;
            this.radioData.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioData.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioData.Location = new System.Drawing.Point(778, 152);
            this.radioData.Name = "radioData";
            this.radioData.Size = new System.Drawing.Size(47, 18);
            this.radioData.TabIndex = 34;
            this.radioData.TabStop = true;
            this.radioData.Text = "Data";
            this.radioData.UseVisualStyleBackColor = true;
            this.radioData.CheckedChanged += new System.EventHandler(this.radioData_CheckedChanged);
            // 
            // radioAno
            // 
            this.radioAno.AutoSize = true;
            this.radioAno.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioAno.Location = new System.Drawing.Point(859, 152);
            this.radioAno.Name = "radioAno";
            this.radioAno.Size = new System.Drawing.Size(44, 17);
            this.radioAno.TabIndex = 35;
            this.radioAno.TabStop = true;
            this.radioAno.Text = "Ano";
            this.radioAno.UseVisualStyleBackColor = true;
            this.radioAno.CheckedChanged += new System.EventHandler(this.radioAno_CheckedChanged);
            // 
            // radioGeral
            // 
            this.radioGeral.AutoSize = true;
            this.radioGeral.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGeral.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioGeral.Location = new System.Drawing.Point(703, 152);
            this.radioGeral.Name = "radioGeral";
            this.radioGeral.Size = new System.Drawing.Size(51, 18);
            this.radioGeral.TabIndex = 36;
            this.radioGeral.TabStop = true;
            this.radioGeral.Text = "Geral";
            this.radioGeral.UseVisualStyleBackColor = true;
            this.radioGeral.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLabel.Location = new System.Drawing.Point(16, 27);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(82, 17);
            this.tituloLabel.TabIndex = 0;
            this.tituloLabel.Text = "tituloLabel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelSemanal);
            this.groupBox1.Controls.Add(this.labelMensal);
            this.groupBox1.Controls.Add(this.labelAnual);
            this.groupBox1.Controls.Add(this.tituloLabel);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(704, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 183);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balanço Actual";
            // 
            // labelAnual
            // 
            this.labelAnual.AutoSize = true;
            this.labelAnual.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnual.Location = new System.Drawing.Point(79, 139);
            this.labelAnual.Name = "labelAnual";
            this.labelAnual.Size = new System.Drawing.Size(42, 15);
            this.labelAnual.TabIndex = 1;
            this.labelAnual.Text = "label3";
            // 
            // labelMensal
            // 
            this.labelMensal.AutoSize = true;
            this.labelMensal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensal.Location = new System.Drawing.Point(79, 105);
            this.labelMensal.Name = "labelMensal";
            this.labelMensal.Size = new System.Drawing.Size(42, 15);
            this.labelMensal.TabIndex = 2;
            this.labelMensal.Text = "label3";
            // 
            // labelSemanal
            // 
            this.labelSemanal.AutoSize = true;
            this.labelSemanal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSemanal.Location = new System.Drawing.Point(79, 68);
            this.labelSemanal.Name = "labelSemanal";
            this.labelSemanal.Size = new System.Drawing.Size(42, 15);
            this.labelSemanal.TabIndex = 3;
            this.labelSemanal.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Semanal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mensal:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Anual:";
            // 
            // DashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 541);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioGeral);
            this.Controls.Add(this.radioAno);
            this.Controls.Add(this.radioData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateInicio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DashBoardForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DashBoardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTotal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFinal;
        private System.Windows.Forms.RadioButton radioData;
        private System.Windows.Forms.RadioButton radioAno;
        private System.Windows.Forms.RadioButton radioGeral;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelSemanal;
        private System.Windows.Forms.Label labelMensal;
        private System.Windows.Forms.Label labelAnual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}