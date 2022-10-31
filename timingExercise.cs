using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication2
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
    public class Program
    {
        static void Array(int[] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(1, 9999);
            }
        }
        static void maxMinArray(int[] arr)
        {
            int max = arr[0]; int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                else if(arr[i] < min)
                {
                    min = arr[i];
                }
            Console.Write(max+"\t");
            Console.WriteLine(min);
        }     
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int ran = 10000000;
            int[] arr = new int[ran];
            Array(arr);
            Timing time = new Timing();
            time.startTime();
            Console.Write("Phần tử lớn nhất và nhỏ nhất lần lượt là: "); 
            maxMinArray(arr);
            time.StopTime();
            Console.Write("Timing: "); Console.WriteLine(time.Result().TotalSeconds);
            Console.ReadLine();
        }
    }
}
