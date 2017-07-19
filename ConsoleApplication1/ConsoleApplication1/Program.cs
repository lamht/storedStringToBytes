using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private const string STR_LOCAL = "Mz6@a0i*";
        //Ensure this value cannot be read as clear text
        private readonly static int[] OPENER = { 52, 97, 29, 39, 72, 23, 80, 17 };
        class String2ArrayInt
        {

            public Byte[] Convert()
            {
                Byte[] localPw = System.Text.Encoding.UTF8.GetBytes(STR_LOCAL);
                Byte[] ba_opener = localPw.Select(x => (byte)(x - 25)).ToArray();
                return ba_opener;
            }

            public string ReConvert(Byte[] ba_opener)
            {
                Byte[] localPw = ba_opener.Select(x => (byte)(x + 25)).ToArray();
                string strPw = System.Text.Encoding.UTF8.GetString(localPw);
                return strPw;
            }
            public string PrintByteArray(byte[] bytes)
            {
                var sb = new StringBuilder("new byte[] { ");
                foreach (var b in bytes)
                {
                    sb.Append(b + ", ");
                }
                if (bytes.Length > 0)
                {
                    //remove end of ","
                    sb.Length--;
                }
                sb.Append("}");
                return sb.ToString();
            }
            public string GetPw(){
                Byte[] localPw = OPENER.Select(x => (byte)(x + 25)).ToArray();
                string strPw = System.Text.Encoding.UTF8.GetString(localPw);
                return strPw;
            }
        }
        static void Main(string[] args)
        {
            
            String2ArrayInt obj = new String2ArrayInt();
            Byte[] bPw = obj.Convert();
            Console.WriteLine("Array " + obj.PrintByteArray(bPw));
            System.Diagnostics.Debug.WriteLine("Array " + obj.PrintByteArray(bPw));
            String strPw = obj.ReConvert(bPw);
            Console.WriteLine("String " + strPw);
            Console.WriteLine("Equal constant " + (strPw == STR_LOCAL));
            strPw = obj.GetPw();
            Console.WriteLine("Get password " + strPw);
            Console.WriteLine("Equal constant get pw " + (strPw == STR_LOCAL));
            Console.ReadLine();
        }
    }
}
