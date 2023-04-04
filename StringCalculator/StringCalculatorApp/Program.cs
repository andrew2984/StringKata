using System.Globalization;

namespace StringCalculatorApp;

public class Program
{
    static void Main()
    {
        //int result = Add("//[*][%]\n1*2%3");
    }

    public static int Add(string numbers)
    {
        if (numbers == "") return 0;

        (string[] delimiters, string newNumbers) = GetDelimiter(numbers);
        string[] stringArray = newNumbers.Split(delimiters,StringSplitOptions.None); //This means use default option when splitting strings. 

        int[] numberArray = ConvertStringToIntArray(stringArray);
        DoesNumberArrayContainNegatives(numberArray);
        
        int sum = 0;
        foreach (var num in numberArray)
        {
            if (num < 1000) sum += num;
        }
        return sum;
    }

    private static (string[] newDelimiter, string newNumbers) GetDelimiter(string numbers)
    {
        List<string> delims = new List<string>() { "\n" };
        if(numbers.Contains("]["))
        {
            string[] newSplitArray = numbers.Split("]\n");
            numbers = newSplitArray[1];
            string[] delimArray = newSplitArray[0].Split(new string[] {"//[","[","]"},StringSplitOptions.None);
            foreach (var item in delimArray)
            {
                delims.Add(item);
            }
        }
        else if (numbers.Contains("//["))
        {
            string[] newSplitArray = numbers.Split("]\n");
            delims.Add(newSplitArray[0].Substring(3));
            numbers = newSplitArray[1];
        }
        else if (numbers.Contains("//"))
        {
            delims.Add(numbers[2].ToString());
            numbers = numbers.Substring(4);
        }
        else
        {
            delims.Add(",");
        }
        return (delims.ToArray(), numbers);
    }

    private static int[] ConvertStringToIntArray(string[] inputStringArray)
    {
        int[] numberArray = Array.ConvertAll(inputStringArray, s => int.TryParse(s, out int x) ? x : 0);
        return numberArray;
    }

    private static void DoesNumberArrayContainNegatives(int[] inputNumberArray)
    {
        string message = "negatives not allowed";
        bool containsNegative = false;
        foreach (var num in inputNumberArray)
        {
            if (num < 0)
            {
                containsNegative = true;
                message += " " + num;
            };
        }
        if (containsNegative) throw new ArgumentOutOfRangeException(message);
    }
}