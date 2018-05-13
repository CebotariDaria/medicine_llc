using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RmoMed.AppLogic
{
    public class AppApiCall
    {
        private static readonly Random Random = new Random();
        protected bool AuthMethod(string name)
        {
            return true;
        }

        protected static Thickness RandomPosition(double width, double height, double dWidth, double dHeight)
        {
            var pW = width;
            var pH = height;

            var minLeft = -1 * dWidth / 2 - pW;
            var maxLeft = dWidth / 2 + pW;

            var minTop = -1 * dHeight / 2 - pH;
            var maxTop = dHeight / 2 + pH;

            var left = RandomBetween(minLeft, maxLeft);
            var top = RandomBetween(minTop, maxTop);

            return new Thickness(left, top, 0, 0);
        }

        private static double RandomBetween(double min, double max)
        {
            return Random.NextDouble() * (max - min) + min;
        }
    }
}
