using System;

namespace BigONotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 10, 15, 20, 25 };

            //O(1) - Constant
            int num = arr[0];

            //O(n) - Liner
            foreach (var item in arr)
            {
                if (item == 36)
                {
                    break;
                }
            }


            //O(n kv)
            int[] arr1 = { 45, 77, 5, 10, 15, 20, 25 };
            int[] arr2 = { 45, 30, 77, 20, 25 };

            int count = 0;
            foreach (var item1 in arr1)
            {
                foreach (var item2 in arr2)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
