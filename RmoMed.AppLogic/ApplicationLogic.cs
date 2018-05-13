using RmoMed.AppLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmoMed.AppLogic
{
    public class ApplicationLogic
    {
        public IMainInterface GetMainInterfaceAL()
        {
            return new MainInterfaceAL();
        }

        public IGameInterface GetGameInterfaceAL()
        {
            return new GameInterfaceAL();
        }
    }
}
