// Simulate getting user data from a database
User user = GetUserFromDatabase(1);

if (user != null)
{
    if (user.Age >= 18)
    {
        double discountedPrice = CalculateDiscountedPrice(user.InitialPrice, 0.1);
        Console.WriteLine($"Final Price for {user.Name}: ${discountedPrice:F2}");
    }
    else
    {
        Console.WriteLine("User is under 18, cannot proceed.");
    }
}
else
{
    Console.WriteLine("User data not found.");
}



/***********************************************************************/



static User GetUserFromDatabase(int userId)
{
    // Simulate fetching user data from a database
    if (userId == 1)
        return new User("Alice", 30, 100.0);
    else
        return null;
}

static double CalculateDiscountedPrice(double initialPrice, double discount)
{
    // Simulate a calculation operation
    return initialPrice * (1 - discount);
}


class User
{
    public string Name { get; }
    public int Age { get; }
    public double InitialPrice { get; }

    public User(string name, int age, double initialPrice)
    {
        Name = name;
        Age = age;
        InitialPrice = initialPrice;
    }
}
