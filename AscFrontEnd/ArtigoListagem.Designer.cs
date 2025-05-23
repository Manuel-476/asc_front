namespace AscFrontEnd
{
    partial class ArtigoListagem
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pesqText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eliminarPicture = new System.Windows.Forms.PictureBox();
            this.editarPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliminarPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editarPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(677, 217);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pesqText
            // 
            this.pesqText.Location = new System.Drawing.Point(13, 90);
            this.pesqText.Name = "pesqText";
            this.pesqText.Size = new System.Drawing.Size(222, 20);
            this.pesqText.TabIndex = 2;
            this.pesqText.TextChanged += new System.EventHandler(this.pesqText_TextChanged);
            this.pesqText.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pesqText_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pesquisar:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 70);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_box_80;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(11, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 58);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(117, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Artigos";
            // 
            // eliminarPicture
            // 
            this.eliminarPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_delete_48;
            this.eliminarPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.eliminarPicture.Location = new System.Drawing.Point(708, 189);
            this.eliminarPicture.Name = "eliminarPicture";
            this.eliminarPicture.Size = new System.Drawing.Size(71, 50);
            this.eliminarPicture.TabIndex = 11;
            this.eliminarPicture.TabStop = false;
            this.eliminarPicture.Click += new System.EventHandler(this.eliminarPicture_Click);
            // 
            // editarPicture
            // 
            this.editarPicture.BackgroundImage = global::AscFrontEnd.Properties.Resources.icons8_edit_40;
            this.editarPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editarPicture.Location = new System.Drawing.Point(708, 116);
            this.editarPicture.Name = "editarPicture";
            this.editarPicture.Size = new System.Drawing.Size(71, 50);
            this.editarPicture.TabIndex = 10;
            this.editarPicture.TabStop = false;
            this.editarPicture.Click += new System.EventHandler(this.editarPicture_Click);
            // 
            // ArtigoListagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 369);
            this.Controls.Add(this.eliminarPicture);
            this.Controls.Add(this.editarPicture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pesqText);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArtigoListagem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ArtigoListagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliminarPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editarPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox pesqText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox eliminarPicture;
        private System.Windows.Forms.PictureBox editarPicture;
    }
}