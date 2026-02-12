using Newtonsoft.Json;
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            // Create a list of people with different properties
            new Person
            {
                name = "Frodo Baggins",
                Age = 30,
                email = "Frodo@LordOfTheRings.com",
                isStudent = false,
            },
             new Person
             {
                 name = "Samwise Gamgie",
                 Age = 35,
                 email = "San@LordOfTheRings.com",
                 isStudent = true,
             },
            new Person{
                name = "Gandalf Gray",
                Age = 100,
                email = "Gandalf@LordOfTheRings.com",
                isStudent = false,
            },

        };

        // Serialize the list of people to JSON
        string json = JsonConvert.SerializeObject(people, Formatting.Indented);
        Console.WriteLine("Serialized JSON: " + json);

        // Deserialize the JSON back to a list of people
        try
        {
            List<Person> deserializedPeople = JsonConvert.DeserializeObject<List<Person>>(json);
            Console.WriteLine("\nDeserialized People:");
            foreach (var person in deserializedPeople)
            {
                Console.WriteLine($"Name: {person.name}, Age: {person.Age}, Email: {person.email}, Is Student: {person.isStudent}");
            }
        }
        catch (JsonReaderException ex)
        {
            Console.WriteLine("Error: JSON formate is invalid");
            Console.WriteLine(ex.Message);
        }
        catch (JsonSerializationException ex)
        {
            Console.WriteLine("Error: JSON could not be converted into person objects.");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred.");
            Console.WriteLine(ex.Message);
        }

        // Invalid JSON string for testing error handling
        string invalidJson = "{ name: 'Frodo Baggins', Age: 30, email: ''}";
        try
        {
            List<Person> invalidDeserialization = JsonConvert.DeserializeObject<List<Person>>(invalidJson);
        }
        catch (JsonReaderException ex)
        {
            Console.WriteLine("\nError: JSON formate is invalid");
            Console.WriteLine(ex.Message);
        }
    }
}
