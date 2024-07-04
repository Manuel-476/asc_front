namespace AscFrontEnd
{
    partial class FamiliaArtigo
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
            this.label2 = new System.Windows.Forms.Label();
            this.codigotxt = new System.Windows.Forms.TextBox();
            this.descricaotxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.balvarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Familia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo";
            // 
            // codigotxt
            // 
            this.codigotxt.Location = new System.Drawing.Point(22, 83);
            this.codigotxt.Name = "codigotxt";
            this.codigotxt.Size = new System.Drawing.Size(194, 20);
            this.codigotxt.TabIndex = 2;
            // 
            // descricaotxt
            // 
            this.descricaotxt.Location = new System.Drawing.Point(237, 83);
            this.descricaotxt.Name = "descricaotxt";
            this.descricaotxt.Size = new System.Drawing.Size(304, 20);
            this.descricaotxt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descricao";
            // 
            // balvarBtn
            // 
            this.balvarBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.balvarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.balvarBtn.ForeColor = System.Drawing.Color.White;
            this.balvarBtn.Location = new System.Drawing.Point(22, 134);
            this.balvarBtn.Name = "balvarBtn";
            this.balvarBtn.Size = new System.Drawing.Size(194, 33);
            this.balvarBtn.TabIndex = 5;
            this.balvarBtn.Text = "Salvar";
            this.balvarBtn.UseVisualStyleBackColor = false;
            this.balvarBtn.Click += new System.EventHandler(this.balvarBtn_Click);
            // 
            // FamiliaArtigo
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
            this.Name = "FamiliaArtigo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FamiliaArtigo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codigotxt;
        private System.Windows.Forms.TextBox descricaotxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button balvarBtn;
    }
}