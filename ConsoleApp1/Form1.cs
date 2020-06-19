using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; //for SeriesChartType

namespace ConsoleApp1
{
    public partial class Form1 : Form
    {
        //BindingSource bs = new BindingSource();        

        public Form1()
        {
            InitializeComponent();

            //bs.DataSource = lohs;
            //bs.DataMember = "Lohs";
            
            //chart1.DataSource = cultureStructure;
        }


        TabControl tabCtrl = new TabControl(); //такие переменные лучше объявлять  вне ф-ий и циклов - иначе их не буедт видно в других ф-иях - что может оказаться нужным!
        
        TabPage[] tabs = new TabPage[State.numberOfCountries];
        
        Chart[,] cultCharts = new Chart[State.numberOfCountries, State.numberOfCountries];  //Chart[] cultCharts = new Chart[State.numberOfCountries]; //чтобы можно было по клику кнопки все графики на всех вкладках менять, надо их всех создавать вне Form1_Load()! Но тогда все должно быть немного иначе - и ех cultCharts должен быть на размерность больше, те двухмерный! чтобы учитывались вкладки, иначе автоматически будет скчитаться, что этот массив графиков относится к последней вкладке! Я графики создавал в цикле, и там это работало - cultCharts использовался повторно (перезаписывался) в каждой итерации - но если я хочу все видеть вне циклов и ф-ии Form_Load(), надо хранить все графики! А значит надо на размерность больше!
        string [,,] seriesName = new string[State.numberOfCountries, State.numberOfCountries, Structs.cultarrayList.Count]; //пар-пед из стрингов - имен всех графиков (линий) культур. Почему такая размерность: можно все представить себе как матрицу 5*5, где каждый столбец - это одна вкладка, а каждая строка - графики одной культуры по странам/столбцам/вкладкам - аналогично как у меня все строится. А на кажом графике еще есть линии, число которых равно числу тактов! И поскольку они накладываются друг на друга на каждом графике, их можно представить как накапливающиеся/растущие вверх эл=ты пар-педа над каждым эл-том плоской м-цы 5*5! Вверх их будет столько, сколько было тактов - а к моменту создания окна это уже известно! Поэтому могу создать массив с четко определенной размерностью!

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //размеры окна
            // no smaller than design time size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;





            //TabControl tabCtrl = new TabControl();
            tabCtrl.Dock = DockStyle.Fill;  //вкладки растянуть на весь размер окна (формы)
            Controls.Add(tabCtrl);


