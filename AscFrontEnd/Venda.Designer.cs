namespace AscFrontEnd
{
    partial class Venda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Venda));
            this.documento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabelaArtigos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clienteBtn = new System.Windows.Forms.Button();
            this.salvarBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.codigoDocumento = new System.Windows.Forms.Label();
            this.Qtd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.clientetxt = new System.Windows.Forms.Label();
            this.tabelaVenda = new System.Windows.Forms.DataGridView();
            this.eliminarBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.vendaBtn = new System.Windows.Forms.Button();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.Imprimir = new System.Drawing.Printing.PrintDocument();
            this.preVisualizacaoDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.dataDocumento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.descontoTxt = new System.Windows.Forms.TextBox();
            this.ivaTotal = new System.Windows.Forms.Label();
            this.descontoTotal = new System.Windows.Forms.Label();
            this.totalBruto = new System.Windows.Forms.Label();
            this.precoLiquido = new System.Windows.Forms.Label();
            this.descricaoLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.localEntregatxt = new System.Windows.Forms.TextBox();
            this.descontoCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaArtigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaVenda)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // documento
            // 
            this.documento.DisplayMember = "FR";
            this.documento.FormattingEnabled = true;
            this.documento.Location = new System.Drawing.Point(12, 136);
            this.documento.Name = "documento";
            this.documento.Size = new System.Drawing.Size(198, 21);
            this.documento.TabIndex = 0;
            this.documento.ValueMember = "FR";
            this.documento.SelectedIndexChanged += new System.EventHandler(this.documento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(8, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Documento";
            // 
            // tabelaArtigos
            // 
            this.tabelaArtigos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaArtigos.BackgroundColor = System.Drawing.Color.White;
            this.tabelaArtigos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tabelaArtigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tabelaArtigos.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabelaArtigos.Location = new System.Drawing.Point(12, 163);
            this.tabelaArtigos.Name = "tabelaArtigos";
            this.tabelaArtigos.ReadOnly = true;
            this.tabelaArtigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaArtigos.Size = new System.Drawing.Size(567, 251);
            this.tabelaArtigos.TabIndex = 2;
            this.tabelaArtigos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaArtigos_CellClick);
            this.tabelaArtigos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaArtigos_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(134, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "Venda";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(373, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(369, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "pesquisar:";
            // 
            // clienteBtn
            // 
            this.clienteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clienteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clienteBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.clienteBtn.Location = new System.Drawing.Point(720, 47);
            this.clienteBtn.Name = "clienteBtn";
            this.clienteBtn.Size = new System.Drawing.Size(177, 33);
            this.clienteBtn.TabIndex = 6;
            this.clienteBtn.Text = "Cliente";
            this.clienteBtn.UseVisualStyleBackColor = false;
            this.clienteBtn.Click += new System.EventHandler(this.clienteBtn_Click);
            this.clienteBtn.MouseLeave += new System.EventHandler(this.clienteBtn_MouseLeave);
            this.clienteBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.clienteBtn_MouseMove);
            // 
            // salvarBtn
            // 
            this.salvarBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.salvarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salvarBtn.ForeColor = System.Drawing.Color.MistyRose;
            this.salvarBtn.Location = new System.Drawing.Point(12, 420);
            this.salvarBtn.Name = "salvarBtn";
            this.salvarBtn.Size = new System.Drawing.Size(198, 29);
            this.salvarBtn.TabIndex = 8;
            this.salvarBtn.Text = "Salvar";
            this.salvarBtn.UseVisualStyleBackColor = false;
            this.salvarBtn.Click += new System.EventHandler(this.salvarBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(900, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 22);
            this.button1.TabIndex = 10;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // codigoDocumento
            // 
            this.codigoDocumento.AutoSize = true;
            this.codigoDocumento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoDocumento.Location = new System.Drawing.Point(229, 138);
            this.codigoDocumento.Name = "codigoDocumento";
            this.codigoDocumento.Size = new System.Drawing.Size(0, 18);
            this.codigoDocumento.TabIndex = 11;
            // 
            // Qtd
            // 
            this.Qtd.Location = new System.Drawing.Point(822, 140);
            this.Qtd.Name = "Qtd";
            this.Qtd.Size = new System.Drawing.Size(102, 20);
            this.Qtd.TabIndex = 12;
            this.Qtd.Text = "0";
            this.Qtd.TextChanged += new System.EventHandler(this.Qtd_TextChanged);
            this.Qtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Qtd_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(818, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Qtd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(938, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Desconto";
            // 
            // clientetxt
            // 
            this.clientetxt.AutoSize = true;
            this.clientetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientetxt.ForeColor = System.Drawing.Color.White;
            this.clientetxt.Location = new System.Drawing.Point(315, 31);
            this.clientetxt.Name = "clientetxt";
            this.clientetxt.Size = new System.Drawing.Size(122, 33);
            this.clientetxt.TabIndex = 17;
            this.clientetxt.Text = "Cliente: ";
            // 
            // tabelaVenda
            // 
            this.tabelaVenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaVenda.BackgroundColor = System.Drawing.Color.White;
            this.tabelaVenda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tabelaVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tabelaVenda.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabelaVenda.Location = new System.Drawing.Point(612, 166);
            this.tabelaVenda.Name = "tabelaVenda";
            this.tabelaVenda.ReadOnly = true;
            this.tabelaVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaVenda.Size = new System.Drawing.Size(441, 251);
            this.tabelaVenda.TabIndex = 18;
            this.tabelaVenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaVenda_CellClick);
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.BackColor = System.Drawing.Color.Red;
            this.eliminarBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eliminarBtn.Location = new System.Drawing.Point(977, 420);
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.Size = new System.Drawing.Size(85, 29);
            this.eliminarBtn.TabIndex = 19;
            this.eliminarBtn.Text = "Eliminar";
            this.eliminarBtn.UseVisualStyleBackColor = false;
            this.eliminarBtn.Click += new System.EventHandler(this.eliminarBtn_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Criar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.vendaBtn);
            this.panel1.Controls.Add(this.logoPicture);
            this.panel1.Controls.Add(this.clienteBtn);
            this.panel1.Controls.Add(this.clientetxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 83);
            this.panel1.TabIndex = 20;
            // 
            // vendaBtn
            // 
            this.vendaBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.vendaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vendaBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.vendaBtn.Location = new System.Drawing.Point(903, 47);
            this.vendaBtn.Name = "vendaBtn";
            this.vendaBtn.Size = new System.Drawing.Size(177, 33);
            this.vendaBtn.TabIndex = 19;
            this.vendaBtn.Text = "Vendas";
            this.vendaBtn.UseVisualStyleBackColor = false;
            this.vendaBtn.Click += new System.EventHandler(this.vendaBtn_Click);
            this.vendaBtn.MouseLeave += new System.EventHandler(this.vendaBtn_MouseLeave);
            this.vendaBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vendaBtn_MouseMove);
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
            // dataDocumento
            // 
            this.dataDocumento.Location = new System.Drawing.Point(612, 139);
            this.dataDocumento.Name = "dataDocumento";
            this.dataDocumento.Size = new System.Drawing.Size(204, 20);
            this.dataDocumento.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(608, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Data";
            // 
            // descontoTxt
            // 
            this.descontoTxt.Location = new System.Drawing.Point(942, 139);
            this.descontoTxt.Name = "descontoTxt";
            this.descontoTxt.Size = new System.Drawing.Size(102, 20);
            this.descontoTxt.TabIndex = 23;
            this.descontoTxt.Text = "0";
            this.descontoTxt.TextChanged += new System.EventHandler(this.descontoTxt_TextChanged);
            this.descontoTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descontoTxt_KeyPress);
            // 
            // ivaTotal
            // 
            this.ivaTotal.AutoSize = true;
            this.ivaTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivaTotal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ivaTotal.Location = new System.Drawing.Point(360, 86);
            this.ivaTotal.Name = "ivaTotal";
            this.ivaTotal.Size = new System.Drawing.Size(54, 19);
            this.ivaTotal.TabIndex = 24;
            this.ivaTotal.Text = "label7";
            // 
            // descontoTotal
            // 
            this.descontoTotal.AutoSize = true;
            this.descontoTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descontoTotal.ForeColor = System.Drawing.Color.Red;
            this.descontoTotal.Location = new System.Drawing.Point(539, 86);
            this.descontoTotal.Name = "descontoTotal";
            this.descontoTotal.Size = new System.Drawing.Size(54, 19);
            this.descontoTotal.TabIndex = 25;
            this.descontoTotal.Text = "label7";
            // 
            // totalBruto
            // 
            this.totalBruto.AutoSize = true;
            this.totalBruto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBruto.ForeColor = System.Drawing.Color.Green;
            this.totalBruto.Location = new System.Drawing.Point(908, 88);
            this.totalBruto.Name = "totalBruto";
            this.totalBruto.Size = new System.Drawing.Size(54, 19);
            this.totalBruto.TabIndex = 26;
            this.totalBruto.Text = "label7";
            this.totalBruto.Click += new System.EventHandler(this.totalBruto_Click);
            // 
            // precoLiquido
            // 
            this.precoLiquido.AutoSize = true;
            this.precoLiquido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoLiquido.ForeColor = System.Drawing.SystemColors.ControlText;
            this.precoLiquido.Location = new System.Drawing.Point(175, 87);
            this.precoLiquido.Name = "precoLiquido";
            this.precoLiquido.Size = new System.Drawing.Size(54, 19);
            this.precoLiquido.TabIndex = 27;
            this.precoLiquido.Text = "label7";
            // 
            // descricaoLabel
            // 
            this.descricaoLabel.AutoSize = true;
            this.descricaoLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoLabel.Location = new System.Drawing.Point(12, 87);
            this.descricaoLabel.Name = "descricaoLabel";
            this.descricaoLabel.Size = new System.Drawing.Size(77, 18);
            this.descricaoLabel.TabIndex = 28;
            this.descricaoLabel.Text = "descricao";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(228, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = "Local Entrega:";
            // 
            // localEntregatxt
            // 
            this.localEntregatxt.Location = new System.Drawing.Point(346, 425);
            this.localEntregatxt.Name = "localEntregatxt";
            this.localEntregatxt.Size = new System.Drawing.Size(233, 20);
            this.localEntregatxt.TabIndex = 50;
            // 
            // descontoCliente
            // 
            this.descontoCliente.AutoSize = true;
            this.descontoCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descontoCliente.ForeColor = System.Drawing.Color.DarkRed;
            this.descontoCliente.Location = new System.Drawing.Point(715, 87);
            this.descontoCliente.Name = "descontoCliente";
            this.descontoCliente.Size = new System.Drawing.Size(54, 19);
            this.descontoCliente.TabIndex = 52;
            this.descontoCliente.Text = "label7";
            // 
            // Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 461);
            this.Controls.Add(this.descontoCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.localEntregatxt);
            this.Controls.Add(this.descricaoLabel);
            this.Controls.Add(this.precoLiquido);
            this.Controls.Add(this.totalBruto);
            this.Controls.Add(this.descontoTotal);
            this.Controls.Add(this.ivaTotal);
            this.Controls.Add(this.descontoTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataDocumento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.eliminarBtn);
            this.Controls.Add(this.tabelaVenda);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Venda";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Venda_FormClosing);
            this.Load += new System.EventHandler(this.Venda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaArtigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaVenda)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox documento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tabelaArtigos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button clienteBtn;
        private System.Windows.Forms.Button salvarBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label codigoDocumento;
        private System.Windows.Forms.TextBox Qtd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label clientetxt;
        private System.Windows.Forms.DataGridView tabelaVenda;
        private System.Windows.Forms.Button eliminarBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Drawing.Printing.PrintDocument Imprimir;
        private System.Windows.Forms.Button vendaBtn;
        private System.Windows.Forms.PrintPreviewDialog preVisualizacaoDialog;
        private System.Windows.Forms.DateTimePicker dataDocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox descontoTxt;
        private System.Windows.Forms.Label ivaTotal;
        private System.Windows.Forms.Label descontoTotal;
        private System.Windows.Forms.Label totalBruto;
        private System.Windows.Forms.Label precoLiquido;
        private System.Windows.Forms.Label descricaoLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox localEntregatxt;
        private System.Windows.Forms.Label descontoCliente;
    }
}