using System;

namespace Targem.List
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new MyList<string>();

            // Add
            Console.WriteLine("Populate MyList");
            test.Add("one");
            test.Add("two");
            test.Add("three");
            test.Add("four");
            test.Add("five");
            test.Add("six");
            test.Add("seven");
            test.Add("eight");
            test.Add("nine");
            foreach (var t in test)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            // Count
            Console.WriteLine("Elements count");
            Console.WriteLine($"Index of \"seven\":  {test.Count}");
            Console.WriteLine();

            // Remove
            Console.WriteLine("Remove elements from the list");
            test.Remove("six");
            test.RemoveAt(8);
            foreach (var t in test)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            // Insert
            Console.WriteLine("Insert an element into the list");
            test.Insert(4, "number");
            foreach (var t in test)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            // Contains
            Console.WriteLine("Check for specific elements in the list");
            Console.WriteLine($"List contains \"three\": {test.Contains("three")}");
            Console.WriteLine($"List contains \"ten\": {test.Contains("ten")}");
            Console.WriteLine();

            // Index
            Console.WriteLine("Index of element");
            Console.WriteLine($"Index of \"seven\": {test.IndexOf("seven")}");
            Console.WriteLine();

            // Iterator
            Console.WriteLine("Get elements of the list by index");
            Console.WriteLine($"Get [1]: {test[1]}");
            Console.WriteLine($"Get [3]: {test[3]}");
            Console.WriteLine($"Get [5]: {test[5]}");
            Console.WriteLine();

            // CopyTo
            Console.WriteLine("Copy to array");
            var array = new string[10];
            test.CopyTo(array, 2);
            foreach (var a in array)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();

            //
            Console.ReadKey();
        }
    }
}
