using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.AgeSets
{
    internal class Child : IHasFunc
    {
        public string Name => "Ребенок";

        public Type GetInputType => typeof(byte);

        public double GetResult(object input)
        {
            byte x = (byte)input;
            if (x < 18) return Math.Pow((18.0 - x) / 18, 1.0/2);
            else return 0;
        }
    }
}
