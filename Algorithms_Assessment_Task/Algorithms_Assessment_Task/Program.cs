using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Algorithms_Assessment_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> numbers = new List<int>();
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(@"E:\Swinburne\git repository\Algorithms-Task\Algorithms_Assessment_Task\Algorithms_Assessment_Task\unsorted_numbers.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    numbers.Add(Convert.ToInt32(line));
                }

                int[] intArray = numbers.ToArray();
                int[] InsertionSortedArray = (int[])intArray.Clone();
                int[] ShellSortedArray = (int[])intArray.Clone();

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Display array");
                Console.WriteLine("2) Insertion sort the array");
                Console.WriteLine("3) Shell sort the array");

                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                {
                    if (intArray.Count() > 0)
                    {
                        foreach (var itemint in intArray)
                        {
                            Console.WriteLine(itemint);
                        }
                    }
                }
                if (input.Key == ConsoleKey.D2)
                {
                    InsertionSort(InsertionSortedArray);
                    if (InsertionSortedArray.Count() > 0)
                    {
                        foreach (var itemint in InsertionSortedArray)
                        {
                            Console.WriteLine(itemint);
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("^ Insertion sorted list ^\n");
                    Console.WriteLine("Choose search method:");
                    Console.WriteLine("1) Run Linear Search");
                    Console.WriteLine("2) Run Binary Search\n");
                    
                    var input2 = Console.ReadKey();
                    if (input2.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter the value to search for using linear search: ");
                        var value1 = Console.ReadLine();
                        int intvalue1 = Convert.ToInt32(value1);
                        int result1 = LinearSearch(InsertionSortedArray, intvalue1);
                        if (result1 == -1)
                            Console.WriteLine("Number is not present in array");
                        else
                            Console.WriteLine("Number " + intvalue1 + " was found at index " + result1);
                    }
                    if (input2.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine("Enter the value to search for using binary search: ");
                        var value2 = Console.ReadLine();
                        int intvalue2 = Convert.ToInt32(value2);
                        int result2 = BinarySearch(InsertionSortedArray, intvalue2);
                        if (result2 == -1)
                            Console.WriteLine("Number is not present in array");
                        else
                            Console.WriteLine("Number " + intvalue2 + " was found at index " + result2);

                    }
                }
                if (input.Key == ConsoleKey.D3)
                {
                    ShellSort(ShellSortedArray);
                    if (ShellSortedArray.Count() > 0)
                    {
                        foreach (var itemint in ShellSortedArray)
                        {
                            Console.WriteLine(itemint);
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("^ Shell sorted list ^\n");
                    Console.WriteLine("Choose search method:");
                    Console.WriteLine("1) Run Linear Search");
                    Console.WriteLine("2) Run Binary Search\n");

                    var input2 = Console.ReadKey();
                    if (input2.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter the value to search for using linear search: ");
                        var value1 = Console.ReadLine();
                        int intvalue1 = Convert.ToInt32(value1);
                        int result1 = LinearSearch(ShellSortedArray, intvalue1);
                        if (result1 == -1)
                            Console.WriteLine("Number is not present in array");
                        else
                            Console.WriteLine("Number " + intvalue1 + " was found at index " + result1);
                    }
                    if (input2.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine("Enter the value to search for using binary search: ");
                        var value2 = Console.ReadLine();
                        int intvalue2 = Convert.ToInt32(value2);
                        int result2 = BinarySearch(ShellSortedArray, intvalue2);
                        if (result2 == -1)
                            Console.WriteLine("Number is not present in array");
                        else
                            Console.WriteLine("Number " + intvalue2 + " was found at index " + result2);

                    }
                }
            }
            Console.ReadLine();
        }
        static void InsertionSort(int[] data)
        {
            int n = data.Count();
            int i, j;
            for (i = 1; i < n; i++)
            {
                int item = data[i];
                int ins = 0;
                for (j = i - 1; j >= 0 && ins != 1;)
                {
                    if (item < data[j])
                    {
                        data[j + 1] = data[j];
                        j--;
                        data[j + 1] = item;
                    }
                    else ins = 1;
                }
            }
        }
        static void ShellSort(int[] data)
        {
            int n = data.Count();
            int gap = n / 2;
            int temp;

            while (gap > 0)
            {
                for (int i = 0; i + gap < n; i++)
                {
                    int j = i + gap;
                    temp = data[j];

                    while (j - gap >= 0 && temp < data[j - gap])
                    {
                        data[j] = data[j - gap];
                        j = j - gap;
                    }

                    data[j] = temp;
                }
                gap = gap / 2; 
            }
        }
        static int LinearSearch(int[] data, int x)
        {
            int n = data.Count();
            for(int i = 0; i < n; i++)
            {
                if (data[i] == x)
                    return i;
            }
            return -1;
        }
        static int BinarySearch(int[] data, int x)
        {
            int l = 0, r = data.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                if (data[m] == x)
                    return m;
                
                if (data[m] < x)
                    l = m + 1;
                
                else
                    r = m - 1;
            }
            return -1;
        }
    }
}
