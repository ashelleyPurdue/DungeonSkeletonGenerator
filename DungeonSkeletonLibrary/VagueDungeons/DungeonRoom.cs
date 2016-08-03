using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonSkeletonLibrary.VagueDungeons
{
    public class DungeonRoom
    {
        //Fields
        public Dungeon dungeon { get; private set; }
        public int roomID { get; private set; }

        public List<KeyData> keysContained = new List<KeyData>(); 

        protected List<DungeonEdge> edges = new List<DungeonEdge>();


        //Constructors
        //This constructor should only be called in VagueDungeonGraph.cs!!!
        internal DungeonRoom(Dungeon dungeon, int id)
        {
            this.dungeon = dungeon;
            this.roomID = id;
        }


        //Methods

        public int GetKeyCount(int keyID)
        {
            //Returns the keycount of the given key

            foreach (KeyData kd in keysContained)
            {
                if (kd.keyID == keyID)
                {
                    return kd.keyCount;
                }
            }

            return 0;
        }

        public DungeonEdge GetEdge(int i)
        {
            return edges[i];
        }

        public int GetEdgeCount()
        {
            return edges.Count;
        }

        public DungeonEdge ConnectTo(DungeonRoom other, bool bidirectional = true)
        {
            //Creates an edge from this node to the other.
            //The edge is added to both nodes' edge list
            //Returns the created edge

            DungeonEdge edge = new DungeonEdge(this, other, bidirectional);
            this.edges.Add(edge);
            other.edges.Add(edge);
            dungeon.AddEdge(edge);

            return edge;
        }

        public void DisconnectEdge(DungeonEdge edge)
        {
            //Removes the given edge from both nodes' edge lists, if it exists.

            //Throw an error if the edge does not contain this node
            if (edge.from != this && edge.to != this)
            {
                throw new EdgeNotFoundException(this, edge);
            }

            //Throw an error if either of the edge lists don't contain the edge
            if (!edge.from.edges.Contains(edge))
            {
                throw new EdgeNotFoundException(edge.from, edge);
            }
            if (!edge.to.edges.Contains(edge))
            {
                throw new EdgeNotFoundException(edge.to, edge);
            }

            //Remove the edge from both nodes and the dungeon
            edge.from.edges.Remove(edge);
            edge.to.edges.Remove(edge);
            dungeon.RemoveEdge(edge);
        }
    }

    class EdgeNotFoundException : Exception
    {
        public readonly DungeonRoom node;
        public readonly DungeonEdge edge;

        public EdgeNotFoundException(DungeonRoom node, DungeonEdge edge)
        {
            this.node = node;
            this.edge = edge;
        }
    }
}
