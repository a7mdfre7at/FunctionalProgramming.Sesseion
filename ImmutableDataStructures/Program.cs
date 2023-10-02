
using System.Collections.Immutable;


// Record types are immutable by default
Person person = new("John", "Doe");
Console.WriteLine(person);

//Person person2 = person with { FirstName = "Sam" };
//Console.WriteLine(person2);






// Immutable collections
// Create an immutable list
ImmutableList<int> immutableList = ImmutableList<int>.Empty.Add(1).Add(2).Add(3);

// Attempting to modify the list will create a new immutable list
ImmutableList<int> modifiedList = immutableList.Add(4);
Console.WriteLine(string.Join(",", immutableList));
Console.WriteLine(string.Join(",", modifiedList));












//public record Person(string FirstName, string LastName);

public class Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    //public override string ToString() => $"{FirstName} {LastName}";
}