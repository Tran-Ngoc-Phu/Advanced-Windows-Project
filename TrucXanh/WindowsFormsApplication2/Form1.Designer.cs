namespace WindowsFormsApplication2
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
            this.Score = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(268, 19);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(185, 46);
            this.Score.TabIndex = 0;
            this.Score.Text = "SCORE: ";
            // 
            // StartButton
            // 
            this.StartButton.Image = global::WindowsFormsApplication2.Properties.Resources.start_button;
            this.StartButton.Location = new System.Drawing.Point(33, 5);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(89, 92);
            this.StartButton.TabIndex = 1;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 489);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Score);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Button StartButton;


    }
}

