﻿using System;
using System.Windows.Forms;

namespace WindowsFormsActions
{
    public partial class Error : Form
    {
        public Error(Exception ex)
        {
            InitializeComponent();

            txtError.Text = ex.Message.ToUpper() + Environment.NewLine + Environment.NewLine + "STACK TRACE" +
                            Environment.NewLine + ex.StackTrace;

            txtError.Text += ex.InnerException != null
                ? Environment.NewLine + "INNER EXCEPTION" + Environment.NewLine +
                  ex.InnerException.Message
                : string.Empty;
        }

        private void LnkCopyToClipboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtError.Text);
        }
    }
}