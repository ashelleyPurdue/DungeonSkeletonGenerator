using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.VagueDungeons;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilders
{
    public class AbstractLayoutBuilder
    {
        public readonly Dungeon vagueDungeon;
        public bool doneBuilding { get; private set; }

        private DungeonLayout layout = new DungeonLayout();

        public AbstractLayoutBuilder(Dungeon vagueDungeon)
        {
            this.vagueDungeon = vagueDungeon;
            doneBuilding = false;
        }

        public void Build()
        {
            //TODO: build the dungeon
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
    }
}
