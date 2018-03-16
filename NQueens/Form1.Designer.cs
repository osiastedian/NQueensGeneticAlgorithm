namespace NQueens
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.generateButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.movesListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sizeNumeric
            // 
            this.sizeNumeric.Location = new System.Drawing.Point(418, 12);
            this.sizeNumeric.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.sizeNumeric.Name = "sizeNumeric";
            this.sizeNumeric.Size = new System.Drawing.Size(120, 20);
            this.sizeNumeric.TabIndex = 1;
            this.sizeNumeric.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.sizeNumeric.ValueChanged += new System.EventHandler(this.SizeNumeric_ValueChanged);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(418, 38);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(120, 23);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(418, 67);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(120, 23);
            this.solveButton.TabIndex = 3;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // movesListBox
            // 
            this.movesListBox.FormattingEnabled = true;
            this.movesListBox.Location = new System.Drawing.Point(418, 96);
            this.movesListBox.Name = "movesListBox";
            this.movesListBox.Size = new System.Drawing.Size(120, 316);
            this.movesListBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 425);
            this.Controls.Add(this.movesListBox);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.sizeNumeric);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown sizeNumeric;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.ListBox movesListBox;
    }
}

