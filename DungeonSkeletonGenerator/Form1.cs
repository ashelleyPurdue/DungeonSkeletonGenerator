﻿using System;
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

            VagueDungeonViewer viewer = new VagueDungeonViewer(generator.GetDungeon());
            viewer.Show();

            //Generate a report on all rooms that are reachable without key-hunting.
            /*Explorer explorer = new Explorer(generator.GetDungeon());
            for (int i = 0; i < generator.GetDungeon().roomCount; i++)
            {
                Console.WriteLine("Room " + i + " reachable: " + DungeonSolver.CanReachRoom(explorer, generator.GetDungeon().GetRoom(i)));
            }*/

        }
    }
}
