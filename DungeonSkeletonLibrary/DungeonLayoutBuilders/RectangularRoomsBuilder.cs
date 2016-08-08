using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.VagueDungeons;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilders
{
    public class RectangularRoomsBuilder : AbstractLayoutBuilder
    {
        public delegate RectangleLayoutRoom RectangularRoomProviderMethod();
        private RectangularRoomProviderMethod GetRoom;

        public RectangularRoomsBuilder(Dungeon vagueDungeon, RectangularRoomProviderMethod GetRoom) : base(vagueDungeon)
        {
            this.GetRoom = GetRoom;
        }

        protected override void BuildInternal()
        {
            //TODO: Build the dungeon.
        }
    }
}
