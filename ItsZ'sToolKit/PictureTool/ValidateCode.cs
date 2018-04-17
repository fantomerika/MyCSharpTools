using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ItsZ_sToolKit.PictureTool
{
    public class ValidateCode
    {
        private int letterWidth = 25;//单个字体的宽度范围
        private int letterHeight = 52;//单个字体的高度范围
        private int letterCount = 4;//验证码位数
        private char[] chars = "0123456789abcdefghijkmnprstuvwxy".ToCharArray();
        private string[] fonts = { "Arial", "Georgia" };

        private const double PI = 3.1415926535897932384626433832795;
        private const double PI2 = 6.283185307179586476925286766559;

        //public object ValidateCode()
        //{
        //    Response.Expires = 0;
        //    Response.Buffer = true;
        //    Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
        //    Response.AddHeader("pragma", "no-cache");
        //    Response.CacheControl = "no-cache";
        //    string str_ValidateCode = GetRandomNumberString(letterCount);
        //    Session["ValidateCode"] = str_ValidateCode;
        //    CreateImage(str_ValidateCode);
        //    return "";
        //}

        public void CreateImage(string checkCode)
        {
            int int_ImageWidth = checkCode.Length * letterWidth + 30;
            Random newRandom = new Random();
            Bitmap image = new Bitmap(int_ImageWidth, letterHeight);
            Graphics g = Graphics.FromImage(image);

            Random random = new Random();

            g.Clear(Color.White);

            for (int i = 0; i < 10; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            int findex;
            for (int int_index = 0; int_index < checkCode.Length; int_index++)
            {
                findex = newRandom.Next(fonts.Length - 1);
                string str_char = checkCode.Substring(int_index, 1);
                Brush newBrush = new SolidBrush(GetRandomColor());
                Point thePos = new Point(int_index * letterWidth + 10 + newRandom.Next(3), 3 + newRandom.Next(3));
                g.DrawString(str_char, new Font(fonts[findex], 28, FontStyle.Bold), newBrush, thePos);
            }

            g.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, int_ImageWidth - 1, (letterHeight - 1));

            image = TwistImage(image, true, 6, 10);

            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            //Response.ClearContent();
            //Response.ContentType = "image/Png";
            //Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
        }

        public System.Drawing.Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            System.Drawing.Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            // 将位图背景填充为白色
            System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();
            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;
            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);
                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);
                    System.Drawing.Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }
        public Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);
            int int_Red = RandomNum_First.Next(210);
            int int_Green = RandomNum_Sencond.Next(180);
            int int_Blue = (int_Red + int_Green > 300) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;
            return Color.FromArgb(int_Red, int_Green, int_Blue);// 5+1+a+s+p+x
        }
        public string GetRandomNumberString(int int_NumberLength)
        {
            Random r = new Random();
            return r.Next(10, 99).ToString() + r.Next(10, 99).ToString() + r.Next(10, 99).ToString();
        }
    }
}
