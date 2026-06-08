using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- Running Assignment 2 Test Cases ---\n");

        // تشغيل حالات الاختبار الخمسة مباشرة
        RunTest(1, 4, "urgent", "Delayed: Urgent sample too long");
        RunTest(1, 2, "urgent", "On Time: Urgent sample OK");
        RunTest(1, 7, "normal", "Delayed: Normal sample too long");
        RunTest(1, 4, "normal", "On Time: Normal sample OK");
        RunTest(1, 3, "unknown", "Error: Unknown type");

        Console.WriteLine("\n--- All Tests Executed Successfully! ---");
    }


    // دالة  لطباعة النتيجة 
    public static void RunTest(int start, int end, string type, string expected)
    {
        string result = CalculateHandlingTime(start, end, type);
        if (result == expected)
        {
            Console.WriteLine($"[PASS] Input: ({start}, {end}, '{type}') -> Result: \"{result}\"");
        }
        else
        {
            Console.WriteLine($"[FAIL] Expected: {expected}, but got: {result}");
        }
    }
}