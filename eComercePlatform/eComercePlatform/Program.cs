using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Platform cSharpazon = new Platform();
            Consumer guest = new Consumer();
            cSharpazon.UsePlatform(guest);
        }
    }
}
