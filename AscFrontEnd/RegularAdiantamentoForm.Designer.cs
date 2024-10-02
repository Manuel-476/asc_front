namespace AscFrontEnd
{
    partial class RegularAdiantamentoForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.adiantado = new System.Windows.Forms.Label();
            this.liquidado = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.adiantamentoTable = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.docRegularTable = new System.Windows.Forms.DataGridView();
            this.botaoSalvar = new System.Windows.Forms.Button();
            this.valorDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.documentoAdiantamento = new System.Windows.Forms.Label();
            this.documentoPagamento = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adiantamentoTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docRegularTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.adiantado);
            this.panel1.Controls.Add(this.liquidado);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 86);
            this.panel1.TabIndex = 11;
            // 
            // adiantado
            // 
            this.adiantado.AutoSize = true;
            this.adiantado.ForeColor = System.Drawing.Color.White;
            this.adiantado.Location = new System.Drawing.Point(515, 32);
            this.adiantado.Name = "adiantado";
            this.adiantado.Size = new System.Drawing.Size(35, 13);
            this.adiantado.TabIndex = 3;
            this.adiantado.Text = "label5";
            // 
            // liquidado
            // 
            this.liquidado.AutoSize = true;
            this.liquidado.ForeColor = System.Drawing.Color.White;
            this.liquidado.Location = new System.Drawing.Point(515, 67);
            this.liquidado.Name = "liquidado";
            this.liquidado.Size = new System.Drawing.Size(35, 13);
            this.liquidado.TabIndex = 2;
            this.liquidado.Text = "label4";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_cash_64;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 69);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(117, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Regular Adiantamento";
            // 
            // adiantamentoTable
            // 
            this.adiantamentoTable.BackgroundColor = System.Drawing.Color.White;
            this.adiantamentoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adiantamentoTable.Location = new System.Drawing.Point(13, 160);
            this.adiantamentoTable.Name = "adiantamentoTable";
            this.adiantamentoTable.Size = new System.Drawing.Size(365, 242);
            this.adiantamentoTable.TabIndex = 12;
            this.adiantamentoTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adiantamentoTable_CellClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(11, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Pesquisar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(412, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Pesquisar:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(470, 130);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(235, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // docRegularTable
            // 
            this.docRegularTable.BackgroundColor = System.Drawing.Color.White;
            this.docRegularTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.docRegularTable.Location = new System.Drawing.Point(413, 160);
            this.docRegularTable.Name = "docRegularTable";
            this.docRegularTable.Size = new System.Drawing.Size(375, 242);
            this.docRegularTable.TabIndex = 15;
            this.docRegularTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.docRegularTable_CellClick);
            // 
            // botaoSalvar
            // 
            this.botaoSalvar.BackColor = System.Drawing.SystemColors.Highlight;
            this.botaoSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoSalvar.ForeColor = System.Drawing.Color.White;
            this.botaoSalvar.Location = new System.Drawing.Point(13, 408);
            this.botaoSalvar.Name = "botaoSalvar";
            this.botaoSalvar.Size = new System.Drawing.Size(172, 34);
            this.botaoSalvar.TabIndex = 18;
            this.botaoSalvar.Text = "Regular";
            this.botaoSalvar.UseVisualStyleBackColor = false;
            this.botaoSalvar.Click += new System.EventHandler(this.botaoSalvar_Click);
            // 
            // valorDocumento
            // 
            this.valorDocumento.Location = new System.Drawing.Point(110, 107);
            this.valorDocumento.Name = "valorDocumento";
            this.valorDocumento.Size = new System.Drawing.Size(268, 20);
            this.valorDocumento.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Valor Documento:";
            // 
            // documentoAdiantamento
            // 
            this.documentoAdiantamento.AutoSize = true;
            this.documentoAdiantamento.ForeColor = System.Drawing.SystemColors.Highlight;
            this.documentoAdiantamento.Location = new System.Drawing.Point(517, 107);
            this.documentoAdiantamento.Name = "documentoAdiantamento";
            this.documentoAdiantamento.Size = new System.Drawing.Size(35, 13);
            this.documentoAdiantamento.TabIndex = 22;
            this.documentoAdiantamento.Text = "label5";
            // 
            // documentoPagamento
            // 
            this.documentoPagamento.AutoSize = true;
            this.documentoPagamento.ForeColor = System.Drawing.SystemColors.Highlight;
            this.documentoPagamento.Location = new System.Drawing.Point(603, 107);
            this.documentoPagamento.Name = "documentoPagamento";
            this.documentoPagamento.Size = new System.Drawing.Size(35, 13);
            this.documentoPagamento.TabIndex = 21;
            this.documentoPagamento.Text = "label4";
            // 
            // RegularAdiantamentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 452);
            this.Controls.Add(this.documentoAdiantamento);
            this.Controls.Add(this.documentoPagamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.valorDocumento);
            this.Controls.Add(this.botaoSalvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.docRegularTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.adiantamentoTable);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegularAdiantamentoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.RegularAdiantamentoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adiantamentoTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docRegularTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView adiantamentoTable;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView docRegularTable;
        private System.Windows.Forms.Button botaoSalvar;
        private System.Windows.Forms.Label adiantado;
        private System.Windows.Forms.Label liquidado;
        private System.Windows.Forms.TextBox valorDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label documentoAdiantamento;
        private System.Windows.Forms.Label documentoPagamento;
    }
}