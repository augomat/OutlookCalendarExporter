namespace OutlookCalendarExporter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.RetrieveAppointments = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RetrieveAppointments
            // 
            this.RetrieveAppointments.Location = new System.Drawing.Point(91, 30);
            this.RetrieveAppointments.Name = "RetrieveAppointments";
            this.RetrieveAppointments.Size = new System.Drawing.Size(122, 23);
            this.RetrieveAppointments.TabIndex = 0;
            this.RetrieveAppointments.Text = "Retrieve appointments";
            this.RetrieveAppointments.UseVisualStyleBackColor = true;
            this.RetrieveAppointments.Click += new System.EventHandler(this.RetrieveAppointments_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 176);
            this.Controls.Add(this.RetrieveAppointments);
            this.Name = "Form1";
            this.Text = "CalendarExporter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RetrieveAppointments;
    }
}

