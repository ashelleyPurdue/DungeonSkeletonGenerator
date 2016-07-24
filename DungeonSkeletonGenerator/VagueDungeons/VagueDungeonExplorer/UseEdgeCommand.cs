﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons.VagueDungeonExplorer
{
    public partial class Explorer
    {

        public class UseEdgeCommand : Explorer.AbstractCommand
        {
            private VagueDungeonNode previousNode;

            public UseEdgeCommand(VagueDungeonNode previousNode, Explorer parent) : base(parent)
            {
                this.previousNode = previousNode;
            }

            public override void Undo()
            {
                parent.currentRoom = previousNode;
            }
        }

    }
}
