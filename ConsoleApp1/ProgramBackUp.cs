//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.BufferHeight = 500; //увеличим запас места в консоли, чтобы весь вывод мог уместиться


//            //Массив населения:
//            double[,,,] populArray = new double[5, 3, 2, 5];

//            Functions.initializePopulationArray(ref populArray);



//            //Массив объектов (стран):
//            State[] st = new State[State.numberOfCountries];
//            for (int i = 0; i < State.numberOfCountries; i++) st[i] = new State();

//            initializeStateObjects(populArray, ref st);


//            //Матрица образования: 
//            double[,] eduMatrix = new double[2, 2];

//            initializeEduMatrix(ref eduMatrix);


//            //Cтруктура векторов культур в каждой из стран: 
//            double[,,] cultureStructure = new double[5, 5, 5];

//            initializeСultStruct(ref cultureStructure);
//            iteratedChange(ref cultureStructure);


//        }

//        //static void initializePopulationArray(ref double[,,,] populationArray) //Задаем массив населения всех стран
//        //{

//        //    //Создание 4D-массива населения всех стран: пар-пед из пяти 3D-массивов (пар-педов) размерностью 3*2*5, каждый из которых соответствует одной стране. Размерности 3D-массива населения (пар-педа): возраст (3 группы - дети, взрослые, старики), образование (2 уровня), культура (5 уровней -по числу стран):
//        //    populationArray = new double[5, 3, 2, 5]
//        //    {
//        //         {//страна 0:
//        //             {//"строка" 0 (возраст 0):          
//        //                 { 5.0,  0.0,  0.0,  0.0,  0.0 },   //столбец 0 строки 0 (образование 0 возраста 0); внутри содержит вектор-столбец численностей населения по культурам (5 элементов) для данного образования и данного возраста. Будем считать, что изначально каждая страна в каждом таком векторе имеет только одно ненулевую численность - для своей культуры. Пусть изначально эта численность в стране 0 везде равна 5 у.е., в стране 1 - 10 у.е. и т.д. (в каждой след стране на 5 у.е. больше)
//        //                 { 5.0,  0.0,  0.0,  0.0,  0.0 },
//        //             },
//        //             {//строка 1:          
//        //                 { 5.0,  0.0,  0.0,  0.0,  0.0 },   
//        //                 { 5.0,  0.0,  0.0,  0.0,  0.0 },
//        //             },
//        //             {//строка 2:          
//        //                 { 5.0,  0.0,  0.0,  0.0,  0.0 },  
//        //                 { 5.0,  0.0,  0.0,  0.0,  0.0 },
//        //             }
//        //         },

//        //         {//страна 1:
//        //            {//строка 0:          
//        //                { 0.0,  10.0,  0.0,  0.0,  0.0 },   
//        //                { 0.0,  10.0,  0.0,  0.0,  0.0 },
//        //            },
//        //            {//строка 1:          
//        //                { 0.0,  10.0,  0.0,  0.0,  0.0 },  
//        //                { 0.0,  10.0,  0.0,  0.0,  0.0 },
//        //            },
//        //            {//строка 2:          
//        //                { 0.0,  10.0,  0.0,  0.0,  0.0 },   
//        //                { 0.0,  10.0,  0.0,  0.0,  0.0 },
//        //            }
//        //        },

//        //        {//страна 2:
//        //            {//строка 0:          
//        //                { 0.0,  0.0,  15.0,  0.0,  0.0 },
//        //                { 0.0,  0.0,  15.0,  0.0,  0.0 },
//        //            },
//        //            {//строка 1:          
//        //                { 0.0,  0.0,  15.0,  0.0,  0.0 },
//        //                { 0.0,  0.0,  15.0,  0.0,  0.0 },
//        //            },
//        //            {//строка 2:          
//        //                { 0.0,  0.0,  15.0,  0.0,  0.0 },
//        //                { 0.0,  0.0,  15.0,  0.0,  0.0 },
//        //            }
//        //        },

//        //        {//страна 3:
//        //            {//строка 0:          
//        //                { 0.0,  0.0,  0.0,  20.0,  0.0 },
//        //                { 0.0,  0.0,  0.0,  20.0,  0.0 },
//        //            },
//        //            {//строка 1:          
//        //                { 0.0,  0.0,  0.0,  20.0,  0.0 },
//        //                { 0.0,  0.0,  0.0,  20.0,  0.0 },
//        //            },
//        //            {//строка 2:          
//        //                { 0.0,  0.0,  0.0,  20.0,  0.0 },
//        //                { 0.0,  0.0,  0.0,  20.0,  0.0 },
//        //            }
//        //        },

