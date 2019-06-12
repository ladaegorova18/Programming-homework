using System;
using System.Windows.Forms;

namespace Clock
{
    public partial class SystemClock : Form
    {
        public SystemClock()
        {
            InitializeComponent();
        }

        private void Start(object sender, EventArgs e)
        {
            ShowData();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            var currentTime = System.DateTime.Now;
            time.Text = currentTime.ToLongTimeString();
            var localTimeZone = System.TimeZoneInfo.Local;
            timeZone.Text = localTimeZone.DisplayName;
        }
    }
}
