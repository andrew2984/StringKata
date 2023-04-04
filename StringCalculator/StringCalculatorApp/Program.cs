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

        if (numbers.Length > 2 && numbers.Contains("\\"))
        {
            delimiter = numbers[2];
            numbers = numbers.Substring(4);
        }

        string[] stringArray = numbers.Split(delimiter, '\n');

        int sum = 0;

        foreach (var item in stringArray)
        {
            if (int.TryParse(item, out int x)) sum += x;
        }

        return sum;



    }
}