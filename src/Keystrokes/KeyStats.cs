using Keystrokes.Data;
using System.Windows.Forms;

namespace Keystrokes
{
    public partial class KeyStats : Form
    {
        KeyInfo keyData = new KeyInfo();

        public KeyStats(KeyInfo keyData_)
        {
            InitializeComponent();

            InitializeComponent();

            // load keyData_ into keyData
            keyData = keyData_;
        }
    }
}
