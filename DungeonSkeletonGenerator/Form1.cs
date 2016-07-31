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

using DungeonSkeletonGenerator.TestForms;

namespace DungeonSkeletonGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void maximumBacktrackingButton_Click(object sender, EventArgs e)
        {
            MaximumBacktrackingForm form = new MaximumBacktrackingForm();
            form.Show();
        }

        private void detourButton_Click(object sender, EventArgs e)
        {
            ShowForm<DetourForm>();
        }

        private void ShowForm<T>() where T : Form, new()
        {
            T form = new T();
            form.Show();
        }
    }
}
