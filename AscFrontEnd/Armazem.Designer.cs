﻿namespace AscFrontEnd
{
    partial class Armazem
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
            this.codigoArmazemtxt = new System.Windows.Forms.TextBox();
            this.codigoArmazenlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descricaoArmazem = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.salvar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localizacaoTable)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // codigoArmazemtxt
            // 
            this.codigoArmazemtxt.Location = new System.Drawing.Point(32, 86);
            this.codigoArmazemtxt.Name = "codigoArmazemtxt";
            this.codigoArmazemtxt.Size = new System.Drawing.Size(346, 20);
            this.codigoArmazemtxt.TabIndex = 1;
            // 
            // codigoArmazenlbl
            // 
            this.codigoArmazenlbl.AutoSize = true;
            this.codigoArmazenlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoArmazenlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.codigoArmazenlbl.Location = new System.Drawing.Point(28, 63);
            this.codigoArmazenlbl.Name = "codigoArmazenlbl";
            this.codigoArmazenlbl.Size = new System.Drawing.Size(59, 20);
            this.codigoArmazenlbl.TabIndex = 2;
            this.codigoArmazenlbl.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(426, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descrição";
            // 
            // descricaoArmazem
            // 
            this.descricaoArmazem.Location = new System.Drawing.Point(430, 86);
            this.descricaoArmazem.Name = "descricaoArmazem";
            this.descricaoArmazem.Size = new System.Drawing.Size(458, 20);
            this.descricaoArmazem.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(32, 132);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(346, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(28, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "sector";
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
            this.panel1.Location = new System.Drawing.Point(32, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 258);
            this.panel1.TabIndex = 7;
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
            this.localizacaoTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.localizacaoTable_CellClick);
            this.localizacaoTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.localizacaoTable_CellContentClick);
            this.localizacaoTable.SelectionChanged += new System.EventHandler(this.localizacaoTable_SelectionChanged);
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
            this.label4.Click += new System.EventHandler(this.label4_Click);
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
            // salvar
            // 
            this.salvar.BackColor = System.Drawing.SystemColors.Highlight;
            this.salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salvar.ForeColor = System.Drawing.Color.White;
            this.salvar.Location = new System.Drawing.Point(32, 427);
            this.salvar.Name = "salvar";
            this.salvar.Size = new System.Drawing.Size(239, 33);
            this.salvar.TabIndex = 9;
            this.salvar.Text = "Salvar";
            this.salvar.UseVisualStyleBackColor = false;
            this.salvar.Click += new System.EventHandler(this.salvar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 57);
            this.panel2.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(774, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 26);
            this.button1.TabIndex = 12;
            this.button1.Text = "Armazens";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
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
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_add_user_male_40;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(430, 109);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 50);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Armazem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.salvar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descricaoArmazem);
            this.Controls.Add(this.codigoArmazenlbl);
            this.Controls.Add(this.codigoArmazemtxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Armazem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Armazem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localizacaoTable)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codigoArmazemtxt;
        private System.Windows.Forms.Label codigoArmazenlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descricaoArmazem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox codigoLocalizacao;
        private System.Windows.Forms.TextBox descricaoLocalizacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label localizacaoFisicatxt;
        private System.Windows.Forms.TextBox localizacaoFisica;
        private System.Windows.Forms.Button salvar;
        private System.Windows.Forms.DataGridView localizacaoTable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button2;
    }
}