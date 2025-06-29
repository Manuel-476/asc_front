﻿namespace AscFrontEnd
{
    partial class VendaListagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendaListagem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.excelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioFp = new System.Windows.Forms.RadioButton();
            this.radioFr = new System.Windows.Forms.RadioButton();
            this.radioFt = new System.Windows.Forms.RadioButton();
            this.radioGt = new System.Windows.Forms.RadioButton();
            this.radioNc = new System.Windows.Forms.RadioButton();
            this.radioAnulado = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.anularPicture = new System.Windows.Forms.PictureBox();
            this.estornarPicture = new System.Windows.Forms.PictureBox();
            this.radioEcl = new System.Windows.Forms.RadioButton();
            this.Imprimir = new System.Drawing.Printing.PrintDocument();
            this.preVisualizacaoDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.radioOrcamento = new System.Windows.Forms.RadioButton();
            this.radioGr = new System.Windows.Forms.RadioButton();
            this.radioGeral = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureAprovar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anularPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estornarPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAprovar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.logoPicture);
            this.panel1.Controls.Add(this.excelBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 83);
            this.panel1.TabIndex = 21;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(745, 47);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(178, 33);
            this.btnActualizar.TabIndex = 32;
            this.btnActualizar.Text = "Atualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            this.btnActualizar.MouseLeave += new System.EventHandler(this.btnActualizar_MouseLeave);
            this.btnActualizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnActualizar_MouseMove);
            // 
            // logoPicture
            // 
            this.logoPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_sell_100;
            this.logoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoPicture.Location = new System.Drawing.Point(4, -9);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(117, 92);
            this.logoPicture.TabIndex = 18;
            this.logoPicture.TabStop = false;
            // 
            // excelBtn
            // 
            this.excelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.excelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excelBtn.ForeColor = System.Drawing.Color.White;
            this.excelBtn.Location = new System.Drawing.Point(555, 47);
            this.excelBtn.Name = "excelBtn";
            this.excelBtn.Size = new System.Drawing.Size(183, 33);
            this.excelBtn.TabIndex = 16;
            this.excelBtn.Text = "Exportar";
            this.excelBtn.UseVisualStyleBackColor = false;
            this.excelBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.excelBtn_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(134, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vendas";
            // 
            // radioFp
            // 
            this.radioFp.AutoSize = true;
            this.radioFp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioFp.Location = new System.Drawing.Point(117, 89);
            this.radioFp.Name = "radioFp";
            this.radioFp.Size = new System.Drawing.Size(100, 17);
            this.radioFp.TabIndex = 22;
            this.radioFp.TabStop = true;
            this.radioFp.Text = "Fatura Proforma";
            this.radioFp.UseVisualStyleBackColor = true;
            this.radioFp.CheckedChanged += new System.EventHandler(this.radioFp_CheckedChanged);
            // 
            // radioFr
            // 
            this.radioFr.AutoSize = true;
            this.radioFr.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioFr.Location = new System.Drawing.Point(321, 89);
            this.radioFr.Name = "radioFr";
            this.radioFr.Size = new System.Drawing.Size(92, 17);
            this.radioFr.TabIndex = 23;
            this.radioFr.TabStop = true;
            this.radioFr.Text = "Fatura Recibo";
            this.radioFr.UseVisualStyleBackColor = true;
            this.radioFr.CheckedChanged += new System.EventHandler(this.radioFr_CheckedChanged);
            // 
            // radioFt
            // 
            this.radioFt.AutoSize = true;
            this.radioFt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioFt.Location = new System.Drawing.Point(243, 89);
            this.radioFt.Name = "radioFt";
            this.radioFt.Size = new System.Drawing.Size(55, 17);
            this.radioFt.TabIndex = 24;
            this.radioFt.TabStop = true;
            this.radioFt.Text = "Fatura";
            this.radioFt.UseVisualStyleBackColor = true;
            this.radioFt.CheckedChanged += new System.EventHandler(this.radioFt_CheckedChanged);
            // 
            // radioGt
            // 
            this.radioGt.AutoSize = true;
            this.radioGt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioGt.Location = new System.Drawing.Point(441, 89);
            this.radioGt.Name = "radioGt";
            this.radioGt.Size = new System.Drawing.Size(116, 17);
            this.radioGt.TabIndex = 25;
            this.radioGt.TabStop = true;
            this.radioGt.Text = "Guia de Transporte";
            this.radioGt.UseVisualStyleBackColor = true;
            this.radioGt.CheckedChanged += new System.EventHandler(this.radioGt_CheckedChanged);
            // 
            // radioNc
            // 
            this.radioNc.AutoSize = true;
            this.radioNc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioNc.Location = new System.Drawing.Point(746, 89);
            this.radioNc.Name = "radioNc";
            this.radioNc.Size = new System.Drawing.Size(84, 17);
            this.radioNc.TabIndex = 26;
            this.radioNc.TabStop = true;
            this.radioNc.Text = "Nota Credito";
            this.radioNc.UseVisualStyleBackColor = true;
            this.radioNc.CheckedChanged += new System.EventHandler(this.radioNv_CheckedChanged);
            // 
            // radioAnulado
            // 
            this.radioAnulado.AutoSize = true;
            this.radioAnulado.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioAnulado.Location = new System.Drawing.Point(243, 120);
            this.radioAnulado.Name = "radioAnulado";
            this.radioAnulado.Size = new System.Drawing.Size(64, 17);
            this.radioAnulado.TabIndex = 27;
            this.radioAnulado.TabStop = true;
            this.radioAnulado.Text = "Anulada";
            this.radioAnulado.UseVisualStyleBackColor = true;
            this.radioAnulado.CheckedChanged += new System.EventHandler(this.radioAnulado_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(801, 269);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 29;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Pesquisar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(843, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Estornar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(835, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Anular Doc.";
            // 
            // anularPicture
            // 
            this.anularPicture.BackColor = System.Drawing.Color.IndianRed;
            this.anularPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_delete_48;
            this.anularPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.anularPicture.Location = new System.Drawing.Point(835, 275);
            this.anularPicture.Name = "anularPicture";
            this.anularPicture.Size = new System.Drawing.Size(63, 52);
            this.anularPicture.TabIndex = 32;
            this.anularPicture.TabStop = false;
            this.anularPicture.Click += new System.EventHandler(this.anularPicture_Click);
            this.anularPicture.MouseLeave += new System.EventHandler(this.anularPicture_MouseLeave);
            this.anularPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.anularPicture_MouseMove);
            // 
            // estornarPicture
            // 
            this.estornarPicture.BackColor = System.Drawing.Color.IndianRed;
            this.estornarPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_chargeback_32;
            this.estornarPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.estornarPicture.Location = new System.Drawing.Point(835, 169);
            this.estornarPicture.Name = "estornarPicture";
            this.estornarPicture.Size = new System.Drawing.Size(63, 52);
            this.estornarPicture.TabIndex = 31;
            this.estornarPicture.TabStop = false;
            this.estornarPicture.Click += new System.EventHandler(this.estornarPicture_Click);
            this.estornarPicture.MouseLeave += new System.EventHandler(this.estornarPicture_MouseLeave);
            this.estornarPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.estornarPicture_MouseMove);
            // 
            // radioEcl
            // 
            this.radioEcl.AutoSize = true;
            this.radioEcl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioEcl.Location = new System.Drawing.Point(15, 120);
            this.radioEcl.Name = "radioEcl";
            this.radioEcl.Size = new System.Drawing.Size(82, 17);
            this.radioEcl.TabIndex = 35;
            this.radioEcl.TabStop = true;
            this.radioEcl.Text = "Encomenda";
            this.radioEcl.UseVisualStyleBackColor = true;
            this.radioEcl.CheckedChanged += new System.EventHandler(this.radioEcl_CheckedChanged);
            // 
            // Imprimir
            // 
            this.Imprimir.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ImprimirPagina_PrintPage);
            // 
            // preVisualizacaoDialog
            // 
            this.preVisualizacaoDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.preVisualizacaoDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.preVisualizacaoDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.preVisualizacaoDialog.Enabled = true;
            this.preVisualizacaoDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("preVisualizacaoDialog.Icon")));
            this.preVisualizacaoDialog.Name = "preVisualizacaoDialog";
            this.preVisualizacaoDialog.Visible = false;
            // 
            // radioOrcamento
            // 
            this.radioOrcamento.AutoSize = true;
            this.radioOrcamento.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioOrcamento.Location = new System.Drawing.Point(117, 120);
            this.radioOrcamento.Name = "radioOrcamento";
            this.radioOrcamento.Size = new System.Drawing.Size(77, 17);
            this.radioOrcamento.TabIndex = 36;
            this.radioOrcamento.TabStop = true;
            this.radioOrcamento.Text = "Orçamento";
            this.radioOrcamento.UseVisualStyleBackColor = true;
            this.radioOrcamento.CheckedChanged += new System.EventHandler(this.radioOrcamento_CheckedChanged);
            // 
            // radioGr
            // 
            this.radioGr.AutoSize = true;
            this.radioGr.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioGr.Location = new System.Drawing.Point(589, 89);
            this.radioGr.Name = "radioGr";
            this.radioGr.Size = new System.Drawing.Size(109, 17);
            this.radioGr.TabIndex = 37;
            this.radioGr.TabStop = true;
            this.radioGr.Text = "Guia de Remessa";
            this.radioGr.UseVisualStyleBackColor = true;
            this.radioGr.CheckedChanged += new System.EventHandler(this.radioGr_CheckedChanged);
            // 
            // radioGeral
            // 
            this.radioGeral.AutoSize = true;
            this.radioGeral.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioGeral.Location = new System.Drawing.Point(15, 89);
            this.radioGeral.Name = "radioGeral";
            this.radioGeral.Size = new System.Drawing.Size(50, 17);
            this.radioGeral.TabIndex = 38;
            this.radioGeral.TabStop = true;
            this.radioGeral.Text = "Geral";
            this.radioGeral.UseVisualStyleBackColor = true;
            this.radioGeral.CheckedChanged += new System.EventHandler(this.radioGeral_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(845, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Aprovar";
            // 
            // pictureAprovar
            // 
            this.pictureAprovar.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureAprovar.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_delete_48;
            this.pictureAprovar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureAprovar.Location = new System.Drawing.Point(835, 362);
            this.pictureAprovar.Name = "pictureAprovar";
            this.pictureAprovar.Size = new System.Drawing.Size(63, 52);
            this.pictureAprovar.TabIndex = 39;
            this.pictureAprovar.TabStop = false;
            this.pictureAprovar.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureAprovar.MouseLeave += new System.EventHandler(this.pictureAprovar_MouseLeave);
            this.pictureAprovar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureAprovar_MouseMove);
            // 
            // VendaListagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureAprovar);
            this.Controls.Add(this.radioGeral);
            this.Controls.Add(this.radioGr);
            this.Controls.Add(this.radioOrcamento);
            this.Controls.Add(this.radioEcl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.anularPicture);
            this.Controls.Add(this.estornarPicture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.radioAnulado);
            this.Controls.Add(this.radioNc);
            this.Controls.Add(this.radioGt);
            this.Controls.Add(this.radioFt);
            this.Controls.Add(this.radioFr);
            this.Controls.Add(this.radioFp);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendaListagem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VendaListagem";
            this.Load += new System.EventHandler(this.VendaListagem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anularPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estornarPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAprovar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Button excelBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioFp;
        private System.Windows.Forms.RadioButton radioFr;
        private System.Windows.Forms.RadioButton radioFt;
        private System.Windows.Forms.RadioButton radioGt;
        private System.Windows.Forms.RadioButton radioNc;
        private System.Windows.Forms.RadioButton radioAnulado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox estornarPicture;
        private System.Windows.Forms.PictureBox anularPicture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioEcl;
        private System.Drawing.Printing.PrintDocument Imprimir;
        private System.Windows.Forms.PrintPreviewDialog preVisualizacaoDialog;
        private System.Windows.Forms.RadioButton radioOrcamento;
        private System.Windows.Forms.RadioButton radioGr;
        private System.Windows.Forms.RadioButton radioGeral;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureAprovar;
        private System.Windows.Forms.Button btnActualizar;
    }
}