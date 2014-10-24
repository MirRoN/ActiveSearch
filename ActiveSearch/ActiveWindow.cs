namespace ActiveSearch
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

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
                resultDisplay.Text += "--------------------------------------------------"
                    + Environment.NewLine + "Started splitting frames..." + System.Environment.NewLine;

                Utils.ClearFolder("..\\Debug\\SplittedFiles");
                string commandLine = "-i " + videoFilePath + " -sameq SplittedFiles/frame_num%05d.jpg";
                Process.Start("ffmpeg_32.exe", commandLine);

                resultDisplay.Text += "Done splitting frames..." + Environment.NewLine
                    + "--------------------------------------------------"
                    + Environment.NewLine;

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
                resultDisplay.Text += "--------------------------------------------------"
                    + Environment.NewLine + "Started searching..." + System.Environment.NewLine;

                Task.Factory.StartNew(() =>
                    {
                        Color[,] advFrame = Utils.PortionOfImageToColorArray(
                            new Bitmap(advFramePath), 135, 285, 165, 315);
                        List<Color[,]> videoFrames =
                            Utils.GetVideoFramesAsColorMatrix("..\\Debug\\SplittedFiles");

                        List<double> matchFrames = new List<double>();

                        for (int i = 0; i < videoFrames.Count; i++)
                        {
                            if (Utils.CalcDifference(advFrame, videoFrames[i]) <= maxDiff)
                            {
                                matchFrames.Add(i / 500.0);
                            }
                        }
                        if (matchFrames.Count > 0)
                        {
                            foreach (var item in matchFrames)
                            {
                                resultDisplay.Text += "Video frame found at approximately: " + item.ToString() + " minute.";
                                resultDisplay.Text += Environment.NewLine;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No matching frame or no video loaded!");
                        }

                        resultDisplay.Text += "Done searching..." + Environment.NewLine
                            + "--------------------------------------------------"
                            + Environment.NewLine;
                    });

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
                Task.Factory.StartNew(() =>
                    {
                        resultDisplay.Text += "--------------------------------------------------"
                            + Environment.NewLine + "Started clearing folder..." 
                            + System.Environment.NewLine;

                        Utils.ClearFolder("..\\Debug\\SplittedFiles");

                        resultDisplay.Text += "Done clearing folder..." + Environment.NewLine
                            + "--------------------------------------------------"
                            + Environment.NewLine;
                    });
            }
            catch (Exception)
            {
                MessageBox.Show("Problem occurred while deleting files! Please try again!");
            }
        }
    }
}
