using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.Utils;
using DungeonSkeletonLibrary.VagueDungeons;

//TODO:  Add a tree depth variable.

namespace DungeonSkeletonLibrary.DungeonLayoutBuilders
{
    public abstract class LayoutRoom
    {
        public readonly DungeonRoom dungeonRoom;

        public int treeDepth
        {
            get; private set;
        }

        public LayoutRoom parent
        {
            get { return internalParent; }

            set
            {
                //Set the parent
                internalParent = value;

                //Update the tree depth
                if (parent == null)
                {
                    treeDepth = 0;
                }
                else
                {
                    treeDepth = parent.treeDepth + 1;
                }
            }
        }
        private LayoutRoom internalParent = null;

        public Vector localPosition = Vector.zero;
        public Vector position
        {
            get
            {
                if (parent == null)
                {
                    return localPosition;
                }
                else
                {
                    return parent.position + localPosition;
                }
            }
        }

        public LayoutRoom(DungeonRoom dungeonRoom)
        {
            this.dungeonRoom = dungeonRoom;
        }
    }
}
