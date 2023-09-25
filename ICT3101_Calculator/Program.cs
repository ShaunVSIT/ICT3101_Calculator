public class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        Calculator _calculator = new Calculator();
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");
        while (!endApp)
        {
            string numInput1 = "";
            string numInput2 = "";
            double result = 0;

            string op;

            while (true)
            {
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tf - Factorial");  // Add this line for factorial option
                Console.Write("Your option? ");

                op = Console.ReadLine() ?? string.Empty;

                // Check if the input is one of the allowable options
                if (new[] { "a", "s", "m", "d", "f" }.Contains(op))
                {
                    break; // exit the loop if a valid option is provided
                }

                Console.WriteLine("Invalid option. Please select a valid operation.");
            }

            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine() ?? string.Empty;
            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput1 = Console.ReadLine() ?? string.Empty;
            }

            // Only ask for second number if the operation isn't factorial
            if (op != "f")
            {
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine() ?? string.Empty;
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine() ?? string.Empty;
                }

                try
                {
                    result = _calculator.DoOperation(cleanNum1, cleanNum2, op);
                    DisplayResult(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                }
            }
            else
            {
                try
                {
                    result = _calculator.Factorial(cleanNum1); // Use the factorial method
                    DisplayResult(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                }
            }

            Console.WriteLine("------------------------\n");
            Console.Write("Press 'q' and Enter to quit the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "q") endApp = true;
            Console.WriteLine("\n"); // Friendly linespacing.
        }
        return;
    }

    // Extracted method to display the result to avoid repetition
    private static void DisplayResult(double result)
    {
        if (double.IsNaN(result))
        {
            Console.WriteLine("This operation will result in a mathematical error.\n");
        }
        else
        {
            Console.WriteLine("Your result: {0:0.##}\n", result);
        }
    }
}
