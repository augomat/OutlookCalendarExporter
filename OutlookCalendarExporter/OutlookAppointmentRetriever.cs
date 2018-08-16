using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookCalendarExporter
{
    class AppointmentInfo
    {
        public DateTime DatStart { get; set; }
        public DateTime DatEnd { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public AppointmentInfo(DateTime datStart, DateTime datEnd, string name, string location)
        {
            DatStart = datStart;
            DatEnd = datEnd;
            Name = name;
            Location = location;
        }
    }

    class OutlookAppointmentRetriever
    {
        public static List<AppointmentInfo> retrieveAppointments(DateTime from, DateTime to)
        {
            var oApp = new Microsoft.Office.Interop.Outlook.Application();
            Outlook.Folder calFolder = oApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar) as Outlook.Folder;
            Outlook.Items rangeAppts = GetAppointmentsInRange(calFolder, from, to);

            var ret = new List<AppointmentInfo>();
            if (rangeAppts != null)
            {
                foreach (Outlook.AppointmentItem appt in rangeAppts)
                {
                    //MessageBox.Show("Subject: " + appt.Subject + " Start: " + appt.Start.ToString("g"));
                    ret.Add(new AppointmentInfo(appt.Start, appt.End, appt.Subject, appt.Location));
                }
            }
            return ret;
        }

        private static Outlook.Items GetAppointmentsInRange(Outlook.Folder folder, DateTime startTime, DateTime endTime)
        {
            string filter = "[Start] <= '" + endTime.ToString("g") + "' AND [End] >= '" + startTime.ToString("g") + "'"; //also consider overlapping appointments

            try
            {
                Outlook.Items calItems = folder.Items;
                calItems.IncludeRecurrences = true;
                calItems.Sort("[Start]", Type.Missing);
                Outlook.Items restrictItems = calItems.Restrict(filter);
                if (restrictItems.Count > 0)
                {
                    return restrictItems;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}