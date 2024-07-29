namespace AscFrontEnd
{
    partial class CaixaForm
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
            this.caixaTable = new System.Windows.Forms.DataGridView();
            this.feitoBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.descText = new System.Windows.Forms.TextBox();
            this.Descricao = new System.Windows.Forms.Label();
            this.codigoText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.eliminarPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.caixaTable)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eliminarPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // caixaTable
            // 
            this.caixaTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.caixaTable.BackgroundColor = System.Drawing.Color.White;
            this.caixaTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.caixaTable.Location = new System.Drawing.Point(22, 222);
            this.caixaTable.Name = "caixaTable";
            this.caixaTable.Size = new System.Drawing.Size(605, 140);
            this.caixaTable.TabIndex = 26;
            this.caixaTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.caixaTable_CellClick);
            // 
            // feitoBtn
            // 
            this.feitoBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.feitoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.feitoBtn.ForeColor = System.Drawing.Color.White;
            this.feitoBtn.Location = new System.Drawing.Point(221, 169);
            this.feitoBtn.Name = "feitoBtn";
            this.feitoBtn.Size = new System.Drawing.Size(193, 31);
            this.feitoBtn.TabIndex = 25;
            this.feitoBtn.Text = "Feito";
            this.feitoBtn.UseVisualStyleBackColor = false;
            this.feitoBtn.Click += new System.EventHandler(this.feitoBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.addBtn.Location = new System.Drawing.Point(22, 169);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(193, 31);
            this.addBtn.TabIndex = 24;
            this.addBtn.Text = "Adicionar";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // descText
            // 
            this.descText.Location = new System.Drawing.Point(271, 124);
            this.descText.Name = "descText";
            this.descText.Size = new System.Drawing.Size(409, 20);
            this.descText.TabIndex = 19;
            // 
            // Descricao
            // 
            this.Descricao.AutoSize = true;
            this.Descricao.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descricao.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Descricao.Location = new System.Drawing.Point(267, 101);
            this.Descricao.Name = "Descricao";
            this.Descricao.Size = new System.Drawing.Size(69, 20);
            this.Descricao.TabIndex = 18;
            this.Descricao.Text = "Descricao";
            // 
            // codigoText
            // 
            this.codigoText.Location = new System.Drawing.Point(22, 124);
            this.codigoText.Name = "codigoText";
            this.codigoText.Size = new System.Drawing.Size(229, 20);
            this.codigoText.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(18, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Codigo";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 87);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(128, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caixa";
            // 
            // eliminarPicture
            // 
            this.eliminarPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_delete_48;
            this.eliminarPicture.Location = new System.Drawing.Point(643, 222);
            this.eliminarPicture.Name = "eliminarPicture";
            this.eliminarPicture.Size = new System.Drawing.Size(48, 50);
            this.eliminarPicture.TabIndex = 27;
            this.eliminarPicture.TabStop = false;
            this.eliminarPicture.Click += new System.EventHandler(this.eliminarPicture_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_cash_64;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(22, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 87);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // CaixaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 370);
            this.Controls.Add(this.eliminarPicture);
            this.Controls.Add(this.caixaTable);
            this.Controls.Add(this.feitoBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.descText);
            this.Controls.Add(this.Descricao);
            this.Controls.Add(this.codigoText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaixaForm";
            this.ShowIcon = false;
            this.Text = "CaixaForm";
            this.Load += new System.EventHandler(this.CaixaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.caixaTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eliminarPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox eliminarPicture;
        private System.Windows.Forms.DataGridView caixaTable;
        private System.Windows.Forms.Button feitoBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox descText;
        private System.Windows.Forms.Label Descricao;
        private System.Windows.Forms.TextBox codigoText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}