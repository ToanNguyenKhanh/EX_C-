using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BTVN_buoi4
{
    internal class Program
    {
        public class Timing
        {
            TimeSpan startingTime;
            TimeSpan duration;
            public Timing()
            {
                startingTime = new TimeSpan(0);
                duration = new TimeSpan(0);
            }
            public void StopTime()
            {
                duration =
                Process.GetCurrentProcess().Threads[0].
                UserProcessorTime.
                Subtract(startingTime);
            }
            public void startTime()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                startingTime =
                Process.GetCurrentProcess().Threads[0].
                UserProcessorTime;
            }
            public TimeSpan Result()
            {
                return duration;
            }
        }
        static int SeqSearch(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == value)
                    return i;
            return -1;
        }
        static int SeqLastSearch(int[] arr, int value)
        {
            int t = -1;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == value)
                    t = i;
            return t;
        }
        static List<int> SeqMultiSearch(int[] arr, int value)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == value)
                    result.Add(i);
            return result;
        }
        static int RecuSearch(int[] arr, int from, int value)
        {
            if (arr.Length == 0 || from >= arr.Length)
                return -1;
            else
            {
                if (arr[from] == value)
                    return from;
                else
                    return RecuSearch(arr, from + 1, value);
            }
        }
        static int SenSearch(int[] A, int value)
        {
            int x = A[A.Length - 1];
            A[A.Length - 1] = value;
            int i = 0;
            while (A[i] != value)
                i++;
            A[A.Length - 1] = x;
            if (A[A.Length - 1] == value || i < A.Length - 1)
                return i;
            return -1;
        }
        public static int BinSearch(int[] arr, int T)
        {
            int L = 0;
            int R = arr.Length - 1;
            while (L <= R)
            {
                int m = (L + R) / 2;
                if (arr[m] == T)
                    return m;
                else if (arr[m] < T)
                    L = m + 1;
                else
                    R = m - 1;
            }
            return -1;
        }
        static void Array(int[] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(1, 10);
            }
        }
        static void sortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int ran = 10000;
            int[] arr = new int[ran];
            int value = 9;
            Array(arr);
            Timing time = new Timing();

            time.startTime();
            sortArray(arr);
            time.StopTime();
            Console.Write("Timing Exchange Sort: "); Console.WriteLine(time.Result().TotalSeconds);

            time.startTime();
            SeqSearch(arr, value);
            time.StopTime();
            Console.Write("Timing SeqSearch: "); Console.WriteLine(time.Result().TotalSeconds);

            time.startTime();
            SeqLastSearch(arr, value);
            time.StopTime();
            Console.Write("Timing SeqLastSearch: "); Console.WriteLine(time.Result().TotalSeconds);

            time.startTime();
            SeqMultiSearch(arr, value);
            time.StopTime();
            Console.Write("Timing SeqMultiSearch: "); Console.WriteLine(time.Result().TotalSeconds);

            time.startTime();
            BinSearch(arr, value);
            time.StopTime();
            Console.Write("Timing BinSearch: "); Console.WriteLine(time.Result().TotalSeconds);

            time.startTime();
            SenSearch(arr, value);
            time.StopTime();
            Console.Write("Timing SenSearch: "); Console.WriteLine(time.Result().TotalSeconds);

            time.startTime();
            RecuSearch(arr, 1, value);
            time.StopTime();
            Console.Write("Timing RecuSearch: "); Console.WriteLine(time.Result().TotalSeconds);

            Console.ReadKey();
        }
    }
}
