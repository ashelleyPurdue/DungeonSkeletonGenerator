using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons
{
    public class VagueDungeonEdge
    {
        public VagueDungeonNode from { get; private set; }
        public VagueDungeonNode to { get; private set; }

        public bool bidirectional;

        public List<KeyData> keysRequired = new List<KeyData>();

        public VagueDungeonEdge(VagueDungeonNode from, VagueDungeonNode to, bool bidirectional)
        {
            this.from = from;
            this.to = to;
            this.bidirectional = true;
        }
    }
}
