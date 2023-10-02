

// Pure function
static int AddPure(int a, int b)
{
    return a + b;
}

// Impure function
static int AddImpure(int a, int b)
{
    Console.WriteLine($"Adding {a} and {b}");
    return a + b;
}