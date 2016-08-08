using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.VagueDungeons;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilders
{
    public class RectangularRoomsBuilder : AbstractLayoutBuilder
    {
        public readonly Dungeon vagueDungeon;
        public bool doneBuilding { get; private set; }

        public delegate RectangleLayoutRoom RectangularRoomProviderMethod();
        private RectangularRoomProviderMethod GetRoom;

        public RectangularRoomsBuilder(Dungeon vagueDungeon, RectangularRoomProviderMethod GetRoom)
        {
            this.vagueDungeon = vagueDungeon;
            this.GetRoom = GetRoom;

            doneBuilding = false;
        }

        public void Build()
        {
            //TODO: build the dungeon
            doneBuilding = true;
        }

        public DungeonLayout GetLayout()
        {
            //TODO: Return the built dungeon.
        }
    }
}
