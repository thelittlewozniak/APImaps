using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using System.Drawing;
using APImaps.DAL;

namespace APImaps.PDF
{
    class PdfCreator
    {
        private int idroute;
        private string username;
        private string[,] InfoUser = new string[3, 2];
        string[,] InfoRoute = new string[3, 2];

        public PdfCreator()
        {
            idroute = 0;
            username = null;
        }
        public void Treatment(Route NewRoute, Player NewUser)
        {
            idroute = NewRoute.idroute;
            username = NewUser.nickname;
            string stringRoute = "Route of " + username;
            PdfDocument doc = new PdfDocument();
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins()
            {
                Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point),
                Bottom = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point),
                Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point),
                Right = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point),
            };
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);
            float y = 10;
            PdfBrush brush1 = PdfBrushes.Black;
            PdfBrush brush2 = PdfBrushes.Blue;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Regular));
            page.Canvas.DrawString("©thelittlewozniak", font2, brush2, 350, 0);
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString(stringRoute, font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString(stringRoute, format1).Height;
            y = y + 5;
            InfoUser[0, 0] = "Name:";
            InfoUser[1, 0] = "Rapidity";
            InfoUser[2, 0] = "Trust";
            InfoUser[0, 1] = NewUser.nickname;
            InfoUser[1, 1] = NewUser.rapidity.RapidityName;
            InfoUser[2, 1] = NewUser.trust.trustName;
            PdfTable table = new PdfTable();
            table.Style.BorderPen = new PdfPen(PdfBrushes.Transparent, 0f);
            table.Style.DefaultStyle.BorderPen = new PdfPen(PdfBrushes.Transparent, 0f);
            table.DataSource = InfoUser;
            PdfLayoutResult result = table.Draw(page, new PointF(0, y));
            y = y + 70;
            string[,] InfoRoute = new string[6, 2];
            InfoRoute[0, 0] = "IDROUTE: ";
            InfoRoute[1, 0] = "WAZELINK: ";
            InfoRoute[2, 0] = "MAPSLINK: ";
            InfoRoute[3, 0] = "DISTANCEKM: ";
            InfoRoute[4, 0] = "TIMEMIN: ";
            InfoRoute[5, 0] = "STATUS: ";
            InfoRoute[0, 1] = NewRoute.idroute.ToString();
            InfoRoute[1, 1] = NewRoute.wazelink;
            InfoRoute[2, 1] = NewRoute.mapslink + "\r\n";
            InfoRoute[3, 1] = Convert.ToString(Math.Round(Convert.ToDouble(NewRoute.distance), 1));
            InfoRoute[4, 1] = Convert.ToString(Math.Round(Convert.ToDouble(NewRoute.time), 1));
            InfoRoute[5, 1] = NewRoute.status.statusName;
            PdfTable table2 = new PdfTable();
            table2.DataSource = InfoRoute;
            table2.Style.CellPadding = 5;
            PdfLayoutResult result2 = table2.Draw(page, new PointF(0, y));

            stringRoute = stringRoute + " " + DateTime.Now.ToLongDateString() + ".pdf";
            doc.SaveToFile(stringRoute);
            doc.Close();
            System.Diagnostics.Process.Start(stringRoute);
        }
    }
}
