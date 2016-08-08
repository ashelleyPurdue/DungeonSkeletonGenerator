using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.Utils;
using DungeonSkeletonLibrary.VagueDungeons;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilders
{
    public class RectangularRoomsBuilder : AbstractLayoutBuilder
    {
        public delegate RectangleLayoutRoom RectangularRoomProviderMethod(DungeonRoom dngRoom);
        private RectangularRoomProviderMethod GetRoom;

        private DefaultDictionary<DungeonRoom, bool> visited = new DefaultDictionary<DungeonRoom, bool>(false);
        private Queue<DungeonRoom> bfsQueue = new Queue<DungeonRoom>();

        public RectangularRoomsBuilder(Dungeon vagueDungeon, RectangularRoomProviderMethod GetRoom) : base(vagueDungeon)
        {
            this.GetRoom = GetRoom;
        }

        protected override void BuildInternal()
        {
            //TODO: Build the dungeon.

            //Start the BFS
            RectangleLayoutRoom startRoom = GetRoom(vagueDungeon.startRoom);
            visited[vagueDungeon.startRoom] = true;
            bfsQueue.Enqueue(vagueDungeon.startRoom);

            //Use breadth first search to lay out every room.
            while (bfsQueue.Count > 0)
            {
                //TODO: Advance the BFS
            }
        }


    }
}
