using System.Text;

namespace Exam
{
    class Program
    {
        static void Main(string[] argv)
        {
            SomeString s1 = new("Hello");
            SomeString s2 = new("How are you");
            SomeString s3 = new("Cruy");
            SomeString s4 = new("Cggy");
            SomeString s5 = new("C!:dfdf:,");

            //Console.WriteLine(s1.Equals(s2));
            //Console.WriteLine(s3.Equals(s4));

            string s = s1 + 's';
            string sTwo = -s2;

            //Console.WriteLine(s);
            //Console.WriteLine(sTwo);
            //Console.WriteLine(s2.str.CountProb());
            //Console.WriteLine(s5.str.deleteZnak());

            SomeString[] arrSS = { s1, s2, s3, s4, s5 };

            var result = (from z in arrSS select z.countProb).Sum();
            //Console.WriteLine(result);
            using (StreamWriter cw = new("File.txt", false))
            {
                cw.WriteLine(s1.Equals(s2));
                cw.WriteLine(s3.Equals(s4));
                cw.WriteLine(s);
                cw.WriteLine(sTwo);
                cw.WriteLine(s2.str.CountProb());
                cw.WriteLine(s5.str.deleteZnak());
                cw.WriteLine(result);
            }

        }
    }
}