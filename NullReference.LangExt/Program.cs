using System;
using LanguageExt;
using static LanguageExt.Prelude;

class Program
{
    static void Main()
    {
        // Simulate getting user data from a database
        Option<User> userOption = GetUserFromDatabase(1);

        var result = userOption
            .Filter(user => user.Age >= 18)
            .Map(user => CalculateDiscountedPrice(user.InitialPrice, 0.1));

        Console.WriteLine(result.Match(
            Some: discountedPrice => $"Final Price for Alice: ${discountedPrice:F2}",
            None: "User data not found or invalid."));
    }

    static Option<User> GetUserFromDatabase(int userId)
    {
        // Simulate fetching user data from a database
        if (userId == 1)
            return Some(new User("Alice", 30, 100.0));
        else
            return None;
    }

    static double CalculateDiscountedPrice(double initialPrice, double discount)
    {
        // Simulate a calculation operation
        return initialPrice * (1 - discount);
    }
}

record User(string Name, int Age, double InitialPrice);
