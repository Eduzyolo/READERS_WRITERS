namespace READERS_WRITERS
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.RB_Crypted = new System.Windows.Forms.RadioButton();
            this.RB_N_crypted = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // RB_Crypted
            // 
            this.RB_Crypted.AutoSize = true;
            this.RB_Crypted.Location = new System.Drawing.Point(650, 28);
            this.RB_Crypted.Name = "RB_Crypted";
            this.RB_Crypted.Size = new System.Drawing.Size(61, 17);
            this.RB_Crypted.TabIndex = 0;
            this.RB_Crypted.TabStop = true;
            this.RB_Crypted.Text = "Criptato";
            this.RB_Crypted.UseVisualStyleBackColor = true;
            // 
            // RB_N_crypted
            // 
            this.RB_N_crypted.AutoSize = true;
            this.RB_N_crypted.Location = new System.Drawing.Point(650, 51);
            this.RB_N_crypted.Name = "RB_N_crypted";
            this.RB_N_crypted.Size = new System.Drawing.Size(83, 17);
            this.RB_N_crypted.TabIndex = 1;
            this.RB_N_crypted.TabStop = true;
            this.RB_N_crypted.Text = "Non criptato";
            this.RB_N_crypted.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1085, 524);
            this.Controls.Add(this.RB_N_crypted);
            this.Controls.Add(this.RB_Crypted);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "READERS_WRITERS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RB_Crypted;
        private System.Windows.Forms.RadioButton RB_N_crypted;
    }
}