//        //        {//страна 4:
//        //            {//строка 0:          
//        //                { 0.0,  0.0,  0.0,  0.0,  25.0 },
//        //                { 0.0,  0.0,  0.0,  0.0,  25.0 },
//        //            },
//        //            {//строка 1:          
//        //                { 0.0,  0.0,  0.0,  0.0,  25.0 },
//        //                { 0.0,  0.0,  0.0,  0.0,  25.0 },
//        //            },
//        //            {//строка 2:          
//        //                { 0.0,  0.0,  0.0,  0.0,  25.0 },
//        //                { 0.0,  0.0,  0.0,  0.0,  25.0 },
//        //            }
//        //        },

//        //    };

//        //    arrOut4D(populationArray);
//        //}

//        static void initializeEduMatrix(ref double[,] eduMat)
//        {
//            double e11 = 0.5;   //значения коэф-тов пока задал произвольно - а должны быть какие?
//            double e21 = 0.5;
//            double e22 = 0.5;

//            eduMat = new double[2, 2]
//            {
//                { e11, 0   },
//                { e21, e22 }
//            };

//        }


//        static void initializeСultStruct(ref double[,,] cultStruct) // Задаем исходную структуру векторов культур в каждой из стран. 
//        {

//            //В каждой стране вектор с номером, совпадающим с номером страны, является вектором своей культуры, а остальные векторы опписывают культуры мигрантов. Каждой стране соответсвует одна "строка" массива (куба):
//            cultStruct = new double[5, 5, 5] {
//                                              {//"строка" 0 (страна 0):          
//                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },   //что в столбце 0 строки 0 - те вектор из пяти эл-тов
//                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
//                                              },

//                                              {//строка 1:
//                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
//                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
//                                              },

//                                              {
//                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
//                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
//                                              },

//                                              {
//                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
//                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
//                                              },

//                                               {
//                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
//                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
//                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
//                                              }
//                                    };




//            System.Console.WriteLine("-----------------------------В исходный момент:-----------------------------");
//            arrOut3D(cultStruct);
//            MatVekKulStOut(cultStruct);
//        }





//        static void initializeStateObjects(double[,,,] arr, ref State[] state) //рассчитаем значения всех свойств каждого объекта (государства)
//        {
//            populationCount(arr, state);
//            educCount(arr, state);
//            productionCalculation(arr, state);
//            consumptionCalculation(arr, state);
//            shareOfMigrantsCalculation(arr, state);
//            toleranceOfMigrantsCalculation(arr, state);
//            socialConditionsConsumCalculation(arr, state);
//            socialConditionsMigCalculation(arr, state);
//            socialConditionsCalculation(arr, state);
//            desireToBeInCalculation(arr, state);
//            flowCapacityCalculation(arr, state);
//            flowSizeCalculation(arr, state);


//        }

//        static void populationCount(double[,,,] arr, State[] state)    //подсчет населения
//        {
//            double[] sum = new double[5];

//            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
//            {
//                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
//                {
//                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
//                    {
//                        for (int k = 0; k < arr.GetLength(3); k++)  //пробегаем все культуры
//                        {
//                            sum[s] += arr[s, i, j, k];
//                        }
//                    }
//                }
//                state[s].population = sum[s];
//                System.Console.WriteLine("Общая численность населения в стране {0}:   {1}", s, state[s].population);
//            }
//            System.Console.WriteLine();
//        }

//        static void educCount(double[,,,] arr, State[] state)
//        {
//            double[] sumOfEducated = new double[5];

//            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
//            {
//                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
//                {
//                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
//                    {
//                        if (j == 1)  //берем только образование уровня 1 (те наличие высшего образование)
//                        {
//                            for (int k = 0; k < arr.GetLength(3); k++)  //пробегаем все культуры
//                            {
//                                sumOfEducated[s] += arr[s, i, j, k];
//                            }
//                        }
//                    }
//                }
//                state[s].education = sumOfEducated[s];
//                System.Console.WriteLine("Общая численность людей с высшим образованием в стране {0}:   {1}", s, state[s].education);
//            }
//            System.Console.WriteLine();
//        }


