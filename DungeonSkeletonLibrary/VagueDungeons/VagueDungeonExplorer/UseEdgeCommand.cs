﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonSkeletonLibrary.VagueDungeons.VagueDungeonExplorer
{
    public partial class Explorer
    {

        public class UseEdgeCommand : Explorer.AbstractCommand
        {
            private DungeonRoom previousNode;

            public UseEdgeCommand(DungeonRoom previousNode, Explorer parent) : base(parent)
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
