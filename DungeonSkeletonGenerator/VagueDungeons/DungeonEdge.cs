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
        public bool isShortcut;

        public List<KeyData> keysRequired = new List<KeyData>();

        public DungeonEdge(DungeonRoom from, DungeonRoom to, bool bidirectional = true, bool isShortcut = false)
        {
            this.from = from;
            this.to = to;

            this.bidirectional = bidirectional;
            this.isShortcut = isShortcut;
        }
    }
}
