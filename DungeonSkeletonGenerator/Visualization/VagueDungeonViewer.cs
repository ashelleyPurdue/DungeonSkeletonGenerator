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
        public VagueDungeonViewer(Dungeon dungeon)
        {
            InitializeComponent();
            this.Controls.Add(CreateViewer(dungeon));
        }

        private GViewer CreateViewer(Dungeon dungeon)
        {
            Graph graph = new Graph("graph");
            GViewer viewer = new GViewer();

            //Add every node
            for (int i = 0; i < dungeon.roomCount; i++)
            {
                DungeonRoom room = dungeon.GetRoom(i);
                StringBuilder text = new StringBuilder();
                Node node = new Node("" + i);

                //Add the room id
                text.AppendLine("Room " + room.roomID);

                //List all keys in this room.
                if (room.keysContained.Count == 0)
                {
                    text.AppendLine("empty");
                }
                else
                {
                    foreach (KeyData key in room.keysContained)
                    {
                        text.AppendLine(key.ToString());
                    }
                }

                //Add the node
                node.LabelText = text.ToString();
                graph.AddNode(node);
            }

            //Add every edge
            for (int i = 0; i < dungeon.edgeCount; i++)
            {
                DungeonEdge dngEdge = dungeon.GetEdge(i);
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

                //Change the shape of the edge if it's bidirectional
                if (dngEdge.bidirectional)
                {
                    edge.Attr.ArrowheadAtSource = ArrowStyle.Normal;
                    edge.Attr.ArrowheadAtTarget = ArrowStyle.Normal;
                }

                //Change the color based on the type of edge.
                if (dngEdge.type == EdgeType.shortcut)
                {
                    edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                }

                //If the edge is locked, make it red.
                if (dngEdge.requiresKeys)
                {
                    edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                }
            }

            //Return the viewer
            viewer.Graph = graph;
            return viewer;
        }
    }
}
