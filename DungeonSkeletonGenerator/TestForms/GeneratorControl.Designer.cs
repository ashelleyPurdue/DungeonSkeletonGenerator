namespace DungeonSkeletonGenerator.TestForms
{
    partial class GeneratorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.seedCheckbox = new System.Windows.Forms.CheckBox();
            this.seedTextbox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // seedCheckbox
            // 
            this.seedCheckbox.AutoSize = true;
            this.seedCheckbox.Location = new System.Drawing.Point(4, 4);
            this.seedCheckbox.Name = "seedCheckbox";
            this.seedCheckbox.Size = new System.Drawing.Size(77, 17);
            this.seedCheckbox.TabIndex = 0;
            this.seedCheckbox.Text = "Use seed?";
            this.seedCheckbox.UseVisualStyleBackColor = true;
            this.seedCheckbox.CheckedChanged += new System.EventHandler(this.seedCheckbox_CheckedChanged);
            // 
            // seedTextbox
            // 
            this.seedTextbox.Enabled = false;
            this.seedTextbox.Location = new System.Drawing.Point(4, 27);
            this.seedTextbox.Name = "seedTextbox";
            this.seedTextbox.Size = new System.Drawing.Size(100, 20);
            this.seedTextbox.TabIndex = 1;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(4, 55);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // GeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.seedTextbox);
            this.Controls.Add(this.seedCheckbox);
            this.Name = "GeneratorControl";
            this.Size = new System.Drawing.Size(150, 94);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox seedCheckbox;
        private System.Windows.Forms.TextBox seedTextbox;
        private System.Windows.Forms.Button generateButton;
    }
}
