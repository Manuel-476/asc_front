namespace AscFrontEnd.Files
{
    partial class SerieForm
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
            this.textSerie = new System.Windows.Forms.TextBox();
            this.CrairSerieBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textSerie
            // 
            this.textSerie.Location = new System.Drawing.Point(29, 72);
            this.textSerie.Name = "textSerie";
            this.textSerie.Size = new System.Drawing.Size(378, 20);
            this.textSerie.TabIndex = 0;
            // 
            // CrairSerieBtn
            // 
            this.CrairSerieBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.CrairSerieBtn.ForeColor = System.Drawing.Color.White;
            this.CrairSerieBtn.Location = new System.Drawing.Point(29, 107);
            this.CrairSerieBtn.Name = "CrairSerieBtn";
            this.CrairSerieBtn.Size = new System.Drawing.Size(136, 32);
            this.CrairSerieBtn.TabIndex = 1;
            this.CrairSerieBtn.Text = "Criar";
            this.CrairSerieBtn.UseVisualStyleBackColor = false;
            this.CrairSerieBtn.Click += new System.EventHandler(this.CrairSerieBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Criar Serie";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(385, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Alterar Serie";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // SerieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 166);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CrairSerieBtn);
            this.Controls.Add(this.textSerie);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SerieForm";
            this.Load += new System.EventHandler(this.SerieForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSerie;
        private System.Windows.Forms.Button CrairSerieBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}