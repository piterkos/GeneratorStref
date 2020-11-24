using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Check.Reports.Framework
{
    //TODO this class needs refactor (static etc.)
    public class RawPrinterHelper
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int size);

        public static void SendFileToPrinter(string pdfFileName)
        {
            try
            {
                // Open the PDF file.
                FileStream fs = new FileStream(pdfFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = new Byte[fs.Length];
                // Unmanaged pointer.
                IntPtr ptrUnmanagedBytes = new IntPtr(0);
                int nLength = Convert.ToInt32(fs.Length);
                // Read contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                SendByteToPrinter(bytes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //TODO this should take stream not byte
        public static void SendByteToPrinter(byte[] bytes)
        {
            try
            {
                #region Get Connected Printer Name
                PrintDocument pd = new PrintDocument();
                StringBuilder dp = new StringBuilder(256);
                int size = dp.Capacity;
                if (GetDefaultPrinter(dp, ref size))
                {
                    pd.PrinterSettings.PrinterName = dp.ToString().Trim();
                }
                #endregion Get Connected Printer Name
                pd.DefaultPageSettings.PaperSize = new PaperSize() { RawKind = (int)PaperKind.A4 };
                pd.PrintController = new StandardPrintController();
                pd.PrintPage += (sender, args) =>
                {
                    var memoryStream = new MemoryStream(bytes);
                    Image i = Image.FromStream(memoryStream);
                    Rectangle m = new Rectangle(0, 0, (int)args.PageSettings.PrintableArea.Width, (int)args.PageSettings.PrintableArea.Height);

                    if (i.Width / (double)i.Height > m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)(i.Height / (double)i.Width * m.Width);
                    }
                    else
                    {
                        m.Width = (int)(i.Width / (double)i.Height * m.Height);
                    }
                    args.Graphics.DrawImage(i, m);
                };

                pd.Print();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

