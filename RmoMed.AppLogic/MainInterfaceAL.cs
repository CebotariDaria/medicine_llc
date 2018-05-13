using RmoMed.AppLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmoMed.AppLogic
{
    public class MainInterfaceAL : AppApiCall, IMainInterface
    {
        public bool ValidateUser(string name)
        {
            return AuthMethod(name);
        }
    }

}
