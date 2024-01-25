using CommunityToolkit.Mvvm.Messaging;
using WinformMessenger.Messages;

namespace WinformMessenger;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        WeakReferenceMessenger.Default.Register<CloseMessage>(this, OnCloseMessageReceived);
    }

    private void OnCloseMessageReceived(object recipient, CloseMessage message)
    {
        this.Close();
    }
}
