using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonSkeletonGenerator.VagueDungeons;

namespace DungeonSkeletonGenerator.VagueDungeonGenerators
{
    public abstract class AbstractVagueDungeonGenerator
    {
        public bool generated { get; protected set; } = false;

        protected VagueDungeonGraph dungeon = new VagueDungeonGraph();
        protected Random randGen;

        public VagueDungeonGraph GetDungeon()
        {
            //Returns the completed dungeon if generated, or null if not finished.

            if (generated)
            {
                return dungeon;
            }
            else
            {
                return null;
            }
        }

        public void Generate()
        {
            GenerateInternal();
            generated = true;
        }

        protected abstract void GenerateInternal();

    }
}
