﻿namespace AscFrontEnd
{
    partial class ListasContasCorrentes
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
            this.correnteTable = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textoPesquisar = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.entidadeText = new System.Windows.Forms.Label();
            this.radioAdiantamento = new System.Windows.Forms.RadioButton();
            this.radioDivida = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.correnteTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // correnteTable
            // 
            this.correnteTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.correnteTable.BackgroundColor = System.Drawing.Color.White;
            this.correnteTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.correnteTable.Location = new System.Drawing.Point(13, 121);
            this.correnteTable.Name = "correnteTable";
            this.correnteTable.ReadOnly = true;
            this.correnteTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.correnteTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.correnteTable.Size = new System.Drawing.Size(501, 218);
            this.correnteTable.TabIndex = 4;
            this.correnteTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.correnteTable_CellDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textoPesquisar
            // 
            this.textoPesquisar.AutoSize = true;
            this.textoPesquisar.Location = new System.Drawing.Point(13, 98);
            this.textoPesquisar.Name = "textoPesquisar";
            this.textoPesquisar.Size = new System.Drawing.Size(56, 13);
            this.textoPesquisar.TabIndex = 6;
            this.textoPesquisar.Text = "Pesquisar:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 62);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Resultados";
            // 
            // entidadeText
            // 
            this.entidadeText.AutoSize = true;
            this.entidadeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entidadeText.Location = new System.Drawing.Point(381, 95);
            this.entidadeText.Name = "entidadeText";
            this.entidadeText.Size = new System.Drawing.Size(81, 20);
            this.entidadeText.TabIndex = 8;
            this.entidadeText.Text = "Entidade";
            // 
            // radioAdiantamento
            // 
            this.radioAdiantamento.AutoSize = true;
            this.radioAdiantamento.BackColor = System.Drawing.SystemColors.Control;
            this.radioAdiantamento.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioAdiantamento.Location = new System.Drawing.Point(88, 67);
            this.radioAdiantamento.Name = "radioAdiantamento";
            this.radioAdiantamento.Size = new System.Drawing.Size(90, 17);
            this.radioAdiantamento.TabIndex = 9;
            this.radioAdiantamento.TabStop = true;
            this.radioAdiantamento.Text = "Adiantamento";
            this.radioAdiantamento.UseVisualStyleBackColor = false;
            this.radioAdiantamento.CheckedChanged += new System.EventHandler(this.radioAdiantamento_CheckedChanged);
            // 
            // radioDivida
            // 
            this.radioDivida.AutoSize = true;
            this.radioDivida.BackColor = System.Drawing.SystemColors.Control;
            this.radioDivida.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioDivida.Location = new System.Drawing.Point(13, 67);
            this.radioDivida.Name = "radioDivida";
            this.radioDivida.Size = new System.Drawing.Size(55, 17);
            this.radioDivida.TabIndex = 10;
            this.radioDivida.TabStop = true;
            this.radioDivida.Text = "Divida";
            this.radioDivida.UseVisualStyleBackColor = false;
            this.radioDivida.CheckedChanged += new System.EventHandler(this.radioDivida_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(394, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 26);
            this.button2.TabIndex = 38;
            this.button2.Text = "Atualizar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button2_MouseMove);
            // 
            // ListasContasCorrentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 351);
            this.Controls.Add(this.radioDivida);
            this.Controls.Add(this.radioAdiantamento);
            this.Controls.Add(this.entidadeText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textoPesquisar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.correnteTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListasContasCorrentes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ListasContasCorrentes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.correnteTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView correnteTable;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label textoPesquisar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label entidadeText;
        private System.Windows.Forms.RadioButton radioAdiantamento;
        private System.Windows.Forms.RadioButton radioDivida;
        private System.Windows.Forms.Button button2;
    }
}