using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using DungeonSkeletonGenerator.Utils;
using DungeonSkeletonGenerator.VagueDungeons.VagueDungeonExplorer;

namespace DungeonSkeletonGenerator.VagueDungeons
{
    public class VagueDungeonSolver
    {
        //Static methods
        public static bool CanReachRoom(Explorer explorer, VagueDungeonNode room)
        {
            //Returns if the explorer can reach the given room in its current state, without key-hunting or unlocking doors.

            DefaultDictionary<VagueDungeonNode, bool> visited = new DefaultDictionary<VagueDungeonNode, bool>(false);
            return DFSForRoom(explorer, room, visited);
        }

        private static bool DFSForRoom(Explorer explorer, VagueDungeonNode room, DefaultDictionary<VagueDungeonNode, bool> visited)
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
            List<VagueDungeonEdge> usableEdges = explorer.UseableNeighboringEdges();
            //Console.WriteLine("" + usableEdges.Count + " usable edges");

            foreach (VagueDungeonEdge edge in usableEdges)
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
