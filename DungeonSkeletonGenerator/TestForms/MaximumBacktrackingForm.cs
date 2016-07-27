using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DungeonSkeletonGenerator.VagueDungeonGenerators;

namespace DungeonSkeletonGenerator.TestForms
{
    public partial class MaximumBacktrackingForm : Form
    {
        public MaximumBacktrackingForm()
        {
            InitializeComponent();

            generatorControl1.GetGenerator = GetGenerator;
        }

        private AbstractDungeonGenerator GetGenerator()
        {
            //Create the generator from this configuration

            MaximumBacktrackingConfig config = new MaximumBacktrackingConfig();

            config.minKeyCount = (int)minKeys.Value;
            config.maxKeyCount = (int)maxKeys.Value;
            config.minRoomCount = (int)minRooms.Value;

            return new MaximumBacktrackingGenerator(config);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