            //TabPage[] tabs = new TabPage[State.numberOfCountries];          


           
            for (int tab = 0; tab < State.numberOfCountries; tab++)     //цикл создания вкладок. Одна вкладка соотв-ет одной стране (в структуре культур - одной "строке" куба)
            {
                string title = "Страна " + (tabCtrl.TabCount + 1).ToString();
                tabs[tab] = new TabPage(title);   // создаем новый объект, который будет в массиве иметь индекс tab. (все эл-ты массива нужно задать/создать как объекты, чтобы их можно было использовать)
                tabCtrl.TabPages.Add(tabs[tab]);
                tabs[tab].AutoScroll = true; // это надо делать для каждой вкладки отдельно



                /*Chart[] cultCharts = new Chart[State.numberOfCountries];*/    //массив графиков культур одной страны. Для каждой страны будет по 5 графиков культур.

                for (int line = 0; line < State.numberOfCountries; line++)      //цикл создания графиков культур для одной страны - те внутри одной вкладки. (для одной страны/вкладки по 5 графиков культур)
                {
                    cultCharts[tab, line] = new Chart(); //cultCharts[line] = new Chart();

                    cultCharts[tab, line].ChartAreas.Add("ChartArea1");
                    if (line == tab) cultCharts[tab, line].ChartAreas["ChartArea1"].BackColor = Color.LightYellow; //выделим график своей культуры данной страны
                    cultCharts[tab, line].ChartAreas[0].AxisX.Title = "культуры";
                    cultCharts[tab, line].ChartAreas[0].AxisY.Title = "доли";

                    //cultCharts[tab, line].Titles.Add("культурная группа " + (line + 1).ToString() +"    ");   //занимает слишком много места

                    cultCharts[tab, line].ChartAreas[0].AxisX.Maximum = 5;   //4
                    cultCharts[tab, line].ChartAreas[0].AxisX.Minimum = 1;   //0

                    cultCharts[tab, line].ChartAreas[0].AxisY.Maximum = 1;

                    cultCharts[tab, line].Size = new System.Drawing.Size(550, 120);
                    if (line > 0) cultCharts[tab, line].Top = cultCharts[tab, line - 1].Bottom;

                    tabs[tab].Controls.Add(cultCharts[tab, line]);    //чтобы вывести в этой вкладке  

    

                    Legend leg = new Legend();
                    cultCharts[tab, line].Legends.Add(leg);
                    leg.Docking = Docking.Right;
                    leg.IsDockedInsideChartArea = true;
                    leg.MaximumAutoSize = 20;
                    leg.LegendStyle = LegendStyle.Table;
                    leg.IsTextAutoFit = true;
                    leg.Title = "Распределение долей культур в векторе k" + (line + 1).ToString();


                    //посчитаем население данной культуры в стране. Если в итоге численность будет нулевая, то данная группа отсутствует в стране, и для нее выводить ничего не будем.
                    double sum = 0;
                    for (int i = 0; i < Structs.populArray.GetLength(1); i++)   
                    {
                        for (int j = 0; j < Structs.populArray.GetLength(2); j++)
                        {
                            sum += Structs.populArray[tab, i, j, line];
                        }
                    }

                    //строим графики (линии) только в том случае, если это имеет смысл - если численность данной культурной группы в стране ненулевая:
                    if (sum != 0) 
                    {
                        for (int l = 0; l < Structs.cultarrayList.Count; l++) //построение графиков (линий). Линий столько, сколько задано число итераций
                        {
                            //string seriesName;
                            //seriesName[tab, line, l] = new seriesName();//[State.numberOfCountries, State.numberOfCountries, Structs.cultarrayList.Count];
                            if (l == 0) seriesName[tab, line, l] = "t=0";   //"нач. знач.";  //if (l == 0) seriesName = "нач. знач.";
                            else seriesName[tab, line, l] = "t=" + l.ToString();
                            cultCharts[tab, line].Series.Add(seriesName[tab, line, l]);

                            cultCharts[tab, line].Series[seriesName[tab, line, l]].ChartType = SeriesChartType.Line;

                            if (l == 0 || l == Structs.cultarrayList.Count - 1) cultCharts[tab, line].Series[seriesName[tab, line, l]].BorderWidth = 3; //выделим жирным первый и последний графики (линии)
                            else cultCharts[tab, line].Series[seriesName[tab, line, l]].BorderWidth = 1;

                            cultCharts[tab, line].Series[seriesName[tab, line, l]].ChartArea = "ChartArea1";

                            for (int i = 0; i < State.numberOfCountries; i++)   //что делать с каждым графиком (линией)
                            {
                                cultCharts[tab, line].Series[seriesName[tab, line, l]].Points.AddXY(i+1, Structs.cultarrayList[l][tab, line, i]);
                            }
                        }
                    }
                    else //если сумма равна 0, то отметим это на графике
                    {
                        cultCharts[tab, line].ChartAreas["ChartArea1"].BackColor = Color.LightGray;
                        Title ty1 = cultCharts[tab, line].Titles.Add("Численность культурной группы k" + (line + 1).ToString() + " в стране s" + (tab + 1).ToString() + " на момент t=" + (Structs.cultarrayList.Count - 1).ToString() + " нулевая"); //("Численность данной культурной группы в стране на данный момент нулевая");                           
                    }






                    //Labels
                    Label[] lbs = new Label[State.numberOfCountries];   //по одному полю напротив каждого графика культуры для выведения информации о конфликтах с другими культурами
                    lbs[line] = new Label();
                    tabs[tab].Controls.Add(lbs[line]);
                    lbs[line].Size = new Size(100, 80);
                    lbs[line].Location = new Point(550, 0);
                    lbs[line].BackColor = Color.LightGreen;
                    if (line > 0) lbs[line].Top = cultCharts[tab, line - 1].Bottom;
                    lbs[line].Text = "Конфликтов культур нет";

                    //Окрашивание лейблов красным у культур, находящихся в конфликте с другими культурами. Рассчитывается очень похоже на socInstabilityIndexCalculation(), но немного отличается по причинам, опичываемым ниже - это просто немного разные вещи. Кроме того, окрашивание показывает с ситуацию с конфликтами на ПОСЛЕДНИЙ такт, а в socInstabilityIndexCalculation() рассчитввается индекс для каждого такта.
                    //наличие конфликтов (окрашивание участников) и индекс нестаб надо считать немного по-разному? Тк в каждом конфликте задействованы как агрессор, так и жертва (которая со своей стороны тоже может быть агрессором, но не обязательно), а на индекс нестабильность должны по-хорошему влиять ТОЛЬКО агрессоры!
                    //Расчет по-разному:
                    //-окрашивание: При наличии хотя бы одного агрессора в каждой паре культур (те даже если агрессия одной культуры к другой происходит при отсутствии агрессии в обратную сторону) надо окрашивать красным обоих! Даже если жертва безответная, ее все равно закрашивать - тк она пусть невольно, но является частью конфликта! 
                    //-индекс нестаб: должен зависеть только от агрессоров? при рассматривании наличия проблем/конфликтов и окрашивании безответная жертва невольно является частью конфликта и потому окрашивается - но при этом она сама нестабильность не увеличивает! Нестабильность увеличивают только агрессоры! Поэтому на индекс нестаб должны влиять только агрессоры! Поэтому в ифе надо делать только одну проверку! И то если в паре оба агрессоры по отн друг к другу, индекс соц нестаб будет выше, чем если агрессор только один!! Это вполне имеет смысл учитывать!!
                    //также см код socInstabilityIndexCalculation()
                    for (int i = 0; i < State.numberOfCountries; i++)   //сравним взаимные толерантности культуры line со всеми остальными культурами i (а в коде индекса сравнивали не взаимные, а односторонние - только агрессора к жертве!)
                    {
                        if ((Structs.toleranceStructure[tab, line, i] < 0.15) || (Structs.toleranceStructure[tab, i, line] < 0.15))         //если толерантность культуры i к культуре line (или наоборот) на конец рассматриваемого периода (те после последнего такта) ниже предельно допустимого значения, то это указывает на ПОТЕНЦИАЛЬНУЮ нестабильность между этой парой культур. РЕАЛЬНАЯ нестабильность будет иметь место, если численности обеих культур ненулевые (проверка на это осуществляется ниже). Здесь не важно, кто "агрессор", а кто "жертва" - в каждой паре культур каждая культура может играть каждую из ролей, поэтому каждую культуру в паре надо проверить и на агрессора, и на жертву! И реальный конфликт возникнет, если обе культуры ненулевые.                  
                                                                                                                                            //условие "наоборот" (те помимо направления тол-ти line-->i еще и i-->line) проверять НУЖНО: так мы будет ниже окрашивать график культуры в случае, если данная культура является ЖЕРТВОЙ в паре с нек другой культурой ИЛИ АГРЕССОРОМ в той же паре - те закрашивать будем в обоих случаях! Что и должно быть! А если сделать только одну из проверок выше, ех первую, то может оказаться, что ех в случае толерантной к агрессору жертвы мы закрасим график агрессора, а когда в цикле дойдем до жертвы, у нее нетолер-ти к аггр не обнаружим, и ее график не закрасим! Поэтому надо делать условие ИЛИ! Если в паре культур одна культ хотя бы одно из "Ж или Агр", то ее закрашиваем! Так все жертвы и все агрессоры будут закрашены! 
                        {
                            double sumOfCultGroup1 = 0;
                            double sumOfCultGroup2 = 0;

                            for (int age = 0; age < Structs.populArray.GetLength(1); age++)
                            {
                                for (int edu = 0; edu < Structs.populArray.GetLength(2); edu++)
                                {
                                    sumOfCultGroup1 += Structs.populArray[tab, age, edu, i];
                                    sumOfCultGroup2 += Structs.populArray[tab, age, edu, line];
                                }
                            }

                            if ((sumOfCultGroup1 > 1) && (sumOfCultGroup2 > 1)) //проверка на ненулевую/не слишком малую численность обеих культур в стране (иначе не имеет смысла говорить о нестабильности между ними)
                            {
                                //charts[line].BackColor = Color.RosyBrown; //если данная культурная группа в стране конфликтует хотя бы с одной другой культурной группой, будем считать это нестабильностью и выделим данный график красным фономю (Не важно, кто агрессор и кто жертва - здесь выделяем просто факт реальной нестабильности/конфликта - это важный показатель ситуации в стране. А кто инициатор не так важно; пери желании это можно посмотреть в м-це толер-ти в консоли.) //решил график весь не выделять - слишком сильно получается - лучше сделать все в одлельном Label рядом! И цветовое выделение, и текст!

                                if (!lbs[line].Text.Contains("Есть конфликт с культурами:")) lbs[line].Text = "Есть конфликт с культурами:";
                                lbs[line].Text += "\n" + (i+1).ToString();
                                lbs[line].BackColor = Color.RosyBrown; //Color.LemonChiffon;//Color.LightGoldenrodYellow;

                            }

                        }
                    }



                }




                Chart populationChart = new Chart(); //один график для одной страны/вкладки (она зафиксирована выше)
                tabs[tab].Controls.Add(populationChart);    //чтобы вывести в этой вкладке 

                populationChart.Location = new Point(700, 0); //Set the Location property of the control to a Point.
                populationChart.Size = new System.Drawing.Size(400, 300); //(400, 200); //(500, 150);

                populationChart.ChartAreas.Add("ChartArea1");
                populationChart.ChartAreas[0].AxisX.Title = "Время";
                populationChart.ChartAreas[0].AxisX.Minimum = 0;    //= 0;
                populationChart.ChartAreas[0].AxisX.Maximum = Structs.populArrayList.Count - 1; //надо -1, мы выводим начиная с нулевого элемента и выводим все эл-ты списка. В цикле в подобной ситуации не надо -1, тк там было бы МЕНЬШЕ populArrayList.Count - а здесь не меньше, а присвоение! А нам на самом деле нужно меньше, тк начинаем с нуля, поэтому нужно -1!

                Legend populLeg = new Legend();
                populationChart.Legends.Add(populLeg);
                populLeg.Docking = Docking.Right;
                populLeg.IsDockedInsideChartArea = true;
                populLeg.MaximumAutoSize = 28; //25;
                populLeg.LegendStyle = LegendStyle.Table;
                populLeg.IsTextAutoFit = true;
                populLeg.Title = "Динамика численности населения в стране";

                Series populSeries = new Series();
                populationChart.Series.Add(populSeries);
                populSeries.Name = "Общ числ";
                populSeries.ChartArea = "ChartArea1";
                populSeries.ChartType = SeriesChartType.Line;
                populSeries.BorderWidth = 2; //выделим график общей численности пожирнее


                for (int year = 0; year < Structs.populArrayList.Count; year++)     //график (линия) общей численности населения в данной стране по тактам
                {
                    populSeries.Points.AddXY(year, Structs.populArrayList[year][tab]);  //динамика численности в стране tab по годам
                }


                for (int l = 0; l < State.numberOfCountries; l++)   //построение графиков (линий) численностей всех культ групп в стране
                {
                    string seriesName = "cult" + (l+1).ToString();
                    if (l == tab) seriesName += " (местная)";
                    populationChart.Series.Add(seriesName);

                    populationChart.Series[seriesName].ChartArea = "ChartArea1";

                    populationChart.Series[seriesName].ChartType = SeriesChartType.Line;
                    if (l == tab) populationChart.Series[seriesName].BorderWidth = 2; //выделим жирным график (линию) численности местной культуры. (То, жирным будет два графика - общей численности и местной. Можно еще подумать, как мб их по-раному выделить)

                    for (int year = 0; year < Structs.populByCultsArrayList.Count; year++)   //что делать с каждым графиком (линией)
                    {
                        populationChart.Series[seriesName].Points.AddXY(year, Structs.populByCultsArrayList[year][tab, l]);
                    }
                }




                Chart demographyChart = new Chart(); //один график для одной страны/вкладки (она зафиксирована выше)
                tabs[tab].Controls.Add(demographyChart);    //чтобы вывести в этой вкладке 

                demographyChart.Top = populationChart.Bottom + 10;     //demographyChart.Location = new Point(700, 0); //Set the Location property of the control to a Point.
                demographyChart.Left = populationChart.Left; //если этого не задать, то по умолч будет в левом углу окна - и окажется под графиками культур

                demographyChart.Size = new System.Drawing.Size(400, 150); //(300, 200); //(400, 200); //(500, 150);

                demographyChart.ChartAreas.Add("ChartArea1");
                demographyChart.ChartAreas[0].AxisX.Minimum = 0;
                demographyChart.ChartAreas[0].AxisX.Maximum = Structs.populArrayList.Count - 1;

                Legend demogrLeg = new Legend();
                demographyChart.Legends.Add(demogrLeg);
                demogrLeg.Docking = Docking.Right;
                demogrLeg.IsDockedInsideChartArea = true;
                demogrLeg.MaximumAutoSize = 30; //25;
                demogrLeg.LegendStyle = LegendStyle.Table;
                demogrLeg.IsTextAutoFit = true;
                demogrLeg.Title = "Динамика численностей возрастных групп";//"Демография";

                for (int l = 0; l < Structs.populArray.GetLength(1); l++)   //построение графиков (линий) численностей всех возр групп в стране
                {
                    string seriesName = "возр. группа " + (l+1).ToString();
                    demographyChart.Series.Add(seriesName);

                    demographyChart.Series[seriesName].ChartArea = "ChartArea1";

                    demographyChart.Series[seriesName].ChartType = SeriesChartType.Line;                    

                    for (int year = 0; year < Structs.populByAgeArrayList.Count; year++)   //что делать с каждым графиком (линией)
                    {
                        demographyChart.Series[seriesName].Points.AddXY(year, Structs.populByAgeArrayList[year][tab, l]);
                    }
                }




                Chart educationChart = new Chart(); //один график для одной страны/вкладки (она зафиксирована выше)
                tabs[tab].Controls.Add(educationChart);    //чтобы вывести в этой вкладке 

                educationChart.Top = demographyChart.Bottom + 10;     //demographyChart.Location = new Point(700, 0); //Set the Location property of the control to a Point.
                educationChart.Left = populationChart.Left; //если этого не задать, то по умолч будет в левом углу окна - и окажется под графиками культур

                educationChart.Size = new System.Drawing.Size(400, 100); //(300, 200); //(400, 200); //(500, 150);

                educationChart.ChartAreas.Add("ChartArea1");
                educationChart.ChartAreas[0].AxisX.Minimum = 0;
                educationChart.ChartAreas[0].AxisX.Maximum = Structs.eduArrayList.Count - 1;

                Legend eduLeg = new Legend();
                educationChart.Legends.Add(eduLeg);
                eduLeg.Docking = Docking.Right;
                eduLeg.IsDockedInsideChartArea = true;
                eduLeg.MaximumAutoSize = 30; 
                eduLeg.LegendStyle = LegendStyle.Table;
                eduLeg.IsTextAutoFit = true;
                eduLeg.Title = "Динамика численности образованных";

                Series eduSeries = new Series();
                educationChart.Series.Add(eduSeries);
                eduSeries.Name = "Кол-во образованных";
                eduSeries.ChartArea = "ChartArea1";
                eduSeries.ChartType = SeriesChartType.Line;
                eduSeries.BorderWidth = 2;

                for (int year = 0; year < Structs.eduArrayList.Count; year++)     //график (линия) численности образованных в данной стране по тактам
                {
                    eduSeries.Points.AddXY(year, Structs.eduArrayList[year][tab]);  //динамика численности образованных в стране tab по годам
                }


            }




