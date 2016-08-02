using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DungeonSkeletonLibrary.VagueDungeonGenerators;
using DungeonSkeletonGenerator.Visualization;

namespace DungeonSkeletonGenerator.TestForms
{
    public partial class GeneratorControl : UserControl
    {
        public delegate AbstractDungeonGenerator GetGeneratorMethod();
        public GetGeneratorMethod GetGenerator;

        public GeneratorControl()
        {
            InitializeComponent();
        }

        private void seedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            seedTextbox.Enabled = seedCheckbox.Checked;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            //Get the generator
            AbstractDungeonGenerator generator = GetGenerator();

            //Check if we should use a seed
            if (seedCheckbox.Checked)
            {
                //TODO: If it's all numbers, parse as an int instead.
                generator.Generate(seedTextbox.Text.GetHashCode());
            }
            else
            {
                generator.Generate();
            }

            //Show the dungeon
            VagueDungeonViewer viewer = new VagueDungeonViewer(generator.GetDungeon());
            viewer.Show();
        }
    }
}
