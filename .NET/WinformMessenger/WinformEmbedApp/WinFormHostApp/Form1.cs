

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinFormHostApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

    }

    private void button1_Click(object sender, EventArgs e)
    {
        Process notepad = new Process();
        ProcessStartInfo psi = new ProcessStartInfo("notepad.exe");
        psi.WindowStyle = ProcessWindowStyle.Normal;
        notepad.StartInfo = psi;

        notepad.Start();
        notepad.WaitForInputIdle(3000);

        SetParent(notepad.MainWindowHandle, this.Handle);
    }

    [DllImport("user32.dll")]
    static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
}
