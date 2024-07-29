namespace AscFrontEnd
{
    partial class BancoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.codigoText = new System.Windows.Forms.TextBox();
            this.descText = new System.Windows.Forms.TextBox();
            this.Descricao = new System.Windows.Forms.Label();
            this.contaText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ibanText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.feitoBtn = new System.Windows.Forms.Button();
            this.bancoTable = new System.Windows.Forms.DataGridView();
            this.eliminarPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bancoTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliminarPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 87);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(128, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Banco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(19, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Codigo";
            // 
            // codigoText
            // 
            this.codigoText.Location = new System.Drawing.Point(23, 123);
            this.codigoText.Name = "codigoText";
            this.codigoText.Size = new System.Drawing.Size(229, 20);
            this.codigoText.TabIndex = 4;
            // 
            // descText
            // 
            this.descText.Location = new System.Drawing.Point(272, 123);
            this.descText.Name = "descText";
            this.descText.Size = new System.Drawing.Size(409, 20);
            this.descText.TabIndex = 6;
            // 
            // Descricao
            // 
            this.Descricao.AutoSize = true;
            this.Descricao.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descricao.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Descricao.Location = new System.Drawing.Point(268, 100);
            this.Descricao.Name = "Descricao";
            this.Descricao.Size = new System.Drawing.Size(69, 20);
            this.Descricao.TabIndex = 5;
            this.Descricao.Text = "Descricao";
            // 
            // contaText
            // 
            this.contaText.Location = new System.Drawing.Point(23, 183);
            this.contaText.Name = "contaText";
            this.contaText.Size = new System.Drawing.Size(317, 20);
            this.contaText.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(19, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nº Conta";
            // 
            // ibanText
            // 
            this.ibanText.Location = new System.Drawing.Point(364, 183);
            this.ibanText.Name = "ibanText";
            this.ibanText.Size = new System.Drawing.Size(317, 20);
            this.ibanText.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(360, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "IBAN";
            // 
            // addBtn
            // 
            this.addBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.addBtn.Location = new System.Drawing.Point(23, 219);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(193, 31);
            this.addBtn.TabIndex = 11;
            this.addBtn.Text = "Adicionar";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // feitoBtn
            // 
            this.feitoBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.feitoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.feitoBtn.ForeColor = System.Drawing.Color.White;
            this.feitoBtn.Location = new System.Drawing.Point(222, 219);
            this.feitoBtn.Name = "feitoBtn";
            this.feitoBtn.Size = new System.Drawing.Size(193, 31);
            this.feitoBtn.TabIndex = 12;
            this.feitoBtn.Text = "Feito";
            this.feitoBtn.UseVisualStyleBackColor = false;
            this.feitoBtn.Click += new System.EventHandler(this.feitoBtn_Click);
            // 
            // bancoTable
            // 
            this.bancoTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bancoTable.BackgroundColor = System.Drawing.Color.White;
            this.bancoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bancoTable.Location = new System.Drawing.Point(23, 266);
            this.bancoTable.Name = "bancoTable";
            this.bancoTable.Size = new System.Drawing.Size(605, 140);
            this.bancoTable.TabIndex = 13;
            this.bancoTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bancoTable_CellClick);
            // 
            // eliminarPicture
            // 
            this.eliminarPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_delete_48;
            this.eliminarPicture.Location = new System.Drawing.Point(644, 266);
            this.eliminarPicture.Name = "eliminarPicture";
            this.eliminarPicture.Size = new System.Drawing.Size(48, 50);
            this.eliminarPicture.TabIndex = 14;
            this.eliminarPicture.TabStop = false;
            this.eliminarPicture.Click += new System.EventHandler(this.eliminarPicture_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_bank_64;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(22, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 87);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // BancoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 417);
            this.Controls.Add(this.eliminarPicture);
            this.Controls.Add(this.bancoTable);
            this.Controls.Add(this.feitoBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.ibanText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.contaText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descText);
            this.Controls.Add(this.Descricao);
            this.Controls.Add(this.codigoText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BancoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BancoFomr";
            this.Load += new System.EventHandler(this.BancoFomr_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bancoTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliminarPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codigoText;
        private System.Windows.Forms.TextBox descText;
        private System.Windows.Forms.Label Descricao;
        private System.Windows.Forms.TextBox contaText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ibanText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button feitoBtn;
        private System.Windows.Forms.DataGridView bancoTable;
        private System.Windows.Forms.PictureBox eliminarPicture;
    }
}