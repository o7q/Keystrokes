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
            this.counterLabel = new System.Windows.Forms.Label();
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
            this.wiggleModeCheckbox = new System.Windows.Forms.CheckBox();
            this.wiggleAmountTextbox = new System.Windows.Forms.TextBox();
            this.secretSettingsLabel = new System.Windows.Forms.Label();
            this.wiggleBiasUpTextbox = new System.Windows.Forms.TextBox();
            this.wiggleBiasDownTextbox = new System.Windows.Forms.TextBox();
            this.wiggleBiasRightTextbox = new System.Windows.Forms.TextBox();
            this.wiggleBiasLeftTextbox = new System.Windows.Forms.TextBox();
            this.wiggleAmountLabel = new System.Windows.Forms.Label();
            this.wiggleBiasUpLabel = new System.Windows.Forms.Label();
            this.wiggleBiasDownLabel = new System.Windows.Forms.Label();
            this.wiggleBiasRightLabel = new System.Windows.Forms.Label();
            this.wiggleBiasLeftLabel = new System.Windows.Forms.Label();
            this.imageButton = new System.Windows.Forms.Button();
            this.imagePressedButton = new System.Windows.Forms.Button();
            this.imageDisposeButton = new System.Windows.Forms.Button();
            this.imagePressedDisposeButton = new System.Windows.Forms.Button();
            this.showTextCheckbox = new System.Windows.Forms.CheckBox();
            this.soundPressedButton = new System.Windows.Forms.Button();
            this.soundButton = new System.Windows.Forms.Button();
            this.useKeyCountCheckbox = new System.Windows.Forms.CheckBox();
            this.soundDisposeButton = new System.Windows.Forms.Button();
            this.soundPressedDisposeButton = new System.Windows.Forms.Button();
            this.keyTextTextbox = new System.Windows.Forms.TextBox();
            this.keyTextLabel = new System.Windows.Forms.Label();
            this.soundVolumeTextbox = new System.Windows.Forms.TextBox();
            this.soundPressedVolumeTextbox = new System.Windows.Forms.TextBox();
            this.useTransparentBackgroundCheckbox = new System.Windows.Forms.CheckBox();
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
            this.createKeyButton.Location = new System.Drawing.Point(7, 325);
            this.createKeyButton.Name = "createKeyButton";
            this.createKeyButton.Size = new System.Drawing.Size(121, 35);
            this.createKeyButton.TabIndex = 26;
            this.createKeyButton.Text = "Create";
            this.createKeyButton.UseVisualStyleBackColor = false;
            this.createKeyButton.Click += new System.EventHandler(this.createKeyButton_Click);
            this.createKeyButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.createKeyButton_PreviewKeyDown);
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
            this.fontSizeTextbox.Location = new System.Drawing.Point(174, 82);
            this.fontSizeTextbox.Name = "fontSizeTextbox";
            this.fontSizeTextbox.Size = new System.Drawing.Size(45, 26);
            this.fontSizeTextbox.TabIndex = 6;
            this.fontSizeTextbox.Text = "20";
            this.fontSizeTextbox.TextChanged += new System.EventHandler(this.fontSizeTextbox_TextChanged);
            // 
            // keyColorButton
            // 
            this.keyColorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.keyColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyColorButton.ForeColor = System.Drawing.Color.White;
            this.keyColorButton.Location = new System.Drawing.Point(6, 144);
            this.keyColorButton.Name = "keyColorButton";
            this.keyColorButton.Size = new System.Drawing.Size(53, 24);
            this.keyColorButton.TabIndex = 8;
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
            this.keyTextColorButton.Location = new System.Drawing.Point(59, 144);
            this.keyTextColorButton.Name = "keyTextColorButton";
            this.keyTextColorButton.Size = new System.Drawing.Size(53, 24);
            this.keyTextColorButton.TabIndex = 9;
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
            this.keyOpacityTextbox.Location = new System.Drawing.Point(6, 238);
            this.keyOpacityTextbox.Name = "keyOpacityTextbox";
            this.keyOpacityTextbox.Size = new System.Drawing.Size(45, 26);
            this.keyOpacityTextbox.TabIndex = 24;
            this.keyOpacityTextbox.Text = "80";
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
            this.keyPreviewPanel.Controls.Add(this.counterLabel);
            this.keyPreviewPanel.Controls.Add(this.keyPreviewTextLabel);
            this.keyPreviewPanel.Location = new System.Drawing.Point(132, 300);
            this.keyPreviewPanel.Name = "keyPreviewPanel";
            this.keyPreviewPanel.Size = new System.Drawing.Size(60, 60);
            this.keyPreviewPanel.TabIndex = 0;
            this.keyPreviewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.keyPreviewPanel_Paint);
            // 
            // counterLabel
            // 
            this.counterLabel.AutoSize = true;
            this.counterLabel.BackColor = System.Drawing.Color.Transparent;
            this.counterLabel.Location = new System.Drawing.Point(1, 45);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(13, 13);
            this.counterLabel.TabIndex = 0;
            this.counterLabel.Text = "0";
            // 
            // keyPreviewTextLabel
            // 
            this.keyPreviewTextLabel.AutoSize = true;
            this.keyPreviewTextLabel.BackColor = System.Drawing.Color.Transparent;
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
            this.fontSizeLabel.Location = new System.Drawing.Point(170, 65);
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
            this.keyOpacityLabel.Location = new System.Drawing.Point(2, 221);
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
            this.keyPreviewLabel.Location = new System.Drawing.Point(128, 282);
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
            this.keyColorLabel.Location = new System.Drawing.Point(2, 127);
            this.keyColorLabel.Name = "keyColorLabel";
            this.keyColorLabel.Size = new System.Drawing.Size(74, 16);
            this.keyColorLabel.TabIndex = 0;
            this.keyColorLabel.Text = "Unpressed";
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
            this.keyBorderCombobox.Location = new System.Drawing.Point(7, 300);
            this.keyBorderCombobox.Name = "keyBorderCombobox";
            this.keyBorderCombobox.Size = new System.Drawing.Size(121, 21);
            this.keyBorderCombobox.TabIndex = 25;
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
            this.borderStyleLabel.Location = new System.Drawing.Point(3, 283);
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
            this.keyTextColorPressedButton.Location = new System.Drawing.Point(169, 144);
            this.keyTextColorPressedButton.Name = "keyTextColorPressedButton";
            this.keyTextColorPressedButton.Size = new System.Drawing.Size(53, 24);
            this.keyTextColorPressedButton.TabIndex = 16;
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
            this.keyColorPressedButton.Location = new System.Drawing.Point(116, 144);
            this.keyColorPressedButton.Name = "keyColorPressedButton";
            this.keyColorPressedButton.Size = new System.Drawing.Size(53, 24);
            this.keyColorPressedButton.TabIndex = 15;
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
            this.keyColorPressedLabel.Location = new System.Drawing.Point(112, 127);
            this.keyColorPressedLabel.Name = "keyColorPressedLabel";
            this.keyColorPressedLabel.Size = new System.Drawing.Size(58, 16);
            this.keyColorPressedLabel.TabIndex = 0;
            this.keyColorPressedLabel.Text = "Pressed";
            // 
            // keyColorPressedInvertCheckbox
            // 
            this.keyColorPressedInvertCheckbox.AutoSize = true;
            this.keyColorPressedInvertCheckbox.Checked = true;
            this.keyColorPressedInvertCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keyColorPressedInvertCheckbox.ForeColor = System.Drawing.Color.White;
            this.keyColorPressedInvertCheckbox.Location = new System.Drawing.Point(116, 221);
            this.keyColorPressedInvertCheckbox.Name = "keyColorPressedInvertCheckbox";
            this.keyColorPressedInvertCheckbox.Size = new System.Drawing.Size(101, 17);
            this.keyColorPressedInvertCheckbox.TabIndex = 22;
            this.keyColorPressedInvertCheckbox.Text = "Invert Key Color";
            this.keyColorPressedInvertCheckbox.UseVisualStyleBackColor = true;
            // 
            // keyTextColorPressedInvertCheckbox
            // 
            this.keyTextColorPressedInvertCheckbox.AutoSize = true;
            this.keyTextColorPressedInvertCheckbox.Checked = true;
            this.keyTextColorPressedInvertCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keyTextColorPressedInvertCheckbox.ForeColor = System.Drawing.Color.White;
            this.keyTextColorPressedInvertCheckbox.Location = new System.Drawing.Point(116, 236);
            this.keyTextColorPressedInvertCheckbox.Name = "keyTextColorPressedInvertCheckbox";
            this.keyTextColorPressedInvertCheckbox.Size = new System.Drawing.Size(104, 17);
            this.keyTextColorPressedInvertCheckbox.TabIndex = 23;
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
            // wiggleModeCheckbox
            // 
            this.wiggleModeCheckbox.AutoSize = true;
            this.wiggleModeCheckbox.ForeColor = System.Drawing.Color.White;
            this.wiggleModeCheckbox.Location = new System.Drawing.Point(1000, 61);
            this.wiggleModeCheckbox.Name = "wiggleModeCheckbox";
            this.wiggleModeCheckbox.Size = new System.Drawing.Size(89, 17);
            this.wiggleModeCheckbox.TabIndex = 0;
            this.wiggleModeCheckbox.TabStop = false;
            this.wiggleModeCheckbox.Text = "Wiggle Mode";
            this.wiggleModeCheckbox.UseVisualStyleBackColor = true;
            // 
            // wiggleAmountTextbox
            // 
            this.wiggleAmountTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.wiggleAmountTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wiggleAmountTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.wiggleAmountTextbox.Location = new System.Drawing.Point(1000, 78);
            this.wiggleAmountTextbox.Name = "wiggleAmountTextbox";
            this.wiggleAmountTextbox.Size = new System.Drawing.Size(30, 20);
            this.wiggleAmountTextbox.TabIndex = 0;
            this.wiggleAmountTextbox.TabStop = false;
            this.wiggleAmountTextbox.Text = "2";
            // 
            // secretSettingsLabel
            // 
            this.secretSettingsLabel.AutoSize = true;
            this.secretSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secretSettingsLabel.ForeColor = System.Drawing.Color.White;
            this.secretSettingsLabel.Location = new System.Drawing.Point(995, 34);
            this.secretSettingsLabel.Name = "secretSettingsLabel";
            this.secretSettingsLabel.Size = new System.Drawing.Size(150, 24);
            this.secretSettingsLabel.TabIndex = 0;
            this.secretSettingsLabel.Text = "Secret Settings";
            // 
            // wiggleBiasUpTextbox
            // 
            this.wiggleBiasUpTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.wiggleBiasUpTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wiggleBiasUpTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.wiggleBiasUpTextbox.Location = new System.Drawing.Point(1000, 101);
            this.wiggleBiasUpTextbox.Name = "wiggleBiasUpTextbox";
            this.wiggleBiasUpTextbox.Size = new System.Drawing.Size(30, 20);
            this.wiggleBiasUpTextbox.TabIndex = 0;
            this.wiggleBiasUpTextbox.TabStop = false;
            this.wiggleBiasUpTextbox.Text = "0";
            // 
            // wiggleBiasDownTextbox
            // 
            this.wiggleBiasDownTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.wiggleBiasDownTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wiggleBiasDownTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.wiggleBiasDownTextbox.Location = new System.Drawing.Point(1000, 121);
            this.wiggleBiasDownTextbox.Name = "wiggleBiasDownTextbox";
            this.wiggleBiasDownTextbox.Size = new System.Drawing.Size(30, 20);
            this.wiggleBiasDownTextbox.TabIndex = 0;
            this.wiggleBiasDownTextbox.TabStop = false;
            this.wiggleBiasDownTextbox.Text = "0";
            // 
            // wiggleBiasRightTextbox
            // 
            this.wiggleBiasRightTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.wiggleBiasRightTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wiggleBiasRightTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.wiggleBiasRightTextbox.Location = new System.Drawing.Point(1075, 101);
            this.wiggleBiasRightTextbox.Name = "wiggleBiasRightTextbox";
            this.wiggleBiasRightTextbox.Size = new System.Drawing.Size(30, 20);
            this.wiggleBiasRightTextbox.TabIndex = 0;
            this.wiggleBiasRightTextbox.TabStop = false;
            this.wiggleBiasRightTextbox.Text = "0";
            // 
            // wiggleBiasLeftTextbox
            // 
            this.wiggleBiasLeftTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.wiggleBiasLeftTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wiggleBiasLeftTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.wiggleBiasLeftTextbox.Location = new System.Drawing.Point(1075, 121);
            this.wiggleBiasLeftTextbox.Name = "wiggleBiasLeftTextbox";
            this.wiggleBiasLeftTextbox.Size = new System.Drawing.Size(30, 20);
            this.wiggleBiasLeftTextbox.TabIndex = 0;
            this.wiggleBiasLeftTextbox.TabStop = false;
            this.wiggleBiasLeftTextbox.Text = "0";
            // 
            // wiggleAmountLabel
            // 
            this.wiggleAmountLabel.AutoSize = true;
            this.wiggleAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wiggleAmountLabel.ForeColor = System.Drawing.Color.White;
            this.wiggleAmountLabel.Location = new System.Drawing.Point(1030, 81);
            this.wiggleAmountLabel.Name = "wiggleAmountLabel";
            this.wiggleAmountLabel.Size = new System.Drawing.Size(79, 13);
            this.wiggleAmountLabel.TabIndex = 0;
            this.wiggleAmountLabel.Text = "Wiggle Amount";
            // 
            // wiggleBiasUpLabel
            // 
            this.wiggleBiasUpLabel.AutoSize = true;
            this.wiggleBiasUpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wiggleBiasUpLabel.ForeColor = System.Drawing.Color.White;
            this.wiggleBiasUpLabel.Location = new System.Drawing.Point(1030, 104);
            this.wiggleBiasUpLabel.Name = "wiggleBiasUpLabel";
            this.wiggleBiasUpLabel.Size = new System.Drawing.Size(43, 13);
            this.wiggleBiasUpLabel.TabIndex = 0;
            this.wiggleBiasUpLabel.Text = "Bias Y+";
            // 
            // wiggleBiasDownLabel
            // 
            this.wiggleBiasDownLabel.AutoSize = true;
            this.wiggleBiasDownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wiggleBiasDownLabel.ForeColor = System.Drawing.Color.White;
            this.wiggleBiasDownLabel.Location = new System.Drawing.Point(1030, 124);
            this.wiggleBiasDownLabel.Name = "wiggleBiasDownLabel";
            this.wiggleBiasDownLabel.Size = new System.Drawing.Size(40, 13);
            this.wiggleBiasDownLabel.TabIndex = 0;
            this.wiggleBiasDownLabel.Text = "Bias Y-";
            // 
            // wiggleBiasRightLabel
            // 
            this.wiggleBiasRightLabel.AutoSize = true;
            this.wiggleBiasRightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wiggleBiasRightLabel.ForeColor = System.Drawing.Color.White;
            this.wiggleBiasRightLabel.Location = new System.Drawing.Point(1105, 104);
            this.wiggleBiasRightLabel.Name = "wiggleBiasRightLabel";
            this.wiggleBiasRightLabel.Size = new System.Drawing.Size(43, 13);
            this.wiggleBiasRightLabel.TabIndex = 0;
            this.wiggleBiasRightLabel.Text = "Bias X+";
            // 
            // wiggleBiasLeftLabel
            // 
            this.wiggleBiasLeftLabel.AutoSize = true;
            this.wiggleBiasLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wiggleBiasLeftLabel.ForeColor = System.Drawing.Color.White;
            this.wiggleBiasLeftLabel.Location = new System.Drawing.Point(1105, 124);
            this.wiggleBiasLeftLabel.Name = "wiggleBiasLeftLabel";
            this.wiggleBiasLeftLabel.Size = new System.Drawing.Size(40, 13);
            this.wiggleBiasLeftLabel.TabIndex = 0;
            this.wiggleBiasLeftLabel.Text = "Bias X-";
            // 
            // imageButton
            // 
            this.imageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.imageButton.Location = new System.Drawing.Point(6, 168);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(82, 24);
            this.imageButton.TabIndex = 10;
            this.imageButton.Text = "Image";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // imagePressedButton
            // 
            this.imagePressedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imagePressedButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.imagePressedButton.Location = new System.Drawing.Point(116, 168);
            this.imagePressedButton.Name = "imagePressedButton";
            this.imagePressedButton.Size = new System.Drawing.Size(82, 24);
            this.imagePressedButton.TabIndex = 17;
            this.imagePressedButton.Text = "Image";
            this.imagePressedButton.UseVisualStyleBackColor = true;
            this.imagePressedButton.Click += new System.EventHandler(this.imagePressedButton_Click);
            // 
            // imageDisposeButton
            // 
            this.imageDisposeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageDisposeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.imageDisposeButton.Location = new System.Drawing.Point(88, 168);
            this.imageDisposeButton.Name = "imageDisposeButton";
            this.imageDisposeButton.Size = new System.Drawing.Size(24, 24);
            this.imageDisposeButton.TabIndex = 11;
            this.imageDisposeButton.Text = "X";
            this.imageDisposeButton.UseVisualStyleBackColor = true;
            this.imageDisposeButton.Click += new System.EventHandler(this.imageDisposeButton_Click);
            // 
            // imagePressedDisposeButton
            // 
            this.imagePressedDisposeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imagePressedDisposeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.imagePressedDisposeButton.Location = new System.Drawing.Point(198, 168);
            this.imagePressedDisposeButton.Name = "imagePressedDisposeButton";
            this.imagePressedDisposeButton.Size = new System.Drawing.Size(24, 24);
            this.imagePressedDisposeButton.TabIndex = 18;
            this.imagePressedDisposeButton.Text = "X";
            this.imagePressedDisposeButton.UseVisualStyleBackColor = true;
            this.imagePressedDisposeButton.Click += new System.EventHandler(this.imagePressedDisposeButton_Click);
            // 
            // showTextCheckbox
            // 
            this.showTextCheckbox.AutoSize = true;
            this.showTextCheckbox.Checked = true;
            this.showTextCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTextCheckbox.ForeColor = System.Drawing.Color.White;
            this.showTextCheckbox.Location = new System.Drawing.Point(114, 109);
            this.showTextCheckbox.Name = "showTextCheckbox";
            this.showTextCheckbox.Size = new System.Drawing.Size(77, 17);
            this.showTextCheckbox.TabIndex = 7;
            this.showTextCheckbox.Text = "Show Text";
            this.showTextCheckbox.UseVisualStyleBackColor = true;
            this.showTextCheckbox.CheckedChanged += new System.EventHandler(this.showTextCheckbox_CheckedChanged);
            // 
            // soundPressedButton
            // 
            this.soundPressedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soundPressedButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.soundPressedButton.Location = new System.Drawing.Point(116, 192);
            this.soundPressedButton.Name = "soundPressedButton";
            this.soundPressedButton.Size = new System.Drawing.Size(52, 24);
            this.soundPressedButton.TabIndex = 19;
            this.soundPressedButton.Text = "Sound";
            this.soundPressedButton.UseVisualStyleBackColor = true;
            this.soundPressedButton.Click += new System.EventHandler(this.soundPressedButton_Click);
            // 
            // soundButton
            // 
            this.soundButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soundButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.soundButton.Location = new System.Drawing.Point(6, 192);
            this.soundButton.Name = "soundButton";
            this.soundButton.Size = new System.Drawing.Size(52, 24);
            this.soundButton.TabIndex = 12;
            this.soundButton.Text = "Sound";
            this.soundButton.UseVisualStyleBackColor = true;
            this.soundButton.Click += new System.EventHandler(this.soundButton_Click);
            // 
            // useKeyCountCheckbox
            // 
            this.useKeyCountCheckbox.AutoSize = true;
            this.useKeyCountCheckbox.ForeColor = System.Drawing.Color.White;
            this.useKeyCountCheckbox.Location = new System.Drawing.Point(6, 109);
            this.useKeyCountCheckbox.Name = "useKeyCountCheckbox";
            this.useKeyCountCheckbox.Size = new System.Drawing.Size(100, 17);
            this.useKeyCountCheckbox.TabIndex = 4;
            this.useKeyCountCheckbox.Text = "Display Counter";
            this.useKeyCountCheckbox.UseVisualStyleBackColor = true;
            this.useKeyCountCheckbox.CheckedChanged += new System.EventHandler(this.useKeyCountCheckbox_CheckedChanged);
            // 
            // soundDisposeButton
            // 
            this.soundDisposeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soundDisposeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.soundDisposeButton.Location = new System.Drawing.Point(88, 192);
            this.soundDisposeButton.Name = "soundDisposeButton";
            this.soundDisposeButton.Size = new System.Drawing.Size(24, 24);
            this.soundDisposeButton.TabIndex = 14;
            this.soundDisposeButton.Text = "X";
            this.soundDisposeButton.UseVisualStyleBackColor = true;
            this.soundDisposeButton.Click += new System.EventHandler(this.soundDisposeButton_Click);
            // 
            // soundPressedDisposeButton
            // 
            this.soundPressedDisposeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soundPressedDisposeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.soundPressedDisposeButton.Location = new System.Drawing.Point(198, 192);
            this.soundPressedDisposeButton.Name = "soundPressedDisposeButton";
            this.soundPressedDisposeButton.Size = new System.Drawing.Size(24, 24);
            this.soundPressedDisposeButton.TabIndex = 21;
            this.soundPressedDisposeButton.Text = "X";
            this.soundPressedDisposeButton.UseVisualStyleBackColor = true;
            this.soundPressedDisposeButton.Click += new System.EventHandler(this.soundPressedDisposeButton_Click);
            // 
            // keyTextTextbox
            // 
            this.keyTextTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.keyTextTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyTextTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyTextTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.keyTextTextbox.Location = new System.Drawing.Point(114, 82);
            this.keyTextTextbox.Name = "keyTextTextbox";
            this.keyTextTextbox.Size = new System.Drawing.Size(57, 26);
            this.keyTextTextbox.TabIndex = 5;
            this.keyTextTextbox.TextChanged += new System.EventHandler(this.keyTextTextbox_TextChanged);
            // 
            // keyTextLabel
            // 
            this.keyTextLabel.AutoSize = true;
            this.keyTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyTextLabel.ForeColor = System.Drawing.Color.White;
            this.keyTextLabel.Location = new System.Drawing.Point(111, 65);
            this.keyTextLabel.Name = "keyTextLabel";
            this.keyTextLabel.Size = new System.Drawing.Size(59, 16);
            this.keyTextLabel.TabIndex = 0;
            this.keyTextLabel.Text = "Key Text";
            // 
            // soundVolumeTextbox
            // 
            this.soundVolumeTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.soundVolumeTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.soundVolumeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundVolumeTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.soundVolumeTextbox.Location = new System.Drawing.Point(58, 192);
            this.soundVolumeTextbox.Name = "soundVolumeTextbox";
            this.soundVolumeTextbox.Size = new System.Drawing.Size(30, 24);
            this.soundVolumeTextbox.TabIndex = 13;
            this.soundVolumeTextbox.Text = "50";
            // 
            // soundPressedVolumeTextbox
            // 
            this.soundPressedVolumeTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.soundPressedVolumeTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.soundPressedVolumeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundPressedVolumeTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.soundPressedVolumeTextbox.Location = new System.Drawing.Point(168, 192);
            this.soundPressedVolumeTextbox.Name = "soundPressedVolumeTextbox";
            this.soundPressedVolumeTextbox.Size = new System.Drawing.Size(30, 24);
            this.soundPressedVolumeTextbox.TabIndex = 20;
            this.soundPressedVolumeTextbox.Text = "50";
            // 
            // useTransparentBackgroundCheckbox
            // 
            this.useTransparentBackgroundCheckbox.AutoSize = true;
            this.useTransparentBackgroundCheckbox.ForeColor = System.Drawing.Color.White;
            this.useTransparentBackgroundCheckbox.Location = new System.Drawing.Point(6, 266);
            this.useTransparentBackgroundCheckbox.Name = "useTransparentBackgroundCheckbox";
            this.useTransparentBackgroundCheckbox.Size = new System.Drawing.Size(144, 17);
            this.useTransparentBackgroundCheckbox.TabIndex = 27;
            this.useTransparentBackgroundCheckbox.Text = "Transparent Background";
            this.useTransparentBackgroundCheckbox.UseVisualStyleBackColor = true;
            this.useTransparentBackgroundCheckbox.CheckedChanged += new System.EventHandler(this.useTransparentBackgroundCheckbox_CheckedChanged);
            // 
            // keymaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(236, 367);
            this.Controls.Add(this.useTransparentBackgroundCheckbox);
            this.Controls.Add(this.soundPressedVolumeTextbox);
            this.Controls.Add(this.soundVolumeTextbox);
            this.Controls.Add(this.keyTextLabel);
            this.Controls.Add(this.keyTextTextbox);
            this.Controls.Add(this.soundPressedDisposeButton);
            this.Controls.Add(this.soundDisposeButton);
            this.Controls.Add(this.useKeyCountCheckbox);
            this.Controls.Add(this.soundButton);
            this.Controls.Add(this.soundPressedButton);
            this.Controls.Add(this.showTextCheckbox);
            this.Controls.Add(this.imagePressedDisposeButton);
            this.Controls.Add(this.imageDisposeButton);
            this.Controls.Add(this.imagePressedButton);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.wiggleBiasLeftLabel);
            this.Controls.Add(this.wiggleBiasRightLabel);
            this.Controls.Add(this.wiggleBiasDownLabel);
            this.Controls.Add(this.wiggleBiasUpLabel);
            this.Controls.Add(this.wiggleAmountLabel);
            this.Controls.Add(this.wiggleBiasLeftTextbox);
            this.Controls.Add(this.wiggleBiasRightTextbox);
            this.Controls.Add(this.wiggleBiasDownTextbox);
            this.Controls.Add(this.wiggleBiasUpTextbox);
            this.Controls.Add(this.secretSettingsLabel);
            this.Controls.Add(this.wiggleAmountTextbox);
            this.Controls.Add(this.wiggleModeCheckbox);
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
            this.Text = "Keystrokes Editor";
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
        private System.Windows.Forms.CheckBox wiggleModeCheckbox;
        private System.Windows.Forms.TextBox wiggleAmountTextbox;
        private System.Windows.Forms.Label secretSettingsLabel;
        private System.Windows.Forms.TextBox wiggleBiasUpTextbox;
        private System.Windows.Forms.TextBox wiggleBiasDownTextbox;
        private System.Windows.Forms.TextBox wiggleBiasRightTextbox;
        private System.Windows.Forms.TextBox wiggleBiasLeftTextbox;
        private System.Windows.Forms.Label wiggleAmountLabel;
        private System.Windows.Forms.Label wiggleBiasUpLabel;
        private System.Windows.Forms.Label wiggleBiasDownLabel;
        private System.Windows.Forms.Label wiggleBiasRightLabel;
        private System.Windows.Forms.Label wiggleBiasLeftLabel;
        private System.Windows.Forms.Button imageButton;
        private System.Windows.Forms.Button imagePressedButton;
        private System.Windows.Forms.Button imageDisposeButton;
        private System.Windows.Forms.Button imagePressedDisposeButton;
        private System.Windows.Forms.CheckBox showTextCheckbox;
        private System.Windows.Forms.Button soundPressedButton;
        private System.Windows.Forms.Button soundButton;
        private System.Windows.Forms.CheckBox useKeyCountCheckbox;
        private System.Windows.Forms.Button soundDisposeButton;
        private System.Windows.Forms.Button soundPressedDisposeButton;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.TextBox keyTextTextbox;
        private System.Windows.Forms.Label keyTextLabel;
        private System.Windows.Forms.TextBox soundVolumeTextbox;
        private System.Windows.Forms.TextBox soundPressedVolumeTextbox;
        private System.Windows.Forms.CheckBox useTransparentBackgroundCheckbox;
    }
}