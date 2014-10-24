namespace ActiveSearch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using System.Diagnostics;

    public partial class ActiveWindow : Form
    {
        private const int maxDiff = 300;

        internal string advFramePath = string.Empty;
        internal string videoFilePath = string.Empty;
        public ActiveWindow()
        {
            InitializeComponent();
        }

        private void SelectAdvFrame_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open advertisment frame";
            fDialog.Filter = "Image files|*.jpg;*.jpeg;*.bmp;*.gif;*.png;*.tif;*.tiff";
            fDialog.InitialDirectory = @"C:\";
            fDialog.AddExtension = true;
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                advFramePath = fDialog.FileName.ToString().Replace('\\', '/');
            }
        }

        private void SelectVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open advertisment frame";
            fDialog.Filter = "MP4 files|*.mp4;*.mpeg4";
            fDialog.InitialDirectory = @"C:\";
            fDialog.AddExtension = true;
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                videoFilePath = fDialog.FileName.ToString().Replace('\\', '/');
            }
        }
        private void SplitFrames_Click(object sender, EventArgs e)
        {
            if (videoFilePath != string.Empty)
            {
                Utils.ClearFolder("..\\Debug\\SplittedFiles");
                string commandLine = "-i " + videoFilePath + " -sameq SplittedFiles/frame_num%05d.jpg";
                Process.Start("ffmpeg_32.exe", commandLine);
            }
            else
            {
                MessageBox.Show("Please select video file!");
            }
        }

        private void BeginSearch_Click(object sender, EventArgs e)
        {
            if (advFramePath != string.Empty)
            {
                Color[,] advFrame = Utils.PortionOfImageToColorArray(
                    new Bitmap(advFramePath), 135, 285, 165, 315);
                List<Color[,]> videoFrames =
                    Utils.GetVideoFramesAsColorMatrix("..\\Debug\\SplittedFiles");

                List<double> matchFrames = new List<double>();
                for (int i = 0; i < videoFrames.Count; i++)
                {
                    if (i % 3 != 0)
                    {
                        continue;
                    }
                    if (Utils.CalcDifference(advFrame, videoFrames[i]) <= maxDiff)
                    {
                        matchFrames.Add(i / 1500.0);
                    }
                }
                if (matchFrames.Count > 0)
                {
                    MessageBox.Show(matchFrames[0].ToString());
                }
                else
                {
                    MessageBox.Show("No matching frame or no video loaded!");
                }
            }
            else
            {
                MessageBox.Show("Please select an advertisement frame!");
            }

        }

        private void UnloadVideoFrames_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.ClearFolder("..\\Debug\\SplittedFiles");
            }
            catch (Exception)
            {
                MessageBox.Show("Problem occurred while deleting files! Please try again!");
            }
        }
    }
}
