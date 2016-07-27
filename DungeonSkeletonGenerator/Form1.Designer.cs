namespace DungeonSkeletonGenerator
{
    partial class Form1
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.detourButton = new System.Windows.Forms.Button();
            this.recursiveButton = new System.Windows.Forms.Button();
            this.maximumBacktrackingButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose an algorithm";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.detourButton);
            this.flowLayoutPanel1.Controls.Add(this.recursiveButton);
            this.flowLayoutPanel1.Controls.Add(this.maximumBacktrackingButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 30);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(166, 183);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // detourButton
            // 
            this.detourButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detourButton.Location = new System.Drawing.Point(3, 3);
            this.detourButton.Name = "detourButton";
            this.detourButton.Size = new System.Drawing.Size(130, 23);
            this.detourButton.TabIndex = 0;
            this.detourButton.Text = "Detour";
            this.detourButton.UseVisualStyleBackColor = true;
            // 
            // recursiveButton
            // 
            this.recursiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recursiveButton.Location = new System.Drawing.Point(3, 32);
            this.recursiveButton.Name = "recursiveButton";
            this.recursiveButton.Size = new System.Drawing.Size(130, 23);
            this.recursiveButton.TabIndex = 1;
            this.recursiveButton.Text = "Recursive Locks";
            this.recursiveButton.UseVisualStyleBackColor = true;
            // 
            // maximumBacktrackingButton
            // 
            this.maximumBacktrackingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumBacktrackingButton.Location = new System.Drawing.Point(3, 61);
            this.maximumBacktrackingButton.Name = "maximumBacktrackingButton";
            this.maximumBacktrackingButton.Size = new System.Drawing.Size(130, 23);
            this.maximumBacktrackingButton.TabIndex = 2;
            this.maximumBacktrackingButton.Text = "Maximum Backtracking";
            this.maximumBacktrackingButton.UseVisualStyleBackColor = true;
            this.maximumBacktrackingButton.Click += new System.EventHandler(this.maximumBacktrackingButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button detourButton;
        private System.Windows.Forms.Button recursiveButton;
        private System.Windows.Forms.Button maximumBacktrackingButton;
    }
}

