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
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(150, 240);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(500, 60);
            this.button4.TabIndex = 4;
            this.button4.Text = "Begin Search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.BeginSearch_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(410, 170);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(240, 60);
            this.button5.TabIndex = 5;
            this.button5.Text = "Unload video";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.UnloadVideoFrames_Click);
            // 
            // ActiveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ActiveWindow";
            this.Text = "Active Search";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

