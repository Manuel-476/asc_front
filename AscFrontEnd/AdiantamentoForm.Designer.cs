namespace AscFrontEnd
{
    partial class AdiantamentoForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.botaoEntidade = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioCliente = new System.Windows.Forms.RadioButton();
            this.radioFornecedor = new System.Windows.Forms.RadioButton();
            this.nomeEntidade = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.valorTxt = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.adiantamentosTable = new System.Windows.Forms.DataGridView();
            this.btnRegular = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adiantamentosTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.botaoEntidade);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 86);
            this.panel1.TabIndex = 4;
            // 
            // botaoEntidade
            // 
            this.botaoEntidade.BackColor = System.Drawing.Color.Transparent;
            this.botaoEntidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoEntidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoEntidade.ForeColor = System.Drawing.Color.White;
            this.botaoEntidade.Location = new System.Drawing.Point(543, 46);
            this.botaoEntidade.Name = "botaoEntidade";
            this.botaoEntidade.Size = new System.Drawing.Size(135, 34);
            this.botaoEntidade.TabIndex = 60;
            this.botaoEntidade.Text = "Entidades";
            this.botaoEntidade.UseVisualStyleBackColor = false;
            this.botaoEntidade.Click += new System.EventHandler(this.botaoFornecedor_Click);
            this.botaoEntidade.MouseLeave += new System.EventHandler(this.botaoFornecedor_MouseLeave);
            this.botaoEntidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.botaoFornecedor_MouseMove);
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
            this.label2.Location = new System.Drawing.Point(126, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Adiantamentos";
            // 
            // radioCliente
            // 
            this.radioCliente.AutoSize = true;
            this.radioCliente.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioCliente.Location = new System.Drawing.Point(12, 94);
            this.radioCliente.Name = "radioCliente";
            this.radioCliente.Size = new System.Drawing.Size(57, 17);
            this.radioCliente.TabIndex = 5;
            this.radioCliente.TabStop = true;
            this.radioCliente.Text = "Cliente";
            this.radioCliente.UseVisualStyleBackColor = true;
            this.radioCliente.CheckedChanged += new System.EventHandler(this.radioCliente_CheckedChanged);
            // 
            // radioFornecedor
            // 
            this.radioFornecedor.AutoSize = true;
            this.radioFornecedor.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioFornecedor.Location = new System.Drawing.Point(84, 94);
            this.radioFornecedor.Name = "radioFornecedor";
            this.radioFornecedor.Size = new System.Drawing.Size(79, 17);
            this.radioFornecedor.TabIndex = 6;
            this.radioFornecedor.TabStop = true;
            this.radioFornecedor.Text = "Fornecedor";
            this.radioFornecedor.UseVisualStyleBackColor = true;
            this.radioFornecedor.CheckedChanged += new System.EventHandler(this.radioFornecedor_CheckedChanged);
            // 
            // nomeEntidade
            // 
            this.nomeEntidade.AutoSize = true;
            this.nomeEntidade.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeEntidade.Location = new System.Drawing.Point(8, 132);
            this.nomeEntidade.Name = "nomeEntidade";
            this.nomeEntidade.Size = new System.Drawing.Size(126, 19);
            this.nomeEntidade.TabIndex = 7;
            this.nomeEntidade.Text = "Nome Entidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(9, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Valor";
            // 
            // valorTxt
            // 
            this.valorTxt.Location = new System.Drawing.Point(12, 189);
            this.valorTxt.Name = "valorTxt";
            this.valorTxt.Size = new System.Drawing.Size(308, 20);
            this.valorTxt.TabIndex = 9;
            this.valorTxt.TextChanged += new System.EventHandler(this.valorTxt_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(12, 251);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 31);
            this.button3.TabIndex = 10;
            this.button3.Text = "Adiantar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // adiantamentosTable
            // 
            this.adiantamentosTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.adiantamentosTable.BackgroundColor = System.Drawing.Color.White;
            this.adiantamentosTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adiantamentosTable.Location = new System.Drawing.Point(365, 132);
            this.adiantamentosTable.Name = "adiantamentosTable";
            this.adiantamentosTable.ReadOnly = true;
            this.adiantamentosTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adiantamentosTable.Size = new System.Drawing.Size(309, 113);
            this.adiantamentosTable.TabIndex = 11;
            // 
            // btnRegular
            // 
            this.btnRegular.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRegular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegular.ForeColor = System.Drawing.Color.White;
            this.btnRegular.Location = new System.Drawing.Point(523, 251);
            this.btnRegular.Name = "btnRegular";
            this.btnRegular.Size = new System.Drawing.Size(151, 31);
            this.btnRegular.TabIndex = 12;
            this.btnRegular.Text = "Regular";
            this.btnRegular.UseVisualStyleBackColor = false;
            this.btnRegular.Click += new System.EventHandler(this.btnRegular_Click);
            // 
            // AdiantamentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 288);
            this.Controls.Add(this.btnRegular);
            this.Controls.Add(this.adiantamentosTable);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.valorTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nomeEntidade);
            this.Controls.Add(this.radioFornecedor);
            this.Controls.Add(this.radioCliente);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdiantamentoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdiantamentoForm_FormClosing);
            this.Load += new System.EventHandler(this.AdiantamentoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adiantamentosTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioCliente;
        private System.Windows.Forms.RadioButton radioFornecedor;
        private System.Windows.Forms.Button botaoEntidade;
        private System.Windows.Forms.Label nomeEntidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox valorTxt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView adiantamentosTable;
        private System.Windows.Forms.Button btnRegular;
    }
}