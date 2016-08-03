using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonSkeletonLibrary.VagueDungeons.VagueDungeonExplorer
{
    public partial class Explorer
    {
        public class LootKeysCommand : AbstractCommand
        {
            private DungeonRoom room;

            public LootKeysCommand(DungeonRoom room, Explorer parent) : base(parent)
            {
                this.room = room;
            }

            public override void Undo()
            {
                //Return all of the keys to the room.
                foreach (KeyData kd in room.keysContained)
                {
                    parent.keyInventory[kd.keyID] -= kd.keyCount;
                }

                //Mark as not looted
                parent.keysLooted[room] = false;
            }
        }
    }
}