            TabPage lastIterationStatsTab = new TabPage();   //доп вкладка с доп статистикой по ситуации на посл такт
            tabCtrl.TabPages.Add(lastIterationStatsTab);
            lastIterationStatsTab.Text = "Последний такт";
            lastIterationStatsTab.AutoScroll = true;

            Chart[] demogrByStatesCharts = new Chart[State.numberOfCountries];

            //5 графиков демографии - по числу стран:
            for (int line = 0; line < State.numberOfCountries; line++) 
            {
                demogrByStatesCharts[line] = new Chart();
                lastIterationStatsTab.Controls.Add(demogrByStatesCharts[line]);    //чтобы вывести в этой вкладке

                demogrByStatesCharts[line].ChartAreas.Add("ChartArea1");
                demogrByStatesCharts[line].ChartAreas[0].AxisY.Title = "Численности";
                demogrByStatesCharts[line].ChartAreas[0].AxisX.Title = "Возраста";

                demogrByStatesCharts[line].Size = new System.Drawing.Size(500, 120); //Size(550, 120);
                if (line > 0) demogrByStatesCharts[line].Top = demogrByStatesCharts[line - 1].Bottom;                

                Legend demogrLeg = new Legend();
                demogrByStatesCharts[line].Legends.Add(demogrLeg);
                demogrLeg.Docking = Docking.Right;
                demogrLeg.IsDockedInsideChartArea = true;
                demogrLeg.MaximumAutoSize = 30; //25;
                demogrLeg.LegendStyle = LegendStyle.Table;
                demogrLeg.IsTextAutoFit = true;
                demogrLeg.Title = "Демография";


                Series LocalPopulSeries = new Series();
                demogrByStatesCharts[line].Series.Add(LocalPopulSeries);
                LocalPopulSeries.Name = "Местные";
                LocalPopulSeries.ChartArea = "ChartArea1";
                LocalPopulSeries.ChartType = SeriesChartType.Bar;

                Series MigPopulSeries = new Series();
                demogrByStatesCharts[line].Series.Add(MigPopulSeries);
                MigPopulSeries.Name = "Мигранты";
                MigPopulSeries.ChartArea = "ChartArea1";
                MigPopulSeries.ChartType = SeriesChartType.Bar; //StackedBar;

                //LocalPopulSeries.Label = "#PERCENT{P0}";    //"возр#VALX   #PERCENT{P0} (#VAL{0})";
                //MigPopulSeries.Label = "#PERCENT{P0}";  //"возр#VALX   #PERCENT{P0} (#VAL{0})";

                double[] localsByAge = new double[3];   //для каждой страны будет по 3 суммы своих и по 3 суммы мигрантов
                double[] migrantsByAge = new double[3];

                for (int i = 0; i < Structs.populArray.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < Structs.populArray.GetLength(2); j++)  //фиксируем образование
                    {
                        for (int k = 0; k < Structs.populArray.GetLength(3); k++)  //пробегаем все культуры
                        {
                            if (line == k) localsByAge[i] += Structs.populArray[line, i, j, k];
                            else migrantsByAge[i] += Structs.populArray[line, i, j, k];
                        }
                    }
                }


