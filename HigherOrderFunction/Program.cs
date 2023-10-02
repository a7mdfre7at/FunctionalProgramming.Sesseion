
// Create a list of numbers
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Use higher-order functions to perform various operations on the list

// 1. Map: Double each number in the list
List<int> doubledNumbers = Map(numbers, x => x * 2);
Console.WriteLine("Doubled Numbers: " + string.Join(", ", doubledNumbers));

// 2. Filter: Select even numbers from the list
List<int> evenNumbers = Filter(numbers, x => x % 2 == 0);
Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

// 3. Reduce: Calculate the sum of all numbers in the list
int sum = Reduce(numbers, (acc, x) => acc + x, 0);
Console.WriteLine("Sum of Numbers: " + sum);


// Higher-order function to map a function over a list
static List<TOutput> Map<TInput, TOutput>(List<TInput> list, Func<TInput, TOutput> func)
{
    List<TOutput> result = new List<TOutput>();
    foreach (var item in list)
    {
        result.Add(func(item));
    }
    return result;
}

// Higher-order function to filter a list based on a predicate
static List<T> Filter<T>(List<T> list, Func<T, bool> predicate)
{
    List<T> result = new List<T>();
    foreach (var item in list)
    {
        if (predicate(item))
        {
            result.Add(item);
        }
    }
    return result;
}

// Higher-order function to reduce a list to a single value
static TOutput Reduce<TInput, TOutput>(List<TInput> list, Func<TOutput, TInput, TOutput> func, TOutput initialValue)
{
    TOutput accumulator = initialValue;
    foreach (TInput? item in list)
    {
        accumulator = func(accumulator, item);
    }
    return accumulator;
}