namespace StringCalculatorApp;

public class Program
{
    static void Main()
    {
    }

    public static int Add(string numbers)
    {
        if (numbers == "") return 0;

        char delimiter = ',';

        if (numbers.Contains("//"))
        {
            delimiter = numbers[2];
            numbers = numbers.Substring(4);
        }

        string[] stringArray = numbers.Split(delimiter, '\n');

        int sum = 0;
        bool foundANegativeValue = false;
        string message = "negatives not allowed";

        foreach (var item in stringArray)
        {
            if (int.TryParse(item, out int x)) 
            {
                if (x < 0)
                {
                    foundANegativeValue = true;
                    message += " " + item;
                }
                else if (x < 1000) sum += x;
            }
        }
        if(foundANegativeValue)
        {
            message.TrimEnd();
            throw new ArgumentOutOfRangeException(message);
        }

        return sum;



    }
}