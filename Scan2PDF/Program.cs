using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace Scan2PDF
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Scan2PDF");
            Console.WriteLine("========\n");
            Console.WriteLine("Accept an image from a scan application, compress the image(s) and save to PDF.\n\n");

            if ((args == null) || (args.Length == 0))
            {
                Console.WriteLine("No args passed - launching config UI");
                Application.Run(new frmConfig());
                return;
            }
            string srcImgLoc = args[0];

            Console.WriteLine(String.Format("Source file: {0}", srcImgLoc));

            Image scannedImg;
            try
            {
                scannedImg = Image.FromFile(srcImgLoc);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load image - aborting");
                return;
            }

            List<Image> Pages = new List<Image>();

            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/tiff");

            Type myType = scannedImg.GetType();
            int iCount = scannedImg.GetFrameCount(FrameDimension.Page);
            EncoderParameters encoderParameters = new EncoderParameters(2);
            encoderParameters.Param[1] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionCCITT4);

            if (iCount > 1)
            {
                for (int i = 0; i < iCount; i++)
                {
                    scannedImg.SelectActiveFrame(FrameDimension.Page, i);

                    PropertyItem propertyItem = scannedImg.GetPropertyItem(297);
                    propertyItem.Value[0] = (byte)(i & 0x00FF);
                    propertyItem.Value[1] = (byte)(i & 0xFF00);
                    propertyItem.Value[2] = (byte)(iCount & 0x00FF);
                    propertyItem.Value[3] = (byte)(iCount & 0xFF00);
                    scannedImg.SetPropertyItem(propertyItem);

                    PropertyItem propertyItem2 = scannedImg.GetPropertyItem(254);
                    propertyItem2.Value[0] = (byte)2;
                    scannedImg.SetPropertyItem(propertyItem2);

                    Pages.Add((Image)scannedImg.Clone());
                }
            }
            else
            {
                Pages.Add((Image)scannedImg.Clone());
            }
            scannedImg.Dispose();

            uint jpgCompression = Settings.JpegCompression;
            Console.WriteLine(String.Format("Images loaded; recompressing to {0} JPEG", jpgCompression));

            // Recompress the images to nice JPGs (95% quality)
            ImageCodecInfo jpgCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters jpgEncParams = new EncoderParameters(1);
            jpgEncParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)jpgCompression);

            for (int i = 0; i < Pages.Count; i++)
            {
                string tmpFile = Path.GetTempFileName();
                Pages[i].Save(tmpFile, jpgCodec, jpgEncParams);
                Pages[i] = Image.FromFile(tmpFile);
                // Still in use: f**k freeing resources then...
                //File.Delete(tmpFile);
            }

            Console.WriteLine("Recompression complete; constructing PDF document");

            PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument();
            pdf.Info.Title = "Scanned image taken at " + DateTime.Now;
            foreach(var page in Pages)
            {
                PdfPage pdfPage = new PdfPage();
                pdfPage.Width = page.Width * 72 / page.HorizontalResolution; // 1 Inch = PostScript Points
                pdfPage.Height = page.Height * 72 / page.VerticalResolution;
                pdf.AddPage(pdfPage);
                XGraphics gfx = XGraphics.FromPdfPage(pdf.Pages[pdf.Pages.Count - 1]);
                XImage ximg = XImage.FromGdiPlusImage(page);
                gfx.DrawImage(ximg, new Point(0, 0));
            }
            DateTime now = DateTime.Now;

            string savePath;
            bool retry = false;
            do
            {
                try
                {
                    savePath = Settings.SaveLocation;
                    if ((CheckLocationSavable(savePath) == false) || (retry))
                    {
                        savePath = Path.GetDirectoryName(Application.ExecutablePath);
                    }
                    savePath += Path.DirectorySeparatorChar;

                    string FileName = String.Format("{0}{1:0000}-{2:00}-{3:00} {4:00}.{5:00}.{6:00}.pdf", 
                                                    savePath, now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);

                    Console.WriteLine("Construction complete; saving PDF");

                    pdf.Save(FileName);

                    Console.WriteLine("File saved to " + FileName);
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to write to saved location - falling back to write locally");
                    if (retry == false)
                    {
                        retry = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("All attempts to save the file failed - sorry.");
                    }
                }
                break;
            } while (true); // Sorry, couldn't think of a better way...
        }

        static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            var encoders = ImageCodecInfo.GetImageEncoders();

            foreach (var encoder in encoders)
            {
                if (encoder.MimeType == mimeType)
                {
                    return encoder;
                }
            }

            // Not found
            return null;
        }

        static bool CheckLocationSavable(string path)
        {
            try
            {
                // Attempt to get a list of security permissions from the folder. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
