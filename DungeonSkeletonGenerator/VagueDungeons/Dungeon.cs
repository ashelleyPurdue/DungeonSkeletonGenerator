using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons
{
    public class Dungeon
    {
        //Fields

        public DungeonRoom startRoom;
        public DungeonRoom bossRoom;

        public int roomCount { get { return rooms.Count; } }
        private List<DungeonRoom> rooms = new List<DungeonRoom>();

        public int edgeCount { get { return edges.Count; } }
        private List<DungeonEdge> edges = new List<DungeonEdge>();


        //Methods

        public DungeonRoom GetRoom(int i)
        {
            return rooms[i];
        }

        public DungeonEdge GetEdge(int i)
        {
            return edges[i];
        }

        public DungeonRoom CreateRoom()
        {
            //Creates a room and returns it.

            DungeonRoom room = new DungeonRoom(this, roomCount);
            rooms.Add(room);

            return room;
        }


        //Internal methods -- DO NOT USE THESE OUTSIDE OF THE VagueDungeons FOLDER!!!

        internal void AddEdge(DungeonEdge edge)
        {
            edges.Add(edge);
        }

        internal void RemoveEdge(DungeonEdge edge)
        {
            edges.Remove(edge);
        }
    }
}
