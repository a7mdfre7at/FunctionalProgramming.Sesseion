// Function 1: Double a number
Func<int, int> doubleNumber = x => x * 2;

// Function 2: Add 3 to a number
Func<int, int> addThree = x => x + 3;

// Apply Function 1 and then Function 2
int result = addThree(doubleNumber(5));

Console.WriteLine("Result: " + result); // Output: 13



//// Function 1: Double a number
//Func<int, int> doubleNumber = x => x * 2;

//// Function 2: Add 3 to a number
//Func<int, int> addThree = x => x + 3;

//// Function composition: Combine Function 1 and Function 2
//Func<int, int> composedFunction = x => addThree(doubleNumber(x));

//int result = composedFunction(5);

//Console.WriteLine("Result: " + result); // Output: 13
