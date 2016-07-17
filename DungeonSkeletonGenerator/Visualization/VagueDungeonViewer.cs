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
                graph.AddNode("" + i);
            }

            //Add every edge
            for (int i = 0; i < dungeon.edgeCount; i++)
            {
                VagueDungeonEdge edge = dungeon.GetEdge(i);
                graph.AddEdge("" + edge.from.roomID, "" + edge.to.roomID);
            }

            //Return the viewer
            viewer.Graph = graph;
            return viewer;
        }
    }
}
