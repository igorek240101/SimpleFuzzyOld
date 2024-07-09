using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFuzzy
{
    public class GingerCat : IHasFunc
    {
        public string Name => "Рыжие котики";

        public Type GetInputType => typeof(Cat);

        public double GetResult(object input)
        {
            Cat x = input as Cat;
            double i = 0;
            if (x.Mother == CatColor.Ginger) i += 0.5;
            if (x.Father == CatColor.Ginger) i += 0.5;
            return i;
        }
    }
}
