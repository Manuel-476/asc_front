namespace AscFrontEnd
{
    partial class SubFamilaArtigo
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
            this.balvarBtn = new System.Windows.Forms.Button();
            this.descricaotxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.codigotxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // balvarBtn
            // 
            this.balvarBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.balvarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.balvarBtn.ForeColor = System.Drawing.Color.White;
            this.balvarBtn.Location = new System.Drawing.Point(21, 133);
            this.balvarBtn.Name = "balvarBtn";
            this.balvarBtn.Size = new System.Drawing.Size(194, 33);
            this.balvarBtn.TabIndex = 11;
            this.balvarBtn.Text = "Salvar";
            this.balvarBtn.UseVisualStyleBackColor = false;
            this.balvarBtn.Click += new System.EventHandler(this.balvarBtn_Click);
            // 
            // descricaotxt
            // 
            this.descricaotxt.Location = new System.Drawing.Point(236, 82);
            this.descricaotxt.Name = "descricaotxt";
            this.descricaotxt.Size = new System.Drawing.Size(304, 20);
            this.descricaotxt.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Descricao";
            // 
            // codigotxt
            // 
            this.codigotxt.Location = new System.Drawing.Point(21, 82);
            this.codigotxt.Name = "codigotxt";
            this.codigotxt.Size = new System.Drawing.Size(194, 20);
            this.codigotxt.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Codigo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "SubFamilia";
            // 
            // SubFamilaArtigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 179);
            this.Controls.Add(this.balvarBtn);
            this.Controls.Add(this.descricaotxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.codigotxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubFamilaArtigo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubFamilaArtigo";
            this.Load += new System.EventHandler(this.SubFamilaArtigo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button balvarBtn;
        private System.Windows.Forms.TextBox descricaotxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox codigotxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}