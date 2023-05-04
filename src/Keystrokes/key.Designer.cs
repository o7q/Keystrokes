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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(key));
            this.keyLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.snapXTextbox = new System.Windows.Forms.TextBox();
            this.snapYTextbox = new System.Windows.Forms.TextBox();
            this.keyTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lockButton = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.controllerPanel = new System.Windows.Forms.Panel();
            this.controllerDebugLabel = new System.Windows.Forms.Label();
            this.controllerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.BackColor = System.Drawing.Color.Transparent;
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
            this.closeButton.Size = new System.Drawing.Size(26, 26);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // snapXTextbox
            // 
            this.snapXTextbox.BackColor = System.Drawing.Color.Black;
            this.snapXTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.snapXTextbox.ForeColor = System.Drawing.Color.White;
            this.snapXTextbox.Location = new System.Drawing.Point(26, 0);
            this.snapXTextbox.Name = "snapXTextbox";
            this.snapXTextbox.Size = new System.Drawing.Size(52, 13);
            this.snapXTextbox.TabIndex = 2;
            this.snapXTextbox.TextChanged += new System.EventHandler(this.snapXTextbox_TextChanged);
            // 
            // snapYTextbox
            // 
            this.snapYTextbox.BackColor = System.Drawing.Color.Black;
            this.snapYTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.snapYTextbox.ForeColor = System.Drawing.Color.White;
            this.snapYTextbox.Location = new System.Drawing.Point(26, 13);
            this.snapYTextbox.Name = "snapYTextbox";
            this.snapYTextbox.Size = new System.Drawing.Size(52, 13);
            this.snapYTextbox.TabIndex = 3;
            this.snapYTextbox.TextChanged += new System.EventHandler(this.snapYTextbox_TextChanged);
            // 
            // keyTooltip
            // 
            this.keyTooltip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.keyTooltip_Draw);
            // 
            // lockButton
            // 
            this.lockButton.BackColor = System.Drawing.Color.Gray;
            this.lockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lockButton.ForeColor = System.Drawing.Color.White;
            this.lockButton.Location = new System.Drawing.Point(0, 26);
            this.lockButton.Name = "lockButton";
            this.lockButton.Size = new System.Drawing.Size(26, 26);
            this.lockButton.TabIndex = 1;
            this.lockButton.Text = "🔒";
            this.lockButton.UseVisualStyleBackColor = false;
            this.lockButton.Click += new System.EventHandler(this.lockButton_Click);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.BackColor = System.Drawing.Color.Transparent;
            this.countLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.countLabel.Location = new System.Drawing.Point(1, 54);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(13, 13);
            this.countLabel.TabIndex = 0;
            this.countLabel.Text = "0";
            this.countLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.countLabel_MouseDown);
            // 
            // controllerPanel
            // 
            this.controllerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controllerPanel.Controls.Add(this.controllerDebugLabel);
            this.controllerPanel.Location = new System.Drawing.Point(63, -4);
            this.controllerPanel.Name = "controllerPanel";
            this.controllerPanel.Size = new System.Drawing.Size(43, 44);
            this.controllerPanel.TabIndex = 4;
            this.controllerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.controllerPanel_MouseDown);
            // 
            // controllerDebugLabel
            // 
            this.controllerDebugLabel.AutoSize = true;
            this.controllerDebugLabel.BackColor = System.Drawing.Color.Transparent;
            this.controllerDebugLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controllerDebugLabel.ForeColor = System.Drawing.Color.White;
            this.controllerDebugLabel.Location = new System.Drawing.Point(1, 27);
            this.controllerDebugLabel.Name = "controllerDebugLabel";
            this.controllerDebugLabel.Size = new System.Drawing.Size(14, 16);
            this.controllerDebugLabel.TabIndex = 0;
            this.controllerDebugLabel.Text = "θ";
            this.controllerDebugLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.controllerDebugLabel_MouseDown);
            // 
            // key
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.Controls.Add(this.controllerPanel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.lockButton);
            this.Controls.Add(this.snapYTextbox);
            this.Controls.Add(this.snapXTextbox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.keyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "key";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Key";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.key_FormClosing);
            this.Load += new System.EventHandler(this.key_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.key_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.key_MouseDown);
            this.controllerPanel.ResumeLayout(false);
            this.controllerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox snapXTextbox;
        private System.Windows.Forms.TextBox snapYTextbox;
        private System.Windows.Forms.ToolTip keyTooltip;
        private System.Windows.Forms.Button lockButton;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Panel controllerPanel;
        private System.Windows.Forms.Label controllerDebugLabel;
    }
}