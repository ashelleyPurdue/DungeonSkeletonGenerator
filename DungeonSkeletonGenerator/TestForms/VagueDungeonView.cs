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

namespace DungeonSkeletonGenerator.TestForms
{
    public partial class VagueDungeonView : Form
    {

        public VagueDungeonView()
        {
            InitializeComponent();

            //Create the test dungeon
            graph = new VagueDungeonGraph();
            graph.startRoom = graph.CreateRoom();

            VagueDungeonNode a = graph.CreateRoom();
            graph.startRoom.ConnectTo(a);

            VagueDungeonNode b = graph.CreateRoom();
            graph.startRoom.ConnectTo(b);

            VagueDungeonNode aa = graph.CreateRoom();
            a.ConnectTo(aa);

            VagueDungeonNode ab = graph.CreateRoom();
            a.ConnectTo(ab);
        }

        public void UpdateView(VagueDungeonGraph graph)
        {
            flowLayoutPanel1.Controls.Clear();
            //CURRENT TASK: Displaying it.
        }
    }
}
