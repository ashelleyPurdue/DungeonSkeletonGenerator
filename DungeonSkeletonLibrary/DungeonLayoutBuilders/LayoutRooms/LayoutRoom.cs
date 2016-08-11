using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.Utils;
using DungeonSkeletonLibrary.VagueDungeons;


namespace DungeonSkeletonLibrary.DungeonLayoutBuilder.LayoutRooms
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
                LayoutRoom oldParent = internalParent;
                internalParent = value;

                //Update the tree depth
                if (internalParent == null)
                {
                    treeDepth = 0;
                }
                else
                {
                    treeDepth = parent.treeDepth + 1;
                }

                //Set off the event.
                if (oldParent != null)
                {
                    oldParent.OnChildParentChanged(this, internalParent);
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


        //Constructors

        public LayoutRoom(DungeonRoom dungeonRoom)
        {
            this.dungeonRoom = dungeonRoom;
        }


        //Events

        protected virtual void OnChildParentChanged(LayoutRoom child, LayoutRoom newParent)
        {
            //Do nothing.  A subclass can implement this.
        }
    }
}
