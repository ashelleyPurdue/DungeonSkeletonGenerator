using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.VagueDungeons;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilders
{
    public abstract class AbstractLayoutBuilder
    {
        public readonly Dungeon dungeon;
        public bool doneBuilding { get; private set; }

        protected DungeonLayout layout = new DungeonLayout();

        public AbstractLayoutBuilder(Dungeon vagueDungeon)
        {
            this.dungeon = vagueDungeon;
            doneBuilding = false;
        }

        public void Build()
        {
            //Build the dungeon
            doneBuilding = false;
            BuildInternal();
            doneBuilding = true;
        }

        public DungeonLayout GetLayout()
        {
            //Return the built layout.  If it's not done, return null.

            if (!doneBuilding)
            {
                return null;
            }

            return layout;
        }

        protected abstract void BuildInternal();
    }
}
