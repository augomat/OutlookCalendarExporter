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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RetrieveAppointments = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lastSuccessfulUpload = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.Calendars = new System.Windows.Forms.CheckedListBox();
            this.End = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.DateTimePicker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.autostart = new System.Windows.Forms.CheckBox();
            this.NotifyIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // RetrieveAppointments
            // 
            this.RetrieveAppointments.Location = new System.Drawing.Point(256, 44);
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
            this.label1.Location = new System.Drawing.Point(16, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Last successful upload:";
            // 
            // lastSuccessfulUpload
            // 
            this.lastSuccessfulUpload.AutoSize = true;
            this.lastSuccessfulUpload.Location = new System.Drawing.Point(140, 217);
            this.lastSuccessfulUpload.Name = "lastSuccessfulUpload";
            this.lastSuccessfulUpload.Size = new System.Drawing.Size(88, 13);
            this.lastSuccessfulUpload.TabIndex = 2;
            this.lastSuccessfulUpload.Text = "Not yet uploaded";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(140, 199);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 4;
            // 
            // Calendars
            // 
            this.Calendars.FormattingEnabled = true;
            this.Calendars.HorizontalScrollbar = true;
            this.Calendars.Location = new System.Drawing.Point(12, 69);
            this.Calendars.Name = "Calendars";
            this.Calendars.Size = new System.Drawing.Size(366, 124);
            this.Calendars.TabIndex = 7;
            // 
            // End
            // 
            this.End.Location = new System.Drawing.Point(50, 47);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(200, 20);
            this.End.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "End:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Start:";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(50, 21);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(200, 20);
            this.Start.TabIndex = 10;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.NotifyIconContextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CalendarExporter";
            this.notifyIcon1.Visible = true;
            // 
            // NotifyIconContextMenu
            // 
            this.NotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOpen,
            this.MenuItemClose});
            this.NotifyIconContextMenu.Name = "NotifyIconContextMenu";
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.Size = new System.Drawing.Size(103, 22);
            this.MenuItemOpen.Text = "Open";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // MenuItemClose
            // 
            this.MenuItemClose.Name = "MenuItemClose";
            this.MenuItemClose.Size = new System.Drawing.Size(103, 22);
            this.MenuItemClose.Text = "Close";
            this.MenuItemClose.Click += new System.EventHandler(this.MenuItemClose_Click);
            // 
            // autostart
            // 
            this.autostart.AutoSize = true;
            this.autostart.Location = new System.Drawing.Point(258, 23);
            this.autostart.Name = "autostart";
            this.autostart.Size = new System.Drawing.Size(114, 17);
            this.autostart.TabIndex = 12;
            this.autostart.Text = "Start with windows";
            this.autostart.UseVisualStyleBackColor = true;
            this.autostart.CheckedChanged += new System.EventHandler(this.autostart_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 246);
            this.Controls.Add(this.autostart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.End);
            this.Controls.Add(this.Calendars);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lastSuccessfulUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RetrieveAppointments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CalendarExporter";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.NotifyIconContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.CheckedListBox Calendars;
        private System.Windows.Forms.DateTimePicker End;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Start;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClose;
        private System.Windows.Forms.CheckBox autostart;
    }
}

