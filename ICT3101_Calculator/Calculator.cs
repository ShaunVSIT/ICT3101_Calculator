using ICT3101_Calculator;

public class Calculator
{
    public double DoOperation(double num1, double num2, string op, double? num3 = null)
    {
        double result = double.NaN; // Default value
                                    // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = Add(num1, num2);
                break;
            case "s":
                result = Subtract(num1, num2);
                break;
            case "m":
                result = Multiply(num1, num2);
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                result = Divide(num1, num2);
                break;
            case "f":
                result = Factorial(num1);
                break;
            case "fi": // failure intensity
                if(!num3.HasValue)
                {
                    throw new ArgumentException("Third argument is required for failure intensity calculation.");
                }
                result = CalculateFailureIntensity(num1, num2, num3.Value);
                break;

            case "ef": // expected failures
                if(!num3.HasValue)
                {
                    throw new ArgumentException("Third argument is required for expected failures calculation.");
                }
                result = CalculateExpectedFailures(num1, num2, num3.Value);
                break;
        }
        return result;
    }
    public double Add(double num1, double num2)
    {
        return (num1 + num2);
    }

    public double Subtract(double num1, double num2)
    {
        return (num1 - num2);
    }
    public double Multiply(double num1, double num2)
    {
        return (num1 * num2);
    }
    public double Divide(double num1, double num2)
    {
        if (num1 == 0 && num2 == 0)
        {
            return 1; // Return 1 when 0/0
        }
        if (num2 == 0)
        {
            throw new ArgumentException("The second number cannot be zero.");
        }
        return (num1 / num2);
    }
    public double Factorial(double num)
    {
        if (num < 0)
            throw new ArgumentException("The number cannot be negative.");
        if (num == 0)
            return 1;
        double result = 1;
        for (int i = 1; i <= num; i++)
        {
            result *= i;
        }
        return result;
    }
    public double TriangleArea(double baseLength, double height)
    {
        if (baseLength < 0 || height < 0)
        {
            throw new ArgumentException("Base and height should be non-negative.");
        }

        return 0.5 * baseLength * height;
    }
    public double CircleArea(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Radius should be non-negative.");
        }

        return Math.PI * radius * radius;
    }
    public double UnknownFunctionA(int n, int k) //Permutation Formula
    {
        // Ensure valid inputs
        if (n < 0 || k > n)
        {
            throw new ArgumentException("Invalid inputs");
        }

        return Factorial(n) / Factorial(n - k);
    }
    public double UnknownFunctionB(int n, int r) //nCr
    {
        if (n < 0 || r < 0 || r > n)
        {
            throw new ArgumentException();
        }

        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }
    public double BinaryAdd(double p0, double p1)
    {
        // Treat the inputs as strings (binary representation)
        string binary1 = p0.ToString("0");
        string binary2 = p1.ToString("0");
        
        // Concatenate the binary strings
        string resultBinary = binary1 + binary2;
        
        // Convert the concatenated binary string to an integer
        return Convert.ToInt32(resultBinary, 2);  // Converts binary string to base-10 integer
    }
    public double CalculateMTBF(double operatingTime, double breakdowns)
    {
        if (breakdowns == 0) //no breakdowns
        {
            return operatingTime;
        }
        return operatingTime / breakdowns;
    }

    public double CalculateAvailability(double mtbf, double mttr)
    {
        return mtbf / (mtbf + mttr);
    }
    
    public double CalculateFailureIntensity(double initialIntensity, double observedFailures, double totalFailures)
    {
        return initialIntensity * (1 - (observedFailures / totalFailures));
    }
    
    public double CalculateExpectedFailures(double initialIntensity, double timeSinceFirst, double totalFailures)
    {
        return totalFailures * (1 - Math.Exp(-initialIntensity * timeSinceFirst / totalFailures));
    }
    // Method to calculate defect density
    public double CalculateDefectDensity(int defects, int loc)
    {
        if (loc == 0) // To avoid division by zero
            throw new ArgumentException("The number of lines of code cannot be zero.");

        return (double)defects / loc;
    }

    // Method to compute total SSI for successive releases
    public int ComputeTotalSSIForSuccessiveReleases(int prevSSI, int additionalSSI)
    {
        return prevSSI + additionalSSI;
    }
    public double GenMagicNum(double input, IFileReader? fileReader = null)
    {
        fileReader ??= new FileReader();
        double result = 0;
        int choice = Convert.ToInt16(input);
        string[] magicStrings = fileReader.Read("MagicNumbers.txt");
        if ((choice >= 0) && (choice < magicStrings.Length))
        {
            result = Convert.ToDouble(magicStrings[choice]);
        }
        result = (result > 0) ? (2 * result) : (-2 * result);
        return result;
    }
}