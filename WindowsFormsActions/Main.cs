using System;
using System.Windows.Forms;

namespace WindowsFormsActions
{
    public partial class Main : Form
    {
        private bool _closeApplication;

        public Main()
        {
            InitializeComponent();

            cmbType.SelectedIndex = 0;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            notifyIcon.BalloonTipIcon = GetTipIcon();
            notifyIcon.BalloonTipTitle = txtTitle.Text;
            notifyIcon.BalloonTipText = txtText.Text;
            notifyIcon.ShowBalloonTip(Convert.ToInt32(txtTime.Text));
        }

        private ToolTipIcon GetTipIcon()
        {
            if (cmbType.SelectedItem.ToString() == "Error")
            {
                return ToolTipIcon.Error;
            }

            if (cmbType.SelectedItem.ToString() == "Info")
            {
                return ToolTipIcon.Info;
            }

            if (cmbType.SelectedItem.ToString() == "Warning")
            {
                return ToolTipIcon.Warning;
            }

            return ToolTipIcon.None;
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_closeApplication)
            {
                WindowState = FormWindowState.Minimized;
                Visible = false;
                e.Cancel = true;

                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.BalloonTipTitle = Text;
                notifyIcon.BalloonTipText = "Running on background";
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _closeApplication = true;
            Close();
        }

        private void tabPage2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void tabPage2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            int fileAdded = 0;
            foreach (string filePath in files)
            {
                txtConsole.Text += Environment.NewLine + filePath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int res = 10 / i;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new ArgumentNullException();
        }
    }
}