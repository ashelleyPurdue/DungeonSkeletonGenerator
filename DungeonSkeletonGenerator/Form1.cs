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
using DungeonSkeletonGenerator.Visualization;

namespace DungeonSkeletonGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Build a test graph
            VagueDungeonGraph graph = new VagueDungeonGraph();

            VagueDungeonNode a = graph.CreateRoom();
            graph.startRoom = a;

            VagueDungeonNode aa = graph.CreateRoom();
            a.ConnectTo(aa);

            VagueDungeonNode aaa = graph.CreateRoom();
            aaa.keysContained.Add(new KeyData(0));
            aa.ConnectTo(aaa);

            VagueDungeonNode ab = graph.CreateRoom();
            VagueDungeonEdge aTOab = a.ConnectTo(ab);
            aTOab.keysRequired.Add(new KeyData(0));

            //Visualize the test graph.
            new VagueDungeonViewer(graph).Show();
        }

        
    }
}