//        static void productionCalculation(double[,,,] arr, State[] state)
//        {
//            double a = 0.5; //некоторый коэф-т 

//            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
//            {

//                state[s].production = a * state[s].education;
//                System.Console.WriteLine("Уровень производственных мощностей в стране {0}:   {1}", s, state[s].production);
//            }
//            System.Console.WriteLine();
//        }



//        static void consumptionCalculation(double[,,,] arr, State[] state)
//        {
//            for (int s = 0; s < arr.GetLength(0); s++)
//            {
//                state[s].consumption = state[s].production / state[s].population;
//                System.Console.WriteLine("Уровень потребления в стране {0}:   {1}", s, state[s].consumption);
//            }
//            System.Console.WriteLine();
//        }


//        static void shareOfMigrantsCalculation(double[,,,] arr, State[] state)
//        {
//            double[] sumOfMig = new double[5];

//            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
//            {
//                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
//                {
//                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
//                    {
//                        for (int k = 0; k < arr.GetLength(3); k++)  //пробегаем все культуры
//                        {
//                            if (k != s) sumOfMig[s] += arr[s, i, j, k];  //берем только чужие для данной страны культуры
//                        }
//                    }
//                }
//                state[s].shareOfMigrants = sumOfMig[s] / state[s].population;
//                System.Console.WriteLine("Общая численность мигрантов в стране {0}:   {1}", s, state[s].shareOfMigrants);
//            }
//            System.Console.WriteLine();
//        }

//        static void toleranceOfMigrantsCalculation(double[,,,] arr, State[] state)
//        {
//            double tol = 0.0;

//            for (int s = 0; s < arr.GetLength(0); s++)
//            {
//                state[s].toleranceOfMigrants = tol;
//                tol++;
//                System.Console.WriteLine("Уровень толерантности к мигрантам в стране {0}:   {1}", s, state[s].toleranceOfMigrants);
//            }
//            System.Console.WriteLine();
//        }

//        static void socialConditionsConsumCalculation(double[,,,] arr, State[] state)
//        {
//            double a = 0.7; //некоторый коэф-т 
//            double b = 0.3; //некоторый коэф-т 

//            for (int s = 0; s < arr.GetLength(0); s++)
//            {

//                state[s].socialConditionsConsum = (a * state[s].consumption) / (b + a * state[s].consumption);
//                System.Console.WriteLine("Характеристика недовольства уровнем потребления в стране {0}:   {1}", s, state[s].socialConditionsConsum);
//            }
//            System.Console.WriteLine();
//        }

//        static void socialConditionsMigCalculation(double[,,,] arr, State[] state)
//        {
//            for (int s = 0; s < arr.GetLength(0); s++)
//            {
//                state[s].socialConditionsMig = (1 / Math.PI) * ((Math.PI / 2) - Math.Atan(state[s].shareOfMigrants - state[s].toleranceOfMigrants));
//                System.Console.WriteLine("Характеристика уровня недовольства мигрантами в стране {0}:   {1}", s, state[s].socialConditionsMig);
//            }
//            System.Console.WriteLine();
//        }

//        static void socialConditionsCalculation(double[,,,] arr, State[] state)
//        {
//            for (int s = 0; s < arr.GetLength(0); s++)
//            {
//                state[s].socialConditions = state[s].socialConditionsConsum * state[s].socialConditionsMig;
//                System.Console.WriteLine("Общая характеристика уровня недовольства в стране {0}:   {1}", s, state[s].socialConditions);
//            }
//            System.Console.WriteLine();
//        }

//        static void desireToBeInCalculation(double[,,,] arr, State[] state)
//        {
//            double a = 0.5; //нек коэф-т пропорциональности

//            for (int s = 0; s < State.numberOfCountries; s++)
//            {
//                for (int d = 0; d < State.numberOfCountries; d++)
//                {
//                    if (s == d)
//                    {
//                        state[s].desireToBeIn[s] = a * state[s].production * state[s].socialConditions;
//                    }
//                    else state[s].desireToBeIn[d] = state[d].production * state[d].socialConditions - state[s].production * state[s].socialConditions;   //подумать насчет формулы    
//                    System.Console.Write("Желание населения страны {0} находиться в стране в стране {1}:   {2}\n", s, d, state[s].desireToBeIn[d]);
//                }
//            }
//            System.Console.WriteLine();

