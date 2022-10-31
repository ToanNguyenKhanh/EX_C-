using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Programming
{
    internal class Program
    {
        static object sum<T>(object var1, object var2)
        {
            T sum;
            sum = (dynamic)var1 + (dynamic)var2;
            return sum;
        }
        static void sumarray<T>(T[] arr1, T[] arr2, out T[] arr3)
        {
            arr3 = new T[5];
            for (int i = 0; i < 5; i++)
            {
                arr3[i] = (dynamic)arr1[i] + arr2[i];
            }            
        }
        static void showMatrix(int[] k)
        {            
            for (int i = 0; i <k.Length; i++)
            {
                Console.Write(k[i] + " ");
            }
        }    
        static void Main(string[] args)
        {
            Console.WriteLine("EX 1:");
            Console.OutputEncoding = Encoding.UTF8;
            int a = 5, b = 6;
            float c = 13.5f, d = 34.6f;
            string e = "Hello", f = " World";
            int[] g = { 1, 2, 3, 4, 5 };
            int[] h = { 6, 7, 8, 9, 10 };            
            int[] k = new int[5];             
            Console.WriteLine("{0} + {1} = {2}", a, b, sum<int>(a, b));
            Console.WriteLine("{0} + {1} = {2}", c, d, sum<float>(c, d));
            Console.WriteLine("{0} + {1} = {2}", e, f, sum<string>(e, f));
            sumarray<int>(g,h,out k);
            Console.Write("Mảng g: "); showMatrix(g);
            Console.Write("Mảng h: "); showMatrix(h);
            Console.Write("Mảng k = g + h = "); showMatrix(k);
            Console.ReadLine();
        }
    }
}
