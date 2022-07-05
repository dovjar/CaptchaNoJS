
using System.Drawing;
using System.Drawing.Imaging;

namespace CaptchaNoJS
{
    public class Captcha
    {
        private String answer;
        private  Random random;
        private Bitmap bmp;
            

        public Captcha(int pWidth, int pHeight, string text)
        {
            bmp = new(pWidth, pHeight,PixelFormat.Format32bppPArgb);
            
            random = new Random();

            answer = text;
        }
       
        public string GenerateAsB64()
        {
            using MemoryStream result = new MemoryStream();
            using var graph = Graphics.FromImage(bmp);
            graph.Clear(Color.White);
            AddLines(4,graph);

            AddStringToImg(graph);
            bmp.Save(result, ImageFormat.Jpeg);
            return Convert.ToBase64String(result.ToArray());
        }

        private void AddLines(int nb, Graphics graph)
        {
            for (int i = 0; i < nb; i++)
            {
                graph.DrawLine(new Pen(new SolidBrush(GetRandomColor()),random.Next(2,10)),random.Next(bmp.Width), random.Next(bmp.Height), random.Next(bmp.Width), random.Next(bmp.Height));
            }
        }
        
        private void AddStringToImg(Graphics graph)
        {

            Font font = new Font(FontFamily.GenericMonospace, 30);
            PointF strLoc = new PointF(0f, 5f);

            foreach (var t in answer)
            {
                graph.DrawString(t.ToString(),font,new SolidBrush(GetRandomColor()),strLoc);
                strLoc.X += (bmp.Width / (answer.Length+1));
            }
        }
        

        private Color GetRandomColor()
        {
            return Color.FromArgb(255,random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

    }
}
