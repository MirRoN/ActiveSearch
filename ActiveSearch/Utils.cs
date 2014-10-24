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

        internal static List<long> CalcAllDiffInFolder(string folderPath)
        {
            string[] paths = Directory.GetFiles(folderPath, "*.jpg",
                                     SearchOption.TopDirectoryOnly);
            List<long> diff = new List<long>();

            try
            {
                for (int i = 0; i < paths.Length - 1; i++)
                {
                    Bitmap bitmapOne = (Bitmap)Image.FromFile(paths[i], true);
                    Bitmap bitmapTwo = (Bitmap)Image.FromFile(paths[i + 1], true);
                    long differrence = Utils.CalcDifference(Utils.PortionOfImageToColorArray(bitmapOne, 130, 280, 170, 320),
                    Utils.PortionOfImageToColorArray(bitmapTwo, 130, 280, 170, 320));
                    diff.Add(differrence);
                }

            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("There was an error opening the bitmap. Please check the path.");
            }
            return diff;
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

        internal static List<long> GetScenesPattern(List<long> list, long threshold)
        {
            List<long> intervals = new List<long>();
            long count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < threshold)
                {
                    count++;
                }
                else
                {
                    intervals.Add(count);
                    count = 0;
                }
            }
            intervals.Add(count);
            return intervals;
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
