﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.VagueDungeons;

namespace DungeonSkeletonLibrary.VagueDungeonGenerators
{
    public class DetourDungeonGenerator : AbstractDungeonGenerator
    {

        //Fields

        private int locksToCreate;
        private int locksCreated = 0;

        private DetourDungeonConfig config;
        private DungeonRoom currentRoom;


        //Constructors

        public DetourDungeonGenerator()
        {
            config = new DetourDungeonConfig();
        }

        public DetourDungeonGenerator(DetourDungeonConfig config)
        {
            this.config = config;
        }


        //Misc methods

        protected override void GenerateInternal()
        {
            //Generates the dungeon.

            //Roll the number of locks to create
            locksToCreate = randGen.Next(config.minLocks, config.maxLocks);

            //Create a starting room
            dungeon.startRoom = dungeon.CreateRoom();
            currentRoom = dungeon.startRoom;

            //Create all of the locks and their detours
            for (locksCreated = 0; locksCreated < locksToCreate; locksCreated++)
            {
                //Create a chain leading up to the lock
                int chainLength = randGen.Next(config.minChainLength, config.maxChainLength);
                GenerateChain(chainLength);

                //Put a locked door in this room
                DungeonRoom lockRoom = currentRoom;
                DungeonRoom roomBehindLock = dungeon.CreateRoom();

                DungeonEdge lockedDoor = lockRoom.ConnectTo(roomBehindLock);
                lockedDoor.keysRequired.Add(new KeyData(locksCreated));

                //Create a chain leading up to the key
                chainLength = randGen.Next(config.minChainLength, config.maxChainLength);
                GenerateChain(chainLength);

                currentRoom.keysContained.Add(new KeyData(locksCreated));

                //Rewind to the lock room and go through the locked door.
                currentRoom = roomBehindLock;
            }

            //Put the boss room right here.  This is the end of the dungeon.
            dungeon.bossRoom = currentRoom;
        }

        private void GenerateChain(int chainLength)
        {
            //Generates a chain of rooms of given length, branching off of the current room

            for (int i = 0; i < chainLength; i++)
            {
                //Create the room.
                DungeonRoom newRoom = dungeon.CreateRoom();

                //Link it to the previous room.
                currentRoom.ConnectTo(newRoom);

                //Move to the newly created room
                currentRoom = newRoom;
            }
        }

    }

    public class DetourDungeonConfig
    {
        public int minLocks = 1;
        public int maxLocks = 10;

        public int minChainLength = 1;
        public int maxChainLength = 3;
    }
}
