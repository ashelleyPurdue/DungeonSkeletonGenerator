using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonLibrary.VagueDungeons
{
    public struct KeyData
    {
        public int keyID;
        public int keyCount;

        public KeyData(int keyID, int keyCount = 1)
        {
            this.keyID = keyID;
            this.keyCount = keyCount;
        }

        public override string ToString()
        {
            //Determine if plural
            string plural;
            if (keyCount == 1)
            {
                plural = "key";
            }
            else
            {
                plural = "keys";
            }

            //Put it together

            return "" + keyCount + " " + ((KeyColor)keyID).ToString() + " " + plural;
        }
    }
}
