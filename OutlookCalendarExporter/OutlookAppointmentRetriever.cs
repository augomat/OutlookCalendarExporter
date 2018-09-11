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
        public string Description { get; set; }

        public AppointmentInfo(DateTime datStart, DateTime datEnd, string name, string location = null, string description = null)
        {
            DatStart = datStart;
            DatEnd = datEnd;
            Name = name;
            Location = location ?? "";
            Description = description ?? "";
        }
    }

    class FolderInfo
    {
        public String Path { get; set; }

        public FolderInfo(String path)
        {
            Path = path;
        }
    }

    class OutlookAppointmentRetriever
    {

        public static List<AppointmentInfo> retrieveAppointments(List<String> folders, DateTime from, DateTime to)
        {
            var outlookFolders = _EnumerateCalendards();

            var ret = new List<AppointmentInfo>();
            foreach (var outlookFolder in outlookFolders)
            {
                if (folders.Contains(outlookFolder.FolderPath))
                {
                    var appointmentsPerFolder = retrieveAppointments(outlookFolder, from, to);
                    ret.AddRange(appointmentsPerFolder);
                }
            }
            return ret;
        }

        private static List<AppointmentInfo> retrieveAppointments(Outlook.Folder folder, DateTime from, DateTime to)
        {
            Outlook.Items rangeAppts = GetAppointmentsInRange(folder, from, to);

            var ret = new List<AppointmentInfo>();
            if (rangeAppts != null)
            {
                foreach (Outlook.AppointmentItem appt in rangeAppts)
                {
                    ret.Add(new AppointmentInfo(appt.Start, appt.End, appt.Subject, appt.Location, appt.Body));
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

        
        public static List<FolderInfo> EnumerateCalendards()
        {
            var calendars = _EnumerateCalendards();

            var ret = new List<FolderInfo>();
            foreach (var calendar in calendars)
            {
                ret.Add(new FolderInfo(calendar.FolderPath));
            }
            return ret;
        }

        private static List<Outlook.Folder> _EnumerateCalendards()
        {
            var oApp = new Microsoft.Office.Interop.Outlook.Application();
            Outlook.Folder root = oApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar) as Outlook.Folder;
            var folders = new List<Outlook.Folder>()
            {
                root
            };
            EnumerateFolders(root, folders);
            return folders;
        }

        private static void EnumerateFolders(Outlook.Folder folder, List<Outlook.Folder> folders)
        {
            Outlook.Folders childFolders = folder.Folders;
            if (childFolders.Count > 0)
            {
                foreach (Outlook.Folder childFolder in childFolders)
                {
                    folders.Add(childFolder);
                    EnumerateFolders(childFolder, folders);
                }
            }
        }
    }
}