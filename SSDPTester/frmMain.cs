using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace SSDPTester
{
    public partial class frmMain : Form
    {
        private SSDPListener myListener = new SSDPListener();

        public frmMain()
        {
            InitializeComponent();
        }

        public void MessageReceiver(DateTime dtReceived, string from, string to, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new MessageReceiverDelegate(MessageReceiver),dtReceived, from, to, message);
                return;
            }            
            
            string[] newItems = new string[4];
            newItems[0] = dtReceived.ToString();
            newItems[1] = from;
            newItems[2] = to;
            newItems[3] = message;
            ListViewItem lvi = new ListViewItem(newItems);
            lvMsgs.Items.Insert(0, lvi);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (myListener.IsRunning())
            {
                btnStartStop.Text = "Start";
                myListener.Stop();
            }
            else
            {
                btnStartStop.Text = "Stop";
                myListener.Start(MessageReceiver);
            }
        }

        private void lvMsgs_DoubleClick(object sender, EventArgs e)
        {
            string time = lvMsgs.SelectedItems[0].SubItems[0].Text;
            string from = lvMsgs.SelectedItems[0].SubItems[1].Text;
            string to = lvMsgs.SelectedItems[0].SubItems[2].Text;
            string msg = lvMsgs.SelectedItems[0].SubItems[3].Text;

            frmMessageViewer msgView = new frmMessageViewer();
            msgView.SetValues(time, from, to, msg);
            msgView.ShowDialog();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            frmMessageSender msgSender = new frmMessageSender();
            if (msgSender.ShowDialog() == DialogResult.OK)
            {
                string msg = msgSender.GetValue();
                myListener.Send(msg);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvMsgs.Items.Clear();
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            if (svCSV.ShowDialog() == DialogResult.OK)
            {
                TextWriter tw = new StreamWriter(svCSV.FileName);
                
                //Column Headers
                StringBuilder csvHeader = new StringBuilder();
                foreach (ColumnHeader ch in lvMsgs.Columns)
                {
                    csvHeader.Append(ch.Text);
                    csvHeader.Append(",");
                }
                tw.WriteLine(csvHeader.ToString());

                //Items
                foreach (ListViewItem lviItem in lvMsgs.Items)
                {
                    StringBuilder csvLine = new StringBuilder();
                    foreach (ListViewItem.ListViewSubItem lviSubItem in lviItem.SubItems)
                    {
                        csvLine.Append(lviSubItem.Text.Replace("\r\n", " "));
                        csvLine.Append(",");
                    }
                    tw.WriteLine(csvLine.ToString());
                }
                tw.Close();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            myListener.Stop();
        }
    }
}
