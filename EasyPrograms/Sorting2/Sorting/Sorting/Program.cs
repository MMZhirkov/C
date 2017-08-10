using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Bubble sort
            ////enter numbers
            //int[] nums = new int[7];
            //Console.WriteLine("Введите 7 чисел");
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    Console.WriteLine("{0}-е число: ", i + 1);
            //    nums[i] = Int32.Parse(Console.ReadLine());
            //}
            ////sort
            //int temp;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = i+1; j < nums.Length; j++)
            //    {
            //        if (nums[i]>nums[j])
            //        {
            //             temp = nums[i];
            //            nums[i] = nums[j];
            //            nums[j] = temp;
            //        }
            //    }
            //}
            #endregion
            #region Find premax element
            int[] nums = new int[7];
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine("Enter {0} -number", i);
                nums[i] = Int32.Parse(Console.ReadLine());
            }
            int max;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]>nums[j])
                    {
                        max = nums[i];
                        nums[i] = nums[j];
                        nums[j] = max;
                    }                    
                }
            }
            int k = nums.Length-1;
            Console.WriteLine(nums[k]);
            #endregion
            Console.ReadKey();
        }
    }
}
