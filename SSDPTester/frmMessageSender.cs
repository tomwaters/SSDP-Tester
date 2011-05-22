using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SSDPTester
{
    
    public partial class frmMessageSender : Form
    {
        private string msgValue;
        private List<ListItem> templates = new List<ListItem>();

        public frmMessageSender()
        {
            InitializeComponent();
            msgValue = string.Empty;
        }

        public string GetValue()
        {
            return msgValue;
        }

        private void frmMessageSender_Load(object sender, EventArgs e)
        {
            templates.Add(new ListItem("All", "M-SEARCH * HTTP/1.1\r\nHOST: 239.255.255.250:1900\r\nST:ssdp:all\r\nMAN: \"ssdp:discover\"\r\nMX: 1\r\n\r\n"));
            templates.Add(new ListItem("Root Devices", "M-SEARCH * HTTP/1.1\r\nHOST: 239.255.255.250:1900\r\nST:upnp:rootdevice\r\nMAN: \"ssdp:discover\"\r\nMX: 1\r\n\r\n"));

            cmbTemplates.DataSource = templates;
            cmbTemplates.DisplayMember = "Name";
            cmbTemplates.ValueMember = "Value";
            cmbTemplates.SelectedIndex = 0;
            cmbTemplates.Select();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            msgValue = txtMessage.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTemplates.SelectedValue.GetType() == typeof(ListItem))
            {
                ListItem li = (ListItem)cmbTemplates.SelectedValue;
                txtMessage.Text = li.Value;
            }
            else if (cmbTemplates.SelectedValue.GetType() == typeof(string))
            {
                txtMessage.Text = cmbTemplates.SelectedValue.ToString();
            }
        }
    }

    public class ListItem
    {
        private string name = string.Empty;
        private string value = string.Empty;
        public ListItem(string szName, string szValue)
        {
            name = szName;
            value = szValue;
        }
        public override string ToString()
        {
            return this.name;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
