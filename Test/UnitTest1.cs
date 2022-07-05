using System.Diagnostics;
using CaptchaNoJS;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var random = new Random();
            var a = random.Next(8)+1;
            var b = random.Next(8)+1;
            var text = a > b ? $"{a} - {b}" : $"{a} + {b}";
            var answer =a > b ? a - b : a + b;
            ;

            var captcha = new Captcha(100, 50, text);
            Debug.Write(captcha.GenerateAsB64());
        }
    }
}