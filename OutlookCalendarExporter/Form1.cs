using System;
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

        public Form1()
        {
            InitializeComponent();
            populateCalendarList();
            
            Start.Value = DateTime.Now.AddMonths(-1);
            End.Value = DateTime.Now.AddYears(1);
        }

        private void populateCalendarList()
        {
            var folders = OutlookAppointmentRetriever.EnumerateCalendards();
            foreach(var folder in folders)
            {
                Calendars.Items.Add(folder.Path);
                Calendars.SetItemChecked(Calendars.Items.Count - 1, true);
            }
        }

        private void RetrieveAppointments_Click(object sender, EventArgs e)
        {
            actionRetrieveAndUploadOutlookAppointments();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actionRetrieveAndUploadOutlookAppointments();
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
        }

        private string generateIcal(List<AppointmentInfo> appointments)
        {
            var calendar = new Ical.Net.Calendar();
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
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + FTP_HOST + '/' + FTP_DIR + '/' + FTP_FILENAME);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
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
    }
}
