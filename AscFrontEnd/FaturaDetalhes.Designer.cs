namespace AscFrontEnd
{
    partial class FaturaDetalhes
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
            this.formaPagamentoCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bancoCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.caixaCombo = new System.Windows.Forms.ComboBox();
            this.formaPagamentoTable = new System.Windows.Forms.DataGridView();
            this.Salvar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.radioCaixa = new System.Windows.Forms.RadioButton();
            this.radioBanco = new System.Windows.Forms.RadioButton();
            this.valorTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.removerPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagamentoTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // formaPagamentoCombo
            // 
            this.formaPagamentoCombo.FormattingEnabled = true;
            this.formaPagamentoCombo.Location = new System.Drawing.Point(12, 88);
            this.formaPagamentoCombo.Name = "formaPagamentoCombo";
            this.formaPagamentoCombo.Size = new System.Drawing.Size(328, 21);
            this.formaPagamentoCombo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Forma Pagamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(370, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Banco";
            // 
            // bancoCombo
            // 
            this.bancoCombo.FormattingEnabled = true;
            this.bancoCombo.Location = new System.Drawing.Point(370, 85);
            this.bancoCombo.Name = "bancoCombo";
            this.bancoCombo.Size = new System.Drawing.Size(328, 21);
            this.bancoCombo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(376, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Caixa";
            // 
            // caixaCombo
            // 
            this.caixaCombo.FormattingEnabled = true;
            this.caixaCombo.Location = new System.Drawing.Point(373, 132);
            this.caixaCombo.Name = "caixaCombo";
            this.caixaCombo.Size = new System.Drawing.Size(328, 21);
            this.caixaCombo.TabIndex = 4;
            // 
            // formaPagamentoTable
            // 
            this.formaPagamentoTable.BackgroundColor = System.Drawing.Color.White;
            this.formaPagamentoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.formaPagamentoTable.Location = new System.Drawing.Point(12, 200);
            this.formaPagamentoTable.Name = "formaPagamentoTable";
            this.formaPagamentoTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.formaPagamentoTable.Size = new System.Drawing.Size(396, 124);
            this.formaPagamentoTable.TabIndex = 6;
            this.formaPagamentoTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.formaPagamentoTable_CellClick);
            // 
            // Salvar
            // 
            this.Salvar.BackColor = System.Drawing.SystemColors.Highlight;
            this.Salvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Salvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salvar.ForeColor = System.Drawing.Color.White;
            this.Salvar.Location = new System.Drawing.Point(548, 293);
            this.Salvar.Name = "Salvar";
            this.Salvar.Size = new System.Drawing.Size(149, 31);
            this.Salvar.TabIndex = 7;
            this.Salvar.Text = "Salvar";
            this.Salvar.UseVisualStyleBackColor = false;
            this.Salvar.Click += new System.EventHandler(this.Salvar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 34);
            this.label4.TabIndex = 8;
            this.label4.Text = "Outros";
            // 
            // radioCaixa
            // 
            this.radioCaixa.AutoSize = true;
            this.radioCaixa.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCaixa.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioCaixa.Location = new System.Drawing.Point(580, 35);
            this.radioCaixa.Name = "radioCaixa";
            this.radioCaixa.Size = new System.Drawing.Size(51, 20);
            this.radioCaixa.TabIndex = 9;
            this.radioCaixa.TabStop = true;
            this.radioCaixa.Text = "Caixa";
            this.radioCaixa.UseVisualStyleBackColor = true;
            this.radioCaixa.CheckedChanged += new System.EventHandler(this.radioCaixa_CheckedChanged);
            // 
            // radioBanco
            // 
            this.radioBanco.AutoSize = true;
            this.radioBanco.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBanco.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioBanco.Location = new System.Drawing.Point(646, 37);
            this.radioBanco.Name = "radioBanco";
            this.radioBanco.Size = new System.Drawing.Size(52, 20);
            this.radioBanco.TabIndex = 10;
            this.radioBanco.TabStop = true;
            this.radioBanco.Text = "Banco";
            this.radioBanco.UseVisualStyleBackColor = true;
            this.radioBanco.CheckedChanged += new System.EventHandler(this.radioBanco_CheckedChanged);
            // 
            // valorTxt
            // 
            this.valorTxt.Location = new System.Drawing.Point(12, 132);
            this.valorTxt.Name = "valorTxt";
            this.valorTxt.Size = new System.Drawing.Size(331, 20);
            this.valorTxt.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(15, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Valor (Kz)";
            // 
            // addButton
            // 
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.addButton.Location = new System.Drawing.Point(12, 158);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(118, 36);
            this.addButton.TabIndex = 13;
            this.addButton.Text = "+ Adicionar";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removerPicture
            // 
            this.removerPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_delete_48;
            this.removerPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.removerPicture.Location = new System.Drawing.Point(414, 200);
            this.removerPicture.Name = "removerPicture";
            this.removerPicture.Size = new System.Drawing.Size(48, 50);
            this.removerPicture.TabIndex = 14;
            this.removerPicture.TabStop = false;
            this.removerPicture.Click += new System.EventHandler(this.removerPicture_Click);
            this.removerPicture.MouseLeave += new System.EventHandler(this.removerPicture_MouseLeave);
            this.removerPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.removerPicture_MouseMove);
            // 
            // FaturaDetalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 336);
            this.Controls.Add(this.removerPicture);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.valorTxt);
            this.Controls.Add(this.radioBanco);
            this.Controls.Add(this.radioCaixa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Salvar);
            this.Controls.Add(this.formaPagamentoTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.caixaCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bancoCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.formaPagamentoCombo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FaturaDetalhes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FaturaDetalhes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.formaPagamentoTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox formaPagamentoCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox bancoCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox caixaCombo;
        private System.Windows.Forms.DataGridView formaPagamentoTable;
        private System.Windows.Forms.Button Salvar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioCaixa;
        private System.Windows.Forms.RadioButton radioBanco;
        private System.Windows.Forms.TextBox valorTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.PictureBox removerPicture;
    }
}