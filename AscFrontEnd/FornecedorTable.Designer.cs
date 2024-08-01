namespace AscFrontEnd
{
    partial class FornecedorTable
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
            this.label1 = new System.Windows.Forms.Label();
            this.pesqText = new System.Windows.Forms.TextBox();
            this.tabelaFornecedor = new System.Windows.Forms.DataGridView();
            this.transformar = new System.Windows.Forms.PictureBox();
            this.eliminarPicture = new System.Windows.Forms.PictureBox();
            this.editarPicture = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaFornecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliminarPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editarPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-1, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 86);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_supplier_80;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(13, 11);
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
            this.label2.Location = new System.Drawing.Point(132, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fornecedores";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Pesquisar:";
            // 
            // pesqText
            // 
            this.pesqText.Location = new System.Drawing.Point(105, 110);
            this.pesqText.Name = "pesqText";
            this.pesqText.Size = new System.Drawing.Size(226, 20);
            this.pesqText.TabIndex = 12;
            // 
            // tabelaFornecedor
            // 
            this.tabelaFornecedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaFornecedor.BackgroundColor = System.Drawing.Color.White;
            this.tabelaFornecedor.Location = new System.Drawing.Point(9, 136);
            this.tabelaFornecedor.Name = "tabelaFornecedor";
            this.tabelaFornecedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaFornecedor.Size = new System.Drawing.Size(673, 308);
            this.tabelaFornecedor.TabIndex = 11;
            this.tabelaFornecedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaCliente_CellClick);
            // 
            // transformar
            // 
            this.transformar.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_transformation_48;
            this.transformar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.transformar.Location = new System.Drawing.Point(705, 287);
            this.transformar.Name = "transformar";
            this.transformar.Size = new System.Drawing.Size(71, 50);
            this.transformar.TabIndex = 17;
            this.transformar.TabStop = false;
            this.transformar.Click += new System.EventHandler(this.transformar_Click);
            this.transformar.MouseLeave += new System.EventHandler(this.transformar_MouseLeave);
            this.transformar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.transformar_MouseMove);
            // 
            // eliminarPicture
            // 
            this.eliminarPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_delete_48;
            this.eliminarPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.eliminarPicture.Location = new System.Drawing.Point(705, 209);
            this.eliminarPicture.Name = "eliminarPicture";
            this.eliminarPicture.Size = new System.Drawing.Size(71, 50);
            this.eliminarPicture.TabIndex = 16;
            this.eliminarPicture.TabStop = false;
            this.eliminarPicture.Click += new System.EventHandler(this.eliminarPicture_Click);
            this.eliminarPicture.MouseLeave += new System.EventHandler(this.eliminarPicture_MouseLeave);
            this.eliminarPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.eliminarPicture_MouseMove);
            // 
            // editarPicture
            // 
            this.editarPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_edit_40;
            this.editarPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editarPicture.Location = new System.Drawing.Point(705, 136);
            this.editarPicture.Name = "editarPicture";
            this.editarPicture.Size = new System.Drawing.Size(71, 50);
            this.editarPicture.TabIndex = 15;
            this.editarPicture.TabStop = false;
            this.editarPicture.MouseLeave += new System.EventHandler(this.editarPicture_MouseLeave);
            this.editarPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.editarPicture_MouseMove);
            // 
            // FornecedorTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.transformar);
            this.Controls.Add(this.eliminarPicture);
            this.Controls.Add(this.editarPicture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pesqText);
            this.Controls.Add(this.tabelaFornecedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FornecedorTable";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FornecedorTable";
            this.Load += new System.EventHandler(this.FornecedorTable_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaFornecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliminarPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editarPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox transformar;
        private System.Windows.Forms.PictureBox eliminarPicture;
        private System.Windows.Forms.PictureBox editarPicture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pesqText;
        private System.Windows.Forms.DataGridView tabelaFornecedor;
    }
}