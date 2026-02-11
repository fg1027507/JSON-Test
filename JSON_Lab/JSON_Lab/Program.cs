using Newtonsoft.Json;
using System;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person
        {
            name = "Finn Gilbert",
            Age = 16,
            email = "fg1027507@otc.edu",
            isStudent = true
        };

        string json = JsonConvert.SerializeObject(person);
        Console.WriteLine("Serialized JSON: " + json);
    }
}