using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons
{
    public class DungeonEdge
    {
        public DungeonRoom from { get; private set; }
        public DungeonRoom to { get; private set; }

        public bool bidirectional;

        public List<KeyData> keysRequired = new List<KeyData>();

        public DungeonEdge(DungeonRoom from, DungeonRoom to, bool bidirectional)
        {
            this.from = from;
            this.to = to;
            this.bidirectional = true;
        }
    }
}
