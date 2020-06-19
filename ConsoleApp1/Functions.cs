using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Functions
    {
        
        public static void initializePopulationArray(ref double[,,,] populationArray) //Задаем массив населения всех стран
        {

            //Создание 4D-массива населения всех стран: пар-пед из пяти 3D-массивов (пар-педов) размерностью 3*2*5, каждый из которых соответствует одной стране. Размерности 3D-массива населения (пар-педа): возраст (3 группы - дети, взрослые, старики), образование (2 уровня), культура (5 уровней -по числу стран):
            populationArray = new double[5, 3, 2, 5]//а не может ли быть лучше сделать массив из 5 (или произвольного количества) 3D-массивов? Это вроде проще для восприятия 
            {
                 {//страна 0:
                     {//"строка" 0 (возраст 0):          
                         { 20.0,  0.0,  0.0,  0.0,  0.0 },   //столбец 0 строки 0 (образование 0 возраста 0); внутри содержит вектор-столбец численностей населения по культурам (5 элементов) для данного образования и данного возраста. Будем считать, что изначально каждая страна в каждом таком векторе имеет только одно ненулевую численность - для своей культуры. Пусть изначально эта численность в стране 0 везде равна 5 у.е., в стране 1 - 10 у.е. и т.д. (в каждой след стране на 5 у.е. больше)
                         { 20.0,  0.0,  0.0,  0.0,  0.0 },
                     },
                     {//строка 1 (возраст 1):          
                         { 20.0,  0.0,  0.0,  0.0,  0.0 },
                         { 20.0,  0.0,  0.0,  0.0,  0.0 },
                     },
                     {//строка 2:          
                         { 20.0,  0.0,  0.0,  0.0,  0.0 },
                         { 20.0,  0.0,  0.0,  0.0,  0.0 },
                     }
                 }, //сначала везде было по 5

                 {//страна 1:
                    {//строка 0:          
                        { 0.0,  20.0,  0.0,  0.0,  0.0 },
                        { 0.0,  20.0,  0.0,  0.0,  0.0 },
                    },
                    {//строка 1:          
                        { 0.0,  20.0,  0.0,  0.0,  0.0 },
                        { 0.0,  20.0,  0.0,  0.0,  0.0 },
                    },
                    {//строка 2:          
                        { 0.0,  20.0,  0.0,  0.0,  0.0 },
                        { 0.0,  20.0,  0.0,  0.0,  0.0 },
                    }
                },

                {//страна 2:
                    {//строка 0:          
                        { 0.0,  0.0,  20.0,  0.0,  0.0 },
                        { 0.0,  0.0,  20.0,  0.0,  0.0 },
                    },
                    {//строка 1:          
                        { 0.0,  0.0,  20.0,  0.0,  0.0 },
                        { 0.0,  0.0,  20.0,  0.0,  0.0 },
                    },
                    {//строка 2:          
                        { 0.0,  0.0,  20.0,  0.0,  0.0 },
                        { 0.0,  0.0,  20.0,  0.0,  0.0 },
                    }
                },

                {//страна 3:
                    {//строка 0:          
                        { 0.0,  0.0,  0.0,  20.0,  0.0 },
                        { 0.0,  0.0,  0.0,  20.0,  0.0 },
                    },
                    {//строка 1:          
                        { 0.0,  0.0,  0.0,  20.0,  0.0 },
                        { 0.0,  0.0,  0.0,  20.0,  0.0 },
                    },
                    {//строка 2:          
                        { 0.0,  0.0,  0.0,  20.0,  0.0 },
                        { 0.0,  0.0,  0.0,  20.0,  0.0 },
                    }
                },

                {//страна 4:
                    {//строка 0:          
                        { 0.0,  0.0,  0.0,  0.0,  20.0 },
                        { 0.0,  0.0,  0.0,  0.0,  20.0 },
                    },
                    {//строка 1:          
                        { 0.0,  0.0,  0.0,  0.0,  20.0 },
                        { 0.0,  0.0,  0.0,  0.0,  20.0 },
                    },
                    {//строка 2:          
                        { 0.0,  0.0,  0.0,  0.0,  20.0 },
                        { 0.0,  0.0,  0.0,  0.0,  20.0 },
                    }
                },

            };


            //{
            //     {//страна 0:
            //         {//"строка" 0 (возраст 0):          
            //             { 10.0,  0.0,  0.0,  0.0,  0.0 },   //столбец 0 строки 0 (образование 0 возраста 0); внутри содержит вектор-столбец численностей населения по культурам (5 элементов) для данного образования и данного возраста. Будем считать, что изначально каждая страна в каждом таком векторе имеет только одно ненулевую численность - для своей культуры. Пусть изначально эта численность в стране 0 везде равна 5 у.е., в стране 1 - 10 у.е. и т.д. (в каждой след стране на 5 у.е. больше)
            //             { 10.0,  0.0,  0.0,  0.0,  0.0 },
            //         },
            //         {//строка 1:          
            //             { 10.0,  0.0,  0.0,  0.0,  0.0 },
            //             { 10.0,  0.0,  0.0,  0.0,  0.0 },
            //         },
            //         {//строка 2:          
            //             { 10.0,  0.0,  0.0,  0.0,  0.0 },
            //             { 10.0,  0.0,  0.0,  0.0,  0.0 },
            //         }
            //     }, //везде было по 5

            //     {//страна 1:
            //        {//строка 0:          
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //        }
            //    },

            //    {//страна 2:
            //        {//строка 0:          
            //            { 0.0,  0.0,  10.0,  0.0,  0.0 },
            //            { 0.0,  0.0,  10.0,  0.0,  0.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  0.0,  10.0,  0.0,  0.0 },
            //            { 0.0,  0.0,  10.0,  0.0,  0.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  0.0,  10.0,  0.0,  0.0 },
            //            { 0.0,  0.0,  10.0,  0.0,  0.0 },
            //        }
            //    },

            //    {//страна 3:
            //        {//строка 0:          
            //            { 0.0,  0.0,  0.0,  10.0,  0.0 },
            //            { 0.0,  0.0,  0.0,  10.0,  0.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  0.0,  0.0,  10.0,  0.0 },
            //            { 0.0,  0.0,  0.0,  10.0,  0.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  0.0,  0.0,  10.0,  0.0 },
            //            { 0.0,  0.0,  0.0,  10.0,  0.0 },
            //        }
            //    },

            //    {//страна 4:
            //        {//строка 0:          
            //            { 0.0,  0.0,  0.0,  0.0,  10.0 },
            //            { 0.0,  0.0,  0.0,  0.0,  10.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  0.0,  0.0,  0.0,  10.0 },
            //            { 0.0,  0.0,  0.0,  0.0,  10.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  0.0,  0.0,  0.0,  10.0 },
            //            { 0.0,  0.0,  0.0,  0.0,  10.0 },
            //        }
            //    },

            //};




            //{
            //     {//страна 0:
            //         {//"строка" 0 (возраст 0):          
            //             { 30.0,  0.0,  0.0,  0.0,  0.0 },   //столбец 0 строки 0 (образование 0 возраста 0); внутри содержит вектор-столбец численностей населения по культурам (5 элементов) для данного образования и данного возраста. Будем считать, что изначально каждая страна в каждом таком векторе имеет только одно ненулевую численность - для своей культуры. Пусть изначально эта численность в стране 0 везде равна 5 у.е., в стране 1 - 10 у.е. и т.д. (в каждой след стране на 5 у.е. больше)
            //             { 30.0,  0.0,  0.0,  0.0,  0.0 },
            //         },
            //         {//строка 1:          
            //             { 30.0,  0.0,  0.0,  0.0,  0.0 },
            //             { 30.0,  0.0,  0.0,  0.0,  0.0 },
            //         },
            //         {//строка 2:          
            //             { 30.0,  0.0,  0.0,  0.0,  0.0 },
            //             { 30.0,  0.0,  0.0,  0.0,  0.0 },
            //         }
            //     }, //везде было по 5

            //     {//страна 1:
            //        {//строка 0:          
            //            { 0.0,  30.0,  0.0,  0.0,  0.0 },
            //            { 0.0,  30.0,  0.0,  0.0,  0.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  30.0,  0.0,  0.0,  0.0 },
            //            { 0.0,  30.0,  0.0,  0.0,  0.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  30.0,  0.0,  0.0,  0.0 },
            //            { 0.0,  30.0,  0.0,  0.0,  0.0 },
            //        }
            //    },

            //    {//страна 2:
            //        {//строка 0:          
            //            { 0.0,  0.0,  30.0,  0.0,  0.0 },
            //            { 0.0,  0.0,  30.0,  0.0,  0.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  0.0,  30.0,  0.0,  0.0 },
            //            { 0.0,  0.0,  30.0,  0.0,  0.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  0.0,  30.0,  0.0,  0.0 },
            //            { 0.0,  0.0,  30.0,  0.0,  0.0 },
            //        }
            //    },

            //    {//страна 3:
            //        {//строка 0:          
            //            { 0.0,  0.0,  0.0,  30.0,  0.0 },
            //            { 0.0,  0.0,  0.0,  30.0,  0.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  0.0,  0.0,  30.0,  0.0 },
            //            { 0.0,  0.0,  0.0,  30.0,  0.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  0.0,  0.0,  30.0,  0.0 },
            //            { 0.0,  0.0,  0.0,  30.0,  0.0 },
            //        }
            //    },

            //    {//страна 4:
            //        {//строка 0:          
            //            { 0.0,  0.0,  0.0,  0.0,  30.0 },
            //            { 0.0,  0.0,  0.0,  0.0,  30.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  0.0,  0.0,  0.0,  30.0 },
            //            { 0.0,  0.0,  0.0,  0.0,  30.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  0.0,  0.0,  0.0,  30.0 },
            //            { 0.0,  0.0,  0.0,  0.0,  30.0 },
            //        }
            //    },

            //};





            //{
            //     {//страна 0:
            //         {//"строка" 0 (возраст 0):          
            //             { 5.0,  0.0,  0.0,  0.0,  0.0 },   //столбец 0 строки 0 (образование 0 возраста 0); внутри содержит вектор-столбец численностей населения по культурам (5 элементов) для данного образования и данного возраста. Будем считать, что изначально каждая страна в каждом таком векторе имеет только одно ненулевую численность - для своей культуры. Пусть изначально эта численность в стране 0 везде равна 5 у.е., в стране 1 - 10 у.е. и т.д. (в каждой след стране на 5 у.е. больше)
            //             { 5.0,  0.0,  0.0,  0.0,  0.0 },
            //         },
            //         {//строка 1:          
            //             { 5.0,  0.0,  0.0,  0.0,  0.0 },
            //             { 5.0,  0.0,  0.0,  0.0,  0.0 },
            //         },
            //         {//строка 2:          
            //             { 5.0,  0.0,  0.0,  0.0,  0.0 },
            //             { 5.0,  0.0,  0.0,  0.0,  0.0 },
            //         }
            //     }, 

            //     {//страна 1:
            //        {//строка 0:          
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //            { 0.0,  10.0,  0.0,  0.0,  0.0 },
            //        }
            //    },

            //    {//страна 2:
            //        {//строка 0:          
            //            { 0.0,  0.0,  15.0,  0.0,  0.0 },
            //            { 0.0,  0.0,  15.0,  0.0,  0.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  0.0,  15.0,  0.0,  0.0 },
            //            { 0.0,  0.0,  15.0,  0.0,  0.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  0.0,  15.0,  0.0,  0.0 },
            //            { 0.0,  0.0,  15.0,  0.0,  0.0 },
            //        }
            //    },

            //    {//страна 3:
            //        {//строка 0:          
            //            { 0.0,  0.0,  0.0,  20.0,  0.0 },
            //            { 0.0,  0.0,  0.0,  20.0,  0.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  0.0,  0.0,  20.0,  0.0 },
            //            { 0.0,  0.0,  0.0,  20.0,  0.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  0.0,  0.0,  20.0,  0.0 },
            //            { 0.0,  0.0,  0.0,  20.0,  0.0 },
            //        }
            //    },

            //    {//страна 4:
            //        {//строка 0:          
            //            { 0.0,  0.0,  0.0,  0.0,  25.0 },
            //            { 0.0,  0.0,  0.0,  0.0,  25.0 },
            //        },
            //        {//строка 1:          
            //            { 0.0,  0.0,  0.0,  0.0,  25.0 },
            //            { 0.0,  0.0,  0.0,  0.0,  25.0 },
            //        },
            //        {//строка 2:          
            //            { 0.0,  0.0,  0.0,  0.0,  25.0 },
            //            { 0.0,  0.0,  0.0,  0.0,  25.0 },
            //        }
            //    },

            //};





            arrOut4D(populationArray);
        }

        public static void arrOut4D(double[,,,] arr)   //вывод 4D-массива
        {
            System.Console.WriteLine("Структура населения в каждой из стран: ");
            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
            {
                System.Console.WriteLine("-------------------------------Страна {0}:", s+1); //для вывода корректируем все индексы на 1
                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
                    {
                        System.Console.WriteLine("Вектор численностей населения по каждой из культур в данной стране для возраста {0} и образования {1}:", i+1, j+1);
                        for (int k = 0; k < arr.GetLength(3); k++)  //пробегаем все культуры
                        {
                            System.Console.Write("{0} ", arr[s, i, j, k]);
                        }
                        System.Console.WriteLine();
                    }
                    System.Console.Write("\n");
                }
                System.Console.WriteLine();
            }
        }

        public static void initializeStateObjects(double[,,,] arr, ref State[] states) //рассчитаем значения всех свойств каждого объекта (государства).
        {                                                                              //насчет использования ref: поскольку в initializeStateObjects уже используется ref для State[] states, то в аргументах всех вызываемых внутри initializeStateObjects функций ref не нужен - тк и так после завершения вызова initializeStateObjects все изменения в Structs.st будет сохранены - проверено.
            //параметры стран, связанные с численностью населения
            populationCount(arr, states);
            educCount(arr, states);
            
            //экономич параметры стран
            //productionCalculation(arr, states); 
            //consumptionCalculation(arr, states);    
            standardOfLivingCalculation(arr, states);

            //параметры, касающиеся мигрантов
            shareOfMigrantsCalculation(arr, states);
            //toleranceOfMigrantsCalculation(arr, states);

            //параметры социальной обстановки 
            //socialConditionsConsumCalculation(arr, states);
            //socialConditionsMigCalculation(arr, states);
            //socialConditionsCalculation(arr, states);

            socInstabilityIndexCalculation(Structs.toleranceStructure, states, arr);

            //параметры, касающиеся миграционных потоков 
            desireToBeInCalculation(arr, states);
            flowCapacityCalculation(arr, states);
            flowSizeCalculation(arr, states);

            setEduResource(states);

            initializeDemography(states);


        }

        public static void recalculateStateObjects(double[,,,] arr, State[] states) //то же, что и initializeStateObjects, но тот для однократного вызова в Main(), чтобы задать нач значения, а этот для вызова в change() при каждой итерации. Разница только в ref в initializeStateObjects.
        {                                                                              
            //параметры стран, связанные с численностью населения
            populationCount(arr, states);
            educCount(arr, states);

            //экономич параметры стран
            //productionCalculation(arr, states); 
            //consumptionCalculation(arr, states);    
            standardOfLivingCalculation(arr, states);

            //параметры, касающиеся мигрантов
            shareOfMigrantsCalculation(arr, states);
            //toleranceOfMigrantsCalculation(arr, states);

            //параметры социальной обстановки 
            //socialConditionsConsumCalculation(arr, states);
            //socialConditionsMigCalculation(arr, states);
            //socialConditionsCalculation(arr, states);

            socInstabilityIndexCalculation(Structs.toleranceStructure, states, arr);

            //параметры, касающиеся миграционных потоков 
            desireToBeInCalculation(arr, states);
            flowCapacityCalculation(arr, states);
            flowSizeCalculation(arr, states);

            setEduResource(states);

            initializeDemography(states);


        }

        public static void populationCount(double[,,,] arr, State[] state)    //подсчет населения
        {
            double[] sum = new double[5];

            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
            {
                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
                    {
                        for (int k = 0; k < arr.GetLength(3); k++)  //пробегаем все культуры
                        {
                            sum[s] += arr[s, i, j, k];
                        }
                    }
                }
                state[s].population = sum[s];
                System.Console.WriteLine("Общая численность населения в стране {0}:   {1}", s+1, state[s].population);
            }
            System.Console.WriteLine();
        }

        public static void educCount(double[,,,] arr, State[] state)
        {
            double[] sumOfEducated = new double[5];

            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
            {
                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
                    {
                        if (j == 1)  //берем только образование уровня 1 (те наличие высшего образования)
                        {
                            for (int k = 0; k < arr.GetLength(3); k++)  //пробегаем все культуры
                            {
                                sumOfEducated[s] += arr[s, i, j, k];
                            }
                        }
                    }
                }
                state[s].education = sumOfEducated[s];
                System.Console.Write("Общая численность людей с высшим образованием в стране {0}:   {1}", s+1, state[s].education);

                state[s].shareOfEducated = (state[s].education / state[s].population) * 100;
                System.Console.WriteLine("; \tдоля людей с высшим образованием в стране {0}:   {1}%", s+1, Math.Round(state[s].shareOfEducated));
            }
            System.Console.WriteLine();
        }


        //public static void productionCalculation(double[,,,] arr, State[] state)
        //{
        //    double a = 0.5; //некоторый коэф-т 

        //    for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
        //    {

        //        state[s].production = a * state[s].education;
        //        System.Console.WriteLine("Уровень производственных мощностей в стране {0}:   {1}", s, state[s].production);
        //    }
        //    System.Console.WriteLine();
        //}

        //public static void consumptionCalculation(double[,,,] arr, State[] state)
        //{
        //    for (int s = 0; s < arr.GetLength(0); s++)
        //    {
        //        state[s].consumption = state[s].production / state[s].population;
        //        System.Console.WriteLine("Уровень потребления в стране {0}:   {1}", s, state[s].consumption);
        //    }
        //    System.Console.WriteLine();
        //}

        public static void standardOfLivingCalculation(double[,,,] arr, State[] state)
        {
            double a = 0.5; //некоторый коэф-т 
            double b = 0.5; //некоторый коэф-т // 0.1;

            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
            {
                state[s].standardOfLiving = a * state[s].shareOfEducated - b * state[s].socInstabilityIndex; //state[s].standardOfLiving = a * state[s].education - b * state[s].socInstabilityIndex;
                System.Console.WriteLine("Уровень жизни в стране {0}:   {1}", s+1, state[s].standardOfLiving);
            }
            System.Console.WriteLine();
        }

        public static void shareOfMigrantsCalculation(double[,,,] arr, State[] state)
        {
            double[] sumOfMig = new double[5];

            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
            {
                sumOfMig[s] = 0;

                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
                    {
                        for (int k = 0; k < arr.GetLength(3); k++)  //пробегаем все культуры
                        {
                            if (k != s) sumOfMig[s] += arr[s, i, j, k];  //берем только чужие для данной страны культуры
                        }
                    }
                }
                state[s].shareOfMigrants = sumOfMig[s] / state[s].population;
                System.Console.WriteLine("Доля мигрантов в стране {0}:   {1}%", s+1, Math.Round(state[s].shareOfMigrants * 100, 2) );
                System.Console.WriteLine(sumOfMig[s]);
            }
            System.Console.WriteLine();
        }

        //public static void toleranceOfMigrantsCalculation(double[,,,] arr, State[] state)
        //{
        //    double tol = 0.0;

        //    for (int s = 0; s < arr.GetLength(0); s++)
        //    {
        //        state[s].toleranceOfMigrants = tol;
        //        tol++;
        //        System.Console.WriteLine("Уровень толерантности к мигрантам в стране {0}:   {1}", s, state[s].toleranceOfMigrants);
        //    }
        //    System.Console.WriteLine();
        //}

        //public static void socialConditionsConsumCalculation(double[,,,] arr, State[] state)
        //{
        //    double a = 0.7; //некоторый коэф-т 
        //    double b = 0.3; //некоторый коэф-т 

        //    for (int s = 0; s < arr.GetLength(0); s++)
        //    {

        //        state[s].socialConditionsConsum = (a * state[s].consumption) / (b + a * state[s].consumption);
        //        System.Console.WriteLine("Характеристика недовольства уровнем потребления в стране {0}:   {1}", s, state[s].socialConditionsConsum);
        //    }
        //    System.Console.WriteLine();
        //}

        //public static void socialConditionsMigCalculation(double[,,,] arr, State[] state) 
        //{
        //    for (int s = 0; s < arr.GetLength(0); s++)
        //    {
        //        state[s].socialConditionsMig = (1 / Math.PI) * ((Math.PI / 2) - Math.Atan(state[s].shareOfMigrants - state[s].toleranceOfMigrants));
        //        System.Console.WriteLine("Характеристика уровня недовольства мигрантами в стране {0}:   {1}", s, state[s].socialConditionsMig);
        //    }
        //    System.Console.WriteLine();
        //}

        //public static void socialConditionsCalculation(double[,,,] arr, State[] state)
        //{
        //    for (int s = 0; s < arr.GetLength(0); s++)
        //    {
        //        state[s].socialConditions = state[s].standardOfLiving * state[s].socialConditionsMig;   //= state[s].socialConditionsConsum * state[s].socialConditionsMig;
        //        System.Console.WriteLine("Общая характеристика уровня недовольства в стране {0}:   {1}", s, state[s].socialConditions);
        //    }
        //    System.Console.WriteLine();
        //}


        public static void socInstabilityIndexCalculation(double[,,] tolStruct, State[] state, double[,,,] arr) //Индекс социальной нестабильности в стране - хар-ка "межнациональной неустойчивости" в стране. Будем считать, что изначально socInstabilityIndex пропорционален доле мигрантов в стране. Далее в случае наличия неустойчивостей в матрице толерантности индекс дополнительно повышается. Добавочное значение считается как количество эл-тов м-цы толерантности страны, значения которых ниже нек критич уровня.
                                                                                                                //initializeTolStruct() должен быть вызван раньше этой ф-ии, тк она использует tolStruct[s, i, j]
                                                                                                                //мб изменить на индекс соц стабильности?
                                                                                                                //также см "Окрашивание красным культур, находящихся в конфликте с другими культурами"^ в коде Form1
        {
            double critInstab = 0.15; //критическое значение для элементов матриц толерантности
            double a = 10;
            for (int s = 0; s < State.numberOfCountries; s++)  //фиксируем страну 
            {
                state[s].socInstabilityIndex = a * state[s].shareOfMigrants + 0.001; //+ 0.1 - чтобы избежать возможного деления на 0 (в другой функции будем делить на socInstabilityIndex)                

                //сравним толерантности культуры i к остальным культурам j:
                for (int i = 0; i < State.numberOfCountries; i++)  //фиксируем культуру, У КОТОРОЙ будем определять толерантность к другим культурам в данной стране
                {
                    for (int j = 0; j < State.numberOfCountries; j++)  //фиксируем культуру, К КОТОРОЙ будем определять толерантность той культуры
                    {
                        if (tolStruct[s, i, j] < critInstab)         //если толерантность культуры i к культуре j ниже предельно допустимого значения, то это указывает на ПОТЕНЦИАЛЬНУЮ нестабильность между этой парой культур. РЕАЛЬНАЯ нестабильность будет иметь место, если численности обеих культур ненулевые (проверка на это осуществляется ниже).                                                                                                                                             
                        {
                            double sumOfCultGroup1 = 0;
                            double sumOfCultGroup2 = 0;

                            for (int age = 0; age < arr.GetLength(1); age++)
                            {
                                for (int edu = 0; edu < arr.GetLength(2); edu++)
                                {
                                    sumOfCultGroup1 += arr[s, age, edu, i];
                                    sumOfCultGroup2 += arr[s, age, edu, j];
                                }
                            }

                            if ((sumOfCultGroup1 > 1) && (sumOfCultGroup2 > 1)) //проверка на ненулевую численность обеих культур в стране (иначе не имеет смысла говорить о нестабильности между ними)
                                                                                //сначала было "if ((sumOfCultGroup1 > 0) && (sumOfCultGroup2 > 0))" - но оказалось, что численности групп могут быть оч малы, чуть больше 0, но при этом приводить к конфликтам и социальной нестабильности, что было слишком нереалистично - нужна была поправка. 
                            {
                                state[s].socInstabilityIndex++;
                            }

                            
                            //не работает в полной мере -- на снижение ур нестаб влиет, но на потоки мигрантов почему-то нет. А вариант выше с численностями больше 1 сразу оказывает заметное влияние на графики численностей и диаграммы долей культур в странах. Из страны 5 меньше уезжают и в нее наконей кто-то теперь приезжает.
                            //if ((sumOfCultGroup1 > 0) && (sumOfCultGroup2 > 0)) //проверка на ненулевую численность обеих культур в стране (иначе не имеет смысла говорить о нестабильности между ними)
                            //                                                    //сначала было "if ((sumOfCultGroup1 > 0) && (sumOfCultGroup2 > 0))" - но оказалось, что численности групп могут быть оч малы, чуть больше 0, но при этом приводить к конфликтам и социальной нестабильности, что было слишком нереалистично - нужна была поправка. 
                            //{
                            //    if( ((sumOfCultGroup1 / sumOfCultGroup2) > 0.15) && ((sumOfCultGroup2 / sumOfCultGroup1) > 0.15) ) 
                            //    state[s].socInstabilityIndex++;
                            //}

                        }



                    }
                }
                System.Console.Write("Индекс социальной нестабильности в стране {0}:   {1}\n", s+1, state[s].socInstabilityIndex);
            }
            System.Console.WriteLine();
        }

        public static void desireToBeInCalculation(double[,,,] arr, State[] state) 
        {
            double a = 0.5; //нек коэф-т пропорциональности
            double b = 0.5; //нек коэф-т пропорциональности

            for (int s = 0; s < State.numberOfCountries; s++)
            {
                for (int d = 0; d < State.numberOfCountries; d++)
                {
                    if (s == d)
                    {
                        state[s].desireToBeIn[s] = (a * state[s].standardOfLiving / state[s].socInstabilityIndex) + b * state[s].eduCultResource; //желание остаться тем больше, чем выше уровень жизни в стране, и тем меньше, чем выше ур межнац неустойчивости в стране. Помимо этого желанию остаться у людей тем способствует культурное образование в стране: чем больше средств вкладывается в культ обр, тем только у людей желание остаться.   
                    }
                    else state[s].desireToBeIn[d] = a * state[d].standardOfLiving / state[d].socInstabilityIndex - a * state[s].standardOfLiving / state[s].socInstabilityIndex;
                    
                    //System.Console.Write("Желание населения страны {0} находиться в стране {1}:   {2}\n", s+1, d+1, state[s].desireToBeIn[d]);
                }
            }
            //System.Console.WriteLine();

            //То же самое в виде матрицы:
            System.Console.WriteLine("Матрица желаний находиться в странах (элемент a_ij  соответствует желанию населения страны i быть в стране j):"); //System.Console.WriteLine("То же самое в виде матрицы:");
            for (int s = 0; s < State.numberOfCountries; s++)
            {
                for (int d = 0; d < State.numberOfCountries; d++)
                {
                    System.Console.Write("{0,-7}    ", Math.Round(state[s].desireToBeIn[d], 2)); //с округлением до сотых
                    //второй параметр в {0,-7} - выравнивание (отриц значения дают выравнивание по правому краю, полож по левому)
                }
                System.Console.Write("\n");
            }
            System.Console.WriteLine();
        }

        public static void flowCapacityCalculation(double[,,,] arr, State[] state)
        {
            for (int s = 0; s < State.numberOfCountries; s++)
            {
                for (int d = 0; d < State.numberOfCountries; d++)
                {
                    if (s == d) state[s].flowCapacity[s] = 0;    //пропускная способность не имеет смысла для одной и той же страны, поэтому заполним главную диагональ матрицы нулями.
                    else
                    {
                        switch (Program.flowHandling) //выбираем, учитывать мигрансткие потоки в расчетах или нет
                        {
                            case "0": state[s].flowCapacity[d] = 0; break;
                            default: state[s].flowCapacity[d] = 0.07 * state[d].population; //увеличил пропускную способность потока в страну с 0.001 до 0.05 (5% населения страны) - так вроде вполне реалистично, даже мб слишком много. Ну это макс размер, он не обяз таким будет, тк еще зависит от числа желающих ехать. Теперь мигранты стали заметны по численности //0.05 //0.10 // 0.01 - 1% нав самое реалистичное, но так изменения слабее заметны
                                     //state[s].flowCapacity[3] = 0.06 * state[3].population;  //корректировка пропускн спос у самой популярной страны (3) - уменьшение. (В принципе можно этого не делать, но так графики выглядят чуть лучше.) Какая самая популярная установлено экспериментально. В дальнейшем желательно бы сделать нахождение самой попул страны и уменьшение у нее проп способности автоматическим. Закоментировал, потому что вручную это не должно корректироваться, хоть графики и красивее.
                                     break; 
                        }
                       
                    }

                    //System.Console.Write("Пропускная способность из страны {0} в страну {1}:   {2}\n", s, d, state[s].flowCapacity[d]); //если пропускную спос динамически не меняем, то и не нужно ее выводить каждый раз
                }
            }
            //System.Console.WriteLine();

            ////То же самое в виде матрицы:
            //System.Console.WriteLine("То же самое в виде матрицы:");
            //for (int s = 0; s < State.numberOfCountries; s++)
            //{
            //    for (int d = 0; d < State.numberOfCountries; d++)
            //    {
            //        System.Console.Write("{0,-5}    ", Math.Round(state[s].flowCapacity[d], 2) );
            //    }
            //    System.Console.Write("\n");
            //}
            //System.Console.WriteLine();

        }

        public static void flowSizeCalculation(double[,,,] arr, State[] state)
        {
            double potentialFlowSize; //временная переменная

            for (int s = 0; s < State.numberOfCountries; s++)
            {
                for (int d = 0; d < State.numberOfCountries; d++)
                {
                    if (s == d)
                    {
                        state[s].flowSize[s] = 0;    //размер потока не имеет смысла для одной и той же страны, поэтому заполним главную диагональ матрицы нулями.
                    }
                    //размер потока из s в d:
                    else
                    {
                        //потенциальный размер потока из А в В:
                        if (state[s].desireToBeIn[d] < 0) potentialFlowSize = 0;    //где желания ехать отрицательные, значения потенциального размера потока делаем равным 0 (иначе будут отрицательными, что не имеет смысла)
                        else potentialFlowSize = state[s].population * state[s].desireToBeIn[d];    //в противном случае рассчитываем потенц размер потока в зависимости от числ насел и желания 

                        //реально допустимый размер потока из А в В:
                        if (potentialFlowSize <= state[s].flowCapacity[d]) state[s].flowSize[d] = potentialFlowSize;
                        else state[s].flowSize[d] = state[s].flowCapacity[d];                     
                    }
                    //System.Console.Write("Размер потока из страны {0} в страну {1}:   {2}\n", s+1, d+1, state[s].flowSize[d]);
                }
            }
            //System.Console.WriteLine();

            //То же самое в виде матрицы:
            System.Console.WriteLine("Матрица размеров потоков (элемент a_ij  соответствует потоку из i в j):");   //System.Console.WriteLine("То же самое в виде матрицы:");
            for (int s = 0; s < State.numberOfCountries; s++)
            {
                for (int d = 0; d < State.numberOfCountries; d++)
                {
                    System.Console.Write("{0,-5}    ", Math.Round(state[s].flowSize[d], 2) );
                }
                System.Console.Write("\n");
            }
            System.Console.WriteLine();
        }

        public static void flow(double[,,,] arr, State[] state) //Влияние потоков на изменения численностей населения
        {
            //Будем считать, что потоки мигрантов преимущественно состоят из людей трудоспособного возраста, и поэтому детьми и стариками в них можно пренебречь.
            //посчитаем количество ненулевых групп населения трудоспособного возраста в массиве населения каждой страны. 
            int[] zeroGroupsCount = new int[5];

            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем страну
            {
                zeroGroupsCount[s] = 0;

                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
                    {
                        for (int k = 0; k < arr.GetLength(3); k++)
                        {
                            if ( (i == 1) && (arr[s, i, j, k] == 0) ) zeroGroupsCount[s]++;
                        }
                    }
                }
            }


            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем страну-источник
            {
                for (int d = 0; d < arr.GetLength(0); d++)  //фиксируем принимающую страну
                {
                    //Возраст людей в потоке принимаем равным 1, считая, что подавляющее большинство людей в потоках принадлежат к трудоспос возрасту. Далее для простоты будем считать, что в каждом потоке распределение по всем группам по обр и культ (возр здесь уже не участвует) равномерное - те кол-во уезжающих делится поровну между всеми имеющимися ненулевыми группами возраста 1. Те из каждой ненулевой группы уезжает одинаковая доля всей численности потока. Поэтому далее в стране-отправителя равномерно уменьшаем численности всех ненулевых групп населения в зав-ти от размера потока (равномерно распределяя размер потока между всеми ненулевыми численностями), а в принимающей стране аналогичным образом увеличиваем численность каждой соотв группы. Из какой группы уезжают, в такую же группу (с такой же комбинацией индексов возр, обр, культ) и приезжают в другую страну.

                    double flowFromEachGroup = state[s].flowSize[d] / (2 * 3 * 5 - zeroGroupsCount[s]); // 2*3*5=30 - общее число "групп" - эл-тов массива населения

                    for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст //можно убрать
                    {
                        for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование
                        {
                            for (int k = 0; k < arr.GetLength(3); k++)  //пробегаем все культуры
                            {
                                if (i == 1) //считаем, что в потоках участвуют только люди трудоспособного возраста
                                {
                                    if ((arr[s, i, j, k] - flowFromEachGroup) > 0) //if и else - для недопущения отрицательных значений населения. В случае, если доля потока, приходящаяся на одну группу населения, превышает численность выбранной в данной момент группы населения (сюда же входит случай, когда выбранная группа населения имеет нулевую численность), уезжает только имеющаяся численность.
                                                                                   //условие if (arr[s, i, j, k] != 0) должно быть учтено - те мы должны отнимать долю потока только если группа относится к неотрицательным. Но это условие и так будет учтено в более широком условии if ( (arr[s, i, j, k] - flowFromEachGroup) > 0), которое помимо этого условия включает еще условие того, чтобы не отнимать 
                                                                                   //но при исп if ( (arr[s, i, j, k] - flowFromEachGroup) > 0) в случае малой численности группы не будет реализовано перемещение всей доли, выделенной на группу! Напр выделено на кажд группу по 10, попалась группа численностью один - 1 будет учтен, а еще 9 нет! Значит для такого случая надо еще писать доп алгоритм по распределению этих неучтенных среди остальных групп, у которых хватит численности! Но это доп сложность - мб лучше пока не учитывать! И оставить как есть - пусть пока буедт  if ( (arr[s, i, j, k] - flowFromEachGroup) > 0)! Он все равно лучше, чем просто if (arr[s, i, j, k] != 0), тк дополнительно правильно учитывает перемещение из малых групп, не допуская отриц значений. Те пусть пока при малой численности группы едут все из этой группы, а остальная часть доли потока, приешдшаяся на эту малую группу, не учитывается. Будем считать это допускаемой погрешностью модели, значением которой можно пренебречь. Для уменьшения погрешности можно побольше задать везде численности населения и поменьше сделать потоки. На данный момент размеры потоков примерно в 100 раз меньше численностей населения стран, поэтому погрешность незначительна.
                                    {
                                        arr[s, i, j, k] -= flowFromEachGroup;
                                        arr[d, i, j, k] += flowFromEachGroup;
                                    }
                                    else //если числ выбранной ненулевой группы меньше численности доли потока, приходящейся на одну группу, перемещаем что можно из этой группы, те всю группу
                                    {
                                        arr[d, i, j, k] += arr[s, i, j, k];
                                        arr[s, i, j, k] = 0;
                                    }
                                }

                                
                                
                                
                            }
                        }
                    }

                    //корректировать общие численности населения в этих двух странах (state[s].population и state[d].population) на размер потока не нужно, тк после вызова данной ф-ии в цикле по времени сразу же вызывается ф-ия пересчета св-в и полей объектов стран, поэтому к след такту общие численности и так обновятся.
                    
                }

            }  
            
        }

        public static void setEduResource(State[] state)
        {
            //Сценарий, использовавшийся в бакалаврской работе:
            //state[0].eduTechResource = 0.1;
            //state[1].eduTechResource = 0.3;
            //state[2].eduTechResource = 0.5;
            //state[3].eduTechResource = 0.7;
            //state[4].eduTechResource = 0.9;


            //Сценарий 50/50
            //state[0].eduTechResource = 0.5;
            //state[1].eduTechResource = 0.5;
            //state[2].eduTechResource = 0.5;
            //state[3].eduTechResource = 0.5;
            //state[4].eduTechResource = 0.5;


            //Сценарий 70% в культ у всех
            //state[0].eduTechResource = 0.3;
            //state[1].eduTechResource = 0.3;
            //state[2].eduTechResource = 0.3;
            //state[3].eduTechResource = 0.3;
            //state[4].eduTechResource = 0.3;


            //Сценарий 90% в культ у всех
            //state[0].eduTechResource = 0.1;
            //state[1].eduTechResource = 0.1;
            //state[2].eduTechResource = 0.1;
            //state[3].eduTechResource = 0.1;
            //state[4].eduTechResource = 0.1;


            //Сценарий 70% в культ у всех, кроме одной страны, кот бешено вкладывается в технику
            //state[0].eduTechResource = 0.3;
            //state[1].eduTechResource = 0.3;
            //state[2].eduTechResource = 0.3;
            //state[3].eduTechResource = 0.3;
            //state[4].eduTechResource = 0.9;

            //Сценарий 70% в культ у всех, кроме одной страны, кот 100% вкладывает в технику
            //state[0].eduTechResource = 0.3;
            //state[1].eduTechResource = 0.3;
            //state[2].eduTechResource = 0.3;
            //state[3].eduTechResource = 0.3;
            //state[4].eduTechResource = 1;

            //Сценарий, где все бешено вкладываются в технику - получаются необычные графики
            state[0].eduTechResource = 0.9;
            state[1].eduTechResource = 0.9;
            state[2].eduTechResource = 0.9;
            state[3].eduTechResource = 0.9;
            state[4].eduTechResource = 0.9;




            //Смотрел, что будет, если у всех сделать 70% на техн обр, что вроде бы хорошо. (--А точно ли хорошо? Не перебор?) Но в таком случае показатели стран получаются очень похожи друг на друга, и миграция теряет свой смысл (тк ее основная цель - улучшение условий жизни). Поскольку данная модель фокусируется на миграционных процессах, она создавалась в предположении того, что между странами (хотя бы между одной парой) всегда есть существенная разница, тк иначе значимой миграции и не будет. Поэтому при одинаково хороших условиях во всех странах данная модель не будет давать корректных расчетов миграционных потоков, тк она изначально принимает за данность существование неравенства в мире. Поэтому в рамках данной модели не имеет смысла рассматривать "идеалистический" сценарий, когда у всех стран на техн обр выделяется по 70%! В данной модели считаем, что для всех стран одновременно такое недостижимо или крайне маловероятно. Можно лишь дать рекомендацию, что каждой стране к этому лучше стремится - в мире, где всегда будут страны с более худшими (или просто другими) показателями. Тогда страна с 70% может претендовать на первенство по большинству показателей в долгосрочной перспективе.
            //state[0].eduTechResource = 0.7;
            //state[1].eduTechResource = 0.7;
            //state[2].eduTechResource = 0.7;
            //state[3].eduTechResource = 0.7;
            //state[4].eduTechResource = 0.7;


            //state[0].eduTechResource = 0.5;
            //state[1].eduTechResource = 0.3;
            //state[2].eduTechResource = 0.1;
            //state[3].eduTechResource = 0.4;
            //state[4].eduTechResource = 0.7;

            for (int s = 0; s < State.numberOfCountries; s++) state[s].eduCultResource = 1.0 - state[s].eduTechResource;
        }
        
        public static void eduChange(double[,,,] arr, State[] state)    //изменение численностей по уровням техн образования. Зависит от кол-ва ресурса на техн образование
        {
            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем страну
            {                
                double eduChange = state[s].eduTechResource * 0.01;  //change определит долю группы населения, у которой произойдет повышение уровня образования. Доля зависит от средств, выделяемых на образование - чем больше средств, тем больше будет доля. В случае выделения на ресурс техн образования 0.5 (50%) к следующему такту ур образования повысится у 5% людей без образования. (помимо этого числености людей по уровням образования будут определяться и меняться в зав-ти от демографии.)

                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование //можно убрать
                    {
                        for (int k = 0; k < arr.GetLength(3); k++)
                        {                            
                            arr[s, i, 0, k] -= arr[s, i, 0, k] * eduChange;     //в отл от  flow() здесь условие вида "if ((arr[s, i, 0, k] - arr[s, i, 0, k] * eduChange) > 0)" перед этой строчкой не нужно, тк вычитаем ДОЛЮ от ТОЙ ЖЕ величины! Поэтому разность всегда будет больше нуля (или в случае нулевой числоенности будет равна 0). А во флоу условие нужно было, тк там вычитали другую величину!
                            arr[s, i, 1, k] += arr[s, i, 0, k] * eduChange;      
                        }
                    }
                }
                //корректировать общую численность образованных здесь не надо - см коммент в конце flow()
            }

        }

        public static void initializeDemography(State[] state)    //задаем демогр коэф-ты для каждой страны. В текущей версии они не меняются с течением времени (что можно добавить при желании).
        {//коэф-ты подобраны такие, чтобы в теч 100 лет численность не менялась кардинально (в десятки и более раз). Некоторые другие комбинации коэф-тов приводят к неустойчивости программы на больших интервалах (пробовал на 100 лет) появляются слишком большие или слишком малые численности (на 10 тактах при все комбинациях проблем не было), и в кубе культур появляются отрицательные значения - чего быть вообще никогда не должно! Значит где-то не хватает какого-то ограничения! В дальнейшем желательно найти и устранить эту неустойчивость, после чего получше подобрать коэф-ты, так чтобы например для роста численности своего населения в стране (если не считать мигрантов) рождаемость должна быть выше смертности взрослых и стариков. И старики должны умирать в знач больших кол-вах, чем трудоспособное население. (войны не учитываем в модели.) Поэтому понижающие численность коэф смертности возраста2 должзны быть значительно большими, чем понижающие численность коэф смертности возраста1. 

            //мб коэф смертности сделать ф-ией от уровня жизни? Чем выше ур жизни, тем меньше смертность? Желательно бы сделать зависимость такой, чтобы получались примерно такие же коэф-ты, как сейчас



            //хороший вариант при проп спос 4-10%. При 4% все графики разные, и стр2 имеет разнообр конфликты. Это можно использ, чтобы сделать вывод о том, что средств на обр не хватило (у стр 3 все ок). Лучшие графики получаются при 7% проп спос (и еще лучше, если страну 3 ограничить 6%). При 7% страны 0 и 4 вымирают/разъезжаются, а 1-3 чувствуют себя неплохо - но во всех очень много мигрантов! По половине населения!
            //сделал коэф-ты рождаемости, коэф-ты сметрности взрослых и смерности стариков тем выше, чем больше средств на культ обр (и соотв меньше на техн) - считаем, что имеет место быть такая зависимость. (Или мб от уровня жизни зав-ть сделать? Чем выше ур жизни, тем меньше смертность?) В дальнейшем желательно эту зав-ть сделать задающейся через формулу в зависимости от доли на культ или тех обр, а то здесь все задано вручную пока.
            state[0].bCoeff_activePeople = 0.139;   
            state[1].bCoeff_activePeople = 0.137;
            state[2].bCoeff_activePeople = 0.135;
            state[3].bCoeff_activePeople = 0.133; 
            state[4].bCoeff_activePeople = 0.131;

            state[0].dCoeff_activePeople = 0.033;
            state[1].dCoeff_activePeople = 0.032;
            state[2].dCoeff_activePeople = 0.031;
            state[3].dCoeff_activePeople = 0.030;
            state[4].dCoeff_activePeople = 0.029;

            state[0].dCoeff_elders = 0.059;
            state[1].dCoeff_elders = 0.049;
            state[2].dCoeff_elders = 0.039;
            state[3].dCoeff_elders = 0.029;
            state[4].dCoeff_elders = 0.019;



            //странные формы графиков
            //state[0].bCoeff_activePeople = 0.1235;   // 0.119 лучше, чем 0.019. //уже 0.129 приводит к эксп росту населения
            //state[1].bCoeff_activePeople = 0.115;   //0.028 лучше, чем 0.018. //0.108 приводит к эксп росту населения почему-то! И появляются отриц значения в культурах этой страны! //0.098;
            //state[2].bCoeff_activePeople = 0.103;    //0.12 эксп нет, но приводит к оч большому росту в странах 0-3! Во всех! И через 100 лет в 0,1,3 половина мигрантов!
            //state[3].bCoeff_activePeople = 0.103;    //0.12 приводит к эксп росту и отр культ у 0 и 3!
            //state[4].bCoeff_activePeople = 0.103;     //0.12 эксп нет но приводит к оч большому росту в 4 

            //state[0].dCoeff_activePeople = 0.021; //0.018;
            //state[1].dCoeff_activePeople = 0.018; //по сравн с 0.002, 0.0002 через 100 лет увеличивает числ взрослых и стариков (причем стариков сильнее - но это мб потому что у меня их и так намного больше) 
            //state[2].dCoeff_activePeople = 0.003;
            //state[3].dCoeff_activePeople = 0.003;
            //state[4].dCoeff_activePeople = 0.003;

            //state[0].dCoeff_elders = 0.165; //0.149;
            //state[1].dCoeff_elders = 0.129;//0.011; //0.015 делает картину долее умеренной; все еще с приростом общего насел через 100 лет. 0.019 через 100 лет возвращает выраставшую числ к исходному значению //0.025; //0.029 //0.049;
            //state[2].dCoeff_elders = 0.049;
            //state[3].dCoeff_elders = 0.049;
            //state[4].dCoeff_elders = 0.019;



            //неплохой вариант с разными культ конфликтами в стр 3, но со странными формами графиков, слишком большим ростом в 0 и полным отсутствием мигрантов в 2 и 4 через 100 лет. Так было при пропускной спос 1% у всех стран.
            //state[0].bCoeff_activePeople = 0.119;   // 0.119 лучше, чем 0.019. //уже 0.129 приводит к эксп росту населения
            //state[1].bCoeff_activePeople = 0.103;   //0.028 лучше, чем 0.018. //0.108 приводит к эксп росту населения почему-то! И появляются отриц значения в культурах этой страны! //0.098;
            //state[2].bCoeff_activePeople = 0.103;    //0.12 эксп нет, но приводит к оч большому росту в странах 0-3! Во всех! И через 100 лет в 0,1,3 половина мигрантов!
            //state[3].bCoeff_activePeople = 0.103;    //0.12 приводит к эксп росту и отр культ у 0 и 3!
            //state[4].bCoeff_activePeople = 0.103;     //0.12 эксп нет но приводит к оч большому росту в 4 

            //state[0].dCoeff_activePeople = 0.003;
            //state[1].dCoeff_activePeople = 0.003; //по сравн с 0.002, 0.0002 через 100 лет увеличивает числ взрослых и стариков (причем стариков сильнее - но это мб потому что у меня их и так намного больше) 
            //state[2].dCoeff_activePeople = 0.003;
            //state[3].dCoeff_activePeople = 0.003;
            //state[4].dCoeff_activePeople = 0.003;

            //state[0].dCoeff_elders = 0.059;
            //state[1].dCoeff_elders = 0.049;//0.011; //0.015 делает картину долее умеренной; все еще с приростом общего насел через 100 лет. 0.019 через 100 лет возвращает выраставшую числ к исходному значению //0.025; //0.029
            //state[2].dCoeff_elders = 0.049;
            //state[3].dCoeff_elders = 0.049;
            //state[4].dCoeff_elders = 0.019;





            //тест№1 "хор варианта для 10%" на 1% - при увеличении всех дем пар-ров на 0.002. Увел на 0.002 дает такие же графики
            //state[0].bCoeff_activePeople = 0.113;   // 0.119 лучше, чем 0.019. //уже 0.129 приводит к эксп росту населения
            //state[1].bCoeff_activePeople = 0.113;   //0.028 лучше, чем 0.018. //0.108 приводит к эксп росту населения почему-то! И появляются отриц значения в культурах этой страны! //0.098;
            //state[2].bCoeff_activePeople = 0.113;    //0.12 эксп нет, но приводит к оч большому росту в странах 0-3! Во всех! И через 100 лет в 0,1,3 половина мигрантов!
            //state[3].bCoeff_activePeople = 0.113;    //0.12 приводит к эксп росту и отр культ у 0 и 3!
            //state[4].bCoeff_activePeople = 0.113;     //0.12 эксп нет но приводит к оч большому росту в 4 

            //state[0].dCoeff_activePeople = 0.033;
            //state[1].dCoeff_activePeople = 0.033; //по сравн с 0.002, 0.0002 через 100 лет увеличивает числ взрослых и стариков (причем стариков сильнее - но это мб потому что у меня их и так намного больше) 
            //state[2].dCoeff_activePeople = 0.033;
            //state[3].dCoeff_activePeople = 0.033;
            //state[4].dCoeff_activePeople = 0.033;

            //state[0].dCoeff_elders = 0.059;
            //state[1].dCoeff_elders = 0.059;//0.011; //0.015 делает картину долее умеренной; все еще с приростом общего насел через 100 лет. 0.019 через 100 лет возвращает выраставшую числ к исходному значению //0.025; //0.029
            //state[2].dCoeff_elders = 0.059;
            //state[3].dCoeff_elders = 0.059;
            //state[4].dCoeff_elders = 0.059;



            //неплохой вариант со стабилизирующейся численностью через 100 лет у всех стран кроме 0 и 4 (они уже через 50 вымирают). Хорошо работал вроде при проп спос 10% (или мб 5, но скор всего 10). При 1% 0 и 4 не вымерли через 100 лет, но из числ постеп уменьшается. А ост графики становятся странными, так же как и при других вариантах с 1%. Мб при 1% надо все демогр параметры увеличить в 10 раз, чтобы было похоже на 10%?--так просто не исправляется
            //state[0].bCoeff_activePeople = 0.103;   // 0.119 лучше, чем 0.019. //уже 0.129 приводит к эксп росту населения
            //state[1].bCoeff_activePeople = 0.103;   //0.028 лучше, чем 0.018. //0.108 приводит к эксп росту населения почему-то! И появляются отриц значения в культурах этой страны! //0.098;
            //state[2].bCoeff_activePeople = 0.103;    //0.12 эксп нет, но приводит к оч большому росту в странах 0-3! Во всех! И через 100 лет в 0,1,3 половина мигрантов!
            //state[3].bCoeff_activePeople = 0.103;    //0.12 приводит к эксп росту и отр культ у 0 и 3!
            //state[4].bCoeff_activePeople = 0.103;     //0.12 эксп нет но приводит к оч большому росту в 4 

            //state[0].dCoeff_activePeople = 0.003;
            //state[1].dCoeff_activePeople = 0.003; //по сравн с 0.002, 0.0002 через 100 лет увеличивает числ взрослых и стариков (причем стариков сильнее - но это мб потому что у меня их и так намного больше) 
            //state[2].dCoeff_activePeople = 0.003;
            //state[3].dCoeff_activePeople = 0.003;
            //state[4].dCoeff_activePeople = 0.003;

            //state[0].dCoeff_elders = 0.049;
            //state[1].dCoeff_elders = 0.049;//0.011; //0.015 делает картину долее умеренной; все еще с приростом общего насел через 100 лет. 0.019 через 100 лет возвращает выраставшую числ к исходному значению //0.025; //0.029
            //state[2].dCoeff_elders = 0.049;
            //state[3].dCoeff_elders = 0.049;
            //state[4].dCoeff_elders = 0.049;

        }
        public static void demographicChange(double[,,,] arr, State[] state)    //изменение численностей по возрастам
        {

            for (int s = 0; s < arr.GetLength(0); s++)  //фиксируем страну
            {
                double shareOfAgedPeople = 0.1; //процент постаревших для возр1, те переходящих из категории трудоспособных в категорию стариков. Считаем, что на каждом такте стареет 10% трудоспособного населения. Это будет одинаково для всех стран.
                double shareOfGrownPeople = shareOfAgedPeople; //процент повзрослевших для возр0 - считаем, что он равен проценту постаревших для возр1.

                for (int i = 0; i < arr.GetLength(1); i++)  //фиксируем возраст //можно убрать
                {
                    for (int j = 0; j < arr.GetLength(2); j++)  //фиксируем образование 
                    {
                        for (int k = 0; k < arr.GetLength(3); k++)
                        {
                            double numOfGrown = arr[s, 0, j, k] * shareOfGrownPeople;   //кол-во детей образования j  и культуры k, которое переходит из группы детей в группу взрослых. 
                            double numOfAged = arr[s, 1, j, k] * shareOfAgedPeople;     //кол-во взрослых, переходящих в группу стариков

                            //если это старики:         //стариков и детей надо посчитать раньше трудовиков, тк в формуле стариков используется числ возр1, и она еще не должна быть перезаписана на новую! Также и с детьми, кот тоже рассчитвваются в зав-ти от трудоспос населения! Поэтому и циклы вида if (i == 2) здесь нельзя делать, иначе будет обрабатывать и перезаписывать снач детей, потом труд, потом стариков, а надо стариков и детей сначала. Можно сделать и с ифом, если перед этим сохранить в отдельные переменные то, что будет исползоваться в ф-лах стариков и детей, но необходимости в этом нет.
                            arr[s, 2, j, k] = arr[s, 2, j, k] - arr[s, 2, j, k] * state[s].dCoeff_elders + numOfAged; //возраст2 (старики) = возр2*(понижающий численность коэф смертности возраста2) + возр1*(процент постаревших для возр1). Те к старикам прибавялется часть трудосп насел предыд такта и отнимается часть стариков, кот умирает

                            //если это дети: 
                            arr[s, 0, j, k] = arr[s, 0, j, k] - numOfGrown + arr[s, 1, j, k] * state[s].bCoeff_activePeople; //возраст0 =  возраст0 + возраст1*(коэф рождаемости возраста1) - возраст0*(процент повзрослевших для возр0); // те сколько было в группе детей + сколько родилось (и выжило) у трудоспос населения минус сколько повзрослело

                            //если это трудоспособные: 
                            arr[s, 1, j, k] = arr[s, 1, j, k] - arr[s, 1, j, k] * state[s].dCoeff_activePeople + numOfGrown - numOfAged; //что было - смертность + повзрослевшая молодежь - постаревшие
                        }
                    }
                }

                //корректировать общую численность здесь не надо - см коммент в конце flow()
            }

        }


        public static void initializeEduMatrix(ref double[,] eduMat) //не используется в текущей версии программы
        {
            double e11 = 0.9;   //e11 принадлежит [0, 1] и является понижающим коэф-том для числа людей без образования. В процессе образования умножается на кол-во людей без образования, тем самым делая его меньше. Получаем кол-во людей, остающихся без образования. Сделать зависимым от доли ресурса на техн обр. Чем больше ресурс, тем меньше будет e11.
            double e21 = 1 - e11;    // e21  хар-зует долю людей, которые получают образование на данном такте. =1 - e11, тк насколько числ людей без обр стала меньше, на такую же долю от числ людей без обр должна увеличиться числ люд с образованием. И + предыдущая числ обр людей: e22(=1) * числ обр, те просто числ обр с предыд шага. (см рисунок матр умнож)

            eduMat = new double[2, 2]
            {
                { e11, 0 },
                { e21, 1 }
            };

        }

        public static void initializeСultStruct(ref double[,,] cultStruct) // Задаем исходную структуру векторов культур в каждой из стран. 
        {

            //В каждой стране вектор с номером, совпадающим с номером страны, является вектором своей культуры, а остальные векторы опписывают культуры мигрантов. Каждой стране соответсвует одна "строка" массива (куба):
            cultStruct = new double[5, 5, 5] {
                                              {//"строка" 0 (страна 0):          
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },   //что в столбце 0 строки 0 - те вектор из пяти эл-тов
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              },

                                              {//строка 1:
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              },

                                              {
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              },

                                              {
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              },

                                               {
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              }
                                    };




            System.Console.WriteLine("-------Структура векторов культур в исходный момент:------");
            arrOut3D(cultStruct);

            System.Console.WriteLine("Извлеченная из куба матрица векторов своих культур в странах (одной стране соответствует одна строка): ");
            MatVekKulStOut(cultStruct);
        }

        public static void initializeTolStruct(ref double[,,] tolStruct) // Задаем исходную структуру матриц толерантности. 
                                                                         //initializeTolStruct() должен быть вызван в Program раньше initializeStateObjects(), тк та ф-ия содержит ф-ию socInstabilityIndexCalculation(), которая в расчетах использует структуру м-ц толерантности. Если к вызову initializeStateObjects() структура не будет задана, расчеты будет неверные 
                                                                         //Считаем, что толерантность к своей культуре всегда максимальна. Поэтому на главную диагональ м-цы толерантности каждой страны заполняем единицами и в дальнейшем изменять не будем. Остальные эл-ты изначально зададим либо равными 0, либо еще как-ниб заполним. При итерации по времени они начнут меняться через ф-ию changeTolStruct. 
        {
            tolStruct = new double[5, 5, 5] {
                                              {//"строка" 0 (страна 0):          
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },   //что в столбце 0 строки 0 - те вектор из пяти эл-тов
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              },

                                              {//строка 1:
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              },

                                              {
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              },

                                              {
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              },

                                               {
                                                 { 1.0,  0.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  1.0,  0.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  1.0,  0.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  1.0,  0.0 },
                                                 { 0.0,  0.0,  0.0,  0.0,  1.0 },
                                              }
                                    };
         
        }

        public static void changeTolStruct(double[,,] tolStruct, double[,,] cultStruct, State[] state) 
        {
            //Меняем только все эл-ты вне главной диагонали (на главной диагонали м-ц толерантности всегда единицы).
            //Меняем эл-ты вне главной диаг м-цы толерантности в зав-ти от следующих переменных. Толерантность в стране s людей культуры i к культуре j тем выше, чем: 
            //а) больше значение культуры j в векторе культуры i; 
            //б) больше общая толерантность к другим культурам в данной стране;
            //в) больше средств, выделяемых страной на культурное образование;
            //г) больше предыдущее значение толерантности.
            //Поскольку в м-цах толерантноти учитываются и коэф-ты толерантности мигранстких культур к местным, то изменение м-ц толерантности под влиянием ресурса культурного образования влияет и на ассимиляционные процессы. Чем больше ресурс культ образования в стране, тем и местные лучше относятся к мигрантам, и мигранты к местным, поэтому и лучше проходит ассимиляция (выше скорость ассимиляции).


            //вместо toleranceOfMigrants и toleranceOfMigrantsCalc:
            double[] tolCoeff = { 0.25, 0.25, 0.25, 0.25, 0.25 };  //нек коэф-ты поправки - по одному для каждой страны. Коэф отраж тол к мигрантам (другим культурам) в целом. Замечание: довольно сильно влияют на м-цы толерантности стран. Поэтому мб лучше ограничить одним кофэ-тогм на всех - считать, что до начала влияния культ обр все культуры толерантны (или нетолерантны) к другим (всем другим сразу) (примерно) одинаково. Поэтому я в итоге везде сделал одинак коэф-ты, чтобы не было непонятных зависимостей. Может вообще не нужен массив значений, а просто везде поставить одни и то же коэф в ф-ле ниже - просто сказать поправочный коэф, и все
                                                                   // { 0.15, 0.2, 0.2, 0.25, 0.3 }; приводит к тому, что вместо страны 3 все выбирают страну 4, где ур обр выше - тк если там и толер знач выше, то большинство отдаст предпочтение ей
                                                                   //{ 0.15, 0.2, 0.2, 0.25, 0.253 };  // при 4% прос спос и 100 тактах: аналогично { 0.25, 0.25, 0.25, 0.25, 0.25 }. { 0.15, 0.2, 0.2, 0.25, 0.253 } лучше не использовать, тк задаются непонятные "преференции" странам с возрастанием номера - которые не зависят ни от образования, ни от чего еще.
                                                                   //{ 0.2, 0.2, 0.2, 0.2, 0.2 };  // при 4% прос спос и 100 тактах: 0-2 растут, а 3 и 4 в конфликтах и вымирают. Изменение на 0.25 везде делает растущими и бесконфликтными 1-3; в 0 сильно падает (но стабилизируется) численность, а 4 вымирает.
            double c = 0.5;  //нек коэф-т 

            for (int s = 0; s < State.numberOfCountries; s++)  //фиксируем страну 
            {
                for (int i = 0; i < State.numberOfCountries; i++)  //фиксируем культуру, у которой будем определять толерантность к другим культурам в данной стране
                {
                    for (int j = 0; j < State.numberOfCountries; j++)  //пробегаем все культуры
                    {
                        if (i != j) tolStruct[s, i, j] = c * (cultStruct[s, i, j] + tolCoeff[s] + tolStruct[s, i, j] * state[s].eduCultResource);     //умножение на коэфт-т с - чтобы не превысить единицы (тк некоторые значения cultStruct[s, i, j] могут быть равны 1)                    
                                                                                                                                                     //можно еще подумать над формулой
                    }
                }
            }
            System.Console.WriteLine("-------Структура матриц толерантности:------");
            arrOut3D(tolStruct);           
        }

        public static void arrOut3D(double[,,] arr)
        {
            for (int l = 0; l < arr.GetLength(0); l++)  //фиксируем "строку" куба (/если смотреть иначе - строку плоской м-цы)
            {
                System.Console.WriteLine("Страна {0}:", l+1);
                for (int m = 0; m < arr.GetLength(1); m++)  //фиксируем строку м-цы в той "строке" куба (/иначе - столбец плоской м-цы)
                {
                    for (int n = 0; n < arr.GetLength(2); n++)  //пробегаем столбцы той м-цы (/пробегаем "в-р-столбец вверх" над плоской м-цей)
                    {
                        System.Console.Write("{0, -6} ", Math.Round(arr[l, m, n], 3) );
                    }
                    System.Console.Write("\n");
                }
                System.Console.WriteLine(); //после каждой итерации внешнего цикла - чтобы вывод был по строкам куба
            }
        }

        public static void MatVekKulStOut(double[,,] cultStruct) //Из куба можно извлечь для каждой страны в-р своей культуры (без учета векторов культур мигрантов в этой стране; при этом вектор своей культуры в этой стране вполне может миняться под влиянием мигрантов). Получим матрицу векторов культур стран (одной стране соотв-ет одна строка):          
        {
            //System.Console.WriteLine("Извлеченная из куба матрица векторов своих культур в странах (одной стране соответствует одна строка): ");

            for (int l = 0; l < cultStruct.GetLength(0); l++)
            {
                for (int m = 0; m < cultStruct.GetLength(1); m++)
                {
                    if (l == m)
                    {
                        for (int n = 0; n < cultStruct.GetLength(2); n++)
                        {
                            System.Console.Write("{0, -6} ", Math.Round(cultStruct[l, m, n], 3) );
                        }
                        System.Console.Write("\n");
                    }
                }
            }
            System.Console.WriteLine();
        }

        public static void cultChange(double[,,] cultureStructure, State[] state, double[,,,] populArray) // изменение культур в каждой стране по тактам.                                                               
        {
            //К культурным изменениям как и у мигрантов, так и у местного населения в каждой стране приводят следующие процессы:
            //а) внутренние процессы культурного взаимовлияния в каждой стране;
            //б) потоки мигрантов между странами.

            //В данной функции задается как механизм внутренних процессов, так и механизм потокового влияния. Задаются они отдельно друг от друга, тк их природа различается.            

            //Случай внутренних процессов:
            //Будем считать, что внутри страны все культурные группы влияют друг на друга. Влияние каждой культурной группы на остальные определяется ее численностью населения и культурным максимумом.

            //Случай потоков:
            //Будем считать, что миграционная волна из страны А в страну В по прибытии в страну В сначала имеет дело преимущественно с преобладающей в В культурой. Поэтому будем считать, что для прибывающего потока мигрантов на начальном этапе происходит взаимовлияние культур только с преобладающей культурой принимающей стороны, а взаимовлиянием с остальными культурами этой страны на данном этапе можно пренебречь. А далее, проживая в стране и начиная участвовать во внутренних процессах страны, мигранты начинают взаимодействовать и с другими группами мигрантов, и начинается взаимовлияние культур и с ними тоже.
            //Таким образом:
            //- влияние на местное население в В зависит от размера входящего потока из А в В и от культуры в А;
            //- влияние на мигрантов из А в В будет зависеть от численности населения преобладающей в стране В культуры и от значения ("силы") этой культуры.




            //в двойном цикле по iz и v пробегаем все возможные сочетания стран. Если стран 5, то сочетаний будет 5*5. Это можно представить как "матрицу процессов" размером 5*5, где номер каждого элемента будет соответствовать номерам пары стран. Элементы с номерами, у которых пары индексов различны, будут представлять потоки между странами (20 шт.). Элементы с одинаковыми номерами в паре (5 шт, расположены на главной диагонали матрицы) - это процессы внутри стран. 
            for (int iz = 0; iz < State.numberOfCountries; iz++)
            {
                for (int v = 0; v < State.numberOfCountries; v++)   //фиксируем iz и v. Так в двойном цикле пробежим все варианты потоков между странами (20 шт) и процессов внутри стран (условно поток из А в А) (5 шт). 
                {
                    double a = 0.001;  //нек коэф-т (будет использоваться при расчете changeForСurrCult, changeForV, changeForIz; в дальнейшем возможно во всех трех случаях будут разные коэф-ты.)

                    //а)
                    if (iz == v)    //Если это одна и та же страна, а не поток между двумя различным странами, то перейдем к рассмотрению культурных процессов внутри одной страны. Для этого от матрицы процессов перейдем к матрице культур данной страны ("строке" куба культур) и будем работать с ней внутри двойного цикла for.
                    {
                        int indexOfLocCult = v; //сохраним номер местной культуры. (Порядковый номер страны совпадает с порядковым номером культуры, что и будет использовано далее.)

                        double[] max = { 0.0, 0.0, 0.0, 0.0, 0.0 };
                        int[] posMax = { -1, -1, -1, -1, -1 };

                        for (int i = 0; i < 5; i++)   //пробегаем строки матрицы данной страны
                        {
                            for (int j = 0; j < 5; j++)   //пробегаем столбцы каждой строки, чтобы найти макс в этой строке
                            {
                                if (max[i] < cultureStructure[indexOfLocCult, i, j])
                                {
                                    max[i] = cultureStructure[indexOfLocCult, i, j];
                                    posMax[i] = j;   //в posMaxIz надо записать последний из индексов, тк далее posMaxIz будет использоваться всегда на месте последнего индекса                          
                                }
                            }
                        }


                        //посчитаем численности всех культурных групп i в данной стране: 
                        double[] sum = new double[5];   //будет временно хранить 5 сумм - по строчкам матрицы в одной "строке" куба за раз. Для каждой страны (под номером indexOfLocCult) будет по пять сумм.

                        for (int iter = 0; iter < populArray.GetLength(0); iter++)
                        {
                            sum[iter] = 0;

                            for (int x = 0; x < populArray.GetLength(1); x++)  //пробегаем возраст
                            {
                                for (int y = 0; y < populArray.GetLength(2); y++)  //пробегаем образование
                                {
                                    for (int z = 0; z < populArray.GetLength(3); z++)  //пробегаем культуры (в данном случае будем выбирать только одну за раз)
                                    {
                                        if (z == iter) sum[iter] += populArray[indexOfLocCult, x, y, z];//надо отойти от for (int s = 0; s < populArr.GetLength(0); s++), тк не нужно пробегать по всем пар-педам стран! пока нужно по одному! И это фиксируем, вместо s ставя indexOfLocCult в populArr[indexOfLocCult, x, y, z]! А культуру там выбираем одну путем приравнивания z == iter!
                                    }
                                }
                            }
                        }



                        double changeForСurrCult;    //в случае процессов внутри одной страны changeForV и changeForIz заменил на одну общую переменную - changeForСurrCult - тк там получается уже не важно, какая культура изначально своя и какие мигрантские. Все культуры начинают влиять друг на друга пропорционально своим численностям.
                        double coeff_changeForСurrCult;     //коэф-т, использующийся при расчете changeForСurrCult                                                       

                        for (int currCult = 0; currCult < State.numberOfCountries; currCult++)    //пробегаем по строчкам матрицы (по четырем мигрантским и одной своей - все будут вычисляться одинаково).
                                                                                                  //Ниже в  cultStruct[] вводимая здесь переменная currCult будет использована в качестве второго индекса - чтобы пробегать строки матрицы. А первый индеск здесь везде будет indexOfLocCult и меняться не будет, тк это строка куба! Она зафиксирована выше как indexOfLocCult!
                        {
                            for (int i = 0; i < State.numberOfCountries; i++)     //Перераспределение значений внутри одной строчки (одного в-ра культур):
                            {
                                //определим значение влияния каждой другой культуры i на данную культуру currCult и произведем перераспределение культур между парой "данная культура currCult - другая культура i".
                                if (i != currCult)      //чтобы не было лишних вычислений (хотя в принципе это не обязательно: при i=indexOfLocCult никаких изменений делать не требуется, но и их не будет, тк в случае одной и той же культуры из нее вычтется changeForV и сразу прибавится снова, те изменений и не будет)
                                {
                                    coeff_changeForСurrCult = 0.001 * sum[i] + 0.01;   //пришлось добавить + 0.01, тк пока численности населений мигрантов пустые, и множитель получался равным 0. Но далее после реализации потоков численности мигрантов должны постепенно начать набираться автоматически!
                                                                                       //при coeff_changeForСurrCult = 0.001 * sum[i]; своя культура не меняется (меняется практ незаметно, на 0.001). А при 0.01 * sum[i] кое-где появ отр знач - в дальнейшем желат выяснить почему. (Мб сначала сделать вывод 0.01 * sum[i] и посмотреть)
                                    changeForСurrCult = coeff_changeForСurrCult * cultureStructure[indexOfLocCult, i, posMax[i]];//первый индекс здесь indexOfLocCult, а не currCult, тк здесь нужен номер "строки" куба. И он должен быть неизменен во всем коде здесь (он определяется выше). А здесь мы работаем внутри одной строки куба! //второй индекс - i, те уходим из строки currCult в строку i и ищем там ее макс! А далее вернемся в строку currCult и будем ее менять.

                                    //перераспределяем значения культур между парой элементов в строке (векторе) выбранной культуры:   
                                    if ((sum[currCult] != 0) && (sum[i] != 0)) //влияние одной культурной группы на другую имеет смысл только в случае, если численности обеих групп ненулевые. Поэтому делаем проверку их численностей, и если хотя бы одна из групп в паре пустая, то перераспеределения культур между этой парой групп не будет.
                                    {
                                        cultureStructure[indexOfLocCult, currCult, posMax[currCult]] -= changeForСurrCult;
                                        cultureStructure[indexOfLocCult, currCult, posMax[i]] += changeForСurrCult;
                                    }


                                }

                            }

                            
                            //Если культура мигрантская, то (в дополнение к описанному выше взаимовлиянию все культур друг на друга) в ее векторе культур дополнительно перераспределим доли культур между ее основной культурой и местной в зависимости от уровня культурного образования в стране. Чем больше средств выделяется на культ образование, быстрее будет увеличиваться доля местной культуры в векторе культур мигрантов, те быстрее будет происходить процесс культурной ассимиляции.
                            double coeff_edu = 0.1 * state[indexOfLocCult].eduCultResource;     //коэф-т, использующийся при расчете влияния культ образования на ассимиляцию
                            double changeEduCult = cultureStructure[indexOfLocCult, currCult, posMax[currCult]] * coeff_edu; //доля макс культуры мигрантов, которую далее будем отнимать от макс культуры мигр. размер доли тем больше, чем больше вложения в культ обр

                            if ((currCult != indexOfLocCult) && (sum[currCult] != 0)) //"&& (sum[currCult] != 0)" - те культурное образование начинает влиять на культуры мигрантов только в том случае, если появляется мигрантское население. Если мигрантов в стране нет, то данные расчеты пропускаются до тех пор, пока они не появятся в стране.  //&& cultureStructure[indexOfLocCult, currCult, posMax[currCult]] !=0?
                            {
                                cultureStructure[indexOfLocCult, currCult, posMax[currCult]] -= changeEduCult;//отнимаем от макс культуры мигрантов ее же долю, размер которой зависит от вложений в культ обр
                                cultureStructure[indexOfLocCult, currCult, posMax[indexOfLocCult]] += changeEduCult;
                                //посмотрел на то, как меняется вывод после этого - в результате у мигрантов доли местной культуры становятся больше во всех странах -- кроме почему-то последней, у которой она наоборот уменьшается! Но у нее вообще сильная культура получается - во всех мигрантских культрух после 10 итераций местная культура уже выше их культур! Поэтому posMax[currCult] вообще уже должно стать равно posMax[indexOfLocCult], и две строчки должны перестать что-то менять, тк отнимаем и прибавляем к одному и тому же эл-ту! Но тут может начинает играть роль какая-то другая зависимость - для этой страны поставил самый большой коэф техн обр, те у нее ур жизни будет быстрее всех повышаться и в нее больше много кто будет хотеть ехать. При этом траты на культ обр у нее низкие по сравн с другими странами, и мб комбинация этих двух факторов приводит к тому, что в нее больше становятся потоки (а потоки в другие страны становятся чуть меньше из-за их культ обр и более низкого ур жизни), и поэтому мб просто мигрантов в стране больше, а из-за этого и их культура меньше меняется? Предположение не проверял, но в принципе такое мб возможно, тк различных связей уже очень много!
                            }

                        }



                    }   //конец обработки процессов внутри одной страны

                    //б)
                    else  //если это не процессы в одной стране, а поток между парой разных стран, то культурные изменения будут вычисляться иначе:
                    {
                        //Сначала делаем поиск максимумов пары стран. Его нужно считать иначе, нежели в случае процессов внутри одной страны (выше) - здесь надо считать макс ПАРЫ iz и v (пара зафиксирована циклом еще выше) - макс страны-источника потока и макс своей страны.

                        //Найдем значение и порядковый номер макс культуры мигранта, значение и порядковый номер принимающей страны:
                        double maxIz = 0;
                        int posMaxIz = -1;  //-1 - те пока позиции нет

                        double maxV = 0;
                        int posMaxV = -1;

                        for (int l = 0; l < cultureStructure.GetLength(0); l++)
                        {
                            for (int m = 0; m < cultureStructure.GetLength(1); m++)
                            {
                                for (int n = 0; n < cultureStructure.GetLength(2); n++)
                                {
                                    if (l == iz && m == iz)
                                    {
                                        if (maxIz < cultureStructure[l, m, n])
                                        {
                                            maxIz = cultureStructure[l, m, n];
                                            posMaxIz = n;   //в posMaxIz надо записать последний из индексов, тк далее posMaxIz будет использоваться всегда на месте последнего индекса                          
                                        }
                                    }

                                    if (l == v && m == v)
                                    {
                                        if (maxV < cultureStructure[l, m, n])
                                        {
                                            maxV = cultureStructure[l, m, n];
                                            posMaxV = n;
                                        }
                                    }
                                }


                            }
                        }
                        //System.Console.WriteLine();
                        //System.Console.WriteLine("Значение макс культуры мигранта (из страны №{0}):\n{1}", iz, maxIz);
                        //System.Console.WriteLine("Номер макс культуры мигранта (из страны №{0}):\n{1}\n", iz, posMaxIz);

                        //System.Console.WriteLine("Значение макс культуры принимающей страны (страна №{0}):\n{1}", v, maxV);
                        //System.Console.WriteLine("Номер макс культуры принимающей страны (страна №{0}):\n{1} \n", v, posMaxV);
                        //System.Console.WriteLine();


                       

                        double changeForV = 0.0001 * state[iz].flowSize[v] * cultureStructure[iz, iz, posMaxIz];//На сколько изменяем вектор культур страны v под влиянием мигрантов из страны iz. Влияние на местное население в В зависит от размера входящего потока из А в В и от культуры в А
                                                                                                                //изначально было 0.001, но это давало слишком быстрое изменение местной культуры под влиянием потоков даже небольшой численности. 0.0001 дает более реалистичные результаты

                        //Окончательный результат - обмен долями между двумя значениями вектора местной культуры:
                        cultureStructure[v, v, posMaxV] -= changeForV;
                        cultureStructure[v, v, posMaxIz] += changeForV;   //Изменение доли культуры страны i в векторе страны j (под влиянием культурного максимума страны i, которым обладают мигранты) - увеличение:


                        //Для проверки работы программы / сравнения результатов до применения изменений changeForIz ниже:
                        //arrOut3D(cultStruct);  
                        //MatVekKulStOut(cultStruct);




                        double changeForIz;  //На сколько изменяем вектор культур мигрантов, приехавших из страны iz в страну v

                        //Посчитаем числ насел в стране v культуры v:
                        double sum = 0;
                        for (int i = 0; i < populArray.GetLength(1); i++)  //фиксируем возраст GetLength(1), а не GetLength(0), тк последнее будет пробегать не по возрастам а странам - а у нас страна уже выбрана, поэтому начинаем сразу со второй размерности массива - те с 1
                        {
                            for (int j = 0; j < populArray.GetLength(2); j++)  //фиксируем образование
                            {
                                for (int k = 0; k < populArray.GetLength(3); k++)  //пробегаем все культуры
                                {
                                    if (k == v) sum += populArray[v, i, j, k];   //if (k != iz) sum += populArr[v, i, j, k]; - если во влиянии учитывать не только людей преобладающей культуры, но и всех остальных, только где культура не совпадает с культурой iz. В текущей версии считаем влияние остальных культур на iz пренебрежительно малым в момент прибытия волны из iz.
                                }
                            }
                        }

                        
                        changeForIz = cultureStructure[v, v, posMaxV] * a * (1.0 - 1.0 / sum) * 1 * state[v].eduCultResource;     //влияние на мигрантов зависит от максимума местной культуры, от численности населения преобладающей в стране культуры и от трат страны на культурное образование. Чем больше выделяется средств на культ обр, тем быстрее будет меняться культура мигрантов в пользу местной культуры, тк быстрее будет происходить культурная ассимиляция.                     
                                                                                        //сумме sum ставим в соответствие нек число между 0 и 1, чтобы коэф-т coeff_changeForIz был похож по величине на coeff_changeForV.Для этого делим 1.0 / sum.Но здесь чем больше сумма, тем меньше будет дробь, а нам нужно наоборот(чем больше население другой культуры, тем больше должно быть влияние), поэтому будем вычитать эту величину из единицы: 1.0 - 1.0 / sum.

                        //Окончательный результат - обмен долями между двумя значениями вектора мигрантов iz, приехавших в страну v: 
                        cultureStructure[v, iz, posMaxIz] -= changeForIz;   //Изменение доли своей культуры (своего культурного максимума) - уменьшение
                        cultureStructure[v, iz, posMaxV] += changeForIz;    //Изменение доли культуры страны (культурного максимума страны) - увеличение

                    }


                }
            }


        }

        public static void initializeLists(double[,,] cultureStructure, State[] state, double[,,,] populArray)  //Добавление в каждый соотв-щий (пока еще пустой) список первым эл-том структуры, заполненной начальными значениями. initializeLists() должна вызываться в головной программе ДО вызова change(), которая начнет менять структуры по тактам. в change() каждая итерация соответствует ситуации ЧЕРЕЗ 1 такт, без нач значений. Поэтому сначала надо сохранить все исходные структуры в соотв списки. Это будут первые (нулевые) элементы в списках. А дальше в конце каждой итерации в change() в каждый список будет добавляться структура с измененными к концу такта значениями.
        {            
            double[,,] initialCultStr = new double[5, 5, 5];    //Создание нового объекта здесь НЕОБХОДИМО при КАЖДОЙ итерации по t/NumOfIterations! эта строчка должна быть внутри цикла по кол-ву итераций, и вынести ее из цикла вверх нельзя! Потому что если объявить объект currCultStr выше цикла, то объявление произойдет всего один раз, и объект получит какой-то ОДИН адрес. Далее в конце каждого цикла копирование "Array.Copy(cultureStructure, currCultStr, 125);" будет происходить на один и тот же адрес, после чего "cultarrayList.Add(currCultStr);" будет добавлять в конец списка ссылку на все тот же один адрес - и в итоге список будет заполнен одинаковыми экземплярами! Значение которых будет равно значению последней из струкур, те значению с последней итерации! А чтобы значения были разными, нужно создавать новый объект currCultStr при КАЖДОЙ итерации! Тогда каждый раз у него будет свой адрес, и в итоге в списке будут храниться ссылки на разные адреса, что и позволит все записать правильно! И + еще нужно использовать "Array.Copy(cultureStructure, currCultStr, 125);" (см комментарий к строке с Array.Copy), чтобы при каждой итерации копировалось значение, а не ссылка. Это все нужно из-за того, что делаем это внутри цикла, тк при выходе из цикла связи по сссылкам нарушаются! Т.о., из-за вычислений внутри цикла нужна как эта строка здесь, так и строка с Array.Copy ниже, и они должны обе быть вунтри цикла по t. 
            Array.Copy(cultureStructure, initialCultStr, cultureStructure.Length);  //Нам нужно передать значение cultureStructure на каждой итерации в cultarrayList - именно значение, а не ссылку на cultureStructure, поэтому надо использовать Array.Copy, а не просто присваивание "currCultStr = cultureStructure;"! Если написать "currCultStr = cultureStructure;", то будет передано не знач cultureStructure, а ссылка на cultureStructure! Разница здесь важна, пскольку мы находимся внутри цикла! При "currCultStr = cultureStructure;" на всех итерациях ссылка будет одна и та же - на cultureStructure! И если внутри цикла это ссылки на разные cultureStructure, существующие внутри цикла, то при выходе цикла это все становится ссылками на один и тот же cultureStructure, тк вне цикла он сущ-ет только в одном экземпляре! Поэтому для копир значений нужно использовать Array.Copy!
            Structs.cultarrayList.Add(initialCultStr);      //если использовать здесь Structs, то отпадает необходимость добавлять список в параметры ф-ии, да еще с ref. Так получается проще


            double[] initialPopul = new double[State.numberOfCountries];   //Изначально планировал создать список, где эл-ми будут массивы объектов гос-в, и сохранять туда по одному массиву объектов на каждом такте. Но это оказалось непросто рализовать: из-за того, что это объекты, тип у которых пользовательский (в данном случае это State), С# не знает, как это обрабатывать, и Array.Copy для массива ОБЪЕКТОВ работать не будет! Чтобы можно было скопировать объекты полностью со всеми св-вами, надо делать так наз deep copy - и для этого надо писать спец ф-ию копирования специально для своего пользовательского типа данных! Подробнее здесь: https://stackoverflow.com/questions/1215198/c-sharp-copy-array-by-value. Отмеченный ответ нав помог бы, но реализация сложная, и проще нав сделать по списку для каждого нужного св-ва и уже в те списки все сохранять на каждом такте! У св-в типа обычные, и с ними проблем не будет!
            for (int i = 0; i < state.Length; i++) initialPopul[i] = state[i].population;
            Structs.populArrayList.Add(initialPopul);


            double[,] initialPopulByCults = new double[State.numberOfCountries, State.numberOfCountries];  //м-ца 5*5 для хранения численностей всех культур в каждой стране
            for (int s = 0; s < populArray.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
            {
                for (int i = 0; i < populArray.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < populArray.GetLength(2); j++)  //фиксируем образование
                    {
                        for (int k = 0; k < populArray.GetLength(3); k++)  //пробегаем все культуры
                        {
                            initialPopulByCults[s, k] += populArray[s, i, j, k];       //sumOfCultGroup[k] += populArray[tab, age, edu, k];
                        }
                    }
                }
            }
            Structs.populByCultsArrayList.Add(initialPopulByCults);    //если использовать здесь Structs, то отпадает необходимость добавлять список в параметры ф-ии, да еще с ref. Так получается проще

            double[,] initialPopulByAge = new double[State.numberOfCountries, populArray.GetLength(1)];  //м-ца 5*3 для хранения численностей всех возрастных групп в каждой стране
            for (int s = 0; s < populArray.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
            {
                for (int i = 0; i < populArray.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < populArray.GetLength(2); j++)  //фиксируем образование
                    {
                        for (int k = 0; k < populArray.GetLength(3); k++)  //пробегаем все культуры
                        {
                            initialPopulByAge[s, i] += populArray[s, i, j, k];
                        }
                    }
                }
            }
            Structs.populByAgeArrayList.Add(initialPopulByAge);    //если использовать здесь Structs, то отпадает необходимость добавлять список в параметры ф-ии, да еще с ref. Так получается проще


            double[] initialEdu = new double[State.numberOfCountries];
            for (int i = 0; i < state.Length; i++) initialEdu[i] = state[i].education;
            Structs.eduArrayList.Add(initialEdu);


            double[] initialStandard = new double[State.numberOfCountries];
            for (int i = 0; i < state.Length; i++) initialStandard[i] = state[i].standardOfLiving;
            Structs.standOfLivArrayList.Add(initialStandard);


            double[] initialInstIndex = new double[State.numberOfCountries];
            for (int i = 0; i < state.Length; i++) initialInstIndex[i] = state[i].socInstabilityIndex;
            Structs.instabIndexArrayList.Add(initialInstIndex);
        }

        public static void change(double[,,] cultureStructure, ref List<double[,,]> cultarrayList, State[] state, ref List<double[]> populArrayList, double[,,,] populArray, double[,,] tolStruct) // изменение культур и других параметров в каждой стране по тактам.                                                                                                                
        {
            
            System.Console.WriteLine("Введите количество тактов:");
            int NumOfIterations = int.Parse(System.Console.ReadLine());

            for (int t = 0; t < NumOfIterations; t++)
            {
                cultChange(cultureStructure, state, populArray);

                //далее аналогично как в initializeLists() - надо добавить в соотв список соотв структуру (теперь она изменена в результуте такта):
                //После исполнения cultChange() в каждой итерации сохраняем копию cultureStructure (в том виде, в котором структура cultureStructure находится к концу такта) в список массивов cultarrayList
                double[,,] currCultStr = new double[5, 5, 5]; //Создание нового объекта currCultStr НЕОБХОДИМО при КАЖДОЙ итерации по t/NumOfIterations! эта строчка должна быть внутри цикла по кол-ву итераций, и вынести ее из цикла вверх нельзя! Потому что если объявить объект currCultStr выше цикла, то объявление произойдет всего один раз, и объект получит какой-то ОДИН адрес. Далее в конце каждого цикла копирование "Array.Copy(cultureStructure, currCultStr, 125);" будет происходить на один и тот же адрес, после чего "cultarrayList.Add(currCultStr);" будет добавлять в конец списка ссылку на все тот же один адрес - и в итоге список будет заполнен одинаковыми экземплярами! Значение которых будет равно значению последней из струкур, те значению с последней итерации! А чтобы значения были разными, нужно создавать новый объект currCultStr при КАЖДОЙ итерации! Тогда каждый раз у него будет свой адрес, и в итоге в списке будут храниться ссылки на разные адреса, что и позволит все записать правильно! И + еще нужно использовать "Array.Copy(cultureStructure, currCultStr, 125);" (см комментарий к строке с Array.Copy), чтобы при каждой итерации копировалось значение, а не ссылка. Это все нужно из-за того, что делаем это внутри цикла, тк при выходе из цикла связи по сссылкам нарушаются! Т.о., из-за вычислений внутри цикла нужна как эта строка здесь, так и строка с Array.Copy ниже, и они должны обе быть вунтри цикла по t. 
                Array.Copy(cultureStructure, currCultStr, cultureStructure.Length); //Нам нужно передать значение cultureStructure на каждой итерации в cultarrayList - именно значение, а не ссылку на cultureStructure, поэтому надо использовать Array.Copy, а не просто присваивание "currCultStr = cultureStructure;"! Если написать "currCultStr = cultureStructure;", то будет передано не знач cultureStructure, а ссылка на cultureStructure! Разница здесь важна, пскольку мы находимся внутри цикла! При "currCultStr = cultureStructure;" на всех итерациях ссылка будет одна и та же - на cultureStructure! И если внутри цикла это ссылки на разные cultureStructure, существующие внутри цикла, то при выходе цикла это все становится ссылками на один и тот же cultureStructure, тк вне цикла он сущ-ет только в одном экземпляре! Поэтому для копир значений нужно использовать Array.Copy!
                cultarrayList.Add(currCultStr);

                
                changeTolStruct(tolStruct, cultureStructure, state);

                flow(populArray, state);

                eduChange(populArray, state);

                demographicChange(populArray, state);

                System.Console.WriteLine("recalculateStateObjects - такт №{0}:", t+1);   //начальный момент времени - до начала изменения по тактам t - выводится при вызове initializeStateObjects(), поэтому здесь начинаем отсчет с 1. (Альтернативно можно в начале цикла t задать начинающимся с 1, но я решил все циклы начинать с 0, а корректировать только вывод где нужно.)
                recalculateStateObjects(populArray, state);     // после всех модификаций надо обновить расчеты полей и св-в объектов (стран).


                double[] popul = new double[State.numberOfCountries];   //Изначально планировал создать список, где эл-ми будут массивы объектов гос-в, и сохранять туда по одному массиву объектов на каждом такте. Но это оказалось непросто рализовать: из-за того, что это объекты, тип у которых пользовательский (в данном случае это State), С# не знает, как это обрабатывать, и Array.Copy для массива ОБЪЕКТОВ работать не будет! Чтобы можно было скопировать объекты полностью со всеми св-вами, надо делать так наз deep copy - и для этого надо писать спец ф-ию копирования специально для своего пользовательского типа данных! Подробнее здесь: https://stackoverflow.com/questions/1215198/c-sharp-copy-array-by-value. Отмеченный ответ нав помог бы, но реализация сложная, и проще нав сделать по списку для каждого нужного св-ва и уже в те списки все сохранять на каждом такте! У св-в типа обычные, и с ними проблем не будет!
                for (int i = 0; i < state.Length; i++) popul[i] = state[i].population;
                populArrayList.Add(popul);


                double[,] populByCults = new double[State.numberOfCountries, State.numberOfCountries];  //м-ца 5*5 для хранения численностей всех культур в каждой стране
                for (int s = 0; s < populArray.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
                {
                    for (int i = 0; i < populArray.GetLength(1); i++)  //фиксируем возраст
                    {
                        for (int j = 0; j < populArray.GetLength(2); j++)  //фиксируем образование
                        {
                            for (int k = 0; k < populArray.GetLength(3); k++)  //пробегаем все культуры
                            {
                                populByCults[s, k] += populArray[s, i, j, k];       //sumOfCultGroup[k] += populArray[tab, age, edu, k];
                            }
                        }
                    }
                }                
                Structs.populByCultsArrayList.Add(populByCults);    //если использовать здесь Structs, то отпадает необходимость добавлять список в параметры ф-ии, да еще с ref. Так получается проще


                double[,] populByAge = new double[State.numberOfCountries, populArray.GetLength(1)];  //м-ца 5*3 для хранения численностей всех возрастных групп в каждой стране
                for (int s = 0; s < populArray.GetLength(0); s++)  //фиксируем пар-пед страны внутри пар-педа всех стран 
                {
                    for (int i = 0; i < populArray.GetLength(1); i++)  //фиксируем возраст
                    {
                        for (int j = 0; j < populArray.GetLength(2); j++)  //фиксируем образование
                        {
                            for (int k = 0; k < populArray.GetLength(3); k++)  //пробегаем все культуры
                            {
                                populByAge[s, i] += populArray[s, i, j, k];       
                            }
                        }
                    }
                }
                Structs.populByAgeArrayList.Add(populByAge);    //если использовать здесь Structs, то отпадает необходимость добавлять список в параметры ф-ии, да еще с ref. Так получается проще



                double[] edu = new double[State.numberOfCountries];   
                for (int i = 0; i < state.Length; i++) edu[i] = state[i].education;
                Structs.eduArrayList.Add(edu);


                double[] standard = new double[State.numberOfCountries];   
                for (int i = 0; i < state.Length; i++) standard[i] = state[i].standardOfLiving;
                Structs.standOfLivArrayList.Add(standard);


                double[] instIndex = new double[State.numberOfCountries];
                for (int i = 0; i < state.Length; i++) instIndex[i] = state[i].socInstabilityIndex;
                Structs.instabIndexArrayList.Add(instIndex);



                //К концу шага имеем:     
                System.Console.WriteLine("-----------------------------После такта №{0}:-------------------------------", t+1);

                System.Console.WriteLine("Структура культур мигрантов в каждой из стран: ");
                arrOut3D(cultureStructure);

                System.Console.WriteLine("Извлеченная из куба матрица векторов своих культур в странах (одной стране соответствует одна строка): ");
                MatVekKulStOut(cultureStructure);
                
            }

        }





    }
}
