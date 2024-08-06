namespace AscFrontEnd
{
    partial class IncrementarStock
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.artigoLabel = new System.Windows.Forms.Label();
            this.qtdLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.qtdText = new System.Windows.Forms.TextBox();
            this.salvarBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 77);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(103, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adicionar Stock";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_add_64;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(17, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 71);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // artigoLabel
            // 
            this.artigoLabel.AutoSize = true;
            this.artigoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artigoLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.artigoLabel.Location = new System.Drawing.Point(15, 94);
            this.artigoLabel.Name = "artigoLabel";
            this.artigoLabel.Size = new System.Drawing.Size(40, 13);
            this.artigoLabel.TabIndex = 2;
            this.artigoLabel.Text = "Artigo";
            // 
            // qtdLabel
            // 
            this.qtdLabel.AutoSize = true;
            this.qtdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtdLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.qtdLabel.Location = new System.Drawing.Point(171, 94);
            this.qtdLabel.Name = "qtdLabel";
            this.qtdLabel.Size = new System.Drawing.Size(27, 13);
            this.qtdLabel.TabIndex = 3;
            this.qtdLabel.Text = "Qtd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantidade:";
            // 
            // qtdText
            // 
            this.qtdText.Location = new System.Drawing.Point(18, 160);
            this.qtdText.Name = "qtdText";
            this.qtdText.Size = new System.Drawing.Size(180, 20);
            this.qtdText.TabIndex = 5;
            // 
            // salvarBtn
            // 
            this.salvarBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.salvarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salvarBtn.ForeColor = System.Drawing.Color.White;
            this.salvarBtn.Location = new System.Drawing.Point(18, 205);
            this.salvarBtn.Name = "salvarBtn";
            this.salvarBtn.Size = new System.Drawing.Size(133, 27);
            this.salvarBtn.TabIndex = 6;
            this.salvarBtn.Text = "Salvar";
            this.salvarBtn.UseVisualStyleBackColor = false;
            this.salvarBtn.Click += new System.EventHandler(this.salvarBtn_Click);
            // 
            // IncrementarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 244);
            this.Controls.Add(this.salvarBtn);
            this.Controls.Add(this.qtdText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.qtdLabel);
            this.Controls.Add(this.artigoLabel);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncrementarStock";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IncrementarStock";
            this.Load += new System.EventHandler(this.IncrementarStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label artigoLabel;
        private System.Windows.Forms.Label qtdLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox qtdText;
        private System.Windows.Forms.Button salvarBtn;
    }
}