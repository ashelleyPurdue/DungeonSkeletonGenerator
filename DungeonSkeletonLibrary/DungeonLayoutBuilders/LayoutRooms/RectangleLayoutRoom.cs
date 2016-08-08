using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.Utils;
using DungeonSkeletonLibrary.VagueDungeons;

using DungeonSkeletonLibrary.DungeonLayoutBuilders.RectangularRoomsBuilder;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilder.LayoutRooms
{
    public class RectangleLayoutRoom : LayoutRoom
    {
        public Vector size;

        public int excessEdgeCount      { get { return excessEdges.Count; } }
        public int availableExitCount   { get { return availableExits.Count; } }

        private DefaultDictionary<ExitDirection, LayoutRoom> directionalExits = new DefaultDictionary<ExitDirection, LayoutRoom>(null);
        private List<LayoutRoom> excessEdges = new List<LayoutRoom>();

        private List<ExitDirection> availableExits = new List<ExitDirection>();


        //Constructors

        public RectangleLayoutRoom(DungeonRoom dungeonRoom, Vector size) : base(dungeonRoom)
        {
            this.size = size;
        }


        //Interface

        public void AttachChildRoom(LayoutRoom childRoom, ExitDirection exit)
        {
            //Attaches the given room at the given exit.
            //Sets childRoom's parent to this.
            //Throws an error if the exit is already taken

            if (directionalExits[exit] != null)
            {
                throw new Exception("Exit already in use");
            }

            //Add it to the dictionary and remove it from the list
            directionalExits[exit] = childRoom;
            availableExits.Remove(exit);

            //Set the child's parent
            childRoom.parent = this;
        }

        public void AttachExcessChild(LayoutRoom childRoom)
        {
            //Attaches the child as an excess edge.
            //Sets the child's parent to this

            excessEdges.Add(childRoom);
            childRoom.parent = this;
        }

        public LayoutRoom GetExit(ExitDirection dir)
        {
            return directionalExits[dir];
        }

        public LayoutRoom GetExcessExit(int i)
        {
            return excessEdges[i];
        }

        public ExitDirection GetParentExit()
        {
            //Returns the ExitDirection pointing to the parent, or ExitDirection.notAssigned if parent is null.
            //Throws an error if the parent isn't in any of the directional exits.

            if (parent == null)
            {
                return ExitDirection.notAssigned;
            }

            //Search for it.
            ExitDirection[] dirs = { ExitDirection.left, ExitDirection.right, ExitDirection.up, ExitDirection.down };
            for (int i = 0; i < dirs.Length; i++)
            {
                if (directionalExits[dirs[i]] == parent)
                {
                    return dirs[i];
                }
            }

            //It wasn't found, throw an error.
            throw new Exception("Parent not in one of the four directional exits.");
        }

        public ExitDirection GetAvailableExit(int i)
        {
            //Returns the ith available exit.
            return availableExits[i];
        }


        //Events

        protected override void OnChildParentChanged(LayoutRoom child, LayoutRoom newParent)
        {
            //Remove the child from the exits.

            //If the parent was changed to the exact same thing, then nevermind.
            if (newParent == this)
            {
                return;
            }

            //Remove from excessEdges, if it's in there
            if (excessEdges.Contains(child))
            {
                excessEdges.Remove(child);
                return;
            }

            //Remove from directionalExits
            ExitDirection[] dirs = { ExitDirection.left, ExitDirection.right, ExitDirection.up, ExitDirection.down };
            foreach (ExitDirection exit in dirs)
            {
                if (directionalExits[exit] == child)
                {
                    //Remove the child if it matches
                    directionalExits[exit] = null;

                    //Add it to the list of available exits
                    availableExits.Add(exit);
                    availableExits.Sort();
                }
            }

            //We didn't find it in any of the exits, so throw an error.
            throw new Exception("Removed child was not in any of the exits, or in the excessEdges list.");
        }

    }
}
