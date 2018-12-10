using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WQAS
{
    public static class Global
    {

        private static string controlState;

        static Global()
        {
            ControlState = "Home";
        }

        #region Properties


        public static string ControlState
        {
            get { return controlState ; }
            set { controlState = value; }

        }

        #endregion

    }
}
