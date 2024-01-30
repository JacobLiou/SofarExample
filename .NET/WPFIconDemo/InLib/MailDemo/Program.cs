// See https://aka.ms/new-console-template for more information
using MailKit.Net.Smtp;
using MimeKit;
using SendGrid.Helpers.Mail;

Console.WriteLine("Hello, World!");

//基于System.Net.Mail封装
var message = new MimeMessage();
message.From.Add(new MailboxAddress("lau", "lau@163.com"));
message.To.Add(new MailboxAddress("Me", "me.163.com"));
message.Subject = "";

message.Body = new TextPart("plain"){
    Text = $@"",
};

using var client = new SmtpClient();
client.Connect("smtp@163.com", 433, false);
client.Authenticate("l", "password");
client.Send(message);
client.Disconnect(true);


//竟然还要注册API key --- Twilo???
SendGrid.SendGridClient client1 = new SendGrid.SendGridClient("apikey");
var from_email = new EmailAddress("lau@163.com", "lau");
var subject = "Sub";
var to_email = new EmailAddress("me.163.com", "Me");
var body = "and easy to do anywhere, even with C#";
var message1 = MailHelper.CreateSingleEmail(from_email, to_email, subject, body, "");
var reponse = await client1.SendEmailAsync(message1);


