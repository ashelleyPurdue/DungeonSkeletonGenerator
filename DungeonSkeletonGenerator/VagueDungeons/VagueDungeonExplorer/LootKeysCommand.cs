using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons.VagueDungeonExplorer
{
    public partial class VagueDungeonExplorer
    {
        public class LootKeysCommand : AbstractCommand
        {
            private VagueDungeonNode room;

            public LootKeysCommand(VagueDungeonNode room, VagueDungeonExplorer parent) : base(parent)
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