//            //То же самое в виде матрицы:
//            System.Console.WriteLine("То же самое в виде матрицы:");
//            for (int s = 0; s < State.numberOfCountries; s++)
//            {
//                for (int d = 0; d < State.numberOfCountries; d++)
//                {
//                    System.Console.Write("{0,-7}    ", Math.Round(state[s].desireToBeIn[d], 2)); //с округлением до сотых
//                    //второй параметр в {0,-7} - выравнивание (отриц значения дают выравнивание по правому краю, полож по левому)
//                }
//                System.Console.Write("\n");
//            }
//            System.Console.WriteLine();
//        }


//        static void flowCapacityCalculation(double[,,,] arr, State[] state)
//        {
//            for (int s = 0; s < State.numberOfCountries; s++)
//            {
//                for (int d = 0; d < State.numberOfCountries; d++)
//                {
//                    if (s == d)
//                    {
//                        state[s].flowCapacity[s] = 0;    //пропускная способность не имеет смысла для одной и той же страны, поэтому заполним главную диагональ матрицы нулями.
//                    }
//                    //пропускная способность из s в d:
//                    else state[s].flowCapacity[d] = 0.001 * state[d].population;
//                    System.Console.Write("Пропускная способность из страны {0} в страну {1}:   {2}\n", s, d, state[s].flowCapacity[d]);
//                }
//            }
//            System.Console.WriteLine();

//            //То же самое в виде матрицы:
//            System.Console.WriteLine("То же самое в виде матрицы:");
//            for (int s = 0; s < State.numberOfCountries; s++)
//            {
//                for (int d = 0; d < State.numberOfCountries; d++)
//                {
//                    System.Console.Write("{0,-5}    ", state[s].flowCapacity[d]);
//                }
//                System.Console.Write("\n");
//            }
//            System.Console.WriteLine();

//        }

//        static void flowSizeCalculation(double[,,,] arr, State[] state)
//        {
//            double potentialFlowSize; //временная переменная

//            for (int s = 0; s < State.numberOfCountries; s++)
//            {
//                for (int d = 0; d < State.numberOfCountries; d++)
//                {
//                    if (s == d)
//                    {
//                        state[s].flowSize[s] = 0;    //размер потока не имеет смысла для одной и той же страны, поэтому заполним главную диагональ матрицы нулями.
//                    }
//                    //размер потока из s в d:
//                    else
//                    {
//                        //потенциальный размер потока из А в В:
//                        if (state[s].desireToBeIn[d] < 0) potentialFlowSize = 0;    //где желания ехать отрицательные, значения потенциального размера потока делаем равным 0 (иначе будут отрицательными, что не имеет смысла)
//                        else potentialFlowSize = state[s].population * state[s].desireToBeIn[d];    //в противном случае рассчитываем потенц размер потока в зависимости от числ насел и желания 

//                        //реально допустимый размер потока из А в В:
//                        if (potentialFlowSize <= state[s].flowCapacity[d]) state[s].flowSize[d] = potentialFlowSize;
//                        else state[s].flowSize[d] = state[s].flowCapacity[d];
//                    }
//                    System.Console.Write("Размер потока из страны {0} в страну {1}:   {2}\n", s, d, state[s].flowSize[d]);
//                }
//            }
//            System.Console.WriteLine();

//            //То же самое в виде матрицы:
//            System.Console.WriteLine("То же самое в виде матрицы:");
//            for (int s = 0; s < State.numberOfCountries; s++)
//            {
//                for (int d = 0; d < State.numberOfCountries; d++)
//                {
//                    System.Console.Write("{0,-5}    ", state[s].flowSize[d]);
//                }
//                System.Console.Write("\n");
//            }
//            System.Console.WriteLine();
//        }


//        //static void arrOut4D(double[,,,] arr)   //вывод 4D-массива
//        //{
//        //    System.Console.WriteLine("Структура населения в каждой из стран: ");
//        //    for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
//        //    {
//        //        System.Console.WriteLine("-------------------------------Страна {0}:", s);
//        //        for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
//        //        {
//        //            for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
//        //            {
//        //                System.Console.WriteLine("Вектор численностей населения по каждой из культур в данной стране для возраста {0} и образования {1}:", i, j);
//        //                for (int k = 0; k < arr.GetLength(3); k++)  //пробегаем все культуры
//        //                {
//        //                    System.Console.Write("{0} ", arr[s, i, j, k]);
//        //                }
//        //                System.Console.WriteLine();
//        //            }
//        //            System.Console.Write("\n");
//        //        }
//        //        System.Console.WriteLine(); 
//        //    }
//        //}


