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
            ((System.ComponentModel.ISupportInitialize)(this.ipPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.senhaPicture)).BeginInit();
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
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 237);
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
    }
}