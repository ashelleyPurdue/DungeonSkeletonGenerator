using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.Utils;

namespace DungeonSkeletonLibrary.VagueDungeons.VagueDungeonModifiers
{
    public static class EdgeCapper
    {
        public static void CapEdges(Dungeon dungeon, int maxEdgesPerRoom)
        {
            //Makes sure there is a limit to the number of edges in each room.
            //If there are too many, it creates another room containing the excess.

            DefaultDictionary<DungeonRoom, bool> visited = new DefaultDictionary<DungeonRoom, bool>(false);
            Visit(dungeon.startRoom, maxEdgesPerRoom, visited);
        }

        private static void Visit(DungeonRoom room, int maxEdgesPerRoom, DefaultDictionary<DungeonRoom, bool> visited)
        {
            //Visits the room and ensures there aren't too many edges

            //Visit the room
            visited[room] = true;
            LimitEdges(room, maxEdgesPerRoom);

            //Visit all neighbors
            for (int i = 0; i < room.GetEdgeCount(); i++)
            {
                DungeonEdge edge = room.GetEdge(i);

                //Find out which one is the neighbor
                DungeonRoom neighbor = edge.to;
                if (edge.from != room)
                {
                    neighbor = edge.from;
                }

                //Visit the neighbor
                if (!visited[neighbor])
                {
                    Visit(neighbor, maxEdgesPerRoom, visited);
                }
            }
        }

        private static void LimitEdges(DungeonRoom room, int maxEdgesPerRoom)
        {
            //Don't go on if the edge count is fine.
            if (room.GetEdgeCount() < maxEdgesPerRoom)
            {
                return;
            }

            //Get a list of all excess edges.
            List<DungeonEdge> excessEdges = new List<DungeonEdge>();
            for (int i = 0; i < room.GetEdgeCount(); i++)
            {
                //Skip this edge if it's under the limit.
                //We take one more edge so we can attach a new room.
                if (i < maxEdgesPerRoom - 1)
                {
                    continue;
                }
                excessEdges.Add(room.GetEdge(i));
            }

            //Create a new room to contain the excess edges
            DungeonRoom excessRoom = room.dungeon.CreateRoom();
            room.ConnectTo(excessRoom);

            //Move all extra edges to the new room.
            foreach (DungeonEdge edge in excessEdges)
            {
                //Determine which way the new edge should go
                DungeonRoom newFrom = null;
                DungeonRoom newTo = null;

                if (edge.from == room)
                {
                    newFrom = excessRoom;
                    newTo = edge.to;
                }
                else if (edge.to == room)
                {
                    newFrom = edge.from;
                    newTo = edge.to;
                }

                //Duplicate the edge
                DungeonEdge duplicateEdge = newFrom.ConnectTo(newTo, edge.type);
                duplicateEdge.keysRequired = edge.keysRequired;

                //Remove the original edge
                room.DisconnectEdge(edge);
            }

            //Recursively call on the excess room
            LimitEdges(excessRoom, maxEdgesPerRoom);
        }
    }
}
