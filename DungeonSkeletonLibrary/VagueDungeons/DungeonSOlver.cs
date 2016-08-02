using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using DungeonSkeletonLibrary.Utils;
using DungeonSkeletonLibrary.VagueDungeons.VagueDungeonExplorer;

namespace DungeonSkeletonLibrary.VagueDungeons
{
    public class DungeonSolver
    {
        //Static methods
        public static bool CanReachRoom(Explorer explorer, DungeonRoom room)
        {
            //Returns if the explorer can reach the given room in its current state, without key-hunting or unlocking doors.

            DefaultDictionary<DungeonRoom, bool> visited = new DefaultDictionary<DungeonRoom, bool>(false);
            return DFSForRoom(explorer, room, visited);
        }

        public static bool CanGetKey(Explorer explorer, KeyData targetKey)
        {
            //Returns if the given explorer can obtain the given number of keys in its current state and then return
            //to the current room, without spending any keys.

            //Breadth-first-search to find all reachable keys of the given type.
            Queue<DungeonRoom> exploreQueue = new Queue<DungeonRoom>();
            exploreQueue.Enqueue(explorer.currentRoom);
            DefaultDictionary<DungeonRoom, bool> visited = new DefaultDictionary<DungeonRoom, bool>(false);

            List<DungeonRoom> keyRooms = new List<DungeonRoom>();

            do
            {
                //Visit the next room in the queue
                DungeonRoom room = exploreQueue.Dequeue();
                visited[room] = true;

                //If this room contains a compatible key, add it to the keyRooms list
                foreach (KeyData kd in room.keysContained)
                {
                    if (kd.keyID == targetKey.keyID)
                    {
                        keyRooms.Add(room);
                    }
                }

                //Add every neighboring, unvisited room to the exploreQueue
                List<DungeonEdge> neighbors = explorer.UseableNeighboringEdges(room);
                foreach (DungeonEdge edge in neighbors)
                {
                    //Get the target room
                    DungeonRoom roomToVisit = edge.to;
                    if (roomToVisit == room)
                    {
                        roomToVisit = edge.from;
                    }

                    //Add it to the explore queue if it's not already visited
                    if (!visited[roomToVisit])
                    {
                        exploreQueue.Enqueue(roomToVisit);
                    }
                }

            } while (exploreQueue.Count > 0);

            //Count up all of the keys we could find that have a path back to currentRoom
            int keysFound = 0;
            foreach (DungeonRoom keyRoom in keyRooms)
            {
                if (explorer.PathToRoom(keyRoom, explorer.currentRoom) != null)
                {
                    keysFound += keyRoom.GetKeyCount(targetKey.keyID);
                }
            }

            //Return if we found enough.
            return keysFound >= targetKey.keyCount;
        }

        private static bool DFSForRoom(Explorer explorer, DungeonRoom room, DefaultDictionary<DungeonRoom, bool> visited)
        {
            //Recursively searches all neighbors to find the room.

            //Console.WriteLine("Visiting room " + explorer.currentRoom.roomID);

            //If this is the room, we're done.  Return true.
            if (explorer.currentRoom == room)
            {
                return true;
            }

            //If we've already visited this room, return false.
            if (visited[explorer.currentRoom])
            {
                //Console.WriteLine("Already visited");
                return false;
            }
            visited[explorer.currentRoom] = true;
            //Console.WriteLine("visited[" + explorer.currentRoom.roomID + "] = " + visited[explorer.currentRoom]);

            //Search all neighbors
            List<DungeonEdge> usableEdges = explorer.UseableNeighboringEdges();
            //Console.WriteLine("" + usableEdges.Count + " usable edges");

            foreach (DungeonEdge edge in usableEdges)
            {
                //Use the edge
                explorer.UseEdge(edge);

                //Check if we've found the room
                bool foundRoom = DFSForRoom(explorer, room, visited);
                
                //Move back to the last room
                //Console.WriteLine("visited[" + explorer.currentRoom.roomID + "] = " + visited[explorer.currentRoom]);
                explorer.Undo();

                //If we've found the room, return true.
                if (foundRoom)
                {
                    return true;
                }
            }

            //We didn't find any in the neighbors, so we can't reach it from here.
            return false;
        }
    }
}
