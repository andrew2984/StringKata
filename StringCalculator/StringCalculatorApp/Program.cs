namespace StringCalculatorApp;

public class Program
{
    static void Main()
    {
    }

    public static int Add(string numbers)
    {
        if (numbers == "") return 0;
        string[] stringArray = numbers.Split(',','\n');
        int sum = 0;
        foreach (var item in stringArray)
        {
            sum += Int32.Parse(item);
        }
        return sum;
    }
}