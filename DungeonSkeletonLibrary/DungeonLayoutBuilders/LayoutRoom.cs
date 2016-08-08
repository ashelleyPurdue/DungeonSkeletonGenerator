using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.Utils;
using DungeonSkeletonLibrary.VagueDungeons;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilders
{
    public class LayoutRoom
    {
        public LayoutRoom parent = null;
        public DungeonRoom dungeonRoom;

        public Vector localPosition = Vector.zero;
        public Vector position
        {
            get
            {
                if (parent == null)
                {
                    return localPosition;
                }
                else
                {
                    return parent.position + localPosition;
                }
            }
        }

        public Vector size = Vector.zero;

        public LayoutRoom(DungeonRoom dungeonRoom)
        {
            this.dungeonRoom = dungeonRoom;
        }
    }
}
