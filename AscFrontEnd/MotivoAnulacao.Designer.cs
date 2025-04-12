namespace AscFrontEnd
{
    partial class MotivoAnulacao
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.motivoAnulacaoTxt = new System.Windows.Forms.RichTextBox();
            this.textDocumento = new System.Windows.Forms.Label();
            this.documentoOrigemTxt = new System.Windows.Forms.TextBox();
            this.caixaDocs = new System.Windows.Forms.Button();
            this.Anular = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estornar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 65);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(15, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Motivo Anulação";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // motivoAnulacaoTxt
            // 
            this.motivoAnulacaoTxt.Location = new System.Drawing.Point(137, 82);
            this.motivoAnulacaoTxt.Name = "motivoAnulacaoTxt";
            this.motivoAnulacaoTxt.Size = new System.Drawing.Size(367, 113);
            this.motivoAnulacaoTxt.TabIndex = 3;
            this.motivoAnulacaoTxt.Text = "";
            // 
            // textDocumento
            // 
            this.textDocumento.AutoSize = true;
            this.textDocumento.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDocumento.ForeColor = System.Drawing.SystemColors.Highlight;
            this.textDocumento.Location = new System.Drawing.Point(15, 218);
            this.textDocumento.Name = "textDocumento";
            this.textDocumento.Size = new System.Drawing.Size(157, 17);
            this.textDocumento.TabIndex = 4;
            this.textDocumento.Text = "Documento de origem:";
            // 
            // documentoOrigemTxt
            // 
            this.documentoOrigemTxt.Location = new System.Drawing.Point(172, 218);
            this.documentoOrigemTxt.Name = "documentoOrigemTxt";
            this.documentoOrigemTxt.Size = new System.Drawing.Size(281, 20);
            this.documentoOrigemTxt.TabIndex = 5;
            this.documentoOrigemTxt.TextChanged += new System.EventHandler(this.documentoOrigemTxt_TextChanged);
            // 
            // caixaDocs
            // 
            this.caixaDocs.BackColor = System.Drawing.SystemColors.Highlight;
            this.caixaDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.caixaDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caixaDocs.ForeColor = System.Drawing.SystemColors.Control;
            this.caixaDocs.Location = new System.Drawing.Point(459, 218);
            this.caixaDocs.Name = "caixaDocs";
            this.caixaDocs.Size = new System.Drawing.Size(45, 23);
            this.caixaDocs.TabIndex = 6;
            this.caixaDocs.Text = ":::";
            this.caixaDocs.UseVisualStyleBackColor = false;
            this.caixaDocs.Click += new System.EventHandler(this.caixaDocs_Click);
            // 
            // Anular
            // 
            this.Anular.BackColor = System.Drawing.SystemColors.Highlight;
            this.Anular.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Anular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Anular.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Anular.ForeColor = System.Drawing.SystemColors.Control;
            this.Anular.Location = new System.Drawing.Point(376, 259);
            this.Anular.Name = "Anular";
            this.Anular.Size = new System.Drawing.Size(128, 30);
            this.Anular.TabIndex = 7;
            this.Anular.Text = "Anular";
            this.Anular.UseVisualStyleBackColor = false;
            this.Anular.Click += new System.EventHandler(this.Anular_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MotivoAnulacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(538, 301);
            this.Controls.Add(this.Anular);
            this.Controls.Add(this.caixaDocs);
            this.Controls.Add(this.documentoOrigemTxt);
            this.Controls.Add(this.textDocumento);
            this.Controls.Add(this.motivoAnulacaoTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MotivoAnulacao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MotivoAnulacao_FormClosing);
            this.Load += new System.EventHandler(this.MotivoAnulacao_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox motivoAnulacaoTxt;
        private System.Windows.Forms.Label textDocumento;
        private System.Windows.Forms.TextBox documentoOrigemTxt;
        private System.Windows.Forms.Button caixaDocs;
        private System.Windows.Forms.Button Anular;
        private System.Windows.Forms.Timer timer1;
    }
}