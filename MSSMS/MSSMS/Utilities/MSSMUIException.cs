using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSMS.Utilities
{
    class MSSMUIException: Exception
    {
        public MSSMUIException()
        {

        }

        public MSSMUIException(string message, string errorCode)
            : base(String.Format("{0}\nError Code: {1}", message, errorCode))
        {

        }

        public MSSMUIException(string message)
            : base(String.Format("{0}", message))
        {

        }
    }
}
