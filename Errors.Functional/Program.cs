using LanguageExt;
using static LanguageExt.Prelude;

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

        Either<string, User> userResult = CreateUser(inputData);

        Console.WriteLine(userResult.Match(
            Right: user => "User created: " + user.Name + ", " + user.Age + ", " + user.Email,
            Left: error => "User validation failed: " + error));
    }

    static Either<string, User> CreateUser(Dictionary<string, string> inputData)
    {
        Either<string, string> nameResult = ValidateName(inputData["name"]);
        Either<string, int> ageResult = ValidateAge(inputData["age"]);
        Either<string, string> emailResult = ValidateEmail(inputData["email"]);

        return nameResult
            .Bind(name => ageResult.Bind(age => emailResult.Map(email => new User(name, age, email))));
    }

    static Either<string, string> ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Left<string, string>("Name is required.");
        return Right<string, string>(name);
    }

    static Either<string, int> ValidateAge(string ageStr)
    {
        if (!int.TryParse(ageStr, out int age) || age < 18 || age > 99)
            return Left<string, int>("Age must be between 18 and 99.");
        return Right<string, int>(age);
    }

    static Either<string, string> ValidateEmail(string email)
    {
        if (!IsValidEmail(email))
            return Left<string, string>("Invalid email address.");
        return Right<string, string>(email);
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