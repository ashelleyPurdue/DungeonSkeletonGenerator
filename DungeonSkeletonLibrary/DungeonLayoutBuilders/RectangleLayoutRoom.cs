using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.Utils;
using DungeonSkeletonLibrary.VagueDungeons;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilders
{
    public class RectangleLayoutRoom : LayoutRoom
    {
        public Vector size;

        public RectangleLayoutRoom(DungeonRoom dungeonRoom, Vector size) : base(dungeonRoom)
        {
            this.size = size;
        }

    }
}
