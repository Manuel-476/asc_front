namespace AscFrontEnd
{
    partial class UserForm
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
            this.nomeText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.senha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nivelAcessoLabel = new System.Windows.Forms.Label();
            this.nivelAcesso = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titulo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nomeText
            // 
            this.nomeText.Location = new System.Drawing.Point(350, 151);
            this.nomeText.Name = "nomeText";
            this.nomeText.Size = new System.Drawing.Size(351, 20);
            this.nomeText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(346, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome Usuario:";
            // 
            // senha
            // 
            this.senha.Location = new System.Drawing.Point(350, 207);
            this.senha.Name = "senha";
            this.senha.Size = new System.Drawing.Size(351, 20);
            this.senha.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(346, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Palavra-Passe:";
            // 
            // nivelAcessoLabel
            // 
            this.nivelAcessoLabel.AutoSize = true;
            this.nivelAcessoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nivelAcessoLabel.ForeColor = System.Drawing.Color.White;
            this.nivelAcessoLabel.Location = new System.Drawing.Point(346, 239);
            this.nivelAcessoLabel.Name = "nivelAcessoLabel";
            this.nivelAcessoLabel.Size = new System.Drawing.Size(103, 20);
            this.nivelAcessoLabel.TabIndex = 7;
            this.nivelAcessoLabel.Text = "Nivel Acesso:";
            // 
            // nivelAcesso
            // 
            this.nivelAcesso.FormattingEnabled = true;
            this.nivelAcesso.Location = new System.Drawing.Point(350, 262);
            this.nivelAcesso.Name = "nivelAcesso";
            this.nivelAcesso.Size = new System.Drawing.Size(351, 21);
            this.nivelAcesso.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_key_200;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(52, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 208);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.White;
            this.titulo.Location = new System.Drawing.Point(46, 22);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(257, 31);
            this.titulo.TabIndex = 10;
            this.titulo.Text = "Credenciais De Acesso";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(530, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "Feito";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.ForeColor = System.Drawing.Color.White;
            this.infoLabel.Location = new System.Drawing.Point(48, 53);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 20);
            this.infoLabel.TabIndex = 12;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 353);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nivelAcesso);
            this.Controls.Add(this.nivelAcessoLabel);
            this.Controls.Add(this.senha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nomeText);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserFotm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomeText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox senha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nivelAcessoLabel;
        private System.Windows.Forms.ComboBox nivelAcesso;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label infoLabel;
    }
}