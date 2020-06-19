using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MethodsClass1
    {

        public static void arrOut(double[,] arr)
        {
            for (int l = 0; l < arr.GetLength(0); l++)
            {
                for (int m = 0; m < arr.GetLength(1); m++)
                {
                    System.Console.Write("{0} ", arr[l, m]);
                }
                System.Console.Write("\n"); //после завершения внутр цикла - чтобы вывод был по строкам
            }

            System.Console.WriteLine();
        }


        public static void ar2()
        {
            int[,,] array3Da = new int[2, 2, 3]     {                                       //пар-пед
                                                        {   {1, 2, 3}, {4, 5, 6}    },   //line 1 (consisting of two vectors standing up)
                                                        {   {7, 8, 9}, {10, 11, 12} }   //line 2 (-//-)
                                                    };


            System.Console.WriteLine(array3Da[1, 0, 1]);
            System.Console.WriteLine(array3Da[1, 1, 2]);
        }


        public static void ar3(int i, int j, int k)
        {
            int[,,] array3D = new int[i, j, k];
            //for ()    //fill the structure at first with the same value everywhere - ex 10
            //{

            //}
        }


    }
}
