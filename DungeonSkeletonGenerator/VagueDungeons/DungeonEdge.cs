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

        public bool bidirectional
        {
            get { return type == EdgeType.bidirectional; }
        }
        public EdgeType type;

        public bool requiresKeys
        {
            get
            {
                foreach (KeyData kd in keysRequired)
                {
                    if (kd.keyCount > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public List<KeyData> keysRequired = new List<KeyData>();

        public DungeonEdge(DungeonRoom from, DungeonRoom to, bool bidirectional)
        {
            this.from = from;
            this.to = to;
            
            if (bidirectional)
            {
                type = EdgeType.bidirectional;
            }
            else
            {
                type = EdgeType.oneWay;
            }
        }

        public DungeonEdge(DungeonRoom from, DungeonRoom to, EdgeType type = EdgeType.bidirectional)
        {
            this.from = from;
            this.to = to;
            this.type = type;
        }
    }

    public enum EdgeType
    {
        bidirectional,
        oneWay,
        shortcut
    }
}
