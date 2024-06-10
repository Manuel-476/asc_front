namespace AscFrontEnd
{
    partial class Compra
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
            this.clientetxt = new System.Windows.Forms.Label();
            this.excelBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iva = new System.Windows.Forms.ComboBox();
            this.Qtd = new System.Windows.Forms.TextBox();
            this.codigoDocumento = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.fecharBtn = new System.Windows.Forms.Button();
            this.salvarBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.clienteBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabelaArtigos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.documento = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaArtigos)).BeginInit();
            this.SuspendLayout();
            // 
            // clientetxt
            // 
            this.clientetxt.AutoSize = true;
            this.clientetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientetxt.Location = new System.Drawing.Point(209, 15);
            this.clientetxt.Name = "clientetxt";
            this.clientetxt.Size = new System.Drawing.Size(175, 42);
            this.clientetxt.TabIndex = 35;
            this.clientetxt.Text = "Cliente: 0";
            // 
            // excelBtn
            // 
            this.excelBtn.BackColor = System.Drawing.Color.Green;
            this.excelBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.excelBtn.Location = new System.Drawing.Point(722, 16);
            this.excelBtn.Name = "excelBtn";
            this.excelBtn.Size = new System.Drawing.Size(68, 21);
            this.excelBtn.TabIndex = 34;
            this.excelBtn.Text = "Excel";
            this.excelBtn.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(626, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Iva";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(502, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Qtd";
            // 
            // iva
            // 
            this.iva.FormattingEnabled = true;
            this.iva.Items.AddRange(new object[] {
            "5",
            "7",
            "14"});
            this.iva.Location = new System.Drawing.Point(626, 93);
            this.iva.Name = "iva";
            this.iva.Size = new System.Drawing.Size(111, 21);
            this.iva.TabIndex = 31;
            // 
            // Qtd
            // 
            this.Qtd.Location = new System.Drawing.Point(506, 94);
            this.Qtd.Name = "Qtd";
            this.Qtd.Size = new System.Drawing.Size(102, 20);
            this.Qtd.TabIndex = 30;
            this.Qtd.Text = "0";
            // 
            // codigoDocumento
            // 
            this.codigoDocumento.AutoSize = true;
            this.codigoDocumento.Location = new System.Drawing.Point(477, 93);
            this.codigoDocumento.Name = "codigoDocumento";
            this.codigoDocumento.Size = new System.Drawing.Size(0, 13);
            this.codigoDocumento.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(644, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 22);
            this.button1.TabIndex = 28;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // fecharBtn
            // 
            this.fecharBtn.BackColor = System.Drawing.Color.Red;
            this.fecharBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fecharBtn.Location = new System.Drawing.Point(127, 407);
            this.fecharBtn.Name = "fecharBtn";
            this.fecharBtn.Size = new System.Drawing.Size(85, 29);
            this.fecharBtn.TabIndex = 27;
            this.fecharBtn.Text = "fechar";
            this.fecharBtn.UseVisualStyleBackColor = false;
            // 
            // salvarBtn
            // 
            this.salvarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.salvarBtn.ForeColor = System.Drawing.Color.MistyRose;
            this.salvarBtn.Location = new System.Drawing.Point(21, 407);
            this.salvarBtn.Name = "salvarBtn";
            this.salvarBtn.Size = new System.Drawing.Size(100, 29);
            this.salvarBtn.TabIndex = 26;
            this.salvarBtn.Text = "Salvar";
            this.salvarBtn.UseVisualStyleBackColor = false;
            this.salvarBtn.Click += new System.EventHandler(this.salvarBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(480, 138);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(310, 251);
            this.listBox1.TabIndex = 25;
            // 
            // clienteBtn
            // 
            this.clienteBtn.BackColor = System.Drawing.Color.Aqua;
            this.clienteBtn.Location = new System.Drawing.Point(563, 15);
            this.clienteBtn.Name = "clienteBtn";
            this.clienteBtn.Size = new System.Drawing.Size(75, 23);
            this.clienteBtn.TabIndex = 24;
            this.clienteBtn.Text = "Cliente";
            this.clienteBtn.UseVisualStyleBackColor = false;
            this.clienteBtn.Click += new System.EventHandler(this.clienteBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "pesquisar:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(230, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 20);
            this.textBox1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 42);
            this.label2.TabIndex = 21;
            this.label2.Text = "Compra";
            // 
            // tabelaArtigos
            // 
            this.tabelaArtigos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tabelaArtigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tabelaArtigos.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabelaArtigos.Location = new System.Drawing.Point(14, 138);
            this.tabelaArtigos.Name = "tabelaArtigos";
            this.tabelaArtigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaArtigos.Size = new System.Drawing.Size(441, 251);
            this.tabelaArtigos.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Documento";
            // 
            // documento
            // 
            this.documento.DisplayMember = "FR";
            this.documento.FormattingEnabled = true;
            this.documento.Location = new System.Drawing.Point(10, 93);
            this.documento.Name = "documento";
            this.documento.Size = new System.Drawing.Size(214, 21);
            this.documento.TabIndex = 18;
            this.documento.ValueMember = "FR";
            // 
            // Compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clientetxt);
            this.Controls.Add(this.excelBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.iva);
            this.Controls.Add(this.Qtd);
            this.Controls.Add(this.codigoDocumento);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fecharBtn);
            this.Controls.Add(this.salvarBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.clienteBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabelaArtigos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.documento);
            this.Name = "Compra";
            this.Text = "Compra";
            this.Load += new System.EventHandler(this.Compra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaArtigos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientetxt;
        private System.Windows.Forms.Button excelBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox iva;
        private System.Windows.Forms.TextBox Qtd;
        private System.Windows.Forms.Label codigoDocumento;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button fecharBtn;
        private System.Windows.Forms.Button salvarBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button clienteBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tabelaArtigos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox documento;
    }
}