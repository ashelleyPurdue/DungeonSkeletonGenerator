using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSkeletonGenerator.VagueDungeons
{
    public class VagueDungeonNode
    {
        //Fields
        public VagueDungeonGraph dungeon { get; private set; }
        public int roomID { get; private set; }

        public List<KeyData> keysContained = new List<KeyData>(); 

        protected List<VagueDungeonEdge> edges = new List<VagueDungeonEdge>();


        //Constructors
        //This constructor should only be called in VagueDungeonGraph.cs!!!
        internal VagueDungeonNode(VagueDungeonGraph dungeon, int id)
        {
            this.dungeon = dungeon;
            this.roomID = id;
        }


        //Methods

        public VagueDungeonEdge GetEdge(int i)
        {
            return edges[i];
        }

        public int GetEdgeCount()
        {
            return edges.Count;
        }

        public VagueDungeonEdge ConnectTo(VagueDungeonNode other, bool bidirectional = true)
        {
            //Creates an edge from this node to the other.
            //The edge is added to both nodes' edge list
            //Returns the created edge

            VagueDungeonEdge edge = new VagueDungeonEdge(this, other, bidirectional);
            this.edges.Add(edge);
            other.edges.Add(edge);
            dungeon.AddEdge(edge);

            return edge;
        }

        public void DisconnectEdge(VagueDungeonEdge edge)
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
        public readonly VagueDungeonNode node;
        public readonly VagueDungeonEdge edge;

        public EdgeNotFoundException(VagueDungeonNode node, VagueDungeonEdge edge)
        {
            this.node = node;
            this.edge = edge;
        }
    }
}
