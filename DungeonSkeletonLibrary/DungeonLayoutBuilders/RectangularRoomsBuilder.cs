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

        private Dictionary<DungeonRoom, LayoutRoom> layoutRooms = new Dictionary<DungeonRoom, LayoutRoom>();

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
            RectangleLayoutRoom startRoom = GetRoom(dungeon.startRoom);
            visited[dungeon.startRoom] = true;
            bfsQueue.Enqueue(dungeon.startRoom);

            //Use breadth first search to lay out every room.
            while (bfsQueue.Count > 0)
            {
                AdvanceBFS();
            }

            //TODO: Prevent colliding rooms
        }

        private void AdvanceBFS()
        {
            //Get the element
            DungeonRoom room = bfsQueue.Dequeue();
            LayoutRoom layoutRoom = layoutRooms[room];

            //Visit all neighboring rooms
            for (int i = 0; i < room.GetEdgeCount(); i++)
            {
                DungeonEdge edge = room.GetEdge(i);

                //Get the neighbor room
                DungeonRoom neighbor = edge.to;
                if (neighbor == room)
                {
                    neighbor = edge.from;
                }

                //Skip this room if it's already visited
                if (visited[neighbor])
                {
                    continue;
                }

                //Visit the neighbor
                visited[neighbor] = true;
                bfsQueue.Enqueue(neighbor);

                //Create the room
                RectangleLayoutRoom neighborLayout = CreateLayoutRoom(neighbor);

                //TODO: Put the room adjacent to its parent.
                //ExitDirection direction = roomScript.GetRandomExit(randGen);
                //PlaceRoom(neighborLayout, roomScript, direction);
            }
        }

        private RectangleLayoutRoom CreateLayoutRoom(DungeonRoom room)
        {
            //Create the LayoutRoom
            RectangleLayoutRoom layoutRoom = GetRoom(room);

            //Add it to the dictionary and the DungeonLayout
            layoutRooms.Add(room, layoutRoom);
            layout.AddRoom(layoutRoom);

            //Return it
            return layoutRoom;
        }
    }
}
