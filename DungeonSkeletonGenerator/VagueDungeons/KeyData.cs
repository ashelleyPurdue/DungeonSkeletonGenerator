using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons
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
    }
}
