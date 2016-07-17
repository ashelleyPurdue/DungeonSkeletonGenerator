using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DungeonSkeletonGenerator.VagueDungeons;
using Microsoft.Msagl;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace DungeonSkeletonGenerator.Visualization
{
    public partial class VagueDungeonViewer : Form
    {
        public VagueDungeonViewer(VagueDungeonGraph dungeon)
        {
            InitializeComponent();
            this.Controls.Add(CreateViewer(dungeon));
        }

        private GViewer CreateViewer(VagueDungeonGraph dungeon)
        {
            Graph graph = new Graph("graph");
            GViewer viewer = new GViewer();

            //Add every node
            for (int i = 0; i < dungeon.roomCount; i++)
            {
                VagueDungeonNode room = dungeon.GetRoom(i);
                Node node = new Node("" + i);

                //List all keys in this room.
                if (room.keysContained.Count == 0)
                {
                    node.LabelText = "empty";
                }
                else
                {
                    StringBuilder text = new StringBuilder();
                    foreach (KeyData key in room.keysContained)
                    {
                        text.AppendLine(key.ToString());
                    }

                    node.LabelText = text.ToString();
                }

                //Add the node
                graph.AddNode(node);
            }

            //Add every edge
            for (int i = 0; i < dungeon.edgeCount; i++)
            {
                VagueDungeonEdge dngEdge = dungeon.GetEdge(i);
                Edge edge = graph.AddEdge("" + dngEdge.from.roomID, "" + dngEdge.to.roomID);

                //List all keys this edge requires
                if (dngEdge.keysRequired.Count != 0)
                {
                    StringBuilder text = new StringBuilder();
                    text.AppendLine("Lock requires: ");

                    foreach (KeyData key in dngEdge.keysRequired)
                    {
                        text.AppendLine(key.ToString());
                    }

                    edge.LabelText = text.ToString();
                }
            }

            //Return the viewer
            viewer.Graph = graph;
            return viewer;
        }
    }
}
