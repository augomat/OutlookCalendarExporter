using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookCalendarExporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RetrieveAppointments_Click(object sender, EventArgs e)
        {
            var appointments = OutlookAppointmentRetriever.retrieveAppointments(new DateTime(2018, 1, 1), new DateTime(2018, 12, 31));
        }
    }
}
