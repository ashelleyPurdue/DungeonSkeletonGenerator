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
using DungeonSkeletonGenerator.VagueDungeonGenerators;
using DungeonSkeletonGenerator.Visualization;

namespace DungeonSkeletonGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Test the detour generator
            DetourDungeonGenerator generator = new DetourDungeonGenerator();
            generator.Generate();

            VagueDungeonViewer viewer = new VagueDungeonViewer(generator.GetDungeon());
            viewer.Show();
        }

        
    }
}
