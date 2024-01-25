using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformMessenger.Messages;

namespace WinformMessenger
{
    public partial class EmbedControl : UserControl
    {
        public EmbedControl()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new CloseMessage());
        }
    }
}
