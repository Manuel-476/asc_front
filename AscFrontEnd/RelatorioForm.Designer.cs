namespace AscFrontEnd
{
    partial class RelatorioForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.relatorioVenda = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureFinanceiro = new System.Windows.Forms.PictureBox();
            this.pictureStock = new System.Windows.Forms.PictureBox();
            this.pictureCompra = new System.Windows.Forms.PictureBox();
            this.pictureVenda = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFinanceiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Relatórios";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // relatorioVenda
            // 
            this.relatorioVenda.AutoSize = true;
            this.relatorioVenda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatorioVenda.ForeColor = System.Drawing.SystemColors.Highlight;
            this.relatorioVenda.Location = new System.Drawing.Point(45, 253);
            this.relatorioVenda.Name = "relatorioVenda";
            this.relatorioVenda.Size = new System.Drawing.Size(47, 16);
            this.relatorioVenda.TabIndex = 2;
            this.relatorioVenda.Text = "Venda";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 69);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(195, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Compra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(360, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Stock";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(500, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Financeiro";
            // 
            // pictureFinanceiro
            // 
            this.pictureFinanceiro.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureFinanceiro.BackgroundImage = global::AscFrontEnd.Properties.Resources.report__1_;
            this.pictureFinanceiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureFinanceiro.Location = new System.Drawing.Point(478, 91);
            this.pictureFinanceiro.Name = "pictureFinanceiro";
            this.pictureFinanceiro.Size = new System.Drawing.Size(117, 150);
            this.pictureFinanceiro.TabIndex = 6;
            this.pictureFinanceiro.TabStop = false;
            this.pictureFinanceiro.MouseLeave += new System.EventHandler(this.pictureFinanceiro_MouseLeave);
            this.pictureFinanceiro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureFinanceiro_MouseMove);
            // 
            // pictureStock
            // 
            this.pictureStock.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureStock.BackgroundImage = global::AscFrontEnd.Properties.Resources.candlestick;
            this.pictureStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureStock.Location = new System.Drawing.Point(325, 91);
            this.pictureStock.Name = "pictureStock";
            this.pictureStock.Size = new System.Drawing.Size(117, 150);
            this.pictureStock.TabIndex = 5;
            this.pictureStock.TabStop = false;
            this.pictureStock.MouseLeave += new System.EventHandler(this.pictureStock_MouseLeave);
            this.pictureStock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureStock_MouseMove);
            // 
            // pictureCompra
            // 
            this.pictureCompra.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureCompra.BackgroundImage = global::AscFrontEnd.Properties.Resources.reports;
            this.pictureCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureCompra.Location = new System.Drawing.Point(164, 91);
            this.pictureCompra.Name = "pictureCompra";
            this.pictureCompra.Size = new System.Drawing.Size(124, 150);
            this.pictureCompra.TabIndex = 4;
            this.pictureCompra.TabStop = false;
            this.pictureCompra.Click += new System.EventHandler(this.pictureCompra_Click);
            this.pictureCompra.MouseLeave += new System.EventHandler(this.pictureCompra_MouseLeave);
            this.pictureCompra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // pictureVenda
            // 
            this.pictureVenda.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureVenda.BackgroundImage = global::AscFrontEnd.Properties.Resources.report__2_;
            this.pictureVenda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureVenda.Location = new System.Drawing.Point(15, 91);
            this.pictureVenda.Name = "pictureVenda";
            this.pictureVenda.Size = new System.Drawing.Size(117, 150);
            this.pictureVenda.TabIndex = 0;
            this.pictureVenda.TabStop = false;
            this.pictureVenda.MouseLeave += new System.EventHandler(this.pictureVenda_MouseLeave);
            this.pictureVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureVenda_MouseMove);
            // 
            // RelatorioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 286);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureFinanceiro);
            this.Controls.Add(this.pictureStock);
            this.Controls.Add(this.pictureCompra);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.relatorioVenda);
            this.Controls.Add(this.pictureVenda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelatorioForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.RelatorioForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFinanceiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureVenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label relatorioVenda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureCompra;
        private System.Windows.Forms.PictureBox pictureStock;
        private System.Windows.Forms.PictureBox pictureFinanceiro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}