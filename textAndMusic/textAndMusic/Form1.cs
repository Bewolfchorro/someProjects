using AxWMPLib;
using System;
using System.Windows.Forms;

namespace textAndMusic
{
    public partial class Form1 : Form
    {
        private bool isPlaying = false;

        public Form1()
        {
            InitializeComponent();
        }

        string[] files, paths;

        private void btnSelect(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]);
                }
            }
        }

        private void btnClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (isPlaying)
                {
                mediaPlayer.Ctlcontrols.stop();
                mediaPlayer.URL = "";
                isPlaying = false;
                 }
                 else
                 {
                    try
                    {   
                        mediaPlayer.URL = paths[listBox1.SelectedIndex];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                 
                 mediaPlayer.Ctlcontrols.play();
                 isPlaying = true;
                 }
             }
        }
    }
}
