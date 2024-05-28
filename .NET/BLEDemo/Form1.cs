using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;

namespace BLEDemo;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        var devices = DiscoverBluetoothDevices().GetAwaiter().GetResult();
        foreach (var device in devices)
        {
            Console.WriteLine($"Name: {device.Name}, Id: {device.Id}");
        }
    }

    public static async Task<List<DeviceInformation>> DiscoverBluetoothDevices()
    {
        List<DeviceInformation> devices = new List<DeviceInformation>();

        // Request access to Bluetooth
        var accessStatus = await DeviceInformation.FindAllAsync(BluetoothDevice.GetDeviceSelector());

        if (accessStatus != null)
        {
            foreach (var device in accessStatus)
            {
                devices.Add(device);
            }
        }

        return devices;
    }
}
