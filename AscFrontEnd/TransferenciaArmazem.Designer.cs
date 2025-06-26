namespace AscFrontEnd
{
    partial class TransferenciaArmazem
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descricaoLabel = new System.Windows.Forms.Label();
            this.localizacaoLabel = new System.Windows.Forms.Label();
            this.armazemLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.qtdText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.localizacaoCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.armazemCombo = new System.Windows.Forms.ComboBox();
            this.artigoLabel = new System.Windows.Forms.Label();
            this.qtdLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-5, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 77);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(103, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transferencia";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.transfer;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(17, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 71);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descricaoLabel);
            this.groupBox1.Controls.Add(this.localizacaoLabel);
            this.groupBox1.Controls.Add(this.armazemLabel);
            this.groupBox1.Location = new System.Drawing.Point(37, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 188);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local";
            // 
            // descricaoLabel
            // 
            this.descricaoLabel.AutoSize = true;
            this.descricaoLabel.Location = new System.Drawing.Point(21, 81);
            this.descricaoLabel.Name = "descricaoLabel";
            this.descricaoLabel.Size = new System.Drawing.Size(55, 13);
            this.descricaoLabel.TabIndex = 2;
            this.descricaoLabel.Text = "Descricao";
            // 
            // localizacaoLabel
            // 
            this.localizacaoLabel.AutoSize = true;
            this.localizacaoLabel.Location = new System.Drawing.Point(21, 138);
            this.localizacaoLabel.Name = "localizacaoLabel";
            this.localizacaoLabel.Size = new System.Drawing.Size(64, 13);
            this.localizacaoLabel.TabIndex = 1;
            this.localizacaoLabel.Text = "Localizacao";
            // 
            // armazemLabel
            // 
            this.armazemLabel.AutoSize = true;
            this.armazemLabel.Location = new System.Drawing.Point(21, 32);
            this.armazemLabel.Name = "armazemLabel";
            this.armazemLabel.Size = new System.Drawing.Size(50, 13);
            this.armazemLabel.TabIndex = 0;
            this.armazemLabel.Text = "Armazem";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.qtdText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.localizacaoCombo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.armazemCombo);
            this.groupBox2.Location = new System.Drawing.Point(434, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 188);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destino";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Qtd";
            // 
            // qtdText
            // 
            this.qtdText.Location = new System.Drawing.Point(33, 155);
            this.qtdText.Name = "qtdText";
            this.qtdText.Size = new System.Drawing.Size(252, 20);
            this.qtdText.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Localizacao";
            // 
            // localizacaoCombo
            // 
            this.localizacaoCombo.FormattingEnabled = true;
            this.localizacaoCombo.Location = new System.Drawing.Point(33, 97);
            this.localizacaoCombo.Name = "localizacaoCombo";
            this.localizacaoCombo.Size = new System.Drawing.Size(252, 21);
            this.localizacaoCombo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Armazem";
            // 
            // armazemCombo
            // 
            this.armazemCombo.FormattingEnabled = true;
            this.armazemCombo.Location = new System.Drawing.Point(33, 48);
            this.armazemCombo.Name = "armazemCombo";
            this.armazemCombo.Size = new System.Drawing.Size(252, 21);
            this.armazemCombo.TabIndex = 0;
            this.armazemCombo.SelectedIndexChanged += new System.EventHandler(this.armazemCombo_SelectedIndexChanged);
            this.armazemCombo.SelectedValueChanged += new System.EventHandler(this.armazemCombo_SelectedValueChanged);
            // 
            // artigoLabel
            // 
            this.artigoLabel.AutoSize = true;
            this.artigoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artigoLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.artigoLabel.Location = new System.Drawing.Point(34, 96);
            this.artigoLabel.Name = "artigoLabel";
            this.artigoLabel.Size = new System.Drawing.Size(44, 13);
            this.artigoLabel.TabIndex = 3;
            this.artigoLabel.Text = "Artigo:";
            // 
            // qtdLabel
            // 
            this.qtdLabel.AutoSize = true;
            this.qtdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtdLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.qtdLabel.Location = new System.Drawing.Point(166, 96);
            this.qtdLabel.Name = "qtdLabel";
            this.qtdLabel.Size = new System.Drawing.Size(31, 13);
            this.qtdLabel.TabIndex = 4;
            this.qtdLabel.Text = "Qtd:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(37, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TransferenciaArmazem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 381);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.qtdLabel);
            this.Controls.Add(this.artigoLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferenciaArmazem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TransferenciaArmazem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label artigoLabel;
        private System.Windows.Forms.Label armazemLabel;
        private System.Windows.Forms.Label qtdLabel;
        private System.Windows.Forms.Label localizacaoLabel;
        private System.Windows.Forms.Label descricaoLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox qtdText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox localizacaoCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox armazemCombo;
        private System.Windows.Forms.Button button1;
    }
}