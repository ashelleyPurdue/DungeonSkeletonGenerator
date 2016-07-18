using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonSkeletonGenerator.VagueDungeons;

namespace DungeonSkeletonGenerator.VagueDungeonGenerators
{
    public class RecursiveLocksDungeonGenerator : AbstractVagueDungeonGenerator
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
            int keysToCreate = randGen.Next(config.minKeys, config.maxKeys);

            //Create a starting room
            dungeon.startRoom = dungeon.CreateRoom();
            VagueDungeonNode currentRoom = dungeon.startRoom;

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

        private VagueDungeonNode GenerateBranch(VagueDungeonNode startingRoom, int recursionDepth)
        {
            //Generates a branch starting off the given room.
            //Returns the room behind the first locked door it creates.

            //Create a locked door with a room behind it.
            KeyData lockInfo = new KeyData(keysCreated);
            keysCreated++;

            VagueDungeonNode roomBehindLock = dungeon.CreateRoom();
            VagueDungeonEdge lockedDoor = startingRoom.ConnectTo(roomBehindLock);

            lockedDoor.keysRequired.Add(lockInfo);

            //Create a chain leading up to the room before the key
            int chainLength = randGen.Next(config.minChainLength, config.maxChainLength) - 1;
            VagueDungeonNode roomBeforeKey = CreateChain(startingRoom, chainLength);

            //Put the key in the keyroom
            VagueDungeonNode keyRoom = dungeon.CreateRoom();
            VagueDungeonEdge keyRoomDoor = roomBeforeKey.ConnectTo(keyRoom);

            keyRoom.keysContained.Add(lockInfo);

            //Try to go recursive
            if (    keysCreated < keysToCreate
                    && recursionDepth < config.maxRecursionDepth
                    && randGen.NextDouble() < config.recursionChance
               )
            {
                //TODO: Go recursive
            }

            return roomBehindLock;
        }

        private VagueDungeonNode CreateChain(VagueDungeonNode startingRoom, int length)
        {
            //Creates a chain of rooms connected to the starting room.
            //Returns the LAST room in the chain.

            VagueDungeonNode currentRoom = startingRoom;

            for (int i = 0; i < length; i++)
            {
                VagueDungeonNode newRoom = dungeon.CreateRoom();
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
