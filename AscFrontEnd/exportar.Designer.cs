namespace AscFrontEnd
{
    partial class exportar
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
            this.excelPicture = new System.Windows.Forms.PictureBox();
            this.pdfPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.excelPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "PDF";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(330, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "EXCEL";
            // 
            // excelPicture
            // 
            this.excelPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_excel_80;
            this.excelPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.excelPicture.Location = new System.Drawing.Point(288, 12);
            this.excelPicture.Name = "excelPicture";
            this.excelPicture.Size = new System.Drawing.Size(143, 139);
            this.excelPicture.TabIndex = 2;
            this.excelPicture.TabStop = false;
            this.excelPicture.Click += new System.EventHandler(this.excelPicture_Click);
            this.excelPicture.MouseLeave += new System.EventHandler(this.excelPicture_MouseLeave);
            this.excelPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.excelPicture_MouseMove);
            // 
            // pdfPicture
            // 
            this.pdfPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_pdf_60;
            this.pdfPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pdfPicture.Location = new System.Drawing.Point(38, 12);
            this.pdfPicture.Name = "pdfPicture";
            this.pdfPicture.Size = new System.Drawing.Size(149, 139);
            this.pdfPicture.TabIndex = 0;
            this.pdfPicture.TabStop = false;
            this.pdfPicture.MouseLeave += new System.EventHandler(this.pdfPicture_MouseLeave);
            this.pdfPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pdfPicture_MouseMove);
            // 
            // exportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 202);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.excelPicture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pdfPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "exportar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "exportar";
            ((System.ComponentModel.ISupportInitialize)(this.excelPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pdfPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox excelPicture;
    }
}