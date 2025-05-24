namespace AscFrontEnd
{
    partial class ConfigForm
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
            this.senhaLabel = new System.Windows.Forms.Label();
            this.stockLabel = new System.Windows.Forms.Label();
            this.imgLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipPicture = new System.Windows.Forms.PictureBox();
            this.imgPicture = new System.Windows.Forms.PictureBox();
            this.stockPicture = new System.Windows.Forms.PictureBox();
            this.senhaPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saftPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ipPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.senhaPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saftPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // senhaLabel
            // 
            this.senhaLabel.AutoSize = true;
            this.senhaLabel.Location = new System.Drawing.Point(33, 194);
            this.senhaLabel.Name = "senhaLabel";
            this.senhaLabel.Size = new System.Drawing.Size(71, 13);
            this.senhaLabel.TabIndex = 4;
            this.senhaLabel.Text = "Alterar Senha";
            // 
            // stockLabel
            // 
            this.stockLabel.AutoSize = true;
            this.stockLabel.Location = new System.Drawing.Point(197, 194);
            this.stockLabel.Name = "stockLabel";
            this.stockLabel.Size = new System.Drawing.Size(71, 13);
            this.stockLabel.TabIndex = 5;
            this.stockLabel.Text = "Stock Minimo";
            // 
            // imgLabel
            // 
            this.imgLabel.AutoSize = true;
            this.imgLabel.Location = new System.Drawing.Point(346, 194);
            this.imgLabel.Name = "imgLabel";
            this.imgLabel.Size = new System.Drawing.Size(76, 13);
            this.imgLabel.TabIndex = 6;
            this.imgLabel.Text = "Alterar imagem";
            this.imgLabel.Click += new System.EventHandler(this.imgLabel_Click);
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(505, 194);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(95, 13);
            this.ipLabel.TabIndex = 7;
            this.ipLabel.Text = "Endereço Servidor";
            // 
            // ipPicture
            // 
            this.ipPicture.BackColor = System.Drawing.SystemColors.Highlight;
            this.ipPicture.Location = new System.Drawing.Point(493, 21);
            this.ipPicture.Name = "ipPicture";
            this.ipPicture.Size = new System.Drawing.Size(119, 150);
            this.ipPicture.TabIndex = 3;
            this.ipPicture.TabStop = false;
            this.ipPicture.Click += new System.EventHandler(this.ipPicture_Click);
            // 
            // imgPicture
            // 
            this.imgPicture.BackColor = System.Drawing.Color.Red;
            this.imgPicture.Location = new System.Drawing.Point(327, 21);
            this.imgPicture.Name = "imgPicture";
            this.imgPicture.Size = new System.Drawing.Size(119, 150);
            this.imgPicture.TabIndex = 2;
            this.imgPicture.TabStop = false;
            this.imgPicture.Click += new System.EventHandler(this.imgPicture_Click);
            // 
            // stockPicture
            // 
            this.stockPicture.BackColor = System.Drawing.Color.SpringGreen;
            this.stockPicture.Location = new System.Drawing.Point(175, 21);
            this.stockPicture.Name = "stockPicture";
            this.stockPicture.Size = new System.Drawing.Size(119, 150);
            this.stockPicture.TabIndex = 1;
            this.stockPicture.TabStop = false;
            this.stockPicture.Click += new System.EventHandler(this.stockPicture_Click);
            // 
            // senhaPicture
            // 
            this.senhaPicture.BackColor = System.Drawing.Color.Gold;
            this.senhaPicture.Location = new System.Drawing.Point(12, 21);
            this.senhaPicture.Name = "senhaPicture";
            this.senhaPicture.Size = new System.Drawing.Size(119, 150);
            this.senhaPicture.TabIndex = 0;
            this.senhaPicture.TabStop = false;
            this.senhaPicture.Click += new System.EventHandler(this.senhaPicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Gerar Saft";
            // 
            // saftPicture
            // 
            this.saftPicture.BackColor = System.Drawing.Color.OrangeRed;
            this.saftPicture.Location = new System.Drawing.Point(652, 21);
            this.saftPicture.Name = "saftPicture";
            this.saftPicture.Size = new System.Drawing.Size(119, 150);
            this.saftPicture.TabIndex = 8;
            this.saftPicture.TabStop = false;
            this.saftPicture.Click += new System.EventHandler(this.saftPicture_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 237);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saftPicture);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.imgLabel);
            this.Controls.Add(this.stockLabel);
            this.Controls.Add(this.senhaLabel);
            this.Controls.Add(this.ipPicture);
            this.Controls.Add(this.imgPicture);
            this.Controls.Add(this.stockPicture);
            this.Controls.Add(this.senhaPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.ipPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.senhaPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saftPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox senhaPicture;
        private System.Windows.Forms.PictureBox stockPicture;
        private System.Windows.Forms.PictureBox imgPicture;
        private System.Windows.Forms.PictureBox ipPicture;
        private System.Windows.Forms.Label senhaLabel;
        private System.Windows.Forms.Label stockLabel;
        private System.Windows.Forms.Label imgLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox saftPicture;
    }
}