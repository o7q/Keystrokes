namespace Keystrokes
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.AddKeyButton = new System.Windows.Forms.Button();
            this.PresetListbox = new System.Windows.Forms.ListBox();
            this.TitlebarPanel = new System.Windows.Forms.Panel();
            this.BannerPicture = new System.Windows.Forms.PictureBox();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.CreditLabel = new System.Windows.Forms.Label();
            this.presetsLabel = new System.Windows.Forms.Label();
            this.Credit2Label = new System.Windows.Forms.Label();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OpenPresetsButton = new System.Windows.Forms.Button();
            this.RefreshPresetsButton = new System.Windows.Forms.Button();
            this.ClearKeysButton = new System.Windows.Forms.Button();
            this.DeletePresetButton = new System.Windows.Forms.Button();
            this.LoadPresetButton = new System.Windows.Forms.Button();
            this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnloadKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TitlebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerPicture)).BeginInit();
            this.MainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddKeyButton
            // 
            this.AddKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddKeyButton.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.AddKeyButton.Location = new System.Drawing.Point(104, 177);
            this.AddKeyButton.Name = "AddKeyButton";
            this.AddKeyButton.Size = new System.Drawing.Size(110, 30);
            this.AddKeyButton.TabIndex = 8;
            this.AddKeyButton.Text = "Open Editor";
            this.AddKeyButton.UseVisualStyleBackColor = true;
            this.AddKeyButton.Click += new System.EventHandler(this.AddKeyButton_Click);
            // 
            // PresetListbox
            // 
            this.PresetListbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.PresetListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PresetListbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PresetListbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PresetListbox.FormattingEnabled = true;
            this.PresetListbox.ItemHeight = 20;
            this.PresetListbox.Location = new System.Drawing.Point(14, 37);
            this.PresetListbox.Name = "PresetListbox";
            this.PresetListbox.Size = new System.Drawing.Size(200, 140);
            this.PresetListbox.TabIndex = 2;
            // 
            // TitlebarPanel
            // 
            this.TitlebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TitlebarPanel.Controls.Add(this.BannerPicture);
            this.TitlebarPanel.Controls.Add(this.MinimizeButton);
            this.TitlebarPanel.Controls.Add(this.CloseButton);
            this.TitlebarPanel.Location = new System.Drawing.Point(-3, -3);
            this.TitlebarPanel.Name = "TitlebarPanel";
            this.TitlebarPanel.Size = new System.Drawing.Size(236, 28);
            this.TitlebarPanel.TabIndex = 0;
            this.TitlebarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlebarPanel_MouseDown);
            // 
            // BannerPicture
            // 
            this.BannerPicture.Image = global::Keystrokes.Properties.Resources.program_banner;
            this.BannerPicture.Location = new System.Drawing.Point(2, 16);
            this.BannerPicture.Name = "BannerPicture";
            this.BannerPicture.Size = new System.Drawing.Size(155, 17);
            this.BannerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BannerPicture.TabIndex = 0;
            this.BannerPicture.TabStop = false;
            this.BannerPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BannerPicture_MouseDown);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.MinimizeButton.Location = new System.Drawing.Point(183, 3);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(25, 25);
            this.MinimizeButton.TabIndex = 0;
            this.MinimizeButton.Text = "_";
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CloseButton.Location = new System.Drawing.Point(208, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 25);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CreditLabel
            // 
            this.CreditLabel.AutoSize = true;
            this.CreditLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CreditLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CreditLabel.Location = new System.Drawing.Point(14, 164);
            this.CreditLabel.Name = "CreditLabel";
            this.CreditLabel.Size = new System.Drawing.Size(98, 12);
            this.CreditLabel.TabIndex = 0;
            this.CreditLabel.Text = "Keystrokes v0.0.0";
            // 
            // presetsLabel
            // 
            this.presetsLabel.AutoSize = true;
            this.presetsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.presetsLabel.Location = new System.Drawing.Point(159, 235);
            this.presetsLabel.Name = "presetsLabel";
            this.presetsLabel.Size = new System.Drawing.Size(70, 20);
            this.presetsLabel.TabIndex = 0;
            this.presetsLabel.Text = "Presets";
            // 
            // Credit2Label
            // 
            this.Credit2Label.AutoSize = true;
            this.Credit2Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Credit2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Credit2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Credit2Label.Location = new System.Drawing.Point(110, 164);
            this.Credit2Label.Name = "Credit2Label";
            this.Credit2Label.Size = new System.Drawing.Size(32, 12);
            this.Credit2Label.TabIndex = 0;
            this.Credit2Label.Text = "by o7q";
            // 
            // MainToolTip
            // 
            this.MainToolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.MainTooltip_Draw);
            // 
            // OpenPresetsButton
            // 
            this.OpenPresetsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.OpenPresetsButton.BackgroundImage = global::Keystrokes.Properties.Resources.open_icon;
            this.OpenPresetsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenPresetsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenPresetsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.OpenPresetsButton.Location = new System.Drawing.Point(189, 152);
            this.OpenPresetsButton.Name = "OpenPresetsButton";
            this.OpenPresetsButton.Size = new System.Drawing.Size(25, 25);
            this.OpenPresetsButton.TabIndex = 4;
            this.OpenPresetsButton.UseVisualStyleBackColor = false;
            this.OpenPresetsButton.Click += new System.EventHandler(this.OpenPresetsButton_Click);
            // 
            // RefreshPresetsButton
            // 
            this.RefreshPresetsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RefreshPresetsButton.BackgroundImage = global::Keystrokes.Properties.Resources.refresh_button;
            this.RefreshPresetsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshPresetsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshPresetsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.RefreshPresetsButton.Location = new System.Drawing.Point(164, 152);
            this.RefreshPresetsButton.Name = "RefreshPresetsButton";
            this.RefreshPresetsButton.Size = new System.Drawing.Size(25, 25);
            this.RefreshPresetsButton.TabIndex = 3;
            this.RefreshPresetsButton.UseVisualStyleBackColor = false;
            this.RefreshPresetsButton.Click += new System.EventHandler(this.RefreshPresetsButton_Click);
            // 
            // ClearKeysButton
            // 
            this.ClearKeysButton.BackgroundImage = global::Keystrokes.Properties.Resources.unload_button;
            this.ClearKeysButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClearKeysButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearKeysButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.ClearKeysButton.Location = new System.Drawing.Point(44, 177);
            this.ClearKeysButton.Name = "ClearKeysButton";
            this.ClearKeysButton.Size = new System.Drawing.Size(30, 30);
            this.ClearKeysButton.TabIndex = 6;
            this.ClearKeysButton.UseVisualStyleBackColor = true;
            this.ClearKeysButton.Click += new System.EventHandler(this.ClearKeysButton_Click);
            // 
            // DeletePresetButton
            // 
            this.DeletePresetButton.BackgroundImage = global::Keystrokes.Properties.Resources.close_button;
            this.DeletePresetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeletePresetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeletePresetButton.ForeColor = System.Drawing.Color.Tomato;
            this.DeletePresetButton.Location = new System.Drawing.Point(74, 177);
            this.DeletePresetButton.Name = "DeletePresetButton";
            this.DeletePresetButton.Size = new System.Drawing.Size(30, 30);
            this.DeletePresetButton.TabIndex = 7;
            this.DeletePresetButton.UseVisualStyleBackColor = true;
            this.DeletePresetButton.Click += new System.EventHandler(this.DeletePresetButton_Click);
            // 
            // LoadPresetButton
            // 
            this.LoadPresetButton.BackgroundImage = global::Keystrokes.Properties.Resources.load_button;
            this.LoadPresetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoadPresetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadPresetButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.LoadPresetButton.Location = new System.Drawing.Point(14, 177);
            this.LoadPresetButton.Name = "LoadPresetButton";
            this.LoadPresetButton.Size = new System.Drawing.Size(30, 30);
            this.LoadPresetButton.TabIndex = 5;
            this.LoadPresetButton.UseVisualStyleBackColor = true;
            this.LoadPresetButton.Click += new System.EventHandler(this.LoadPresetButton_Click);
            // 
            // MainNotifyIcon
            // 
            this.MainNotifyIcon.BalloonTipText = "Keystrokes";
            this.MainNotifyIcon.BalloonTipTitle = "Keystrokes";
            this.MainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MainNotifyIcon.Icon")));
            this.MainNotifyIcon.Text = "Keystrokes";
            this.MainNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainNotifyIcon_MouseClick);
            // 
            // MainContextMenuStrip
            // 
            this.MainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowToolStripMenuItem,
            this.UnloadKeysToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.MainContextMenuStrip.Name = "MainContextMenuStrip";
            this.MainContextMenuStrip.Size = new System.Drawing.Size(181, 92);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ShowToolStripMenuItem
            // 
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            this.ShowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ShowToolStripMenuItem.Text = "Show";
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // UnloadKeysToolStripMenuItem
            // 
            this.UnloadKeysToolStripMenuItem.Name = "UnloadKeysToolStripMenuItem";
            this.UnloadKeysToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.UnloadKeysToolStripMenuItem.Text = "Unload Keys";
            this.UnloadKeysToolStripMenuItem.Click += new System.EventHandler(this.UnloadKeysToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(230, 222);
            this.Controls.Add(this.OpenPresetsButton);
            this.Controls.Add(this.Credit2Label);
            this.Controls.Add(this.presetsLabel);
            this.Controls.Add(this.CreditLabel);
            this.Controls.Add(this.TitlebarPanel);
            this.Controls.Add(this.RefreshPresetsButton);
            this.Controls.Add(this.ClearKeysButton);
            this.Controls.Add(this.DeletePresetButton);
            this.Controls.Add(this.LoadPresetButton);
            this.Controls.Add(this.PresetListbox);
            this.Controls.Add(this.AddKeyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Keystrokes";
            this.Load += new System.EventHandler(this.Main_Load);
            this.TitlebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BannerPicture)).EndInit();
            this.MainContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddKeyButton;
        private System.Windows.Forms.ListBox PresetListbox;
        private System.Windows.Forms.Button LoadPresetButton;
        private System.Windows.Forms.Button DeletePresetButton;
        private System.Windows.Forms.Button ClearKeysButton;
        private System.Windows.Forms.Button RefreshPresetsButton;
        private System.Windows.Forms.Panel TitlebarPanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label CreditLabel;
        private System.Windows.Forms.Label presetsLabel;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Label Credit2Label;
        private System.Windows.Forms.PictureBox BannerPicture;
        private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.Button OpenPresetsButton;
        private System.Windows.Forms.NotifyIcon MainNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip MainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnloadKeysToolStripMenuItem;
    }
}