                for (int age = 0; age < Structs.populArray.GetLength(1); age++)
                {
                    MigPopulSeries.Points.AddXY(age+1, migrantsByAge[age]);
                    LocalPopulSeries.Points.AddXY(age+1, localsByAge[age]);
                }

            }





            Chart[] sharesOfCultsCharts = new Chart[State.numberOfCountries];

            //5 графиков численностей по культурам в кажд стране:
            for (int line = 0; line < State.numberOfCountries; line++)
            {
                sharesOfCultsCharts[line] = new Chart();
                lastIterationStatsTab.Controls.Add(sharesOfCultsCharts[line]);    //чтобы вывести в этой вкладке

                sharesOfCultsCharts[line].ChartAreas.Add("ChartArea1");

                sharesOfCultsCharts[line].Size = new System.Drawing.Size(500, 120); //Size(550, 120);
                sharesOfCultsCharts[line].Left = demogrByStatesCharts[line].Right +30;
                if (line > 0) sharesOfCultsCharts[line].Top = sharesOfCultsCharts[line - 1].Bottom;

                Legend sharesOfCultsLeg = new Legend();
                sharesOfCultsCharts[line].Legends.Add(sharesOfCultsLeg);
                sharesOfCultsLeg.Docking = Docking.Right;
                sharesOfCultsLeg.IsDockedInsideChartArea = true;
                sharesOfCultsLeg.MaximumAutoSize = 30; //25;
                sharesOfCultsLeg.LegendStyle = LegendStyle.Table;
                sharesOfCultsLeg.IsTextAutoFit = true;
                sharesOfCultsLeg.Title = "Культурные группы";//"Доли и численности культурных групп";


                Series sharesOfCultsSeries = new Series();
                sharesOfCultsCharts[line].Series.Add(sharesOfCultsSeries);
                //sharesOfCultsSeries.Name = "Культуры";
                sharesOfCultsSeries.ChartArea = "ChartArea1";
                sharesOfCultsSeries.ChartType = SeriesChartType.Pie;

                sharesOfCultsSeries.Label = "к#VALX   #PERCENT{P0} (#VAL{0})"; //для каждого графика (пирога) для долей выведем лейблы в формате "значение по Х (это номер культуры), знач У в процентах, знач У". {0} получается означ У?

                sharesOfCultsSeries["PieLabelStyle"] = "Outside"; //расположить лейблы ВНЕ пирога
                sharesOfCultsSeries["PieLineColor"] = "Black";  //провести линии между леблами и соотв долями

                //решение проблемы налезания лейблов друг на друга:
                sharesOfCultsCharts[line].ChartAreas[0].Area3DStyle.Enable3D = true;
                sharesOfCultsCharts[line].ChartAreas[0].Area3DStyle.Inclination = 10;


                

                double[] populByCult = new double[State.numberOfCountries];   

                for (int i = 0; i < Structs.populArray.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < Structs.populArray.GetLength(2); j++)  //фиксируем образование
                    {
                        for (int k = 0; k < Structs.populArray.GetLength(3); k++)  //пробегаем все культуры
                        {
                            populByCult[k] += Structs.populArray[line, i, j, k];
                        }
                    }
                }


