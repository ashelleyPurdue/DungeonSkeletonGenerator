using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonSkeletonGenerator.Utils;

namespace DungeonSkeletonGenerator.VagueDungeons
{
    public class VagueDungeonExplorer
    {
        public VagueDungeonGraph dungeon { get; private set; }
        public VagueDungeonNode currentRoom { get; private set; }

        private DefaultDictionary<int, int> keyInventory = new DefaultDictionary<int, int>(0);

        private DefaultDictionary<VagueDungeonEdge, bool> edgesUnlocked = new DefaultDictionary<VagueDungeonEdge, bool>(false);

        public VagueDungeonExplorer(VagueDungeonGraph dungeon)
        {
            this.dungeon = dungeon;
            currentRoom = dungeon.startRoom;
        }


        //Misc methods

        public bool EdgeUnlocked(VagueDungeonEdge edge)
        {
            //Returns if the given edge has been unlocked.
            //If the edge was never locked in the first place, returns true.

            //Return true if the edge was never locked in the first place
            bool startedLocked = false;
            foreach (KeyData keyData in edge.keysRequired)
            {
                if (keyData.keyCount > 0)
                {
                    startedLocked = true;
                    break;
                }
            }

            if (startedLocked)
            {
                return true;
            }

            //Return the contents of the unlock dictionary
            return edgesUnlocked[edge];
        }

        public List<VagueDungeonEdge> UseableNeighboringEdges()
        {
            //Returns all of the neighboring edges that can be used.

            List<VagueDungeonEdge> edgeList = new List<VagueDungeonEdge>();

            for (int i = 0; i < currentRoom.GetEdgeCount(); i++)
            {
                //Add it to the list if it's useable
                VagueDungeonEdge edge = currentRoom.GetEdge(i);
                if (CanUseEdge(edge))
                {
                    edgeList.Add(edge);
                }
            }

            return edgeList;
        }

        private bool CanUseEdge(VagueDungeonEdge edge)
        {
            //Returns if the explorer can use the given neighboring edge.

            //Return false if the edge isn't bidirectional and we're not in the right spot
            if (!edge.bidirectional && currentRoom != edge.from)
            {
                return false;
            }

            //Return false if the edge is locked
            if (!EdgeUnlocked(edge))
            {
                return false;
            }

            return true;
        }
    }
}
