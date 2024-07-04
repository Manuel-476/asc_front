namespace AscFrontEnd
{
    partial class OpcaoDialog
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.Label();
            this.modeloPicture = new System.Windows.Forms.PictureBox();
            this.marcaPicture = new System.Windows.Forms.PictureBox();
            this.subfamiliaPicture = new System.Windows.Forms.PictureBox();
            this.familiaPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.modeloPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcaPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subfamiliaPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(54, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Familia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(196, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sub-Familia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(546, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Modelo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(383, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Marca";
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(19, 9);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(79, 33);
            this.titulo.TabIndex = 8;
            this.titulo.Text = "Criar";
            // 
            // modeloPicture
            // 
            this.modeloPicture.BackColor = System.Drawing.SystemColors.Highlight;
            this.modeloPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_prototype_50;
            this.modeloPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.modeloPicture.Location = new System.Drawing.Point(511, 53);
            this.modeloPicture.Name = "modeloPicture";
            this.modeloPicture.Size = new System.Drawing.Size(122, 94);
            this.modeloPicture.TabIndex = 3;
            this.modeloPicture.TabStop = false;
            this.modeloPicture.Click += new System.EventHandler(this.modeloPicture_Click);
            this.modeloPicture.MouseLeave += new System.EventHandler(this.modeloPicture_MouseLeave);
            this.modeloPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.modeloPicture_MouseMove);
            // 
            // marcaPicture
            // 
            this.marcaPicture.BackColor = System.Drawing.SystemColors.Highlight;
            this.marcaPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_brand_58;
            this.marcaPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.marcaPicture.Location = new System.Drawing.Point(347, 53);
            this.marcaPicture.Name = "marcaPicture";
            this.marcaPicture.Size = new System.Drawing.Size(122, 94);
            this.marcaPicture.TabIndex = 2;
            this.marcaPicture.TabStop = false;
            this.marcaPicture.Click += new System.EventHandler(this.marcaPicture_Click);
            this.marcaPicture.MouseLeave += new System.EventHandler(this.marcaPicture_MouseLeave);
            this.marcaPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.marcaPicture_MouseMove);
            // 
            // subfamiliaPicture
            // 
            this.subfamiliaPicture.BackColor = System.Drawing.SystemColors.Highlight;
            this.subfamiliaPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_product_50_family;
            this.subfamiliaPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.subfamiliaPicture.Location = new System.Drawing.Point(185, 53);
            this.subfamiliaPicture.Name = "subfamiliaPicture";
            this.subfamiliaPicture.Size = new System.Drawing.Size(122, 94);
            this.subfamiliaPicture.TabIndex = 1;
            this.subfamiliaPicture.TabStop = false;
            this.subfamiliaPicture.Click += new System.EventHandler(this.subfamiliaPicture_Click);
            this.subfamiliaPicture.MouseLeave += new System.EventHandler(this.subfamiliaPicture_MouseLeave);
            this.subfamiliaPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.subfamiliaPicture_MouseMove);
            // 
            // familiaPicture
            // 
            this.familiaPicture.BackColor = System.Drawing.SystemColors.Highlight;
            this.familiaPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_product_50;
            this.familiaPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.familiaPicture.Location = new System.Drawing.Point(25, 53);
            this.familiaPicture.Name = "familiaPicture";
            this.familiaPicture.Size = new System.Drawing.Size(122, 94);
            this.familiaPicture.TabIndex = 0;
            this.familiaPicture.TabStop = false;
            this.familiaPicture.Click += new System.EventHandler(this.familiaPicture_Click);
            this.familiaPicture.MouseLeave += new System.EventHandler(this.familiaPicture_MouseLeave);
            this.familiaPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.familiaPicture_MouseMove);
            // 
            // OpcaoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 210);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modeloPicture);
            this.Controls.Add(this.marcaPicture);
            this.Controls.Add(this.subfamiliaPicture);
            this.Controls.Add(this.familiaPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpcaoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpcaoDialog";
            ((System.ComponentModel.ISupportInitialize)(this.modeloPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcaPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subfamiliaPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiaPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox familiaPicture;
        private System.Windows.Forms.PictureBox subfamiliaPicture;
        private System.Windows.Forms.PictureBox marcaPicture;
        private System.Windows.Forms.PictureBox modeloPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label titulo;
    }
}