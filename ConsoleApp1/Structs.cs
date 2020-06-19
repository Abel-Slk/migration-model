using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Structs //Класс структур, используемых в программе
    {

        public static State[] st = new State[State.numberOfCountries]; //Массив объектов (стран)   
        

        public static double[,,,] populArray = new double[5, 3, 2, 5];  //Массив населения

        public static double[,,] cultureStructure = new double[5, 5, 5];    //Cтруктура векторов культур в каждой из стран        

        public static double[,,] toleranceStructure = new double[5, 5, 5]; //Cтруктура из "матриц толерантности": каждой стране соответсвует своя матрицы толерантности, элементы которой отражают толерантность каждой культуры в стране ко всем остальным культурам в стране.

        public static double[,] eduMatrix = new double[2, 2]; //Матрица образования  

        //Как альтернативный вариант дизайна - более интуитивный (и, возможно, лучше масштабируемого?) - сделать
        //populArray, cultureStructure и toleranceStructure на размерность меньше и поместить их в класс State, те
        //сделать св-вами одного гос-ва. А потом уже снова ЗДЕСЬ (в классе Structs) сделать массив из таких структур, 
        //где уже будет инф-ция о всех 
        //странах: 
        //populArrays = [populArray0, populArray1, ...];
        //cultureStructures = [cultureStructure0, cultureStructure1, ...];
        //При таком подходе мб получится динамически задавать кол-во стран! (Сейчас оно тоже задается в 
        //numberOfCountries, но в структурах типа populArray сейчас все равно приходится вводить число стран вручную!)


        //Списки - для хранения структур по тактам:       

        public static List<double[]> populArrayList = new List<double[]>(); //список из векторов общих численностей населения всех стран по тактам (один эл-т - один в-р, соответствующий одному такту)
        public static List<double[,]> populByCultsArrayList = new List<double[,]>();
        public static List<double[,]> populByAgeArrayList = new List<double[,]>();

        public static List<double[,,]> cultarrayList = new List<double[,,]>();  //Список из массивов - для хранения культурной структуры по тактам: один элемент списка представляет собой структуру культур в момент времени, соответствующий номеру данного элемента 

        public static List<double[]> eduArrayList = new List<double[]>();

        public static List<double[]> standOfLivArrayList = new List<double[]>();

        public static List<double[]> instabIndexArrayList = new List<double[]>();


        //public static List<State[]> statesArrayList = new List<State[]>();  //Список из массивов объектов (стран) - для хранения их данных по тактам -- не использую, тк получается трудно реализовать

    }
}
