using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons.VagueDungeonExplorer
{
    public partial class VagueDungeonExplorer
    {
        public abstract class AbstractCommand
        {
            private VagueDungeonExplorer parent;

            public AbstractCommand(VagueDungeonExplorer parent)
            {
                this.parent = parent;
            }

            public abstract void Undo();
        }
    }
}
