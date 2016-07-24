using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using DungeonSkeletonGenerator.Utils;
using DungeonSkeletonGenerator.VagueDungeons;

namespace DungeonSkeletonGenerator.VagueDungeons.VagueDungeonExplorer
{
    public partial class Explorer
    {
        public Dungeon dungeon { get; private set; }
        public DungeonRoom currentRoom { get; private set; }

        private DefaultDictionary<int, int> keyInventory = new DefaultDictionary<int, int>(0);

        private DefaultDictionary<DungeonEdge, bool> edgesUnlocked = new DefaultDictionary<DungeonEdge, bool>(false);
        private DefaultDictionary<DungeonRoom, bool> keysLooted = new DefaultDictionary<DungeonRoom, bool>(false);

        private Stack<AbstractCommand> undoStack = new Stack<AbstractCommand>();

        public Explorer(Dungeon dungeon)
        {
            this.dungeon = dungeon;
            currentRoom = dungeon.startRoom;
        }


        //Misc methods

        public void Undo()
        {
            //Undoes the last action, as if it never happened.

            if (undoStack.Count > 0)
            {
                undoStack.Pop().Undo();
            }
        }


        //Key/unlocking methods
        
        public bool EdgeUnlocked(DungeonEdge edge)
        {
            //Returns if the given edge has been unlocked.
            //If the edge was never locked in the first place, returns true.

            //Return true if the edge was never locked in the first place
            bool startedLocked = false;
            foreach (KeyData keyData in edge.keysRequired)
            {
                if (keyData.keyCount > 0)
                {
                    startedLocked = true;
                    break;
                }
            }

            if (!startedLocked)
            {
                return true;
            }

            //Return the contents of the unlock dictionary
            return edgesUnlocked[edge];
        }

        public bool HasEnoughKeys(DungeonEdge edge)
        {
            //Returns if we have enough keys to unlock the given edge.

            foreach (KeyData keyData in edge.keysRequired)
            {
                if (keyInventory[keyData.keyID] < keyData.keyCount)
                {
                    return false;
                }
            }

            return true;
        }

        public bool TryUnlock(DungeonEdge edge)
        {
            //Tries to unlock a door.
            //Returns true if successful or if already unlocked, false if otherwise.
            //Fails if not enough keys, or if already unlocked

            //If it's already unlocked, do nothing and return true.
            if (EdgeUnlocked(edge))
            {
                return true;
            }

            //If not enough keys, do nothing and return false.
            if (!HasEnoughKeys(edge))
            {
                return false;
            }

            //Remove the keys from the inventory
            foreach (KeyData keyData in edge.keysRequired)
            {
                keyInventory[keyData.keyID] -= keyData.keyCount;
            }

            //Mark it as unlocked
            edgesUnlocked[edge] = true;

            //Add to the undo history
            undoStack.Push(new UnlockEdgeCommand(edge, this));

            //Return successful
            return true;
        }

        public void LootKeys()
        {
            //Loots the keys in the current room.

            //Don't go on if already looted.
            if (keysLooted[currentRoom])
            {
                return;
            }

            //Loot the keys
            foreach (KeyData kd in currentRoom.keysContained)
            {
                keyInventory[kd.keyID] += kd.keyCount;
            }

            keysLooted[currentRoom] = true;

            //Save the undo history
            undoStack.Push(new LootKeysCommand(currentRoom, this));
        }


        //Edge/movement methods

        public List<DungeonEdge> UseableNeighboringEdges()
        {
            //Returns all of the neighboring edges that can be used.

            //Console.WriteLine("Getting usable edges on room " + currentRoom.roomID);

            List<DungeonEdge> edgeList = new List<DungeonEdge>();

            for (int i = 0; i < currentRoom.GetEdgeCount(); i++)
            {
                //Add it to the list if it's useable
                DungeonEdge edge = currentRoom.GetEdge(i);
                if (CanUseEdge(edge))
                {
                    edgeList.Add(edge);
                }

                //Console.WriteLine("" + i + " < " + currentRoom.GetEdgeCount());
            }

            return edgeList;
        }

        public void UseEdge(DungeonEdge edge)
        {
            //Throw an error if not usable
            if (!CanUseEdge(edge))
            {
                throw new CantUseEdgeException(edge, this);
            }

            //TODO: Add to room history

            //Add to undo history
            undoStack.Push(new UseEdgeCommand(currentRoom, this));

            //Use the edge
            if (currentRoom == edge.from)
            {
                currentRoom = edge.to;
            }
            else
            {
                currentRoom = edge.from;
            }
        }

        private bool CanUseEdge(DungeonEdge edge)
        {
            //Returns if the explorer can use the given neighboring edge.

            //Console.Write("Edge from " + edge.from.roomID + " to " + edge.to.roomID + " ");

            //Return false if the edge isn't a neighbor
            if (edge.from != currentRoom && edge.to != currentRoom)
            {
                //Console.WriteLine("isn't a neighbor");
                return false;
            }

            //Return false if the edge isn't bidirectional and we're not in the right spot
            if (!edge.bidirectional && currentRoom != edge.from)
            {
                //Console.WriteLine("is going the wrong way");
                return false;
            }

            //Return false if the edge is locked
            if (!EdgeUnlocked(edge))
            {
                //Console.WriteLine("is not unlocked");
                return false;
            }

            //Console.WriteLine("is usable");
            return true;
        }
    }

    public class CantUseEdgeException : Exception
    {
        public DungeonEdge edge;
        public Explorer explorer;

        public CantUseEdgeException(DungeonEdge edge, Explorer explorer)
        {
            this.edge = edge;
            this.explorer = explorer;
        }
    }
}
