namespace Keystrokes
{
    partial class key
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(key));
            this.keyLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyLabel.ForeColor = System.Drawing.Color.White;
            this.keyLabel.Location = new System.Drawing.Point(60, 61);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(40, 38);
            this.keyLabel.TabIndex = 0;
            this.keyLabel.Text = "A";
            this.keyLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyLabel_MouseDown);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Maroon;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.Red;
            this.closeButton.Location = new System.Drawing.Point(0, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 22);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // key
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.keyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "key";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "key";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.key_FormClosing);
            this.Load += new System.EventHandler(this.key_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.key_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.key_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Button closeButton;
    }
}