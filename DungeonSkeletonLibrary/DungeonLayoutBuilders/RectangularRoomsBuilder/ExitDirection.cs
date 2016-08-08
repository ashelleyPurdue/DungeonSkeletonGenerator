using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DungeonSkeletonLibrary.Utils;

namespace DungeonSkeletonLibrary.DungeonLayoutBuilders.RectangularRoomsBuilder
{
    public enum ExitDirection
    {
        notAssigned = -1,
        left = 0,
        up = 1,
        right = 2,
        down = 3
    }

    public static class ExitDirectionMethods
    {
        private static readonly Vector[] exitDirections = { Vector.left, Vector.up, Vector.right, Vector.down };
        private static readonly ExitDirection[] oppositeExits = { ExitDirection.right, ExitDirection.down, ExitDirection.left, ExitDirection.up };

        public static Vector ExitVector(ExitDirection exit)
        {
            //Returns a vector pointing in the direction of the exit
            return exitDirections[(int)exit];
        }

        public static ExitDirection OppositeExit(ExitDirection exit)
        {
            //Returns the opposite exit of the given one.
            return oppositeExits[(int)exit];
        }
    }
}
