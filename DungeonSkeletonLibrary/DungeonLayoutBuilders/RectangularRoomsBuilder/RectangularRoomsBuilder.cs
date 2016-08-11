using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.Utils;
using DungeonSkeletonLibrary.VagueDungeons;
using DungeonSkeletonLibrary.DungeonLayoutBuilder.LayoutRooms;
using DungeonSkeletonLibrary.DungeonLayoutBuilders.RectangularRoomsBuilder;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilder.RectangularRoomsBuilder
{
    public class RectangularRoomsBuilder : AbstractLayoutBuilder
    {
        //Delegates
        public delegate RectangleLayoutRoom RectangularRoomProviderMethod(DungeonRoom dngRoom);
        private RectangularRoomProviderMethod GetRoom;


        //Private fields

        private Random randGen;

        private Dictionary<DungeonRoom, RectangleLayoutRoom> layoutRooms = new Dictionary<DungeonRoom, RectangleLayoutRoom>();


        //BFS fields

        private DefaultDictionary<DungeonRoom, bool> visited = new DefaultDictionary<DungeonRoom, bool>(false);
        private Queue<DungeonRoom> bfsQueue = new Queue<DungeonRoom>();


        //Constructors

        public RectangularRoomsBuilder(Dungeon vagueDungeon, RectangularRoomProviderMethod GetRoom) : base(vagueDungeon)
        {
            this.GetRoom = GetRoom;

            //Set the RNG
            //TODO: Use the same seed that the dungeon was generated with
            randGen = new Random(12345);
        }


        //Required abstract methods

        protected override void BuildInternal()
        {
            //TODO: Build the dungeon.

            //Start the BFS
            RectangleLayoutRoom startRoom = CreateLayoutRoom(dungeon.startRoom);
            visited[dungeon.startRoom] = true;
            bfsQueue.Enqueue(dungeon.startRoom);

            //Use breadth first search to lay out every room.
            while (bfsQueue.Count > 0)
            {
                AdvanceBFS();
            }

            //TODO: Prevent colliding rooms
        }


        //Misc methods

        private void AdvanceBFS()
        {
            //Get the element
            DungeonRoom room = bfsQueue.Dequeue();
            RectangleLayoutRoom layoutRoom = layoutRooms[room];

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

                //Pick a random exit to put the new room at
                ExitDirection direction = PickExit(neighborLayout, layoutRoom);

                //If there was no available exit, put it as an excess room.  Else, attach it to the chosen exit.
                if (direction == ExitDirection.notAssigned)
                {
                    layoutRoom.AttachChildRoom(neighborLayout, direction);
                }
                else
                {
                    layoutRoom.AttachExcessChild(neighborLayout);
                }

                //Place the room physically next to it.
                PlaceRoom(neighborLayout, layoutRoom, direction);
            }
        }

        private ExitDirection PickExit(LayoutRoom child, RectangleLayoutRoom parent)
        {
            //Picks a random, valid, and available exit from parent.  If no such exit exists, returns ExitDirection.notAssigned
            
            if (parent.availableExitCount == 0)
            {
                return ExitDirection.notAssigned;
            }

            //Pick a random room from the list
            //TODO: Check if the exit is valid(IE: doesn't overlap other rooms)
            return parent.GetAvailableExit(randGen.Next(parent.availableExitCount));
        }

        private void PlaceRoom(RectangleLayoutRoom child, RectangleLayoutRoom parent, ExitDirection direction)
        {
            const double paddingDistance = 0.1;

            //Get the direciton vector
            Vector dir = ExitDirectionMethods.ExitVector(direction);

            //Get the distance to move it
            double dist = 0;
            if (direction == ExitDirection.left || direction == ExitDirection.right)
            {
                dist = parent.size.x + child.size.x;
            }
            else if (direction == ExitDirection.up || direction == ExitDirection.down)
            {
                dist = parent.size.y + child.size.y;
            }
            dist /= 2;
            dist += paddingDistance;

            //Put it in the right spot
            child.localPosition = dist * dir;
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
