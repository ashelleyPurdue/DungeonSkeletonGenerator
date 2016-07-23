using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons
{
    public class VagueDungeonExplorer
    {
        public VagueDungeonGraph dungeon { get; private set; }
        public VagueDungeonNode currentRoom { get; private set; }

        private Dictionary<int, int> keyInventory = new Dictionary<int, int>();

        public VagueDungeonExplorer(VagueDungeonGraph dungeon)
        {
            this.dungeon = dungeon;
            currentRoom = dungeon.startRoom;
        }


        //Misc methods

        public bool CanUseEdge(VagueDungeonEdge edge)
        {
            //Returns if the explorer can use the given edge.

            return false;
        }

        public VagueDungeonNode[] UseableNeighboringEdges()
        {
            //Returns all of the neighbors that can 

            return null;
        }
    }
}
