class Program
{
    static void Main()
    {
        var inputData = new Dictionary<string, string>
        {
            { "name", "John" },
            { "age", "25" },
            { "email", "invalid-email" }
        };

        try
        {
            var user = CreateUser(inputData);
            Console.WriteLine("User created: " + user.Name + ", " + user.Age + ", " + user.Email);
        }
        catch (UserValidationException ex)
        {
            Console.WriteLine("User validation failed: " + ex.Message);
        }
    }

    static User CreateUser(Dictionary<string, string> inputData)
    {
        string name = inputData["name"];
        int age = int.Parse(inputData["age"]);
        string email = inputData["email"];

        if (string.IsNullOrWhiteSpace(name))
            throw new UserValidationException("Name is required.");

        if (age < 18 || age > 99)
            throw new UserValidationException("Age must be between 18 and 99.");

        if (!IsValidEmail(email))
            throw new UserValidationException("Invalid email address.");

        return new User(name, age, email);
    }

    static bool IsValidEmail(string email)
    {
        // Simplified email validation logic
        return email.Contains("@");
    }
}

class User
{
    public string Name { get; }
    public int Age { get; }
    public string Email { get; }

    public User(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
    }
}

class UserValidationException : Exception
{
    public UserValidationException(string message) : base(message)
    {
    }
}