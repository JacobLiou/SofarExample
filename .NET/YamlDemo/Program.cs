// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;



var person = new Person
{
    Name = "John Doe",
    Age = 30,
    Addresses = new Dictionary<string, Address>{
        { "home", new  Address() {
                Street = "2720  Sundown Lane",
                City = "Kentucketsville",
                State = "Calousiyorkida",
                Zip = "99978",
            }},
        { "work", new  Address() {
                Street = "1600 Pennsylvania Avenue NW",
                City = "Washington",
                State = "District of Columbia",
                Zip = "20500",
            }},
    }
};

var serilizor = new SerializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance)
    .Build();

var yaml = serilizor.Serialize(person);
Console.WriteLine(yaml);
File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "person.yaml"), yaml);


public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public Dictionary<string, Address> Addresses { get; set; }
}

public class Address
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
}