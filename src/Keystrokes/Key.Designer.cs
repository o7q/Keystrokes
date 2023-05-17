namespace Keystrokes
{
    partial class Key
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Key));
            this.KeyLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SnapXTextbox = new System.Windows.Forms.TextBox();
            this.SnapYTextbox = new System.Windows.Forms.TextBox();
            this.KeyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.LockButton = new System.Windows.Forms.Button();
            this.ControllerPanel = new System.Windows.Forms.Panel();
            this.ControllerDebugLabel = new System.Windows.Forms.Label();
            this.StatsButton = new System.Windows.Forms.Button();
            this.CpsLabel = new System.Windows.Forms.Label();
            this.ControllerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.BackColor = System.Drawing.Color.Transparent;
            this.KeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyLabel.ForeColor = System.Drawing.Color.White;
            this.KeyLabel.Location = new System.Drawing.Point(60, 61);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(40, 38);
            this.KeyLabel.TabIndex = 0;
            this.KeyLabel.Text = "A";
            this.KeyLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KeyLabel_MouseDown);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Maroon;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.Red;
            this.CloseButton.Location = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(20, 20);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SnapXTextbox
            // 
            this.SnapXTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.SnapXTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SnapXTextbox.ForeColor = System.Drawing.Color.White;
            this.SnapXTextbox.Location = new System.Drawing.Point(20, 0);
            this.SnapXTextbox.Name = "SnapXTextbox";
            this.SnapXTextbox.Size = new System.Drawing.Size(43, 13);
            this.SnapXTextbox.TabIndex = 3;
            this.SnapXTextbox.TextChanged += new System.EventHandler(this.SnapXTextbox_TextChanged);
            // 
            // SnapYTextbox
            // 
            this.SnapYTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.SnapYTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SnapYTextbox.ForeColor = System.Drawing.Color.White;
            this.SnapYTextbox.Location = new System.Drawing.Point(20, 13);
            this.SnapYTextbox.Name = "SnapYTextbox";
            this.SnapYTextbox.Size = new System.Drawing.Size(43, 13);
            this.SnapYTextbox.TabIndex = 4;
            this.SnapYTextbox.TextChanged += new System.EventHandler(this.SnapYTextbox_TextChanged);
            // 
            // KeyToolTip
            // 
            this.KeyToolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.KeyTooltip_Draw);
            // 
            // LockButton
            // 
            this.LockButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.LockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LockButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(150)))));
            this.LockButton.Location = new System.Drawing.Point(0, 20);
            this.LockButton.Name = "LockButton";
            this.LockButton.Size = new System.Drawing.Size(20, 20);
            this.LockButton.TabIndex = 1;
            this.LockButton.Text = "🔒";
            this.LockButton.UseVisualStyleBackColor = false;
            this.LockButton.Click += new System.EventHandler(this.LockButton_Click);
            // 
            // ControllerPanel
            // 
            this.ControllerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ControllerPanel.Controls.Add(this.ControllerDebugLabel);
            this.ControllerPanel.Location = new System.Drawing.Point(63, -4);
            this.ControllerPanel.Name = "ControllerPanel";
            this.ControllerPanel.Size = new System.Drawing.Size(43, 44);
            this.ControllerPanel.TabIndex = 0;
            this.ControllerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControllerPanel_MouseDown);
            // 
            // ControllerDebugLabel
            // 
            this.ControllerDebugLabel.AutoSize = true;
            this.ControllerDebugLabel.BackColor = System.Drawing.Color.Transparent;
            this.ControllerDebugLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerDebugLabel.ForeColor = System.Drawing.Color.White;
            this.ControllerDebugLabel.Location = new System.Drawing.Point(1, 27);
            this.ControllerDebugLabel.Name = "ControllerDebugLabel";
            this.ControllerDebugLabel.Size = new System.Drawing.Size(14, 16);
            this.ControllerDebugLabel.TabIndex = 0;
            this.ControllerDebugLabel.Text = "θ";
            this.ControllerDebugLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControllerDebugLabel_MouseDown);
            // 
            // StatsButton
            // 
            this.StatsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.StatsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(250)))), ((int)(((byte)(150)))));
            this.StatsButton.Location = new System.Drawing.Point(0, 40);
            this.StatsButton.Name = "StatsButton";
            this.StatsButton.Size = new System.Drawing.Size(20, 20);
            this.StatsButton.TabIndex = 2;
            this.StatsButton.Text = "📚";
            this.StatsButton.UseVisualStyleBackColor = false;
            this.StatsButton.Click += new System.EventHandler(this.StatsButton_Click);
            // 
            // CpsLabel
            // 
            this.CpsLabel.AutoSize = true;
            this.CpsLabel.BackColor = System.Drawing.Color.Transparent;
            this.CpsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CpsLabel.ForeColor = System.Drawing.Color.White;
            this.CpsLabel.Location = new System.Drawing.Point(0, 87);
            this.CpsLabel.Name = "CpsLabel";
            this.CpsLabel.Size = new System.Drawing.Size(13, 13);
            this.CpsLabel.TabIndex = 0;
            this.CpsLabel.Text = "0";
            this.CpsLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CpsLabel_MouseDown);
            // 
            // Key
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.Controls.Add(this.CpsLabel);
            this.Controls.Add(this.StatsButton);
            this.Controls.Add(this.ControllerPanel);
            this.Controls.Add(this.LockButton);
            this.Controls.Add(this.SnapYTextbox);
            this.Controls.Add(this.SnapXTextbox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.KeyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Key";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Key";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Key_FormClosing);
            this.Load += new System.EventHandler(this.Key_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Key_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Key_MouseDown);
            this.ControllerPanel.ResumeLayout(false);
            this.ControllerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox SnapXTextbox;
        private System.Windows.Forms.TextBox SnapYTextbox;
        private System.Windows.Forms.ToolTip KeyToolTip;
        private System.Windows.Forms.Button LockButton;
        private System.Windows.Forms.Panel ControllerPanel;
        private System.Windows.Forms.Label ControllerDebugLabel;
        private System.Windows.Forms.Button StatsButton;
        private System.Windows.Forms.Label CpsLabel;
    }
}