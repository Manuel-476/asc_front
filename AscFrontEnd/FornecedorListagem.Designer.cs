namespace AscFrontEnd
{
    partial class FornecedorListagem
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
            this.pesqText = new System.Windows.Forms.TextBox();
            this.tabelaCliente = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pesquisar:";
            // 
            // pesqText
            // 
            this.pesqText.Location = new System.Drawing.Point(19, 39);
            this.pesqText.Name = "pesqText";
            this.pesqText.Size = new System.Drawing.Size(220, 20);
            this.pesqText.TabIndex = 4;
            // 
            // tabelaCliente
            // 
            this.tabelaCliente.Location = new System.Drawing.Point(23, 73);
            this.tabelaCliente.Name = "tabelaCliente";
            this.tabelaCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaCliente.Size = new System.Drawing.Size(758, 362);
            this.tabelaCliente.TabIndex = 3;
            // 
            // FornecedorListagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pesqText);
            this.Controls.Add(this.tabelaCliente);
            this.Name = "FornecedorListagem";
            this.Text = "FornecedorListagem";
            this.Load += new System.EventHandler(this.FornecedorListagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pesqText;
        private System.Windows.Forms.DataGridView tabelaCliente;
    }
}