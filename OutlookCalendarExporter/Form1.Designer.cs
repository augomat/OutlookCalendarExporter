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
            this.components = new System.ComponentModel.Container();
            this.RetrieveAppointments = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lastSuccessfulUpload = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RetrieveAppointments
            // 
            this.RetrieveAppointments.Location = new System.Drawing.Point(12, 12);
            this.RetrieveAppointments.Name = "RetrieveAppointments";
            this.RetrieveAppointments.Size = new System.Drawing.Size(122, 23);
            this.RetrieveAppointments.TabIndex = 0;
            this.RetrieveAppointments.Text = "Retrieve and Upload";
            this.RetrieveAppointments.UseVisualStyleBackColor = true;
            this.RetrieveAppointments.Click += new System.EventHandler(this.RetrieveAppointments_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Last successful upload:";
            // 
            // lastSuccessfulUpload
            // 
            this.lastSuccessfulUpload.AutoSize = true;
            this.lastSuccessfulUpload.Location = new System.Drawing.Point(140, 66);
            this.lastSuccessfulUpload.Name = "lastSuccessfulUpload";
            this.lastSuccessfulUpload.Size = new System.Drawing.Size(88, 13);
            this.lastSuccessfulUpload.TabIndex = 2;
            this.lastSuccessfulUpload.Text = "Not yet uploaded";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(140, 48);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 176);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lastSuccessfulUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RetrieveAppointments);
            this.Name = "Form1";
            this.Text = "CalendarExporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RetrieveAppointments;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lastSuccessfulUpload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Status;
    }
}