//        static void arrOut3D(double[,,] arr)
//        {
//            System.Console.WriteLine("Структура культур мигрантов в каждой из стран: ");
//            for (int l = 0; l < arr.GetLength(0); l++)  //фиксируем "строку" куба (/если смотреть иначе - строку плоской м-цы)
//            {
//                System.Console.WriteLine("Страна {0}:", l);
//                for (int m = 0; m < arr.GetLength(1); m++)  //фиксируем строку м-цы в той строке куба (/иначе - столбец плоской м-цы)
//                {
//                    for (int n = 0; n < arr.GetLength(2); n++)  //пробегаем столбцы той м-цы (/пробегаем "в-р-столбец вверх" над плоской м-цей)
//                    {
//                        System.Console.Write("{0} ", arr[l, m, n]);
//                    }
//                    System.Console.Write("\n");
//                }
//                System.Console.WriteLine(); //после каждой итерации внешнего цикла - чтобы вывод был по строкам куба
//            }
//        }


//        static void MatVekKulStOut(double[,,] MatVekKulMig) //Из куба можно извлечь для каждой страны в-р своей культуры (без учета векторов культур мигрантов в этой стране; при этом вектор своей культуры в этой стране вполне может миняться под влиянием мигрантов). Получим матрицу векторов культур стран (одной стране соотв-ет одна строка):          
//        {
//            System.Console.WriteLine("Извлеченная из куба матрица векторов своих культур в странах (одной стране соотв-ет одна строка): ");

//            for (int l = 0; l < MatVekKulMig.GetLength(0); l++)
//            {
//                for (int m = 0; m < MatVekKulMig.GetLength(1); m++)
//                {
//                    if (l == m)
//                    {
//                        for (int n = 0; n < MatVekKulMig.GetLength(2); n++)
//                        {
//                            System.Console.Write("{0} ", MatVekKulMig[l, m, n]);
//                        }
//                        System.Console.Write("\n");
//                    }
//                }
//            }
//            System.Console.WriteLine();
//        }



//        static void change(double[,,] MatVekKulMig)
//        {

//            System.Console.WriteLine("Введите количество пар стран, между которыми на данном шаге будут потоки мигрантов:");
//            int NumOfPairs = int.Parse(System.Console.ReadLine());

//            for (int t = 0; t < NumOfPairs; t++)
//            {
//                System.Console.WriteLine("Введите номер страны, откуда будет волна мигрантов / откуда мигранты, уже находящиеся в стране и остающиеся там на данном шаге:");
//                int iz = int.Parse(System.Console.ReadLine());  //= 0;     

//                System.Console.WriteLine("Введите номер принимающей страны:");
//                int v = int.Parse(System.Console.ReadLine());   //= 4;


//                //Найдем значение и порядковый номер макс культуры мигранта, значение и порядковый номер принимающей страны:

//                double maxIz = 0;
//                int posMaxIz = -1;  //-1 - те пока позиции нет

//                double maxV = 0;
//                int posMaxV = -1;

//                for (int l = 0; l < MatVekKulMig.GetLength(0); l++)
//                {
//                    for (int m = 0; m < MatVekKulMig.GetLength(1); m++)
//                    {
//                        for (int n = 0; n < MatVekKulMig.GetLength(2); n++)
//                        {
//                            if (l == iz && m == iz)    //мб как и ниже надо добавить еще выбор в зав-ти от того, новая волны или нет?
//                            {
//                                if (maxIz < MatVekKulMig[l, m, n])
//                                {
//                                    maxIz = MatVekKulMig[l, m, n];
//                                    posMaxIz = n;   //в posMaxIz надо записать последний из индексов, тк далее он будет использоваться всегда на месте последнего индекса                          
//                                }
//                            }

//                            if (l == v && m == v)
//                            {
//                                if (maxV < MatVekKulMig[l, m, n])
//                                {
//                                    maxV = MatVekKulMig[l, m, n];
//                                    posMaxV = n;
//                                }
//                            }
//                        }


//                    }
//                }

//                System.Console.WriteLine();
//                System.Console.WriteLine("Значение макс культуры мигранта (из страны №{0}):\n{1}", iz, maxIz);
//                System.Console.WriteLine("Номер макс культуры мигранта (из страны №{0}):\n{1}\n", iz, posMaxIz);

