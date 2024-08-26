namespace AscFrontEnd
{
    partial class Historico
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioVenda = new System.Windows.Forms.RadioButton();
            this.radioCompra = new System.Windows.Forms.RadioButton();
            this.radioCliente = new System.Windows.Forms.RadioButton();
            this.radioFornecedor = new System.Windows.Forms.RadioButton();
            this.radioAmarzem = new System.Windows.Forms.RadioButton();
            this.radioArtigo = new System.Windows.Forms.RadioButton();
            this.radioFuncionario = new System.Windows.Forms.RadioButton();
            this.radiobanco = new System.Windows.Forms.RadioButton();
            this.radioCaixa = new System.Windows.Forms.RadioButton();
            this.radioCc = new System.Windows.Forms.RadioButton();
            this.radioCcF = new System.Windows.Forms.RadioButton();
            this.historicoTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicoTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 79);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_supplier_80;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
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
            this.label2.Location = new System.Drawing.Point(128, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Historico Laboral";
            // 
            // radioVenda
            // 
            this.radioVenda.AutoSize = true;
            this.radioVenda.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioVenda.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioVenda.Location = new System.Drawing.Point(12, 95);
            this.radioVenda.Name = "radioVenda";
            this.radioVenda.Size = new System.Drawing.Size(56, 20);
            this.radioVenda.TabIndex = 16;
            this.radioVenda.TabStop = true;
            this.radioVenda.Text = "Venda";
            this.radioVenda.UseVisualStyleBackColor = true;
            this.radioVenda.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioCompra
            // 
            this.radioCompra.AutoSize = true;
            this.radioCompra.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCompra.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioCompra.Location = new System.Drawing.Point(85, 95);
            this.radioCompra.Name = "radioCompra";
            this.radioCompra.Size = new System.Drawing.Size(63, 20);
            this.radioCompra.TabIndex = 17;
            this.radioCompra.TabStop = true;
            this.radioCompra.Text = "Compra";
            this.radioCompra.UseVisualStyleBackColor = true;
            this.radioCompra.CheckedChanged += new System.EventHandler(this.radioCompra_CheckedChanged);
            // 
            // radioCliente
            // 
            this.radioCliente.AutoSize = true;
            this.radioCliente.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCliente.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioCliente.Location = new System.Drawing.Point(180, 95);
            this.radioCliente.Name = "radioCliente";
            this.radioCliente.Size = new System.Drawing.Size(57, 20);
            this.radioCliente.TabIndex = 18;
            this.radioCliente.TabStop = true;
            this.radioCliente.Text = "Cliente";
            this.radioCliente.UseVisualStyleBackColor = true;
            // 
            // radioFornecedor
            // 
            this.radioFornecedor.AutoSize = true;
            this.radioFornecedor.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFornecedor.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioFornecedor.Location = new System.Drawing.Point(268, 95);
            this.radioFornecedor.Name = "radioFornecedor";
            this.radioFornecedor.Size = new System.Drawing.Size(81, 20);
            this.radioFornecedor.TabIndex = 19;
            this.radioFornecedor.TabStop = true;
            this.radioFornecedor.Text = "Fornecedor";
            this.radioFornecedor.UseVisualStyleBackColor = true;
            // 
            // radioAmarzem
            // 
            this.radioAmarzem.AutoSize = true;
            this.radioAmarzem.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAmarzem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioAmarzem.Location = new System.Drawing.Point(381, 95);
            this.radioAmarzem.Name = "radioAmarzem";
            this.radioAmarzem.Size = new System.Drawing.Size(69, 20);
            this.radioAmarzem.TabIndex = 20;
            this.radioAmarzem.TabStop = true;
            this.radioAmarzem.Text = "Armazem";
            this.radioAmarzem.UseVisualStyleBackColor = true;
            // 
            // radioArtigo
            // 
            this.radioArtigo.AutoSize = true;
            this.radioArtigo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioArtigo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioArtigo.Location = new System.Drawing.Point(486, 95);
            this.radioArtigo.Name = "radioArtigo";
            this.radioArtigo.Size = new System.Drawing.Size(52, 20);
            this.radioArtigo.TabIndex = 21;
            this.radioArtigo.TabStop = true;
            this.radioArtigo.Text = "Artigo";
            this.radioArtigo.UseVisualStyleBackColor = true;
            // 
            // radioFuncionario
            // 
            this.radioFuncionario.AutoSize = true;
            this.radioFuncionario.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFuncionario.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioFuncionario.Location = new System.Drawing.Point(595, 95);
            this.radioFuncionario.Name = "radioFuncionario";
            this.radioFuncionario.Size = new System.Drawing.Size(81, 20);
            this.radioFuncionario.TabIndex = 22;
            this.radioFuncionario.TabStop = true;
            this.radioFuncionario.Text = "Funcionario";
            this.radioFuncionario.UseVisualStyleBackColor = true;
            // 
            // radiobanco
            // 
            this.radiobanco.AutoSize = true;
            this.radiobanco.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobanco.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radiobanco.Location = new System.Drawing.Point(718, 95);
            this.radiobanco.Name = "radiobanco";
            this.radiobanco.Size = new System.Drawing.Size(55, 20);
            this.radiobanco.TabIndex = 23;
            this.radiobanco.TabStop = true;
            this.radiobanco.Text = "Banco";
            this.radiobanco.UseVisualStyleBackColor = true;
            // 
            // radioCaixa
            // 
            this.radioCaixa.AutoSize = true;
            this.radioCaixa.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCaixa.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioCaixa.Location = new System.Drawing.Point(827, 95);
            this.radioCaixa.Name = "radioCaixa";
            this.radioCaixa.Size = new System.Drawing.Size(53, 20);
            this.radioCaixa.TabIndex = 24;
            this.radioCaixa.TabStop = true;
            this.radioCaixa.Text = "Caixa";
            this.radioCaixa.UseVisualStyleBackColor = true;
            // 
            // radioCc
            // 
            this.radioCc.AutoSize = true;
            this.radioCc.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioCc.Location = new System.Drawing.Point(12, 131);
            this.radioCc.Name = "radioCc";
            this.radioCc.Size = new System.Drawing.Size(143, 20);
            this.radioCc.TabIndex = 25;
            this.radioCc.TabStop = true;
            this.radioCc.Text = "Contas Correntes Cliente";
            this.radioCc.UseVisualStyleBackColor = true;
            // 
            // radioCcF
            // 
            this.radioCcF.AutoSize = true;
            this.radioCcF.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCcF.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioCcF.Location = new System.Drawing.Point(165, 131);
            this.radioCcF.Name = "radioCcF";
            this.radioCcF.Size = new System.Drawing.Size(167, 20);
            this.radioCcF.TabIndex = 26;
            this.radioCcF.TabStop = true;
            this.radioCcF.Text = "Contas Correntes Fornecedor";
            this.radioCcF.UseVisualStyleBackColor = true;
            // 
            // historicoTable
            // 
            this.historicoTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.historicoTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.historicoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historicoTable.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.historicoTable.Location = new System.Drawing.Point(13, 203);
            this.historicoTable.Name = "historicoTable";
            this.historicoTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.historicoTable.Size = new System.Drawing.Size(952, 305);
            this.historicoTable.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(13, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Pesquisar:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 172);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 20);
            this.textBox1.TabIndex = 29;
            // 
            // Historico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 520);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.historicoTable);
            this.Controls.Add(this.radioCcF);
            this.Controls.Add(this.radioCc);
            this.Controls.Add(this.radioCaixa);
            this.Controls.Add(this.radiobanco);
            this.Controls.Add(this.radioFuncionario);
            this.Controls.Add(this.radioArtigo);
            this.Controls.Add(this.radioAmarzem);
            this.Controls.Add(this.radioFornecedor);
            this.Controls.Add(this.radioCliente);
            this.Controls.Add(this.radioCompra);
            this.Controls.Add(this.radioVenda);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Historico";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historico";
            this.Load += new System.EventHandler(this.Historico_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicoTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioVenda;
        private System.Windows.Forms.RadioButton radioCompra;
        private System.Windows.Forms.RadioButton radioCliente;
        private System.Windows.Forms.RadioButton radioFornecedor;
        private System.Windows.Forms.RadioButton radioAmarzem;
        private System.Windows.Forms.RadioButton radioArtigo;
        private System.Windows.Forms.RadioButton radioFuncionario;
        private System.Windows.Forms.RadioButton radiobanco;
        private System.Windows.Forms.RadioButton radioCaixa;
        private System.Windows.Forms.RadioButton radioCc;
        private System.Windows.Forms.RadioButton radioCcF;
        private System.Windows.Forms.DataGridView historicoTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}