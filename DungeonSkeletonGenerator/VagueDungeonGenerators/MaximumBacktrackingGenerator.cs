using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonSkeletonGenerator.VagueDungeons;

namespace DungeonSkeletonGenerator.VagueDungeonGenerators
{
    public class MaximumBacktrackingGenerator : AbstractDungeonGenerator
    {
        private MaximumBacktrackingConfig config;
        private int keysToCreate;

        private List<DungeonRoom> leafRooms = new List<DungeonRoom>();

        public MaximumBacktrackingGenerator(MaximumBacktrackingGenerator config = null)
        {
            if (config == null)
            {
                this.config = new MaximumBacktrackingConfig();
            }
        }

        protected override void GenerateInternal()
        {
            //Roll the number of keys to create
            keysToCreate = randGen.Next(config.minKeyCount, config.maxKeyCount);

            //Create a random tree
            CreateRandomTree();

            //TODO: Hide keys in it

            //TODO: Create shortcuts
        }

        private void CreateRandomTree()
        {
            //Creates a randomly-generated tree of rooms.

            DungeonRoom root = dungeon.CreateRoom();
            dungeon.startRoom = root;
            leafRooms.Add(root);

            //Keep randomly adding leaves until we reach the minimum room count AND
            //there are enough leaf rooms for all of the keys
            while (dungeon.roomCount < config.minRoomCount && leafRooms.Count < keysToCreate)
            {
                //Choose a random room from the dungeon
                int roomID = randGen.Next(0, dungeon.roomCount);
                DungeonRoom chosenRoom = dungeon.GetRoom(roomID);

                //Remove this room from the leaf list, since we're about to give it a child
                if (leafRooms.Contains(chosenRoom))
                {
                    leafRooms.Remove(chosenRoom);
                }

                //Add a new room as a leaf/child
                DungeonRoom newLeaf = dungeon.CreateRoom();
                chosenRoom.ConnectTo(newLeaf);

                leafRooms.Add(newLeaf);
            } 
        }
    }

    public class MaximumBacktrackingConfig
    {
        public int minKeyCount = 3;
        public int maxKeyCount = 5;

        public int minRoomCount = 10;
    }
}
