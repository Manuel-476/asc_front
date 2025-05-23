namespace AscFrontEnd
{
    partial class DocumentosDetalhesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentosDetalhesForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataDocumento = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numDocumento = new System.Windows.Forms.Label();
            this.serieDocumento = new System.Windows.Forms.Label();
            this.codigoDocumento = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.printVenda = new System.Drawing.Printing.PrintDocument();
            this.printCompra = new System.Drawing.Printing.PrintDocument();
            this.preVisualizacaoDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-6, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 73);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Documento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataDocumento);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numDocumento);
            this.groupBox1.Controls.Add(this.serieDocumento);
            this.groupBox1.Controls.Add(this.codigoDocumento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 141);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sobre Documento";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataDocumento
            // 
            this.dataDocumento.AutoSize = true;
            this.dataDocumento.Location = new System.Drawing.Point(77, 114);
            this.dataDocumento.Name = "dataDocumento";
            this.dataDocumento.Size = new System.Drawing.Size(28, 13);
            this.dataDocumento.TabIndex = 7;
            this.dataDocumento.Text = "data";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(6, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Data:";
            // 
            // numDocumento
            // 
            this.numDocumento.AutoSize = true;
            this.numDocumento.Location = new System.Drawing.Point(77, 85);
            this.numDocumento.Name = "numDocumento";
            this.numDocumento.Size = new System.Drawing.Size(42, 13);
            this.numDocumento.TabIndex = 5;
            this.numDocumento.Text = "numero";
            // 
            // serieDocumento
            // 
            this.serieDocumento.AutoSize = true;
            this.serieDocumento.Location = new System.Drawing.Point(77, 59);
            this.serieDocumento.Name = "serieDocumento";
            this.serieDocumento.Size = new System.Drawing.Size(29, 13);
            this.serieDocumento.TabIndex = 4;
            this.serieDocumento.Text = "serie";
            // 
            // codigoDocumento
            // 
            this.codigoDocumento.AutoSize = true;
            this.codigoDocumento.Location = new System.Drawing.Point(77, 28);
            this.codigoDocumento.Name = "codigoDocumento";
            this.codigoDocumento.Size = new System.Drawing.Size(60, 13);
            this.codigoDocumento.TabIndex = 3;
            this.codigoDocumento.Text = "documento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(6, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Numero:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Serie:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Documento:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataTable);
            this.groupBox2.Location = new System.Drawing.Point(278, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 141);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Artigos";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dataTable
            // 
            this.dataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Location = new System.Drawing.Point(7, 22);
            this.dataTable.Name = "dataTable";
            this.dataTable.ReadOnly = true;
            this.dataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTable.Size = new System.Drawing.Size(195, 105);
            this.dataTable.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_printer_60;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(448, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 34);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // printVenda
            // 
            this.printVenda.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printVenda_PrintPage);
            // 
            // printCompra
            // 
            this.printCompra.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printCompra_PrintPage);
            // 
            // preVisualizacaoDialog
            // 
            this.preVisualizacaoDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.preVisualizacaoDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.preVisualizacaoDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.preVisualizacaoDialog.Enabled = true;
            this.preVisualizacaoDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("preVisualizacaoDialog.Icon")));
            this.preVisualizacaoDialog.Name = "preVisualizacaoDialog";
            this.preVisualizacaoDialog.Visible = false;
            // 
            // DocumentosDetalhesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 283);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentosDetalhesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DocumentosDetalhesForm";
            this.Load += new System.EventHandler(this.DocumentosDetalhesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label serieDocumento;
        private System.Windows.Forms.Label codigoDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numDocumento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label dataDocumento;
        private System.Windows.Forms.Label label11;
        private System.Drawing.Printing.PrintDocument printVenda;
        private System.Drawing.Printing.PrintDocument printCompra;
        private System.Windows.Forms.PrintPreviewDialog preVisualizacaoDialog;
        private System.Windows.Forms.DataGridView dataTable;
    }
}