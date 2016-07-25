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
        private List<DungeonRoom> keyRooms = new List<DungeonRoom>();

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
            HideKeys();

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
            while (dungeon.roomCount < config.minRoomCount || leafRooms.Count < keysToCreate)
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

        private void HideKeys()
        {
            //Randomly hides keys in leaf rooms, locking them with another key

            //Make a copy of the leaf list so we can draw from it.
            List<DungeonRoom> leafPool = new List<DungeonRoom>();
            foreach (DungeonRoom room in leafRooms)
            {
                leafPool.Add(room);
            }

            //Hide all of the keys in random leaf rooms
            for (int i = 0; i < keysToCreate; i++)
            {
                //Choose a random leaf room
                int roomID = randGen.Next(0, leafPool.Count);
                DungeonRoom roomChosen = leafPool[roomID];

                leafPool.RemoveAt(roomID);
                keyRooms.Add(roomChosen);

                //Lock this room with the key before it.
                if (i != 0)
                {
                    DungeonEdge door = roomChosen.GetEdge(0);
                    door.keysRequired.Add(new KeyData(i - 1));

                    //TODO: Possibly lock one of the rooms before it instead?
                }

                //Put a key in this room, unless it's the final one.
                if (i + 1 < keysToCreate)
                {
                    roomChosen.keysContained.Add(new KeyData(i));
                }
                else
                {
                    //Make this the boss room.
                    dungeon.bossRoom = roomChosen;
                }
            }
            
        }

    }

    public class MaximumBacktrackingConfig
    {
        public int minKeyCount = 3;
        public int maxKeyCount = 3;

        public int minRoomCount = 10;
    }
}