                for (int k = 0; k < State.numberOfCountries; k++)
                {
                    sharesOfCultsSeries.Points.AddXY(k+1, populByCult[k]);

                    //if (k == line) sharesOfCultsSeries.Points[k]["Exploded"] = "true"; //выделить кусок местной культуры сдвигом - убрал, потому что не оч смотрится - сдивигает всегда самая большая часть, и получается выглядит это так, как будто не этоа большая часть сдвигается, а все остальные маленькие сдвигаются относит нее - и не оч смотрится
                }

            }


            Chart[] sharesOfEducatedCharts = new Chart[State.numberOfCountries];

            //5 графиков численностей по культурам в кажд стране:
            for (int line = 0; line < State.numberOfCountries; line++)
            {
                sharesOfEducatedCharts[line] = new Chart();
                lastIterationStatsTab.Controls.Add(sharesOfEducatedCharts[line]);    //чтобы вывести в этой вкладке

                sharesOfEducatedCharts[line].ChartAreas.Add("ChartArea1");

                sharesOfEducatedCharts[line].Size = new System.Drawing.Size(450, 120);
                //sharesOfEducatedCharts[line].Left = sharesOfCultsCharts[line].Right + 10;
                //if (line > 0) sharesOfEducatedCharts[line].Top = sharesOfEducatedCharts[line - 1].Bottom;
                //sharesOfEducatedCharts[line].Left = demogrByStatesCharts[line].Right + 30;
                if (line == 0) sharesOfEducatedCharts[line].Top = demogrByStatesCharts[State.numberOfCountries - 1].Bottom + 40; //верх первого графика отсчитывается от низа последнего из графиков диаграмм культур
                else sharesOfEducatedCharts[line].Top = sharesOfEducatedCharts[line - 1].Bottom;

                Legend sharesOfEduLeg = new Legend();
                sharesOfEducatedCharts[line].Legends.Add(sharesOfEduLeg);
                sharesOfEduLeg.Docking = Docking.Right;
                sharesOfEduLeg.IsDockedInsideChartArea = true;
                sharesOfEduLeg.MaximumAutoSize = 30; //25;
                sharesOfEduLeg.LegendStyle = LegendStyle.Table;
                sharesOfEduLeg.IsTextAutoFit = true;
                sharesOfEduLeg.Title = "Уровни образования"; //"Доли и численности по уровням образования"; - слишком длинно


                Series sharesOfEduSeries = new Series();
                sharesOfEducatedCharts[line].Series.Add(sharesOfEduSeries);
                //sharesOfCultsSeries.Name = "Культуры";
                sharesOfEduSeries.ChartArea = "ChartArea1";
                sharesOfEduSeries.ChartType = SeriesChartType.Pie;

                sharesOfEduSeries.Label = "обр#VALX   #PERCENT{P0} (#VAL{0})";

                sharesOfEduSeries["PieLabelStyle"] = "Outside"; //расположить лейблы ВНЕ пирога
                sharesOfEduSeries["PieLineColor"] = "Black";  //провести линии между леблами и соотв долями

                //решение проблемы налезания лейблов друг на друга:
                sharesOfEducatedCharts[line].ChartAreas[0].Area3DStyle.Enable3D = true;
                sharesOfEducatedCharts[line].ChartAreas[0].Area3DStyle.Inclination = 10;




                double[] populByEdu = new double[Structs.populArray.GetLength(2)];

                for (int i = 0; i < Structs.populArray.GetLength(1); i++)  //фиксируем возраст
                {
                    for (int j = 0; j < Structs.populArray.GetLength(2); j++)  //фиксируем образование
                    {
                        for (int k = 0; k < Structs.populArray.GetLength(3); k++)  //пробегаем все культуры
                        {
                            populByEdu[j] += Structs.populArray[line, i, j, k];
                        }
                    }
                }


                for (int j = 0; j < Structs.populArray.GetLength(2); j++)
                {
                    sharesOfEduSeries.Points.AddXY(j + 1, populByEdu[j]);

                    //sharesOfCultsSeries.Points[j]["Exploded"] = "true"; // не оч смотрится
                }

            }








            TabPage GeneralStatsTab = new TabPage();   //доп вкладка с общ статистикой (по всем странам сразу) - туда можно и то тактам, и к посл моменту
            tabCtrl.TabPages.Add(GeneralStatsTab);
            GeneralStatsTab.Text = "Все страны вместе";
            GeneralStatsTab.AutoScroll = true;

            Chart standOfLivChart = new Chart();

            GeneralStatsTab.Controls.Add(standOfLivChart);    //чтобы вывести в этой вкладке 

            //standOfLivChart.Location = new Point(700, 0); //Set the Location property of the control to a Point.
            standOfLivChart.Size = new System.Drawing.Size(400, 300); //(400, 200); //(500, 150);

            standOfLivChart.ChartAreas.Add("ChartArea1");
            standOfLivChart.ChartAreas[0].AxisX.Title = "Время";
            standOfLivChart.ChartAreas[0].AxisX.Minimum = 0;
            standOfLivChart.ChartAreas[0].AxisX.Maximum = Structs.populArrayList.Count - 1;

            Legend standLeg = new Legend();
            standOfLivChart.Legends.Add(standLeg);
            standLeg.Docking = Docking.Right;
            standLeg.IsDockedInsideChartArea = true;
            standLeg.MaximumAutoSize = 28; //25;
            standLeg.LegendStyle = LegendStyle.Table;
            standLeg.IsTextAutoFit = true;
            standLeg.Title = "Динамика уровня жизни в странах";

            for (int l = 0; l < State.numberOfCountries; l++)   //построение графиков (линий) для всех стран
            {
                string seriesName = "Страна " + (l+1).ToString();
                standOfLivChart.Series.Add(seriesName);
                standOfLivChart.Series[seriesName].ChartArea = "ChartArea1";
                standOfLivChart.Series[seriesName].ChartType = SeriesChartType.Line;                

                for (int year = 0; year < Structs.standOfLivArrayList.Count; year++)   //что делать с каждым графиком (линией)
                {
                    standOfLivChart.Series[seriesName].Points.AddXY(year, Structs.standOfLivArrayList[year][l]);
                }
            }



            Chart instabIndexChart = new Chart();

            GeneralStatsTab.Controls.Add(instabIndexChart);    //чтобы вывести в этой вкладке 

            instabIndexChart.Top = standOfLivChart.Bottom;
            instabIndexChart.Size = new System.Drawing.Size(400, 300); //(400, 200); //(500, 150);

            instabIndexChart.ChartAreas.Add("ChartArea1");
            instabIndexChart.ChartAreas[0].AxisX.Title = "Время";
            instabIndexChart.ChartAreas[0].AxisX.Minimum = 0;
            instabIndexChart.ChartAreas[0].AxisX.Maximum = Structs.populArrayList.Count - 1;// + 0.5;

            Legend indexLeg = new Legend();
            instabIndexChart.Legends.Add(indexLeg);
            indexLeg.Docking = Docking.Right;
            indexLeg.IsDockedInsideChartArea = true;
            indexLeg.MaximumAutoSize = 28; //25;
            indexLeg.LegendStyle = LegendStyle.Table;
            indexLeg.IsTextAutoFit = true;
            indexLeg.Title = "Динамика уровня соц. нестабильности";

            for (int s = 0; s < State.numberOfCountries; s++)   //построение графиков (линий) для всех стран
            {
                string seriesName = "Страна " + (s+1).ToString();
                instabIndexChart.Series.Add(seriesName);
                instabIndexChart.Series[seriesName].ChartArea = "ChartArea1";
                instabIndexChart.Series[seriesName].ChartType = SeriesChartType.Line;

                for (int year = 0; year < Structs.standOfLivArrayList.Count; year++)   //что делать с каждым графиком (линией)
                {
                    instabIndexChart.Series[seriesName].Points.AddXY(year, Structs.instabIndexArrayList[year][s]);
                }
            }


            TabPage GraphSettingsTab = new TabPage();   //доп вкладка с общ статистикой (по всем странам сразу) - туда можно и то тактам, и к посл моменту
            tabCtrl.TabPages.Add(GraphSettingsTab);
            GraphSettingsTab.Text = "Настройки графиков";
            GraphSettingsTab.AutoScroll = true;


            Label cultLabel = new Label();
            GraphSettingsTab.Controls.Add(cultLabel);
            cultLabel.Size = new Size(150, 20);
            //cultLabel.Location = new Point(150, 50);
            cultLabel.Text = "Вид графиков культур";


            //Кнопки
            //Хорошая комб кнопок: "столбики + Показать только последний такт + Показать значения в %"
            //На малых тактах (напр 3), если еще где-то не появились мигранты, будет выскакивать ошибка (исключение) - и те графики не будут меняться. Но на работу остальных это не влияет. А когда ненулевых численностей уже нет, то все работает хорошо и ошибок не выскакивает
            Button cultButton = new Button(); //кнопка для изменения типов графиков с линий на столбики
            GraphSettingsTab.Controls.Add(cultButton);
            cultButton.Text = "столбики";
            cultButton.Top = cultLabel.Bottom + 10;
            cultButton.Size = new Size(100, 20);
            cultButton.Click += cultButton_Click;   //new EventHandler(this.cultButton_Click); - результат тот же

            Button cultButton2 = new Button(); 
            GraphSettingsTab.Controls.Add(cultButton2);
            cultButton2.Text = "радар";
            cultButton2.Top = cultButton.Bottom + 10;   //cultButton2.Left = cultButton.Right + 10;
            cultButton2.Size = new Size(100, 20);
            cultButton2.Click += cultButton2_Click;

            Button cultButton3 = new Button(); //кнопка для показа только последнего такта (линии) на всех графиках культур с изменением типов графиков с линий на столбики
            GraphSettingsTab.Controls.Add(cultButton3);
            cultButton3.Text = "линии"; 
            cultButton3.Top = cultButton2.Bottom + 10;   //cultButton2.Left = cultButton.Right + 10;
            cultButton3.Size = new Size(100, 20);
            cultButton3.Click += cultButton3_Click;

            Button cultButton4 = new Button();  //кнопка для показа только последнего такта (линии) на всех графиках культур
            GraphSettingsTab.Controls.Add(cultButton4);
            cultButton4.Text = "Показать только последний такт";
            cultButton4.Top = cultLabel.Bottom + 10;
            cultButton4.Left = cultButton.Right + 20;
            cultButton4.Size = new Size(100, 50);
            cultButton4.Click += cultButton4_Click;

            Button cultButton5 = new Button(); 
            GraphSettingsTab.Controls.Add(cultButton5);
            cultButton5.Text = "Показать все такты"; 
            cultButton5.Top = cultButton4.Bottom + 10;
            cultButton5.Left = cultButton.Right + 20;
            cultButton5.Size = new Size(100, 50);
            cultButton5.Click += cultButton5_Click;

            Button cultButton6 = new Button();
            GraphSettingsTab.Controls.Add(cultButton6);
            cultButton6.Text = "Показать значения в %";
            cultButton6.Top = cultLabel.Bottom + 10;
            cultButton6.Left = cultButton5.Right + 20;
            cultButton6.Size = new Size(100, 50);
            cultButton6.Click += cultButton6_Click;

            Button cultButton7 = new Button();
            GraphSettingsTab.Controls.Add(cultButton7);
            cultButton7.Text = "Сбросить настройки";
            cultButton7.Top = cultLabel.Bottom + 10;
            cultButton7.Left = cultButton6.Right + 30;
            cultButton7.Size = new Size(100, 50);
            cultButton7.Click += cultButton7_Click;


        }
        

        void cultButton_Click(object sender, EventArgs e)   
        {
            //MessageBox.Show("Message here");
            //this.Close();

            for (int tab = 0; tab < State.numberOfCountries; tab++)
            {
                for (int line = 0; line < State.numberOfCountries; line++) //line - номер графика
                {
                    for (int l = 0; l < Structs.cultarrayList.Count; l++)
                    {
                        cultCharts[tab, line].Series[seriesName[tab, line, l]].ChartType = SeriesChartType.Column;
                    }                    
                }
            }

        }

        void cultButton2_Click(object sender, EventArgs e)
        {
            for (int tab = 0; tab < State.numberOfCountries; tab++)
            {
                for (int line = 0; line < State.numberOfCountries; line++) //line - номер графика
                {
                    for (int l = 0; l < Structs.cultarrayList.Count; l++)
                    {
                        cultCharts[tab, line].Series[seriesName[tab, line, l]].ChartType = SeriesChartType.Radar;
                    }                    
                }
            }
        }

        void cultButton3_Click(object sender, EventArgs e)
        {
            for (int tab = 0; tab < State.numberOfCountries; tab++)
            {
                for (int line = 0; line < State.numberOfCountries; line++) //line - номер графика
                {
                    for (int l = 0; l < Structs.cultarrayList.Count; l++)
                    {
                        cultCharts[tab, line].Series[seriesName[tab, line, l]].ChartType = SeriesChartType.Line;
                    }

                }
            }
        }

        void cultButton4_Click(object sender, EventArgs e)  //вывод только графика (линии) для посл такта (путем сокрытия остальных линий)
        {
            for (int tab = 0; tab < State.numberOfCountries; tab++)
            {
                for (int line = 0; line < State.numberOfCountries; line++) //line - номер графика
                {
                    for (int l = 0; l < Structs.cultarrayList.Count; l++)
                    {
                        if (l != Structs.cultarrayList.Count - 1) cultCharts[tab, line].Series[seriesName[tab, line, l]].Enabled = false;


                        //или вариант вывода помимо последнего еще и первого графика (линии) - но только последний смотрится лучше, а этот еще редактировать надо - мб не стоит того
                        //if ((l != 0) && (l != (Structs.cultarrayList.Count - 1))) cultCharts[tab, line].Series[seriesName[tab, line, l]].Enabled = false;                      
                    }

                }
            }
        }

        void cultButton5_Click(object sender, EventArgs e)
        {
            for (int tab = 0; tab < State.numberOfCountries; tab++)
            {
                for (int line = 0; line < State.numberOfCountries; line++) //line - номер графика
                {
                    for (int l = 0; l < Structs.cultarrayList.Count; l++)
                    {
                        cultCharts[tab, line].Series[seriesName[tab, line, l]].Enabled = true;   
                    }
                }
            }
        }

        void cultButton6_Click(object sender, EventArgs e)
        {
            for (int tab = 0; tab < State.numberOfCountries; tab++)
            {
                for (int line = 0; line < State.numberOfCountries; line++) //line - номер графика
                {
                    for (int l = 0; l < Structs.cultarrayList.Count; l++)
                    {
                        cultCharts[tab, line].Series[seriesName[tab, line, l]].Label = "#PERCENT{P0}"; //"#PERCENT{P0} (#VALY)";

                        //здесь приходится увеличивать границы по Х на 1 в обе стороны - иначе лейблы для первой и посл культуры не умещаются!
                        cultCharts[tab, line].ChartAreas[0].AxisX.Minimum = -1;
                        cultCharts[tab, line].ChartAreas[0].AxisX.Maximum = 6;
                    }
                }
            }
        }

        void cultButton7_Click(object sender, EventArgs e)
        {
            for (int tab = 0; tab < State.numberOfCountries; tab++)
            {
                for (int line = 0; line < State.numberOfCountries; line++) //line - номер графика
                {
                    for (int l = 0; l < Structs.cultarrayList.Count; l++)
                    {
                        cultCharts[tab, line].Series[seriesName[tab, line, l]].Enabled = true;
                        cultCharts[tab, line].Series[seriesName[tab, line, l]].ChartType = SeriesChartType.Line;

                        cultCharts[tab, line].Series[seriesName[tab, line, l]].Label = ""; 

                        
                        cultCharts[tab, line].ChartAreas[0].AxisX.Minimum = 1;
                        cultCharts[tab, line].ChartAreas[0].AxisX.Maximum = 5;
                    }
                }
            }
        }




    }
}
