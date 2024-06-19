using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SerialLogsDemo;

public partial class Form1 : Form
{
    private ILogger<Form1>? logger;

    public Form1()
    {
        InitializeComponent();
        logger = Program.ServiceProvider?.GetRequiredService<ILogger<Form1>>();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var ramdon = new Random();
        logger?.LogInformation("Hello" + ramdon.NextInt64());
    }
}
