using System.Drawing;
using System.Windows.Forms;
using static Keystrokes.Tools.Forms;

namespace Keystrokes.Tools.CustomMessageBox
{
    public partial class CustomMessageBox : Form
    {
        public string MessageText
        {
            get { return MessageLabel.Text; }
            set { MessageLabel.Text = value; }
        }

        public DialogResult Result { get; private set; }

        public CustomMessageBox()
        {
            InitializeComponent();
        }

        private void CustomMessageBox_Load(object sender, System.EventArgs e)
        {
            Width = MessageLabel.Width + 10;
            Height = MessageLabel.Height + 105;

            TitlebarPanel.Width = Width;
            BottomBarPanel.Width = Width;
            BottomBarPanel.Location = new Point(BottomBarPanel.Location.X, MessageLabel.Height + 105 - BottomBarPanel.Height);

            CloseButton.Location = new Point(Width - CloseButton.Width, CloseButton.Location.Y);
            OkButton.Location = new Point(Width - OkButton.Width - 7, OkButton.Location.Y);
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            Result = DialogResult.OK;
            Close();
        }

        private void TitlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }

        private void BannerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(Handle, e);
        }
    }
}