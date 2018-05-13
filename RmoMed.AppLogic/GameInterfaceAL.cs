using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RmoMed.AppLogic.Interfaces;

namespace RmoMed.AppLogic
{
    class GameInterfaceAL : AppApiCall, IGameInterface
    {
        public Thickness GetRandomPosition(double width, double height, double dWidth, double dHeight)
        {
            return RandomPosition(width, height, dWidth, dHeight);
        }
    }
}
