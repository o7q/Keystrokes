namespace Keystrokes
{
    partial class keymaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(keymaker));
            this.closeButton = new System.Windows.Forms.Button();
            this.createKeyButton = new System.Windows.Forms.Button();
            this.keyWidthTextbox = new System.Windows.Forms.TextBox();
            this.keyHeightTextbox = new System.Windows.Forms.TextBox();
            this.fontSizeTextbox = new System.Windows.Forms.TextBox();
            this.keyColorButton = new System.Windows.Forms.Button();
            this.keyTextColorButton = new System.Windows.Forms.Button();
            this.keyOpacityTextbox = new System.Windows.Forms.TextBox();
            this.titlebarPanel = new System.Windows.Forms.Panel();
            this.bannerPicture = new System.Windows.Forms.PictureBox();
            this.keyPreviewPanel = new System.Windows.Forms.Panel();
            this.keyPreviewTextLabel = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.size2Label = new System.Windows.Forms.Label();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.keyOpacityLabel = new System.Windows.Forms.Label();
            this.keyPreviewLabel = new System.Windows.Forms.Label();
            this.configureKeyLabel = new System.Windows.Forms.Label();
            this.keyColorLabel = new System.Windows.Forms.Label();
            this.keyBorderCombobox = new System.Windows.Forms.ComboBox();
            this.presetNameLabel = new System.Windows.Forms.Label();
            this.borderStyleLabel = new System.Windows.Forms.Label();
            this.keyTextColorPressedButton = new System.Windows.Forms.Button();
            this.keyColorPressedButton = new System.Windows.Forms.Button();
            this.keyColorPressedLabel = new System.Windows.Forms.Label();
            this.keyColorPressedInvertCheckbox = new System.Windows.Forms.CheckBox();
            this.keyTextColorPressedInvertCheckbox = new System.Windows.Forms.CheckBox();
            this.presetNameCombobox = new System.Windows.Forms.ComboBox();
            this.keymakerTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.titlebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPicture)).BeginInit();
            this.keyPreviewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.closeButton.Location = new System.Drawing.Point(216, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 25);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // createKeyButton
            // 
            this.createKeyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.createKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createKeyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.createKeyButton.Location = new System.Drawing.Point(6, 238);
            this.createKeyButton.Name = "createKeyButton";
            this.createKeyButton.Size = new System.Drawing.Size(121, 35);
            this.createKeyButton.TabIndex = 13;
            this.createKeyButton.Text = "Create";
            this.createKeyButton.UseVisualStyleBackColor = false;
            this.createKeyButton.Click += new System.EventHandler(this.createKeyButton_Click);
            this.createKeyButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.createKeyButton_KeyDown);
            // 
            // keyWidthTextbox
            // 
            this.keyWidthTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.keyWidthTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyWidthTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyWidthTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.keyWidthTextbox.Location = new System.Drawing.Point(6, 82);
            this.keyWidthTextbox.Name = "keyWidthTextbox";
            this.keyWidthTextbox.Size = new System.Drawing.Size(45, 26);
            this.keyWidthTextbox.TabIndex = 2;
            this.keyWidthTextbox.Text = "60";
            this.keyWidthTextbox.TextChanged += new System.EventHandler(this.keyWidthTextbox_TextChanged);
            // 
            // keyHeightTextbox
            // 
            this.keyHeightTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.keyHeightTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyHeightTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyHeightTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.keyHeightTextbox.Location = new System.Drawing.Point(62, 82);
            this.keyHeightTextbox.Name = "keyHeightTextbox";
            this.keyHeightTextbox.Size = new System.Drawing.Size(45, 26);
            this.keyHeightTextbox.TabIndex = 3;
            this.keyHeightTextbox.Text = "60";
            this.keyHeightTextbox.TextChanged += new System.EventHandler(this.keyHeightTextbox_TextChanged);
            // 
            // fontSizeTextbox
            // 
            this.fontSizeTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.fontSizeTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fontSizeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSizeTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.fontSizeTextbox.Location = new System.Drawing.Point(115, 82);
            this.fontSizeTextbox.Name = "fontSizeTextbox";
            this.fontSizeTextbox.Size = new System.Drawing.Size(45, 26);
            this.fontSizeTextbox.TabIndex = 4;
            this.fontSizeTextbox.Text = "20";
            this.fontSizeTextbox.TextChanged += new System.EventHandler(this.fontSizeTextbox_TextChanged);
            // 
            // keyColorButton
            // 
            this.keyColorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.keyColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyColorButton.ForeColor = System.Drawing.Color.White;
            this.keyColorButton.Location = new System.Drawing.Point(6, 126);
            this.keyColorButton.Name = "keyColorButton";
            this.keyColorButton.Size = new System.Drawing.Size(53, 23);
            this.keyColorButton.TabIndex = 5;
            this.keyColorButton.Text = "Color 1";
            this.keyColorButton.UseVisualStyleBackColor = true;
            this.keyColorButton.Click += new System.EventHandler(this.keyColorButton_Click);
            // 
            // keyTextColorButton
            // 
            this.keyTextColorButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.keyTextColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyTextColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyTextColorButton.ForeColor = System.Drawing.Color.White;
            this.keyTextColorButton.Location = new System.Drawing.Point(59, 126);
            this.keyTextColorButton.Name = "keyTextColorButton";
            this.keyTextColorButton.Size = new System.Drawing.Size(53, 23);
            this.keyTextColorButton.TabIndex = 6;
            this.keyTextColorButton.Text = "Color 2";
            this.keyTextColorButton.UseVisualStyleBackColor = true;
            this.keyTextColorButton.Click += new System.EventHandler(this.keyTextColorButton_Click);
            // 
            // keyOpacityTextbox
            // 
            this.keyOpacityTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.keyOpacityTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyOpacityTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyOpacityTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.keyOpacityTextbox.Location = new System.Drawing.Point(6, 168);
            this.keyOpacityTextbox.Name = "keyOpacityTextbox";
            this.keyOpacityTextbox.Size = new System.Drawing.Size(45, 26);
            this.keyOpacityTextbox.TabIndex = 11;
            this.keyOpacityTextbox.Text = "0.8";
            // 
            // titlebarPanel
            // 
            this.titlebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(20)))));
            this.titlebarPanel.Controls.Add(this.bannerPicture);
            this.titlebarPanel.Controls.Add(this.closeButton);
            this.titlebarPanel.Location = new System.Drawing.Point(-5, -6);
            this.titlebarPanel.Name = "titlebarPanel";
            this.titlebarPanel.Size = new System.Drawing.Size(246, 31);
            this.titlebarPanel.TabIndex = 0;
            this.titlebarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebarPanel_MouseDown);
            // 
            // bannerPicture
            // 
            this.bannerPicture.Image = global::Keystrokes.Properties.Resources.program_banner_editor;
            this.bannerPicture.Location = new System.Drawing.Point(4, 19);
            this.bannerPicture.Name = "bannerPicture";
            this.bannerPicture.Size = new System.Drawing.Size(155, 17);
            this.bannerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bannerPicture.TabIndex = 0;
            this.bannerPicture.TabStop = false;
            this.bannerPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bannerPicture_MouseDown);
            // 
            // keyPreviewPanel
            // 
            this.keyPreviewPanel.BackColor = System.Drawing.Color.Silver;
            this.keyPreviewPanel.Controls.Add(this.keyPreviewTextLabel);
            this.keyPreviewPanel.Location = new System.Drawing.Point(131, 213);
            this.keyPreviewPanel.Name = "keyPreviewPanel";
            this.keyPreviewPanel.Size = new System.Drawing.Size(60, 60);
            this.keyPreviewPanel.TabIndex = 0;
            this.keyPreviewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.keyPreviewPanel_Paint);
            // 
            // keyPreviewTextLabel
            // 
            this.keyPreviewTextLabel.AutoSize = true;
            this.keyPreviewTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyPreviewTextLabel.Location = new System.Drawing.Point(0, 1);
            this.keyPreviewTextLabel.Name = "keyPreviewTextLabel";
            this.keyPreviewTextLabel.Size = new System.Drawing.Size(15, 13);
            this.keyPreviewTextLabel.TabIndex = 0;
            this.keyPreviewTextLabel.Text = "A";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.sizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLabel.ForeColor = System.Drawing.Color.White;
            this.sizeLabel.Location = new System.Drawing.Point(2, 65);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(59, 16);
            this.sizeLabel.TabIndex = 0;
            this.sizeLabel.Text = "Key Size";
            // 
            // size2Label
            // 
            this.size2Label.AutoSize = true;
            this.size2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size2Label.ForeColor = System.Drawing.Color.White;
            this.size2Label.Location = new System.Drawing.Point(51, 89);
            this.size2Label.Name = "size2Label";
            this.size2Label.Size = new System.Drawing.Size(11, 9);
            this.size2Label.TabIndex = 0;
            this.size2Label.Text = "X";
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSizeLabel.ForeColor = System.Drawing.Color.White;
            this.fontSizeLabel.Location = new System.Drawing.Point(111, 65);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(62, 16);
            this.fontSizeLabel.TabIndex = 0;
            this.fontSizeLabel.Text = "Font Size";
            // 
            // keyOpacityLabel
            // 
            this.keyOpacityLabel.AutoSize = true;
            this.keyOpacityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyOpacityLabel.ForeColor = System.Drawing.Color.White;
            this.keyOpacityLabel.Location = new System.Drawing.Point(2, 151);
            this.keyOpacityLabel.Name = "keyOpacityLabel";
            this.keyOpacityLabel.Size = new System.Drawing.Size(79, 16);
            this.keyOpacityLabel.TabIndex = 0;
            this.keyOpacityLabel.Text = "Key Opacity";
            // 
            // keyPreviewLabel
            // 
            this.keyPreviewLabel.AutoSize = true;
            this.keyPreviewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyPreviewLabel.ForeColor = System.Drawing.Color.White;
            this.keyPreviewLabel.Location = new System.Drawing.Point(127, 195);
            this.keyPreviewLabel.Name = "keyPreviewLabel";
            this.keyPreviewLabel.Size = new System.Drawing.Size(81, 16);
            this.keyPreviewLabel.TabIndex = 0;
            this.keyPreviewLabel.Text = "Key Preview";
            // 
            // configureKeyLabel
            // 
            this.configureKeyLabel.AutoSize = true;
            this.configureKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configureKeyLabel.ForeColor = System.Drawing.Color.White;
            this.configureKeyLabel.Location = new System.Drawing.Point(2, 34);
            this.configureKeyLabel.Name = "configureKeyLabel";
            this.configureKeyLabel.Size = new System.Drawing.Size(106, 24);
            this.configureKeyLabel.TabIndex = 0;
            this.configureKeyLabel.Text = "Key Editor";
            // 
            // keyColorLabel
            // 
            this.keyColorLabel.AutoSize = true;
            this.keyColorLabel.BackColor = System.Drawing.Color.Transparent;
            this.keyColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyColorLabel.ForeColor = System.Drawing.Color.White;
            this.keyColorLabel.Location = new System.Drawing.Point(2, 109);
            this.keyColorLabel.Name = "keyColorLabel";
            this.keyColorLabel.Size = new System.Drawing.Size(65, 16);
            this.keyColorLabel.TabIndex = 0;
            this.keyColorLabel.Text = "Key Color";
            // 
            // keyBorderCombobox
            // 
            this.keyBorderCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.keyBorderCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyBorderCombobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.keyBorderCombobox.FormattingEnabled = true;
            this.keyBorderCombobox.Items.AddRange(new object[] {
            "Solid",
            "Inset",
            "Outset",
            "Dashed",
            "None"});
            this.keyBorderCombobox.Location = new System.Drawing.Point(6, 213);
            this.keyBorderCombobox.Name = "keyBorderCombobox";
            this.keyBorderCombobox.Size = new System.Drawing.Size(121, 21);
            this.keyBorderCombobox.TabIndex = 12;
            // 
            // presetNameLabel
            // 
            this.presetNameLabel.AutoSize = true;
            this.presetNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.presetNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetNameLabel.ForeColor = System.Drawing.Color.White;
            this.presetNameLabel.Location = new System.Drawing.Point(111, 28);
            this.presetNameLabel.Name = "presetNameLabel";
            this.presetNameLabel.Size = new System.Drawing.Size(86, 16);
            this.presetNameLabel.TabIndex = 0;
            this.presetNameLabel.Text = "Preset Name";
            // 
            // borderStyleLabel
            // 
            this.borderStyleLabel.AutoSize = true;
            this.borderStyleLabel.BackColor = System.Drawing.Color.Transparent;
            this.borderStyleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderStyleLabel.ForeColor = System.Drawing.Color.White;
            this.borderStyleLabel.Location = new System.Drawing.Point(2, 196);
            this.borderStyleLabel.Name = "borderStyleLabel";
            this.borderStyleLabel.Size = new System.Drawing.Size(107, 16);
            this.borderStyleLabel.TabIndex = 0;
            this.borderStyleLabel.Text = "Key Border Style";
            // 
            // keyTextColorPressedButton
            // 
            this.keyTextColorPressedButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.keyTextColorPressedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyTextColorPressedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyTextColorPressedButton.ForeColor = System.Drawing.Color.White;
            this.keyTextColorPressedButton.Location = new System.Drawing.Point(169, 126);
            this.keyTextColorPressedButton.Name = "keyTextColorPressedButton";
            this.keyTextColorPressedButton.Size = new System.Drawing.Size(53, 23);
            this.keyTextColorPressedButton.TabIndex = 8;
            this.keyTextColorPressedButton.Text = "Color 2";
            this.keyTextColorPressedButton.UseVisualStyleBackColor = true;
            this.keyTextColorPressedButton.Click += new System.EventHandler(this.keyTextColorPressedButton_Click);
            // 
            // keyColorPressedButton
            // 
            this.keyColorPressedButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.keyColorPressedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyColorPressedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyColorPressedButton.ForeColor = System.Drawing.Color.White;
            this.keyColorPressedButton.Location = new System.Drawing.Point(116, 126);
            this.keyColorPressedButton.Name = "keyColorPressedButton";
            this.keyColorPressedButton.Size = new System.Drawing.Size(53, 23);
            this.keyColorPressedButton.TabIndex = 7;
            this.keyColorPressedButton.Text = "Color 1";
            this.keyColorPressedButton.UseVisualStyleBackColor = true;
            this.keyColorPressedButton.Click += new System.EventHandler(this.keyColorPressedButton_Click);
            // 
            // keyColorPressedLabel
            // 
            this.keyColorPressedLabel.AutoSize = true;
            this.keyColorPressedLabel.BackColor = System.Drawing.Color.Transparent;
            this.keyColorPressedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyColorPressedLabel.ForeColor = System.Drawing.Color.White;
            this.keyColorPressedLabel.Location = new System.Drawing.Point(112, 109);
            this.keyColorPressedLabel.Name = "keyColorPressedLabel";
            this.keyColorPressedLabel.Size = new System.Drawing.Size(119, 16);
            this.keyColorPressedLabel.TabIndex = 0;
            this.keyColorPressedLabel.Text = "Key Pressed Color";
            // 
            // keyColorPressedInvertCheckbox
            // 
            this.keyColorPressedInvertCheckbox.AutoSize = true;
            this.keyColorPressedInvertCheckbox.Checked = true;
            this.keyColorPressedInvertCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keyColorPressedInvertCheckbox.ForeColor = System.Drawing.Color.White;
            this.keyColorPressedInvertCheckbox.Location = new System.Drawing.Point(116, 150);
            this.keyColorPressedInvertCheckbox.Name = "keyColorPressedInvertCheckbox";
            this.keyColorPressedInvertCheckbox.Size = new System.Drawing.Size(101, 17);
            this.keyColorPressedInvertCheckbox.TabIndex = 9;
            this.keyColorPressedInvertCheckbox.Text = "Invert Key Color";
            this.keyColorPressedInvertCheckbox.UseVisualStyleBackColor = true;
            // 
            // keyTextColorPressedInvertCheckbox
            // 
            this.keyTextColorPressedInvertCheckbox.AutoSize = true;
            this.keyTextColorPressedInvertCheckbox.Checked = true;
            this.keyTextColorPressedInvertCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keyTextColorPressedInvertCheckbox.ForeColor = System.Drawing.Color.White;
            this.keyTextColorPressedInvertCheckbox.Location = new System.Drawing.Point(116, 165);
            this.keyTextColorPressedInvertCheckbox.Name = "keyTextColorPressedInvertCheckbox";
            this.keyTextColorPressedInvertCheckbox.Size = new System.Drawing.Size(104, 17);
            this.keyTextColorPressedInvertCheckbox.TabIndex = 10;
            this.keyTextColorPressedInvertCheckbox.Text = "Invert Text Color";
            this.keyTextColorPressedInvertCheckbox.UseVisualStyleBackColor = true;
            // 
            // presetNameCombobox
            // 
            this.presetNameCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.presetNameCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.presetNameCombobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.presetNameCombobox.FormattingEnabled = true;
            this.presetNameCombobox.Location = new System.Drawing.Point(115, 44);
            this.presetNameCombobox.Name = "presetNameCombobox";
            this.presetNameCombobox.Size = new System.Drawing.Size(107, 21);
            this.presetNameCombobox.TabIndex = 1;
            this.presetNameCombobox.Text = "Default";
            // 
            // keymakerTooltip
            // 
            this.keymakerTooltip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.keymakerTooltip_Draw);
            // 
            // keymaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(236, 280);
            this.Controls.Add(this.presetNameCombobox);
            this.Controls.Add(this.keyTextColorPressedInvertCheckbox);
            this.Controls.Add(this.keyColorPressedInvertCheckbox);
            this.Controls.Add(this.keyColorPressedLabel);
            this.Controls.Add(this.keyTextColorPressedButton);
            this.Controls.Add(this.keyColorPressedButton);
            this.Controls.Add(this.borderStyleLabel);
            this.Controls.Add(this.presetNameLabel);
            this.Controls.Add(this.keyBorderCombobox);
            this.Controls.Add(this.keyColorLabel);
            this.Controls.Add(this.configureKeyLabel);
            this.Controls.Add(this.keyPreviewLabel);
            this.Controls.Add(this.keyOpacityLabel);
            this.Controls.Add(this.fontSizeLabel);
            this.Controls.Add(this.size2Label);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.keyPreviewPanel);
            this.Controls.Add(this.titlebarPanel);
            this.Controls.Add(this.keyOpacityTextbox);
            this.Controls.Add(this.keyTextColorButton);
            this.Controls.Add(this.keyColorButton);
            this.Controls.Add(this.fontSizeTextbox);
            this.Controls.Add(this.keyHeightTextbox);
            this.Controls.Add(this.keyWidthTextbox);
            this.Controls.Add(this.createKeyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "keymaker";
            this.Text = "Key Editor";
            this.Load += new System.EventHandler(this.keymaker_Load);
            this.titlebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bannerPicture)).EndInit();
            this.keyPreviewPanel.ResumeLayout(false);
            this.keyPreviewPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button createKeyButton;
        private System.Windows.Forms.TextBox keyWidthTextbox;
        private System.Windows.Forms.TextBox keyHeightTextbox;
        private System.Windows.Forms.TextBox fontSizeTextbox;
        private System.Windows.Forms.Button keyColorButton;
        private System.Windows.Forms.Button keyTextColorButton;
        private System.Windows.Forms.TextBox keyOpacityTextbox;
        private System.Windows.Forms.Panel titlebarPanel;
        private System.Windows.Forms.Panel keyPreviewPanel;
        private System.Windows.Forms.Label keyPreviewTextLabel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label size2Label;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.Label keyOpacityLabel;
        private System.Windows.Forms.Label keyPreviewLabel;
        private System.Windows.Forms.Label configureKeyLabel;
        private System.Windows.Forms.Label keyColorLabel;
        private System.Windows.Forms.ComboBox keyBorderCombobox;
        private System.Windows.Forms.Label presetNameLabel;
        private System.Windows.Forms.Label borderStyleLabel;
        private System.Windows.Forms.Button keyTextColorPressedButton;
        private System.Windows.Forms.Button keyColorPressedButton;
        private System.Windows.Forms.Label keyColorPressedLabel;
        private System.Windows.Forms.CheckBox keyColorPressedInvertCheckbox;
        private System.Windows.Forms.CheckBox keyTextColorPressedInvertCheckbox;
        private System.Windows.Forms.ComboBox presetNameCombobox;
        private System.Windows.Forms.PictureBox bannerPicture;
        private System.Windows.Forms.ToolTip keymakerTooltip;
    }
}