// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using FluentFTP;

var ftp = new FtpClient("", 1000);
var response = ftp.UploadFile("a.exe", "b.exe");

var client = new FtpClient("hostIp", "username", "pwd");
client.AutoConnect();

foreach (var item in client.GetListing("/docs"))
{
    if(item.Type == FtpObjectType.File && Path.GetExtension(item.FullName).Contains("doc"))
    {

        var size = client.GetFileSize(item.FullName);
        var hash = client.GetChecksum(item.FullName);
    }

    //修改时间戳
    client.SetModifiedTime(item.FullName, DateTime.Now);
}

//client.UploadFiles()
client.UploadFile(@"C:\Myvideo.mp4", "docs/MyVideo.mp4");

client.DownloadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Myvideo.mp4"), "docs/Myvideo.mp4");

//文件操作
//流操作

client.Disconnect();


var asyncClient = new AsyncFtpClient("hostIp", "username", "pwd");
await asyncClient.AutoConnect();

await asyncClient.UploadFile("localFile", "remoteFile");

await asyncClient.DownloadFile("localFilePath", "remoteFilePath");


