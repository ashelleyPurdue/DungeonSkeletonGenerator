using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons.VagueDungeonExplorer
{
    public partial class Explorer
    {
        public class UnlockEdgeCommand : AbstractCommand
        {
            private DungeonEdge edge;

            public UnlockEdgeCommand(DungeonEdge edge, Explorer parent) : base(parent)
            {
                this.edge = edge;
            }

            public override void Undo()
            {
                //Add all of the keys back.
                foreach (KeyData kd in edge.keysRequired)
                {
                    parent.keyInventory[kd.keyID] += kd.keyCount;
                }

                //Mark the edge as locked again
                parent.edgesUnlocked[edge] = false;
            }
        }
    }
}
