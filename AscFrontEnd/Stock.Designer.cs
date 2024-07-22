namespace AscFrontEnd
{
    partial class Stock
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pesqText = new System.Windows.Forms.TextBox();
            this.tabelaInventario = new System.Windows.Forms.DataGridView();
            this.removeStockPicture = new System.Windows.Forms.PictureBox();
            this.addStockPicture = new System.Windows.Forms.PictureBox();
            this.transferPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.artigoTexto = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeStockPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addStockPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.artigoTexto);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 93);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(135, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inventario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pesquisar:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pesqText
            // 
            this.pesqText.Location = new System.Drawing.Point(106, 104);
            this.pesqText.Name = "pesqText";
            this.pesqText.Size = new System.Drawing.Size(220, 20);
            this.pesqText.TabIndex = 5;
            this.pesqText.TextChanged += new System.EventHandler(this.pesqText_TextChanged);
            // 
            // tabelaInventario
            // 
            this.tabelaInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaInventario.BackgroundColor = System.Drawing.Color.White;
            this.tabelaInventario.Location = new System.Drawing.Point(13, 130);
            this.tabelaInventario.Name = "tabelaInventario";
            this.tabelaInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaInventario.Size = new System.Drawing.Size(890, 293);
            this.tabelaInventario.TabIndex = 4;
            this.tabelaInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaCliente_CellContentClick);
            // 
            // removeStockPicture
            // 
            this.removeStockPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.remove;
            this.removeStockPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.removeStockPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeStockPicture.Location = new System.Drawing.Point(945, 337);
            this.removeStockPicture.Name = "removeStockPicture";
            this.removeStockPicture.Size = new System.Drawing.Size(100, 86);
            this.removeStockPicture.TabIndex = 10;
            this.removeStockPicture.TabStop = false;
            this.removeStockPicture.Tag = "Decrementar Stock";
            // 
            // addStockPicture
            // 
            this.addStockPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.warehouse;
            this.addStockPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addStockPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addStockPicture.Location = new System.Drawing.Point(945, 236);
            this.addStockPicture.Name = "addStockPicture";
            this.addStockPicture.Size = new System.Drawing.Size(100, 86);
            this.addStockPicture.TabIndex = 9;
            this.addStockPicture.TabStop = false;
            this.addStockPicture.Tag = "Incrementar Stock";
            // 
            // transferPicture
            // 
            this.transferPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.transfer;
            this.transferPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.transferPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transferPicture.Location = new System.Drawing.Point(945, 130);
            this.transferPicture.Name = "transferPicture";
            this.transferPicture.Size = new System.Drawing.Size(100, 86);
            this.transferPicture.TabIndex = 8;
            this.transferPicture.TabStop = false;
            this.transferPicture.Tag = "Transferencia Stock";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_client_80;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(13, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 69);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // artigoTexto
            // 
            this.artigoTexto.AutoSize = true;
            this.artigoTexto.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artigoTexto.ForeColor = System.Drawing.Color.White;
            this.artigoTexto.Location = new System.Drawing.Point(571, 32);
            this.artigoTexto.Name = "artigoTexto";
            this.artigoTexto.Size = new System.Drawing.Size(93, 32);
            this.artigoTexto.TabIndex = 2;
            this.artigoTexto.Text = "Artigo:";
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 461);
            this.Controls.Add(this.removeStockPicture);
            this.Controls.Add(this.addStockPicture);
            this.Controls.Add(this.transferPicture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pesqText);
            this.Controls.Add(this.tabelaInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.Stock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeStockPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addStockPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pesqText;
        private System.Windows.Forms.DataGridView tabelaInventario;
        private System.Windows.Forms.PictureBox transferPicture;
        private System.Windows.Forms.PictureBox addStockPicture;
        private System.Windows.Forms.PictureBox removeStockPicture;
        private System.Windows.Forms.Label artigoTexto;
    }
}