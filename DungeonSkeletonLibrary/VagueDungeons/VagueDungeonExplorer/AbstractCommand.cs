using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonSkeletonLibrary.VagueDungeons.VagueDungeonExplorer
{
    public partial class Explorer
    {
        public abstract class AbstractCommand
        {
            protected Explorer parent;

            public AbstractCommand(Explorer parent)
            {
                this.parent = parent;
            }

            public abstract void Undo();
        }
    }
}
