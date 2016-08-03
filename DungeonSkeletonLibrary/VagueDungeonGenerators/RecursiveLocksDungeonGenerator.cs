using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.VagueDungeons;

namespace DungeonSkeletonLibrary.VagueDungeonGenerators
{
    public class RecursiveLocksDungeonGenerator : AbstractDungeonGenerator
    {
        //Fields

        private RecursiveLocksGeneratorConfig config = new RecursiveLocksGeneratorConfig();

        private int keysToCreate;
        private int keysCreated = 0;


        //Constructors

        public RecursiveLocksDungeonGenerator(RecursiveLocksGeneratorConfig config = null)
        {
            //Set up the config.
            if (config != null)
            {
                this.config = config;
            }
        }


        //Misc methods

        protected override void GenerateInternal()
        {
            //Roll a number of keys
            keysToCreate = randGen.Next(config.minKeys, config.maxKeys);

            //Create a starting room
            dungeon.startRoom = dungeon.CreateRoom();
            DungeonRoom currentRoom = dungeon.startRoom;

            //Keep going as long as we haven't created enough keys
            while (keysCreated < keysToCreate)
            {
                //Generate a chain leading to a a branch.
                int chainLength = randGen.Next(config.minChainLength, config.maxChainLength);
                currentRoom = CreateChain(currentRoom, chainLength);

                //Generate a branch starting off the current room
                //Go through the locked door it creates.
                currentRoom = GenerateBranch(currentRoom, 0);
            }
        }

        private DungeonRoom GenerateBranch(DungeonRoom startingRoom, int recursionDepth)
        {
            //Generates a branch starting off the given room.
            //Returns the room behind the first locked door it creates.

            //Create a locked door with a room behind it.
            KeyData lockInfo = new KeyData(keysCreated);
            keysCreated++;

            DungeonRoom roomBehindLock = dungeon.CreateRoom();
            DungeonEdge lockedDoor = startingRoom.ConnectTo(roomBehindLock);

            lockedDoor.keysRequired.Add(lockInfo);

            //Create a chain leading up to the room before the key
            int chainLength = randGen.Next(config.minChainLength, config.maxChainLength) - 1;
            DungeonRoom roomBeforeKey = CreateChain(startingRoom, chainLength);

            //Try to go recursive
            if (    keysCreated < keysToCreate
                    && recursionDepth < config.maxRecursionDepth
                    && randGen.NextDouble() < config.recursionChance
               )
            {
                //Go recursive to create the key room.
                Console.WriteLine("Went recursive");
                DungeonRoom keyRoom = GenerateBranch(roomBeforeKey, recursionDepth + 1);
                keyRoom.keysContained.Add(lockInfo);
            }
            else
            {
                //Put the key in the keyroom
                DungeonRoom keyRoom = dungeon.CreateRoom();
                DungeonEdge keyRoomDoor = roomBeforeKey.ConnectTo(keyRoom);

                keyRoom.keysContained.Add(lockInfo);
            }

            return roomBehindLock;
        }

        private DungeonRoom CreateChain(DungeonRoom startingRoom, int length)
        {
            //Creates a chain of rooms connected to the starting room.
            //Returns the LAST room in the chain.

            DungeonRoom currentRoom = startingRoom;

            for (int i = 0; i < length; i++)
            {
                DungeonRoom newRoom = dungeon.CreateRoom();
                currentRoom.ConnectTo(newRoom);
                currentRoom = newRoom;
            }

            return currentRoom;
        }
    }

    public class RecursiveLocksGeneratorConfig
    {
        public int minKeys = 1;
        public int maxKeys = 5;

        public int minChainLength = 1;
        public int maxChainLength = 3;

        public int maxRecursionDepth = 2;
        public double recursionChance = 0.5;
    }
}
