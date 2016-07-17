using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons
{
    public class VagueDungeonGraph
    {
        //Fields

        public VagueDungeonNode startRoom;
        public VagueDungeonNode bossRoom;

        public int roomCount { get { return rooms.Count; } }
        private List<VagueDungeonNode> rooms = new List<VagueDungeonNode>();

        public int edgeCount { get { return edges.Count; } }
        private List<VagueDungeonEdge> edges = new List<VagueDungeonEdge>();


        //Methods

        public VagueDungeonNode GetRoom(int i)
        {
            return rooms[i];
        }

        public VagueDungeonEdge GetEdge(int i)
        {
            return edges[i];
        }

        public VagueDungeonNode CreateRoom()
        {
            //Creates a room and returns it.

            VagueDungeonNode room = new VagueDungeonNode(this, roomCount);
            rooms.Add(room);

            return room;
        }


        //Internal methods -- DO NOT USE THESE OUTSIDE OF THE VagueDungeons FOLDER!!!

        internal void AddEdge(VagueDungeonEdge edge)
        {
            edges.Add(edge);
        }

        internal void RemoveEdge(VagueDungeonEdge edge)
        {
            edges.Remove(edge);
        }
    }
}
