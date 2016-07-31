namespace DungeonSkeletonGenerator.TestForms
{
    partial class DetourForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.minChain = new System.Windows.Forms.NumericUpDown();
            this.maxKeys = new System.Windows.Forms.NumericUpDown();
            this.minKeys = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.generatorControl1 = new DungeonSkeletonGenerator.TestForms.GeneratorControl();
            this.label4 = new System.Windows.Forms.Label();
            this.maxChain = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minChain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChain)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum Keys";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.maxChain, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.minChain, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.maxKeys, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.minKeys, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99875F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99875F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99875F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00375F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 122);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // minChain
            // 
            this.minChain.Location = new System.Drawing.Point(132, 63);
            this.minChain.Name = "minChain";
            this.minChain.Size = new System.Drawing.Size(120, 20);
            this.minChain.TabIndex = 5;
            // 
            // maxKeys
            // 
            this.maxKeys.Location = new System.Drawing.Point(132, 33);
            this.maxKeys.Name = "maxKeys";
            this.maxKeys.Size = new System.Drawing.Size(120, 20);
            this.maxKeys.TabIndex = 4;
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
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum Keys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Minimum Chain Length";
            // 
            // generatorControl1
            // 
            this.generatorControl1.Location = new System.Drawing.Point(122, 266);
            this.generatorControl1.Name = "generatorControl1";
            this.generatorControl1.Size = new System.Drawing.Size(150, 94);
            this.generatorControl1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maximum Chain Length";
            // 
            // maxChain
            // 
            this.maxChain.Location = new System.Drawing.Point(132, 93);
            this.maxChain.Name = "maxChain";
            this.maxChain.Size = new System.Drawing.Size(120, 20);
            this.maxChain.TabIndex = 6;
            // 
            // DetourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 372);
            this.Controls.Add(this.generatorControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DetourForm";
            this.Text = "DetourForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minChain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown minChain;
        private System.Windows.Forms.NumericUpDown maxKeys;
        private System.Windows.Forms.NumericUpDown minKeys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private GeneratorControl generatorControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown maxChain;
    }
}