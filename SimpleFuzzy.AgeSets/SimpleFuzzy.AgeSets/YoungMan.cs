using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.AgeSets
{
    internal class YoungMan : IHasFunc
    {
        public static string Name => "Молодой человек";

        public Type GetInputType => typeof(byte);

        public double GetResult(object input)
        {
            byte x = (byte)input;
            if (x < 14) return 0;
            if (x < 18) return (x - 13.0) / 4;
            if (x < 25) return 1;
            if (x < 35) return (10 - (x - 24.0)) / 10;
            else return 0;
        }
    }
}
