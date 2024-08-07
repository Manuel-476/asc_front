namespace AscFrontEnd
{
    partial class LiquidaDivida
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.entidadeLabel = new System.Windows.Forms.Label();
            this.dividaLabel = new System.Windows.Forms.Label();
            this.liquidado = new System.Windows.Forms.Label();
            this.valorTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.documentoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 75);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(98, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Liquidar Divida";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_chain_48;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(37, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 83);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // entidadeLabel
            // 
            this.entidadeLabel.AutoSize = true;
            this.entidadeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entidadeLabel.Location = new System.Drawing.Point(37, 91);
            this.entidadeLabel.Name = "entidadeLabel";
            this.entidadeLabel.Size = new System.Drawing.Size(142, 24);
            this.entidadeLabel.TabIndex = 2;
            this.entidadeLabel.Text = "entidadeLabel";
            // 
            // dividaLabel
            // 
            this.dividaLabel.AutoSize = true;
            this.dividaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dividaLabel.ForeColor = System.Drawing.Color.Red;
            this.dividaLabel.Location = new System.Drawing.Point(15, 22);
            this.dividaLabel.Name = "dividaLabel";
            this.dividaLabel.Size = new System.Drawing.Size(41, 13);
            this.dividaLabel.TabIndex = 3;
            this.dividaLabel.Text = "divida";
            // 
            // liquidado
            // 
            this.liquidado.AutoSize = true;
            this.liquidado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liquidado.ForeColor = System.Drawing.Color.Green;
            this.liquidado.Location = new System.Drawing.Point(15, 61);
            this.liquidado.Name = "liquidado";
            this.liquidado.Size = new System.Drawing.Size(58, 13);
            this.liquidado.TabIndex = 4;
            this.liquidado.Text = "liquidado";
            // 
            // valorTxt
            // 
            this.valorTxt.Location = new System.Drawing.Point(37, 152);
            this.valorTxt.Name = "valorTxt";
            this.valorTxt.Size = new System.Drawing.Size(290, 20);
            this.valorTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(37, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.liquidado);
            this.groupBox1.Controls.Add(this.dividaLabel);
            this.groupBox1.Location = new System.Drawing.Point(450, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 87);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condicao";
            // 
            // documentoLabel
            // 
            this.documentoLabel.AutoSize = true;
            this.documentoLabel.Location = new System.Drawing.Point(447, 196);
            this.documentoLabel.Name = "documentoLabel";
            this.documentoLabel.Size = new System.Drawing.Size(60, 13);
            this.documentoLabel.TabIndex = 9;
            this.documentoLabel.Text = "documento";
            // 
            // LiquidaDivida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 249);
            this.Controls.Add(this.documentoLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.valorTxt);
            this.Controls.Add(this.entidadeLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LiquidaDivida";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiquidaDivida";
            this.Load += new System.EventHandler(this.LiquidaDivida_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label entidadeLabel;
        private System.Windows.Forms.Label dividaLabel;
        private System.Windows.Forms.Label liquidado;
        private System.Windows.Forms.TextBox valorTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label documentoLabel;
    }
}