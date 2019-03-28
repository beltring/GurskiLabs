using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Function3 : Calculate
    {
        public Function3(double a, double b, double step) : base(a, b, step) { }

        public string Function { set; get; }

        public override double Func(double x)
        {
            return Math.Pow(Math.E, x);
        }
    }
}
