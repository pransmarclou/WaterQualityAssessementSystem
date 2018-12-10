using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic
{
    interface IFuzzyLogic
    {
        double Temp
        {
            get;
            set;
        }

        double Turb
        {
            get;
            set;
        }        
    }

}
