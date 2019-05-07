using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class DivUr3 : DivUr
    {
        public DivUr3(double a, double b, double step) : base(a, b, step) { }
        public override double Func(double x, double y)
        {
            return x * y + x * x;
        }

        public override void CreateFile(double x, double y, int i)
        {
            using (FileStream fstream = new FileStream(@"d:\Study\COURSE_TWO\visual enviroment\4sem\labs\lab7\ur3.txt", FileMode.Append))
            {
                string str = "n" + i + "{ x:" + Math.Round(x, 3) + " y:" + Math.Round(y, 3) + "}";
                byte[] array = System.Text.Encoding.Default.GetBytes(str);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
