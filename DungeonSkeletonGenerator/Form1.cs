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
using DungeonSkeletonGenerator.VagueDungeons.VagueDungeonExplorer;
using DungeonSkeletonGenerator.VagueDungeonGenerators;
using DungeonSkeletonGenerator.Visualization;

namespace DungeonSkeletonGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Create a test dungeon with the given seed.
            MaximumBacktrackingGenerator generator = new MaximumBacktrackingGenerator();
            generator.Generate();

            //Test the CanFindKey method
            int maxKeys = 5;
            Explorer explorer = new Explorer(generator.GetDungeon());
            for (int i = 0; i < maxKeys; i++)
            {
                //Print if we can find each key
                Console.WriteLine("" + i + ": " + DungeonSolver.CanGetKey(explorer, new KeyData(i)));
            }

            //Show the dungeon
            VagueDungeonViewer viewer = new VagueDungeonViewer(generator.GetDungeon());
            viewer.ShowDialog();
        }
    }
}
