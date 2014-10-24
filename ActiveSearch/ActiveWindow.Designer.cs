namespace ActiveSearch
{
    partial class ActiveWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.beginSearchButton = new System.Windows.Forms.Button();
            this.unloadVideoButton = new System.Windows.Forms.Button();
            this.resultDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(500, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select Advertisment Frame";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SelectAdvFrame_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(500, 60);
            this.button2.TabIndex = 2;
            this.button2.Text = "Select Video File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SelectVideo_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 170);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(240, 60);
            this.button3.TabIndex = 3;
            this.button3.Text = "Load video";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SplitFrames_Click);
            // 
            // beginSearchButton
            // 
            this.beginSearchButton.Location = new System.Drawing.Point(150, 240);
            this.beginSearchButton.Name = "beginSearchButton";
            this.beginSearchButton.Size = new System.Drawing.Size(500, 60);
            this.beginSearchButton.TabIndex = 4;
            this.beginSearchButton.Text = "Begin Search";
            this.beginSearchButton.UseVisualStyleBackColor = true;
            this.beginSearchButton.Click += new System.EventHandler(this.BeginSearch_Click);
            // 
            // unloadVideoButton
            // 
            this.unloadVideoButton.Location = new System.Drawing.Point(410, 170);
            this.unloadVideoButton.Name = "unloadVideoButton";
            this.unloadVideoButton.Size = new System.Drawing.Size(240, 60);
            this.unloadVideoButton.TabIndex = 5;
            this.unloadVideoButton.Text = "Unload video";
            this.unloadVideoButton.UseVisualStyleBackColor = true;
            this.unloadVideoButton.Click += new System.EventHandler(this.UnloadVideoFrames_Click);
            // 
            // resultDisplay
            // 
            this.resultDisplay.Enabled = false;
            this.resultDisplay.Location = new System.Drawing.Point(50, 310);
            this.resultDisplay.Multiline = true;
            this.resultDisplay.Name = "resultDisplay";
            this.resultDisplay.ReadOnly = true;
            this.resultDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultDisplay.Size = new System.Drawing.Size(700, 200);
            this.resultDisplay.TabIndex = 6;
            // 
            // ActiveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.resultDisplay);
            this.Controls.Add(this.unloadVideoButton);
            this.Controls.Add(this.beginSearchButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ActiveWindow";
            this.Text = "Active Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button beginSearchButton;
        private System.Windows.Forms.Button unloadVideoButton;
        private System.Windows.Forms.TextBox resultDisplay;
    }
}

