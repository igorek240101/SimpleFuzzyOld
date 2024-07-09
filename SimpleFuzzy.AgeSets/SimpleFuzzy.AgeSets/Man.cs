using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.AgeSets
{
    internal class Man : IHasFunc
    {
        public string Name => "Взрослый";

        public Type GetInputType => typeof(byte);

        public double GetResult(object input)
        {
            byte x = (byte)input;
            if (x <= 18) return 0;
            if (x <= 22) return Math.Pow((x - 18.0) / 4, 2);
            if (x <= 50) return 1;
            if (x <= 70) return Math.Pow((20 - (x - 50.0)) / 20, 2);
            else return 0;
        }
    }
}
