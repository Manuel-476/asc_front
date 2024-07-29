namespace AscFrontEnd
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
            ((System.ComponentModel.ISupportInitialize)(this.correnteTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // correnteTable
            // 
            this.correnteTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.correnteTable.BackgroundColor = System.Drawing.Color.White;
            this.correnteTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.correnteTable.Location = new System.Drawing.Point(13, 93);
            this.correnteTable.Name = "correnteTable";
            this.correnteTable.ReadOnly = true;
            this.correnteTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.correnteTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.correnteTable.Size = new System.Drawing.Size(501, 246);
            this.correnteTable.TabIndex = 4;
            this.correnteTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.correnteTable_CellDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textoPesquisar
            // 
            this.textoPesquisar.AutoSize = true;
            this.textoPesquisar.Location = new System.Drawing.Point(12, 70);
            this.textoPesquisar.Name = "textoPesquisar";
            this.textoPesquisar.Size = new System.Drawing.Size(56, 13);
            this.textoPesquisar.TabIndex = 6;
            this.textoPesquisar.Text = "Pesquisar:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 62);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Resultados";
            // 
            // entidadeText
            // 
            this.entidadeText.AutoSize = true;
            this.entidadeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entidadeText.Location = new System.Drawing.Point(433, 70);
            this.entidadeText.Name = "entidadeText";
            this.entidadeText.Size = new System.Drawing.Size(81, 20);
            this.entidadeText.TabIndex = 8;
            this.entidadeText.Text = "Entidade";
            // 
            // ListasContasCorrentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 351);
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
            this.Text = "Listas ContasCorrentes";
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
    }
}