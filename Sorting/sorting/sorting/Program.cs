using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    enum FillType
    {
        Increment,
        Decrement,
        Random
    }
    abstract class Sort
    {
        protected int[] array;
        protected int arrayLength;

        public Sort(int length)
        {
            this.arrayLength = length;
        }

        public int Transactions { get; protected set; }

        public int Comparisions { get; protected set; }

        public void Fill(FillType type)
        {
            array = new int[arrayLength];

            switch (type)
            {
                case FillType.Increment:
                    FillIncrement();
                    break;
                case FillType.Decrement:
                    FillDecrement();
                    break;
                case FillType.Random:
                    FillRandom();
                    break;
                default:
                    break;
            }
        }

        public abstract void Sorting();

        public int GetChecksum()
        {
            int summ = 0;

            for (int i = 0; i < array.Length; i++)
            {
                summ += array[i];
            }

            return summ;
        }

        public int GetSeriesCount()
        {
            int series = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    series++;
                }
            }

            return series;
        }

        public void Print()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
        }

        void FillIncrement()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
        }

        void FillDecrement()
        {
            int j = array.Length - 1;

            for (int i = 0; i < array.Length; i++, j--)
            {
                array[i] = j;
            }
        }

        void FillRandom()
        {
            var rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-100, 100);
            }

        }
    }
}
