namespace DungeonSkeletonGenerator.TestForms
{
    partial class MaximumBacktrackingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.minRooms = new System.Windows.Forms.NumericUpDown();
            this.maxKeys = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.minKeys = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.generatorControl1 = new DungeonSkeletonGenerator.TestForms.GeneratorControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.minRooms, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.maxKeys, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.minKeys, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 122);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // minRooms
            // 
            this.minRooms.Location = new System.Drawing.Point(132, 83);
            this.minRooms.Name = "minRooms";
            this.minRooms.Size = new System.Drawing.Size(120, 20);
            this.minRooms.TabIndex = 5;
            // 
            // maxKeys
            // 
            this.maxKeys.Location = new System.Drawing.Point(132, 43);
            this.maxKeys.Name = "maxKeys";
            this.maxKeys.Size = new System.Drawing.Size(120, 20);
            this.maxKeys.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum Keys";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // minKeys
            // 
            this.minKeys.Location = new System.Drawing.Point(132, 3);
            this.minKeys.Name = "minKeys";
            this.minKeys.Size = new System.Drawing.Size(120, 20);
            this.minKeys.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum Keys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Minimum Room Count";
            // 
            // generatorControl1
            // 
            this.generatorControl1.Location = new System.Drawing.Point(145, 140);
            this.generatorControl1.Name = "generatorControl1";
            this.generatorControl1.Size = new System.Drawing.Size(127, 144);
            this.generatorControl1.TabIndex = 1;
            // 
            // MaximumBacktrackingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 283);
            this.Controls.Add(this.generatorControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MaximumBacktrackingForm";
            this.Text = "MaximumBacktrackingForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minKeys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown minKeys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minRooms;
        private System.Windows.Forms.NumericUpDown maxKeys;
        private GeneratorControl generatorControl1;
    }
}