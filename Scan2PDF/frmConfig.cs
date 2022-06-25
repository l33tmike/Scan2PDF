using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Scan2PDF
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            valJpegCompression.Value = Settings.JpegCompression;
            txtSaveLoc.Text = Settings.SaveLocation;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Settings.JpegCompression = (uint)valJpegCompression.Value;
            if (Settings.JpegCompression != valJpegCompression.Value)
            {
                MessageBox.Show("Failed to save JPEG compression value", "Error");
            }
            
            Settings.SaveLocation = txtSaveLoc.Text;
            if (Settings.SaveLocation != txtSaveLoc.Text)
            {
                MessageBox.Show("Failed to save PDF save location - invalid path?", "Error");
            }
        }

        private void cmdBrowseForSaveLoc_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog
                                             {
                                                 SelectedPath = txtSaveLoc.Text,
                                                 Description = "Choose where to save the PDFs to"
                                             };
            if (browse.ShowDialog() == DialogResult.OK)
            {
                txtSaveLoc.Text = browse.SelectedPath;
            }
        }
    }
}
