namespace Keystrokes
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.addKeyButton = new System.Windows.Forms.Button();
            this.presetListbox = new System.Windows.Forms.ListBox();
            this.titlebarPanel = new System.Windows.Forms.Panel();
            this.bannerPicture = new System.Windows.Forms.PictureBox();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.creditLabel = new System.Windows.Forms.Label();
            this.presetsLabel = new System.Windows.Forms.Label();
            this.credit2Label = new System.Windows.Forms.Label();
            this.refreshPresetsButton = new System.Windows.Forms.Button();
            this.clearKeysButton = new System.Windows.Forms.Button();
            this.deletePresetButton = new System.Windows.Forms.Button();
            this.loadPresetButton = new System.Windows.Forms.Button();
            this.mainTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.titlebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // addKeyButton
            // 
            this.addKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addKeyButton.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.addKeyButton.Location = new System.Drawing.Point(104, 177);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(110, 30);
            this.addKeyButton.TabIndex = 7;
            this.addKeyButton.Text = "Open Editor";
            this.addKeyButton.UseVisualStyleBackColor = true;
            this.addKeyButton.Click += new System.EventHandler(this.addKeyButton_Click);
            // 
            // presetListbox
            // 
            this.presetListbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.presetListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.presetListbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetListbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.presetListbox.FormattingEnabled = true;
            this.presetListbox.ItemHeight = 20;
            this.presetListbox.Location = new System.Drawing.Point(14, 37);
            this.presetListbox.Name = "presetListbox";
            this.presetListbox.Size = new System.Drawing.Size(200, 140);
            this.presetListbox.TabIndex = 2;
            // 
            // titlebarPanel
            // 
            this.titlebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.titlebarPanel.Controls.Add(this.bannerPicture);
            this.titlebarPanel.Controls.Add(this.minimizeButton);
            this.titlebarPanel.Controls.Add(this.closeButton);
            this.titlebarPanel.Location = new System.Drawing.Point(-3, -3);
            this.titlebarPanel.Name = "titlebarPanel";
            this.titlebarPanel.Size = new System.Drawing.Size(236, 28);
            this.titlebarPanel.TabIndex = 0;
            this.titlebarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebarPanel_MouseDown);
            // 
            // bannerPicture
            // 
            this.bannerPicture.Image = global::Keystrokes.Properties.Resources.program_banner;
            this.bannerPicture.Location = new System.Drawing.Point(2, 16);
            this.bannerPicture.Name = "bannerPicture";
            this.bannerPicture.Size = new System.Drawing.Size(155, 17);
            this.bannerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bannerPicture.TabIndex = 0;
            this.bannerPicture.TabStop = false;
            this.bannerPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bannerPicture_MouseDown);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.minimizeButton.Location = new System.Drawing.Point(183, 3);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(25, 25);
            this.minimizeButton.TabIndex = 0;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.closeButton.Location = new System.Drawing.Point(208, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 25);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // creditLabel
            // 
            this.creditLabel.AutoSize = true;
            this.creditLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.creditLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.creditLabel.Location = new System.Drawing.Point(14, 164);
            this.creditLabel.Name = "creditLabel";
            this.creditLabel.Size = new System.Drawing.Size(98, 12);
            this.creditLabel.TabIndex = 0;
            this.creditLabel.Text = "Keystrokes v0.0.0";
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
            // credit2Label
            // 
            this.credit2Label.AutoSize = true;
            this.credit2Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.credit2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credit2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.credit2Label.Location = new System.Drawing.Point(110, 164);
            this.credit2Label.Name = "credit2Label";
            this.credit2Label.Size = new System.Drawing.Size(32, 12);
            this.credit2Label.TabIndex = 0;
            this.credit2Label.Text = "by o7q";
            // 
            // refreshPresetsButton
            // 
            this.refreshPresetsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.refreshPresetsButton.BackgroundImage = global::Keystrokes.Properties.Resources.refresh_button;
            this.refreshPresetsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshPresetsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshPresetsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(90)))));
            this.refreshPresetsButton.Location = new System.Drawing.Point(189, 152);
            this.refreshPresetsButton.Name = "refreshPresetsButton";
            this.refreshPresetsButton.Size = new System.Drawing.Size(25, 25);
            this.refreshPresetsButton.TabIndex = 3;
            this.refreshPresetsButton.UseVisualStyleBackColor = false;
            this.refreshPresetsButton.Click += new System.EventHandler(this.refreshPresetsButton_Click);
            // 
            // clearKeysButton
            // 
            this.clearKeysButton.BackgroundImage = global::Keystrokes.Properties.Resources.unload_button;
            this.clearKeysButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearKeysButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearKeysButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.clearKeysButton.Location = new System.Drawing.Point(44, 177);
            this.clearKeysButton.Name = "clearKeysButton";
            this.clearKeysButton.Size = new System.Drawing.Size(30, 30);
            this.clearKeysButton.TabIndex = 5;
            this.clearKeysButton.UseVisualStyleBackColor = true;
            this.clearKeysButton.Click += new System.EventHandler(this.clearKeysButton_Click);
            // 
            // deletePresetButton
            // 
            this.deletePresetButton.BackgroundImage = global::Keystrokes.Properties.Resources.close_button;
            this.deletePresetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deletePresetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletePresetButton.ForeColor = System.Drawing.Color.Tomato;
            this.deletePresetButton.Location = new System.Drawing.Point(74, 177);
            this.deletePresetButton.Name = "deletePresetButton";
            this.deletePresetButton.Size = new System.Drawing.Size(30, 30);
            this.deletePresetButton.TabIndex = 6;
            this.deletePresetButton.UseVisualStyleBackColor = true;
            this.deletePresetButton.Click += new System.EventHandler(this.deletePresetButton_Click);
            // 
            // loadPresetButton
            // 
            this.loadPresetButton.BackgroundImage = global::Keystrokes.Properties.Resources.load_button;
            this.loadPresetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadPresetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadPresetButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.loadPresetButton.Location = new System.Drawing.Point(14, 177);
            this.loadPresetButton.Name = "loadPresetButton";
            this.loadPresetButton.Size = new System.Drawing.Size(30, 30);
            this.loadPresetButton.TabIndex = 4;
            this.loadPresetButton.UseVisualStyleBackColor = true;
            this.loadPresetButton.Click += new System.EventHandler(this.loadPresetButton_Click);
            // 
            // mainTooltip
            // 
            this.mainTooltip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.mainTooltip_Draw);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(230, 222);
            this.Controls.Add(this.credit2Label);
            this.Controls.Add(this.presetsLabel);
            this.Controls.Add(this.creditLabel);
            this.Controls.Add(this.titlebarPanel);
            this.Controls.Add(this.refreshPresetsButton);
            this.Controls.Add(this.clearKeysButton);
            this.Controls.Add(this.deletePresetButton);
            this.Controls.Add(this.loadPresetButton);
            this.Controls.Add(this.presetListbox);
            this.Controls.Add(this.addKeyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "Keystrokes";
            this.Load += new System.EventHandler(this.main_Load);
            this.titlebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bannerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addKeyButton;
        private System.Windows.Forms.ListBox presetListbox;
        private System.Windows.Forms.Button loadPresetButton;
        private System.Windows.Forms.Button deletePresetButton;
        private System.Windows.Forms.Button clearKeysButton;
        private System.Windows.Forms.Button refreshPresetsButton;
        private System.Windows.Forms.Panel titlebarPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label creditLabel;
        private System.Windows.Forms.Label presetsLabel;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Label credit2Label;
        private System.Windows.Forms.PictureBox bannerPicture;
        private System.Windows.Forms.ToolTip mainTooltip;
    }
}

