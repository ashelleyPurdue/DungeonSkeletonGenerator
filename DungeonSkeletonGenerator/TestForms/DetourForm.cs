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
    public partial class DetourForm : Form
    {
        public DetourForm()
        {
            InitializeComponent();
            generatorControl1.GetGenerator = GetGenerator;
        }

        public AbstractDungeonGenerator GetGenerator()
        {
            DetourDungeonConfig config = new DetourDungeonConfig();

            config.minLocks = (int)minKeys.Value;
            config.maxLocks = (int)maxKeys.Value;
            config.minChainLength = (int)minChain.Value;
            config.maxChainLength = (int)maxChain.Value;

            DetourDungeonGenerator generator = new DetourDungeonGenerator(config);

            return generator;
        }
    }
}
