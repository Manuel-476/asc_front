namespace AscFrontEnd
{
    partial class RelatorioFiltros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioFiltros));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataInicioCombo = new System.Windows.Forms.DateTimePicker();
            this.dataFinalCombo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.artigoList = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.armazemList = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.entidadeList = new System.Windows.Forms.Label();
            this.documentoCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnArmazem = new System.Windows.Forms.Button();
            this.btnEntidade = new System.Windows.Forms.Button();
            this.btnArtigo = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.documentoList = new System.Windows.Forms.Label();
            this.printVenda = new System.Drawing.Printing.PrintDocument();
            this.printCompra = new System.Drawing.Printing.PrintDocument();
            this.printArmazem = new System.Drawing.Printing.PrintDocument();
            this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 97);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.relatorio_de_noticias;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(30, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 90);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(133, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Relatórios";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data Inicio";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataInicioCombo
            // 
            this.dataInicioCombo.Location = new System.Drawing.Point(19, 61);
            this.dataInicioCombo.Name = "dataInicioCombo";
            this.dataInicioCombo.Size = new System.Drawing.Size(242, 25);
            this.dataInicioCombo.TabIndex = 6;
            // 
            // dataFinalCombo
            // 
            this.dataFinalCombo.Location = new System.Drawing.Point(284, 61);
            this.dataFinalCombo.Name = "dataFinalCombo";
            this.dataFinalCombo.Size = new System.Drawing.Size(248, 25);
            this.dataFinalCombo.TabIndex = 8;
            this.dataFinalCombo.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(281, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data Final";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataInicioCombo);
            this.groupBox1.Controls.Add(this.dataFinalCombo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 129);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Periodo";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.documentoCombo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(12, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 187);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documento";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.artigoList);
            this.groupBox5.Location = new System.Drawing.Point(394, 97);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(158, 84);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Artigo";
            // 
            // artigoList
            // 
            this.artigoList.AutoSize = true;
            this.artigoList.Location = new System.Drawing.Point(6, 21);
            this.artigoList.Name = "artigoList";
            this.artigoList.Size = new System.Drawing.Size(0, 17);
            this.artigoList.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.armazemList);
            this.groupBox4.Location = new System.Drawing.Point(216, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(158, 84);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Armazem";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // armazemList
            // 
            this.armazemList.AutoSize = true;
            this.armazemList.Location = new System.Drawing.Point(7, 21);
            this.armazemList.Name = "armazemList";
            this.armazemList.Size = new System.Drawing.Size(0, 17);
            this.armazemList.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.entidadeList);
            this.groupBox3.Location = new System.Drawing.Point(19, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 90);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entidade";
            // 
            // entidadeList
            // 
            this.entidadeList.AutoSize = true;
            this.entidadeList.Location = new System.Drawing.Point(7, 25);
            this.entidadeList.Name = "entidadeList";
            this.entidadeList.Size = new System.Drawing.Size(0, 17);
            this.entidadeList.TabIndex = 0;
            // 
            // documentoCombo
            // 
            this.documentoCombo.FormattingEnabled = true;
            this.documentoCombo.Location = new System.Drawing.Point(19, 60);
            this.documentoCombo.Name = "documentoCombo";
            this.documentoCombo.Size = new System.Drawing.Size(513, 25);
            this.documentoCombo.TabIndex = 9;
            this.documentoCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(16, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Documento";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.Location = new System.Drawing.Point(395, 462);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(185, 37);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnArmazem
            // 
            this.btnArmazem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnArmazem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArmazem.Location = new System.Drawing.Point(611, 231);
            this.btnArmazem.Name = "btnArmazem";
            this.btnArmazem.Size = new System.Drawing.Size(197, 37);
            this.btnArmazem.TabIndex = 12;
            this.btnArmazem.Text = "Selecionar Armazem";
            this.btnArmazem.UseVisualStyleBackColor = false;
            this.btnArmazem.Click += new System.EventHandler(this.btnArmazem_Click);
            // 
            // btnEntidade
            // 
            this.btnEntidade.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnEntidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntidade.Location = new System.Drawing.Point(611, 129);
            this.btnEntidade.Name = "btnEntidade";
            this.btnEntidade.Size = new System.Drawing.Size(197, 37);
            this.btnEntidade.TabIndex = 13;
            this.btnEntidade.Text = "Selecionar Entidade";
            this.btnEntidade.UseVisualStyleBackColor = false;
            this.btnEntidade.Click += new System.EventHandler(this.btnEntidade_Click);
            // 
            // btnArtigo
            // 
            this.btnArtigo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnArtigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArtigo.Location = new System.Drawing.Point(611, 178);
            this.btnArtigo.Name = "btnArtigo";
            this.btnArtigo.Size = new System.Drawing.Size(197, 37);
            this.btnArtigo.TabIndex = 14;
            this.btnArtigo.Text = "Selecionar Artigo";
            this.btnArtigo.UseVisualStyleBackColor = false;
            this.btnArtigo.Click += new System.EventHandler(this.btnArtigo_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.documentoList);
            this.groupBox6.Location = new System.Drawing.Point(611, 316);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(197, 124);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Documentos Selecionados";
            // 
            // documentoList
            // 
            this.documentoList.AutoSize = true;
            this.documentoList.Location = new System.Drawing.Point(7, 20);
            this.documentoList.Name = "documentoList";
            this.documentoList.Size = new System.Drawing.Size(0, 14);
            this.documentoList.TabIndex = 0;
            // 
            // printVenda
            // 
            this.printVenda.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printVenda_PrintPage);
            // 
            // printPreview
            // 
            this.printPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreview.Enabled = true;
            this.printPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreview.Icon")));
            this.printPreview.Name = "printPreview";
            this.printPreview.Visible = false;
            // 
            // RelatorioFiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 502);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnArtigo);
            this.Controls.Add(this.btnEntidade);
            this.Controls.Add(this.btnArmazem);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelatorioFiltros";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.RelatorioFiltros_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dataInicioCombo;
        private System.Windows.Forms.DateTimePicker dataFinalCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox documentoCombo;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnArmazem;
        private System.Windows.Forms.Button btnEntidade;
        private System.Windows.Forms.Button btnArtigo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label documentoList;
        private System.Windows.Forms.Label entidadeList;
        private System.Windows.Forms.Label artigoList;
        private System.Windows.Forms.Label armazemList;
        private System.Drawing.Printing.PrintDocument printVenda;
        private System.Drawing.Printing.PrintDocument printCompra;
        private System.Drawing.Printing.PrintDocument printArmazem;
        private System.Windows.Forms.PrintPreviewDialog printPreview;
    }
}