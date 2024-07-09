using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy
{
    public interface IVariable
    {
        int Count();
        string Name();
        List<(int, double)> Terms();
    }
}
