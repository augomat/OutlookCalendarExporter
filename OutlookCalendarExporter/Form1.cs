﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;

namespace OutlookCalendarExporter
{
    public partial class Form1 : Form
    {
        private const string FTP_FILENAME = "kapeller_outlook.ics";
        private const string FTP_HOST = "files.000webhost.com";
        private const string FTP_DIR = "public_html/icals";
        private const string FTP_USER = "augomat";
        private const string FTP_PWD = "1234georgsMasterPwd!!";

        private bool firstStartup = true;

        public Form1()
        {
            InitializeComponent();
            populateCalendarList();
            
            Start.Value = DateTime.Now.AddMonths(-1);
            End.Value = DateTime.Now.AddYears(1);

            if (RegistryHelper.IsApplicationRegisteredForStartup())
                autostart.Checked = true;
        }

        private void populateCalendarList()
        {
            var folders = OutlookAppointmentRetriever.EnumerateCalendards();
            foreach (var folder in folders)
            {
                Calendars.Items.Add(folder.Path);
                Calendars.SetItemChecked(Calendars.Items.Count - 1, true);
            }
        }

        private void actionRetrieveAndUploadOutlookAppointments()
        {
            Status.Text = "Retrieving and Uploading...";
            try
            {
                retrieveAndUploadOutlookAppointments();
                Status.Text = "Uploaded";
                lastSuccessfulUpload.Text = DateTime.Now.ToString();
            } catch (Exception ex)
            {
                Status.Text = ex.Message;
            }
            showInfoBalloon("Status", Status.Text);
        }

        private void retrieveAndUploadOutlookAppointments()
        {
            List<String> folders = new List<string>();
            foreach(var item in Calendars.CheckedItems)
            {
                folders.Add(item.ToString());
            }

            var appointments = OutlookAppointmentRetriever.retrieveAppointments(folders, Start.Value, End.Value);

            var icalString = generateIcal(appointments);

            uploadToFTP(icalString);
            //writeToFile(icalString);
        }

        private string generateIcal(List<AppointmentInfo> appointments)
        {
            var calendar = new Ical.Net.Calendar();
            calendar.AddTimeZone(new Ical.Net.CalendarComponents.VTimeZone("Europe/Berlin")); //bringt das was? Muss fast das ical checken...
            foreach (var appointment in appointments)
            {
                var newEvent = new Ical.Net.CalendarComponents.CalendarEvent();
                newEvent.Summary = appointment.Name;
                newEvent.Location = appointment.Location;
                newEvent.Start = new Ical.Net.DataTypes.CalDateTime(appointment.DatStart);
                newEvent.End = new Ical.Net.DataTypes.CalDateTime(appointment.DatEnd);

                calendar.Events.Add(newEvent);
            }

            var calendarSerializer = new Ical.Net.Serialization.CalendarSerializer();
            var icalString = calendarSerializer.SerializeToString(calendar);

            return icalString;
        }

        private void uploadToFTP(string icalString)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + FTP_HOST + '/' + FTP_DIR + '/' + FTP_FILENAME);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(FTP_USER, FTP_PWD);

            using (Stream requestStream = request.GetRequestStream())
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] icalByteArray = encoding.GetBytes(icalString);
                requestStream.Write(icalByteArray, 0, icalString.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != FtpStatusCode.ClosingData)
                    throw new Exception("FTP-Upload failed: " + response.StatusDescription);
            }
        }

        private void writeToLocalFile(string icalString)
        {
            System.IO.File.WriteAllText(FTP_FILENAME, icalString);
        }

        // ---------------------------------------------------------------------------

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                hideWindow();
            }
        }

        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            showWindow();
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showWindow();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (firstStartup && args.Count() >= 2 && args[1] == "-minimized")
            {
                hideWindow();
            }
            firstStartup = false;
        }

        protected void hideWindow()
        {
            this.Hide();
            notifyIcon1.Visible = true;
        }

        protected void showWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = true;
        }

        public void showInfoBalloon(string title, string message)
        {
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.BalloonTipTitle = title;

            notifyIcon1.ShowBalloonTip(1000);
        }

        // ---------------------------------------------------------------------------

        private void autostart_CheckedChanged(object sender, EventArgs e)
        {
            if (autostart.Checked)
                RegistryHelper.AddApplicationToStartup();
            else
                RegistryHelper.RemoveApplicationFromStartup();
        }

        private void RetrieveAppointments_Click(object sender, EventArgs e)
        {
            actionRetrieveAndUploadOutlookAppointments();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actionRetrieveAndUploadOutlookAppointments();
            End.Value = DateTime.Now.AddYears(1);
        }
    }
}
