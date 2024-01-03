using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient
{
    public partial class Form1 : Form
    {
        private HubConnection hubConnection;

        public Form1()
        {
            InitializeComponent();

            var connBuilder = new HubConnectionBuilder()
                .WithUrl("http://localhost:5169/chathub")
                .WithAutomaticReconnect();
            hubConnection = connBuilder.Build();
            hubConnection.On<string, string>("ReceiveMessage", OnReceiveMessage);
        }

        private void OnReceiveMessage(string user, string message)
        {
            this.BeginInvoke(new Action(() =>
            {
                richTextBox1.AppendText($"User: {user}");
                richTextBox1.AppendText($"Msg: {message}");
            }));
        }

        private async void btnConn_Click(object sender, EventArgs e)
        {
            try
            {
                await hubConnection.StartAsync();
                this.Text = "已建立连接";
            }
            catch (Exception ex)
            {
                this.Text = ex.Message;
            }
        }

        private async void btnDisconn_Click(object sender, EventArgs e)
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                await hubConnection.StopAsync();
                this.Text = "已断开连接";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await hubConnection.InvokeAsync("SendMessage", "UserMe", "Hello" + Guid.NewGuid().ToString("N"));
        }
    }
}
