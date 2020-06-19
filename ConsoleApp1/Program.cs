using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program   
    {
        public static string flowHandling;

       [STAThread]
        static void Main(string[] args)
        {
            //На данный момент нумерация всех элементов в программе принята начиная с 0, и так написаны все циклы. При выводе в консоль и на графики нумерация  корректируется на начало с 1. 
            
            
            //System.Windows.Forms.Application.Run(new Form1());

            System.Console.BufferHeight = 500; //= 1000;//увеличим запас места в консоли, чтобы весь вывод мог уместиться



            System.Console.WriteLine("Учитывать мигрансткие потоки? Нажмите 0, если не надо");
            flowHandling = System.Console.ReadLine();//почему-то работает не совсем корректно для стран 3 и 4, если это поместить после инициализации всех структур и перед cultChange. Если поставить туда, то почему-то у тех стран даже при вводе 0 доли мигр и числ насел мигр не нулевые будут. А если поместить здесь, то все считается правильно. структуры не могут никак влиять на flowHandling вообще, но мб вывод от ф-ий структур как-то влияет на ReadLine()?



            //1. Инициализация структур:
            Functions.initializePopulationArray(ref Structs.populArray);   //Инициализация массива населения

            Functions.initializeTolStruct(ref Structs.toleranceStructure);     //Инициализация структуры матриц толерантности            

            for (int i = 0; i < State.numberOfCountries; i++) Structs.st[i] = new State();
            System.Console.WriteLine("initializeStateObjects - начальные значения:");
            Functions.initializeStateObjects(Structs.populArray, ref Structs.st);   //Инициализация массива объектов (стран)           

            Functions.initializeСultStruct(ref Structs.cultureStructure);       //Инициализация структуры векторов культур

            //Functions.initializeEduMatrix(ref Structs.eduMatrix);    //Инициализация матрицы образования


            Functions.initializeLists(Structs.cultureStructure, Structs.st, Structs.populArray);

            //2. Выполнение вычислений по тактам:
            Functions.change(Structs.cultureStructure, ref Structs.cultarrayList, Structs.st, ref Structs.populArrayList, Structs.populArray, Structs.toleranceStructure);
          


            System.Windows.Forms.Application.Run(new Form1()); 
        }

       
    }
}
