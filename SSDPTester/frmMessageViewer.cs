using System;
using System.Text;
using System.Windows.Forms;

namespace SSDPTester
{
    public partial class frmMessageViewer : Form
    {
        public frmMessageViewer()
        {
            InitializeComponent();
        }

        public void SetValues(string time, string from, string to, string message)
        {
            txtTime.Text = time;
            txtFrom.Text = from;
            txtTo.Text = to;
            txtMessage.Text = message;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
