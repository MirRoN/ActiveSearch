namespace ActiveSearch
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    public static class Utils
    {
        public static long CalcDifference(Color[,] imageA, Color[,] imageB)
        {
            long difference = 0;
            for (int i = 0; i < imageA.GetLength(0); i++)
            {
                for (int j = 0; j < imageA.GetLength(1); j++)
                {
                    difference += Math.Abs(imageA[i, j].R - imageB[i, j].R)
                        + Math.Abs(imageA[i, j].G - imageB[i, j].G)
                        + Math.Abs(imageA[i, j].B - imageB[i, j].B);
                }
            }
            return difference;
        }

        public static Color[,] PortionOfImageToColorArray(System.Drawing.Bitmap imageIn, int xB, int yB, int xE, int yE)
        {
            Color[,] colorMatrix = new Color[xE - xB, yE - yB];
            using (imageIn)
            {
                for (int i = xB; i < xE; i++)
                {
                    for (int j = yB; j < yE; j++)
                    {
                        colorMatrix[i - xB, j - yB] = imageIn.GetPixel(i, j);
                    }
                }
            }
            return colorMatrix;
        }

        internal static void ExportList(List<double> listOfDifferences, string outputFilePath)
        {
            StreamWriter wr = new StreamWriter(outputFilePath);
            using (wr)
            {
                foreach (var item in listOfDifferences)
                {
                    wr.WriteLine("Frame found approximately at: {0:#,##0}", item);
                }
            }
        }

        internal static List<Color[,]> GetVideoFramesAsColorMatrix(string folderPath)
        {
            string[] paths = Directory.GetFiles(folderPath, "*.jpg",
                                     SearchOption.TopDirectoryOnly);
            List<Color[,]> frames = new List<Color[,]>();
            for (int i = 0; i < paths.Length; i++)
            {
                frames.Add(Utils.PortionOfImageToColorArray(
                    new Bitmap(paths[i]), 135, 285, 165, 315));
            }
            return frames;
        }

        internal static void ClearFolder(string folderName)
        {
            DirectoryInfo dir = new DirectoryInfo(folderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.IsReadOnly = false;
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }
    }
}
