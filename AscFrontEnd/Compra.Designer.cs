namespace AscFrontEnd
{
    partial class Compra
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compra));
            this.fornecedortxt = new System.Windows.Forms.Label();
            this.comprasBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Qtd = new System.Windows.Forms.TextBox();
            this.codigoDocumento = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.salvarBtn = new System.Windows.Forms.Button();
            this.clienteBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabelaArtigos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.documento = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.precotxt = new System.Windows.Forms.TextBox();
            this.codigoDocumentotxt = new System.Windows.Forms.Label();
            this.tabelaCompra = new System.Windows.Forms.DataGridView();
            this.eliminarBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.Imprimir = new System.Drawing.Printing.PrintDocument();
            this.preVisualizacaoDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.descontoTxt = new System.Windows.Forms.TextBox();
            this.precoLiquido = new System.Windows.Forms.Label();
            this.totalBruto = new System.Windows.Forms.Label();
            this.descontoTotal = new System.Windows.Forms.Label();
            this.ivaTotal = new System.Windows.Forms.Label();
            this.descricaoLabel = new System.Windows.Forms.Label();
            this.localEntregatxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.descontoFornecedorTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaArtigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaCompra)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fornecedortxt
            // 
            this.fornecedortxt.AutoSize = true;
            this.fornecedortxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fornecedortxt.ForeColor = System.Drawing.Color.White;
            this.fornecedortxt.Location = new System.Drawing.Point(319, 42);
            this.fornecedortxt.Name = "fornecedortxt";
            this.fornecedortxt.Size = new System.Drawing.Size(180, 33);
            this.fornecedortxt.TabIndex = 35;
            this.fornecedortxt.Text = "Fornecedor: ";
            // 
            // comprasBtn
            // 
            this.comprasBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comprasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comprasBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.comprasBtn.Location = new System.Drawing.Point(890, 59);
            this.comprasBtn.Name = "comprasBtn";
            this.comprasBtn.Size = new System.Drawing.Size(190, 33);
            this.comprasBtn.TabIndex = 34;
            this.comprasBtn.Text = "Compras";
            this.comprasBtn.UseVisualStyleBackColor = false;
            this.comprasBtn.Click += new System.EventHandler(this.excelBtn_Click);
            this.comprasBtn.MouseLeave += new System.EventHandler(this.excelBtn_MouseLeave);
            this.comprasBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.excelBtn_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(926, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Desconto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(790, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Qtd";
            // 
            // Qtd
            // 
            this.Qtd.Location = new System.Drawing.Point(794, 146);
            this.Qtd.Name = "Qtd";
            this.Qtd.Size = new System.Drawing.Size(130, 20);
            this.Qtd.TabIndex = 30;
            this.Qtd.Text = "0";
            this.Qtd.TextChanged += new System.EventHandler(this.Qtd_TextChanged);
            this.Qtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Qtd_KeyPress);
            this.Qtd.Leave += new System.EventHandler(this.Qtd_Leave);
            // 
            // codigoDocumento
            // 
            this.codigoDocumento.AutoSize = true;
            this.codigoDocumento.Location = new System.Drawing.Point(564, 32);
            this.codigoDocumento.Name = "codigoDocumento";
            this.codigoDocumento.Size = new System.Drawing.Size(0, 13);
            this.codigoDocumento.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(880, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 29);
            this.button1.TabIndex = 28;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // salvarBtn
            // 
            this.salvarBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.salvarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salvarBtn.ForeColor = System.Drawing.Color.MistyRose;
            this.salvarBtn.Location = new System.Drawing.Point(12, 427);
            this.salvarBtn.Name = "salvarBtn";
            this.salvarBtn.Size = new System.Drawing.Size(203, 29);
            this.salvarBtn.TabIndex = 26;
            this.salvarBtn.Text = "Salvar";
            this.salvarBtn.UseVisualStyleBackColor = false;
            this.salvarBtn.Click += new System.EventHandler(this.salvarBtn_Click);
            // 
            // clienteBtn
            // 
            this.clienteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clienteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clienteBtn.ForeColor = System.Drawing.Color.White;
            this.clienteBtn.Location = new System.Drawing.Point(720, 59);
            this.clienteBtn.Name = "clienteBtn";
            this.clienteBtn.Size = new System.Drawing.Size(164, 33);
            this.clienteBtn.TabIndex = 24;
            this.clienteBtn.Text = "Fornecedores";
            this.clienteBtn.UseVisualStyleBackColor = false;
            this.clienteBtn.Click += new System.EventHandler(this.clienteBtn_Click);
            this.clienteBtn.MouseLeave += new System.EventHandler(this.clienteBtn_MouseLeave);
            this.clienteBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.clienteBtn_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(399, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "pesquisar:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(403, 149);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 20);
            this.textBox1.TabIndex = 22;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(130, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 42);
            this.label2.TabIndex = 21;
            this.label2.Text = "Compra";
            // 
            // tabelaArtigos
            // 
            this.tabelaArtigos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaArtigos.BackgroundColor = System.Drawing.Color.White;
            this.tabelaArtigos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tabelaArtigos.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabelaArtigos.Location = new System.Drawing.Point(12, 173);
            this.tabelaArtigos.Name = "tabelaArtigos";
            this.tabelaArtigos.ReadOnly = true;
            this.tabelaArtigos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tabelaArtigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaArtigos.Size = new System.Drawing.Size(593, 251);
            this.tabelaArtigos.TabIndex = 20;
            this.tabelaArtigos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaArtigos_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Documento";
            // 
            // documento
            // 
            this.documento.DisplayMember = "FR";
            this.documento.FormattingEnabled = true;
            this.documento.Location = new System.Drawing.Point(12, 145);
            this.documento.Name = "documento";
            this.documento.Size = new System.Drawing.Size(214, 21);
            this.documento.TabIndex = 18;
            this.documento.ValueMember = "FR";
            this.documento.SelectedIndexChanged += new System.EventHandler(this.documento_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(638, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Preço:";
            // 
            // precotxt
            // 
            this.precotxt.Location = new System.Drawing.Point(642, 146);
            this.precotxt.Name = "precotxt";
            this.precotxt.Size = new System.Drawing.Size(146, 20);
            this.precotxt.TabIndex = 36;
            this.precotxt.Text = "0";
            this.precotxt.TextChanged += new System.EventHandler(this.precotxt_TextChanged);
            this.precotxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.precotxt_KeyPress);
            this.precotxt.Leave += new System.EventHandler(this.precotxt_Leave);
            // 
            // codigoDocumentotxt
            // 
            this.codigoDocumentotxt.AutoSize = true;
            this.codigoDocumentotxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoDocumentotxt.Location = new System.Drawing.Point(243, 146);
            this.codigoDocumentotxt.Name = "codigoDocumentotxt";
            this.codigoDocumentotxt.Size = new System.Drawing.Size(0, 20);
            this.codigoDocumentotxt.TabIndex = 38;
            // 
            // tabelaCompra
            // 
            this.tabelaCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaCompra.BackgroundColor = System.Drawing.Color.White;
            this.tabelaCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaCompra.Location = new System.Drawing.Point(642, 173);
            this.tabelaCompra.Name = "tabelaCompra";
            this.tabelaCompra.ReadOnly = true;
            this.tabelaCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaCompra.Size = new System.Drawing.Size(417, 251);
            this.tabelaCompra.TabIndex = 39;
            this.tabelaCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaCompra_CellClick);
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.BackColor = System.Drawing.Color.Red;
            this.eliminarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminarBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eliminarBtn.Location = new System.Drawing.Point(976, 427);
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.Size = new System.Drawing.Size(85, 29);
            this.eliminarBtn.TabIndex = 40;
            this.eliminarBtn.Text = "Eliminar";
            this.eliminarBtn.UseVisualStyleBackColor = false;
            this.eliminarBtn.Click += new System.EventHandler(this.eliminarBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.fornecedortxt);
            this.panel1.Controls.Add(this.clienteBtn);
            this.panel1.Controls.Add(this.comprasBtn);
            this.panel1.Location = new System.Drawing.Point(1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 95);
            this.panel1.TabIndex = 41;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_truck_80;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(15, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 72);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // Imprimir
            // 
            this.Imprimir.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.Imprimir_PrintPage);
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
            // descontoTxt
            // 
            this.descontoTxt.Location = new System.Drawing.Point(931, 145);
            this.descontoTxt.Name = "descontoTxt";
            this.descontoTxt.Size = new System.Drawing.Size(130, 20);
            this.descontoTxt.TabIndex = 42;
            this.descontoTxt.Text = "0";
            this.descontoTxt.TextChanged += new System.EventHandler(this.descontoTxt_TextChanged);
            this.descontoTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descontoTxt_KeyPress);
            this.descontoTxt.Leave += new System.EventHandler(this.descontoTxt_Leave);
            // 
            // precoLiquido
            // 
            this.precoLiquido.AutoSize = true;
            this.precoLiquido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoLiquido.ForeColor = System.Drawing.SystemColors.ControlText;
            this.precoLiquido.Location = new System.Drawing.Point(199, 96);
            this.precoLiquido.Name = "precoLiquido";
            this.precoLiquido.Size = new System.Drawing.Size(54, 19);
            this.precoLiquido.TabIndex = 46;
            this.precoLiquido.Text = "label7";
            // 
            // totalBruto
            // 
            this.totalBruto.AutoSize = true;
            this.totalBruto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBruto.ForeColor = System.Drawing.Color.Green;
            this.totalBruto.Location = new System.Drawing.Point(906, 96);
            this.totalBruto.Name = "totalBruto";
            this.totalBruto.Size = new System.Drawing.Size(54, 19);
            this.totalBruto.TabIndex = 45;
            this.totalBruto.Text = "label7";
            // 
            // descontoTotal
            // 
            this.descontoTotal.AutoSize = true;
            this.descontoTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descontoTotal.ForeColor = System.Drawing.Color.Red;
            this.descontoTotal.Location = new System.Drawing.Point(542, 97);
            this.descontoTotal.Name = "descontoTotal";
            this.descontoTotal.Size = new System.Drawing.Size(54, 19);
            this.descontoTotal.TabIndex = 44;
            this.descontoTotal.Text = "label7";
            // 
            // ivaTotal
            // 
            this.ivaTotal.AutoSize = true;
            this.ivaTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivaTotal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ivaTotal.Location = new System.Drawing.Point(383, 96);
            this.ivaTotal.Name = "ivaTotal";
            this.ivaTotal.Size = new System.Drawing.Size(54, 19);
            this.ivaTotal.TabIndex = 43;
            this.ivaTotal.Text = "label7";
            // 
            // descricaoLabel
            // 
            this.descricaoLabel.AutoSize = true;
            this.descricaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoLabel.Location = new System.Drawing.Point(12, 96);
            this.descricaoLabel.Name = "descricaoLabel";
            this.descricaoLabel.Size = new System.Drawing.Size(77, 20);
            this.descricaoLabel.TabIndex = 47;
            this.descricaoLabel.Text = "descricao";
            // 
            // localEntregatxt
            // 
            this.localEntregatxt.Location = new System.Drawing.Point(357, 432);
            this.localEntregatxt.Name = "localEntregatxt";
            this.localEntregatxt.Size = new System.Drawing.Size(248, 20);
            this.localEntregatxt.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(239, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 49;
            this.label7.Text = "Local Entrega:";
            // 
            // descontoFornecedorTxt
            // 
            this.descontoFornecedorTxt.AutoSize = true;
            this.descontoFornecedorTxt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descontoFornecedorTxt.ForeColor = System.Drawing.Color.DarkRed;
            this.descontoFornecedorTxt.Location = new System.Drawing.Point(717, 97);
            this.descontoFornecedorTxt.Name = "descontoFornecedorTxt";
            this.descontoFornecedorTxt.Size = new System.Drawing.Size(54, 19);
            this.descontoFornecedorTxt.TabIndex = 50;
            this.descontoFornecedorTxt.Text = "label7";
            // 
            // Compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 461);
            this.Controls.Add(this.descontoFornecedorTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.localEntregatxt);
            this.Controls.Add(this.descricaoLabel);
            this.Controls.Add(this.precoLiquido);
            this.Controls.Add(this.totalBruto);
            this.Controls.Add(this.descontoTotal);
            this.Controls.Add(this.ivaTotal);
            this.Controls.Add(this.descontoTxt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.eliminarBtn);
            this.Controls.Add(this.tabelaCompra);
            this.Controls.Add(this.codigoDocumentotxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.precotxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Qtd);
            this.Controls.Add(this.codigoDocumento);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.salvarBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabelaArtigos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.documento);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Compra";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Compra_FormClosing);
            this.Load += new System.EventHandler(this.Compra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaArtigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaCompra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fornecedortxt;
        private System.Windows.Forms.Button comprasBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Qtd;
        private System.Windows.Forms.Label codigoDocumento;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button salvarBtn;
        private System.Windows.Forms.Button clienteBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tabelaArtigos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox documento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox precotxt;
        private System.Windows.Forms.Label codigoDocumentotxt;
        private System.Windows.Forms.DataGridView tabelaCompra;
        private System.Windows.Forms.Button eliminarBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Drawing.Printing.PrintDocument Imprimir;
        private System.Windows.Forms.PrintPreviewDialog preVisualizacaoDialog;
        private System.Windows.Forms.TextBox descontoTxt;
        private System.Windows.Forms.Label precoLiquido;
        private System.Windows.Forms.Label totalBruto;
        private System.Windows.Forms.Label descontoTotal;
        private System.Windows.Forms.Label ivaTotal;
        private System.Windows.Forms.Label descricaoLabel;
        private System.Windows.Forms.TextBox localEntregatxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label descontoFornecedorTxt;
    }
}