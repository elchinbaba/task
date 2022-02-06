using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        int isthere(int num, ref int[] array, int length)
        {
            for(int i = 0; i < length; i++)
            {
                if (num == array[i])
                {
                    return i;
                }
            }
            return -1;
        }

        void swap(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }

        static void Main(string[] args)
        {
            Console.Write("N = ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[] A = new int[N];
            int[] V = new int[N];
            int[] C = new int[N];
            Random random = new Random();
            Program program = new Program();
            int Hmd = 0;
            int isit;
            for (int i = 0; i < N; i++)
            {
                A[i] = random.Next(0,20);
                isit = program.isthere(A[i], ref V, Hmd);
                if (isit == -1)
                {
                    V[Hmd] = A[i];
                    C[Hmd] = 1;
                    Hmd++;
                }
                else
                    C[isit]++;
            }

            for (int i = 0; i < Hmd; i++)
            for (int k = 0; k < Hmd - 1; k++)
            {
                if (V[k] > V[k+1])
                {
                    program.swap(ref V[k], ref V[k + 1]);
                    program.swap(ref C[k], ref C[k + 1]);
                }
            }

            int Pos = 0;

            for (int i = 0; i < Hmd; i++)
            {
                for (int j = Pos; j < Pos + C[i]; j++)
                    A[j] = V[i];
                Pos += C[i];
            }

            for (int i = 0; i < N; i++) Console.Write("{0} ", A[i]);
            Console.WriteLine();
            for (int i = 0; i < Hmd; i++) Console.Write("{0} ", V[i]);
            Console.WriteLine();
            for (int i = 0; i < Hmd; i++) Console.Write("{0} ", C[i]);
            Console.WriteLine();

            Console.WriteLine("Press enter to close...");
            Console.ReadKey();
            return;
        }
    }
}
