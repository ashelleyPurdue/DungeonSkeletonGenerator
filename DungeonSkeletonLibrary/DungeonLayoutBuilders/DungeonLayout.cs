using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.DungeonLayoutBuilder.LayoutRooms;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilder
{
    public class DungeonLayout
    {
        //Store things related to the dungeon layout

        public LayoutRoom this[int i]
        {
            get { return rooms[i]; }
        }

        public int roomCount { get { return rooms.Count; } }

        private List<LayoutRoom> rooms = new List<LayoutRoom>();


        public void AddRoom(LayoutRoom room)
        {
            if (!rooms.Contains(room))
            {
                rooms.Add(room);
            }
        }
    }
}
