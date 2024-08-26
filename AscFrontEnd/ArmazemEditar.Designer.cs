namespace AscFrontEnd
{
    partial class ArmazemEditar
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
            this.salvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.localizacaoTable = new System.Windows.Forms.DataGridView();
            this.localizacaoFisicatxt = new System.Windows.Forms.Label();
            this.localizacaoFisica = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.codigoLocalizacao = new System.Windows.Forms.TextBox();
            this.descricaoLocalizacao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descricaoArmazem = new System.Windows.Forms.TextBox();
            this.codigoArmazenlbl = new System.Windows.Forms.Label();
            this.codigoArmazemtxt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localizacaoTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // salvar
            // 
            this.salvar.BackColor = System.Drawing.SystemColors.Highlight;
            this.salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salvar.ForeColor = System.Drawing.Color.White;
            this.salvar.Location = new System.Drawing.Point(30, 430);
            this.salvar.Name = "salvar";
            this.salvar.Size = new System.Drawing.Size(239, 33);
            this.salvar.TabIndex = 13;
            this.salvar.Text = "Salvar";
            this.salvar.UseVisualStyleBackColor = false;
            this.salvar.Click += new System.EventHandler(this.salvar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.localizacaoTable);
            this.panel1.Controls.Add(this.localizacaoFisicatxt);
            this.panel1.Controls.Add(this.localizacaoFisica);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.codigoLocalizacao);
            this.panel1.Controls.Add(this.descricaoLocalizacao);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(30, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 258);
            this.panel1.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(16, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 35);
            this.button2.TabIndex = 17;
            this.button2.Text = "Adicionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_delete_48;
            this.pictureBox4.Location = new System.Drawing.Point(792, 152);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(51, 50);
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // localizacaoTable
            // 
            this.localizacaoTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.localizacaoTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.localizacaoTable.BackgroundColor = System.Drawing.Color.White;
            this.localizacaoTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.localizacaoTable.Location = new System.Drawing.Point(16, 153);
            this.localizacaoTable.Name = "localizacaoTable";
            this.localizacaoTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.localizacaoTable.Size = new System.Drawing.Size(770, 102);
            this.localizacaoTable.TabIndex = 14;
            // 
            // localizacaoFisicatxt
            // 
            this.localizacaoFisicatxt.AutoSize = true;
            this.localizacaoFisicatxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localizacaoFisicatxt.Location = new System.Drawing.Point(12, 56);
            this.localizacaoFisicatxt.Name = "localizacaoFisicatxt";
            this.localizacaoFisicatxt.Size = new System.Drawing.Size(138, 20);
            this.localizacaoFisicatxt.TabIndex = 13;
            this.localizacaoFisicatxt.Text = "Localização Física";
            // 
            // localizacaoFisica
            // 
            this.localizacaoFisica.Location = new System.Drawing.Point(16, 79);
            this.localizacaoFisica.Name = "localizacaoFisica";
            this.localizacaoFisica.Size = new System.Drawing.Size(518, 20);
            this.localizacaoFisica.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(394, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Descrição";
            // 
            // codigoLocalizacao
            // 
            this.codigoLocalizacao.Location = new System.Drawing.Point(16, 31);
            this.codigoLocalizacao.Name = "codigoLocalizacao";
            this.codigoLocalizacao.Size = new System.Drawing.Size(330, 20);
            this.codigoLocalizacao.TabIndex = 8;
            // 
            // descricaoLocalizacao
            // 
            this.descricaoLocalizacao.Location = new System.Drawing.Point(394, 31);
            this.descricaoLocalizacao.Name = "descricaoLocalizacao";
            this.descricaoLocalizacao.Size = new System.Drawing.Size(438, 20);
            this.descricaoLocalizacao.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Codigo";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 135);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(346, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_add_user_male_40;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(428, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 50);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 57);
            this.panel2.TabIndex = 19;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_store_48;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(9, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(75, 50);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(85, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Armazem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(424, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Descrição";
            // 
            // descricaoArmazem
            // 
            this.descricaoArmazem.Location = new System.Drawing.Point(428, 87);
            this.descricaoArmazem.Name = "descricaoArmazem";
            this.descricaoArmazem.Size = new System.Drawing.Size(458, 20);
            this.descricaoArmazem.TabIndex = 17;
            // 
            // codigoArmazenlbl
            // 
            this.codigoArmazenlbl.AutoSize = true;
            this.codigoArmazenlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoArmazenlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.codigoArmazenlbl.Location = new System.Drawing.Point(26, 64);
            this.codigoArmazenlbl.Name = "codigoArmazenlbl";
            this.codigoArmazenlbl.Size = new System.Drawing.Size(59, 20);
            this.codigoArmazenlbl.TabIndex = 16;
            this.codigoArmazenlbl.Text = "Codigo";
            // 
            // codigoArmazemtxt
            // 
            this.codigoArmazemtxt.Location = new System.Drawing.Point(30, 87);
            this.codigoArmazemtxt.Name = "codigoArmazemtxt";
            this.codigoArmazemtxt.Size = new System.Drawing.Size(346, 20);
            this.codigoArmazemtxt.TabIndex = 15;
            // 
            // ArmazemEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descricaoArmazem);
            this.Controls.Add(this.codigoArmazenlbl);
            this.Controls.Add(this.codigoArmazemtxt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.salvar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Name = "ArmazemEditar";
            this.Text = "ArmazemEditar";
            this.Load += new System.EventHandler(this.ArmazemEditar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localizacaoTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button salvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridView localizacaoTable;
        private System.Windows.Forms.Label localizacaoFisicatxt;
        private System.Windows.Forms.TextBox localizacaoFisica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox codigoLocalizacao;
        private System.Windows.Forms.TextBox descricaoLocalizacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descricaoArmazem;
        private System.Windows.Forms.Label codigoArmazenlbl;
        private System.Windows.Forms.TextBox codigoArmazemtxt;
    }
}