//                System.Console.WriteLine("Значение макс культуры принимающей страны (страна №{0}):\n{1}", v, maxV);
//                System.Console.WriteLine("Номер макс культуры принимающей страны (страна №{0}):\n{1} \n", v, posMaxV);
//                System.Console.WriteLine();




//                //На сколько изменяем вектор культур страны j (v) под влиянием мигрантов из страны i (iz): 
//                double changeForV = 0.0;
//                double coeff_changeForV = 1.0 / 100.0;  //Вместо коэф-та (1.0 / 100.0) потом сделать некоторую зависимость от численностей в массиве населения?

//                System.Console.WriteLine("Если на данном такте это новая волна мигрантов, введите 1; если это мигранты, которые на предыдущем шаге уже жили в данной стране, введите 0. (Случай новой волны при наличии уже живущих мигрантов считать равносильным воздействию новой волны.)");
//                int newMigWave = int.Parse(System.Console.ReadLine());

//                if (newMigWave == 1)    // если это новые мигранты из страны i в страну j, то изменение местной культуры происходит под влиянием макс культуры страны i к текущему шагу
//                {
//                    changeForV = coeff_changeForV * MatVekKulMig[iz, iz, posMaxIz];
//                    System.Console.WriteLine("На сколько изменяем вектор культур страны j (v) под влиянием мигрантов из страны i (iz):\n{0}", changeForV);
//                }

//                else if (newMigWave == 0)   //если же это мигранты из страны i, которые на предыд шаге уже жили в стране j, то изменение местной культуры происходит под влиянием макс культуры этих мигрантов, а не макс культуры в стране i к текущему шагу. (Со временем культура мигрантов из i и культура в их родной стране i будут все сильнее расходиться.)
//                {
//                    changeForV = coeff_changeForV * MatVekKulMig[v, iz, posMaxIz];
//                    System.Console.WriteLine("На сколько изменяем вектор культур страны j (v) под влиянием мигрантов из страны i (iz):\n{0}", changeForV);
//                }
//                //Замечание: случай новой волны при наличии уже живущих мигрантов считаем равносильным воздействию новой волны




//                //На сколько изменяем вектор культур мигрантов, приехавших из страны i в страну j: 
//                double changeForIz; //changeForV зависела от newMigWave, а для changeForIz подобной зависимости нет
//                double coeff_changeForIz = 1.0 / 10.0;  //Вместо коэф-та потом сделать некоторую зависимость от численностей населения 3D-массива населения?
//                changeForIz = coeff_changeForIz * MatVekKulMig[v, v, posMaxV];
//                System.Console.WriteLine("На сколько изменяем вектор культур мигрантов, приехавших из страны i (iz) в страну j (v):\n{0}", changeForIz);

//                //1. Изменение вектора культур страны j (v) под влиянием мигрантов из страны i (iz):
//                //"Изменение доли своей культуры j в стране j (своего культурного максимума) - уменьшение:"
//                MatVekKulMig[v, v, posMaxV] -= changeForV;    //[v, v, posMaxV] значит, что идем в "строку" v куба - попадаем в м-цу. В ней выбираем строку v и столбец posMaxV

//                //"Изменение доли культуры страны i в векторе страны j (под влиянием культурного максимума страны i, которым обладают мигранты) - увеличение:"
//                MatVekKulMig[v, v, posMaxIz] += changeForV;


//                //2. Изменение вектора культур мигрантов, приехавших из страны i в страну j:  
//                //"Изменение доли своей культуры (своего культурного максимума) - уменьшение:"
//                MatVekKulMig[v, iz, posMaxIz] -= changeForIz;

//                //"Изменение доли культуры страны (культурного максимума страны) - увеличение:"
//                MatVekKulMig[v, iz, posMaxV] += changeForIz;

//            }
//        }

//        static void iteratedChange(ref double[,,] MatVekKulMig) // изменение культур по тактам
//        {
//            System.Console.WriteLine("Введите количество тактов:");
//            int NumOfIterations = int.Parse(System.Console.ReadLine());   //= 1;

//            for (int t = 0; t < NumOfIterations; t++)
//            {
//                change(MatVekKulMig);

//                //К концу шага имеем:     
//                System.Console.WriteLine("-----------------------------После такта №{0}:-------------------------------", t);
//                arrOut3D(MatVekKulMig);
//                MatVekKulStOut(MatVekKulMig);

//            }
//        }




//    }
//}
