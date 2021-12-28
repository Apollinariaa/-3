using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace lab1
{
    class Program
    {
        const string MatrixDll = "C:\\Users\\Полина\\source\repos\\MatrixDll.dll";
        [DllImport(MatrixDll)]
        static extern double Time_VR(int n, int repeat);
        [DllImport(MatrixDll)]
        static unsafe extern void Solve_VR(int n, double[] a, double[] b, double* x);

        static void Main(string[] args)
        {
            //Magazine m1 = new Magazine();
            //Console.WriteLine(m1.ToShortString());
            //Console.WriteLine("\n");
            //Console.WriteLine(m1[Frequency.Weekly]);
            //Console.WriteLine(m1[Frequency.Monthly]);
            //Console.WriteLine(m1[Frequency.Yearly]);
            //Console.WriteLine("\n");
            //m1.Name_magazine = "Мир";
            //m1.Frequency = Frequency.Monthly;
            //m1.Date = new DateTime(2025, 01, 02);
            //m1.Number = 15988;
            //m1.ListArtic = new Article[] { new Article(new Person("Полина", "Рослякова", new DateTime(2002, 02, 28)), "Современная классика", 5) };
            //Console.WriteLine(m1.ToString());
            //m1.AddArticle(new Article[] { new Article(new Person("Марина", "Константинова", new DateTime(2002, 08, 22)), "Древняя классика", 1) });
            //Console.WriteLine("-------------------------------------------------------------------------------");
            //Console.WriteLine(m1.ToString());

            //Stopwatch sw = new Stopwatch();
            //Console.WriteLine("Введите размерность массива: число строк и столбцов, разделенные одним из символов: ' ', '.', ','");
            //string str = Console.ReadLine();
            //string[] mas = str.Split(' ', '.', ',');
            //int rows = int.Parse(mas[0]);
            //int cols = int.Parse(mas[1]);
            //Magazine[] magazines_1 = new Magazine[rows * cols];  // создаем одномерный массив (выделяем память)
            //for (int i = 0; i < rows * cols; i++)
            //{
            //    magazines_1[i] = new Magazine();
            //}

            //Magazine[,] magazines_2 = new Magazine[rows, cols]; // создаём двухмерный массив (выделяем память)
            //for (int i = 0; i < rows; i++)
            //    for (int j = 0; j < cols; j++)
            //    {
            //        magazines_2[i, j] = new Magazine();
            //    }

            //Magazine[][] magazines_3 = new Magazine[rows][];  // создаём ступенчатый массив (выделяем память)
            //for (int i = 0; i < rows; i++)
            //    magazines_3[i] = new Magazine[cols];
            //for (int i = 0; i < rows; i++)
            //    for (int j = 0; j < cols; j++)
            //    {
            //        magazines_3[i][j] = new Magazine();
            //    }

            //sw.Start();
            //for (int i = 0; i < rows * cols; i++)  // засекаем время, пока кажд ячейку присваивается значение мир
            //{
            //    magazines_1[i].Name_magazine = "Мир";
            //}

            //sw.Stop();
            //Console.WriteLine("Время работы одномерного массива " + sw.Elapsed);

            //sw.Start();
            //for (int i = 0; i < rows; i++)
            //    for (int j = 0; j < cols; j++)
            //    {
            //        magazines_2[i, j].Name_magazine = "Мир";
            //    }

            //sw.Stop();
            //Console.WriteLine("Время работы двумерного массива " + sw.Elapsed);

            //sw.Start();
            //for (int i = 0; i < rows; i++)
            //    for (int j = 0; j < cols; j++)
            //    {
            //        magazines_3[i][j].Name_magazine = "Мир";
            //    }
            //sw.Stop();
            //Console.WriteLine("Время работы ступенчатого массива " + sw.Elapsed);

            //////////////////////////////////////////////////////////////

            //Edition e1 = new Edition();
            //Edition e2 = new Edition();

            //Console.WriteLine((object)e1 == (object)e2); // сравнение ссылок е1 и е2

            //Console.WriteLine(e1 == e2);
            //Console.WriteLine("Результат метода hech-code e1");
            //Console.WriteLine(e1.GetHashCode());
            //Console.WriteLine("Результат метода hech-code e2");
            //Console.WriteLine(e2.GetHashCode());

            ///////////////////////////////////////////////////////////////

            //Magazine e1 = new Magazine();
            //try
            //{
            //    e1.Number = -12;
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine("-------------------------------------До изменения-------------------------------------------------------");
            //Magazine m1 = new Magazine();

            //Article[] artic_arr = {new Article(new Person("Полина", "Рослякова", new DateTime(2002, 02, 28)), "Современная классика", 5),
            //new Article(new Person("Марина", "Константинова", new DateTime(2002, 08, 22)), "Древняя классика", 1) };
            //Person[] person_arr = { new Person("Полина", "Рослякова", new DateTime(2002, 02, 28)), new Person("Марина", "Константинова", new DateTime(2002, 08, 22)) };
            //m1.AddArticle(artic_arr);
            //m1.AddMembers(person_arr);
            //Console.WriteLine(m1);

            //Magazine m2 = (Magazine)m1.DeepCopy();
            //Console.WriteLine(m2);
            //Console.WriteLine("-------------------------------------После изменения-------------------------------------------------------");
            //m2.AddMembers(new Person("Полина", "Смолева", new DateTime(2002, 02, 28)));
            //Console.WriteLine(m1);
            //Console.WriteLine(m2);


            //foreach (Article item in m1.GetRating(0))
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (Article item in m1.GetNameArticle("классика"))
            //{
            //    Console.WriteLine(item);
            //}

            //Magazine m1 = new Magazine();

            //Article[] artic_arr = {new Article(new Person("Полина", "Рослякова", new DateTime(2002, 02, 28)), "Современная классика", 5),
            //new Article(new Person("Марина", "Константинова", new DateTime(2002, 08, 22)), "Древняя классика", 1) };
            //Person[] person_arr = { new Person("Марина", "Константинова", new DateTime(2002, 08, 22)) };
            //m1.AddArticle(artic_arr);
            //m1.AddMembers(person_arr);
            //foreach (Article item in m1)
            //{
            //    Console.WriteLine(item);
            //}

            //Magazine m1 = new Magazine();

            //Article[] artic_arr = {new Article(new Person("Полина", "Рослякова", new DateTime(2002, 02, 28)), "Современная классика", 5),
            //new Article(new Person("Марина", "Константинова", new DateTime(2002, 08, 22)), "Древняя классика", 1) };
            //Person[] person_arr = { new Person("Марина", "Константинова", new DateTime(2002, 08, 22)) };
            //m1.AddArticle(artic_arr);
            //m1.AddMembers(person_arr);
            //foreach (Article item in m1.GetInRedactors())
            //{
            //    Console.WriteLine(item);
            //}

            //Magazine m1 = new Magazine();

            //Article[] artic_arr = { new Article(new Person("Марина", "Константинова", new DateTime(2002, 08, 22)), "Древняя классика", 1) };
            //Person[] person_arr = { new Person("Полина", "Рослякова", new DateTime(2002, 02, 28)), new Person("Марина", "Константинова", new DateTime(2002, 08, 22)) };
            //m1.AddArticle(artic_arr);
            //m1.AddMembers(person_arr);
            //m1.Name_magazine = "Плохо жить";
            ////foreach (Person item in m1.GetNoArtics())
            ////{
            ////    Console.WriteLine(item);
            ////}
            //Magazine m3 = new Magazine();
            //m3.Name_magazine = "Полишка Красотка";
            //m3.Frequency = Frequency.Weekly;

            //Magazine m2 = new Magazine();
            //Article[] artic_arr_1 = { new Article(new Person("Марина", "Константинова", new DateTime(2002, 08, 22)), "Древняя классика", 1), new Article(new Person("Марина", "Петрова", new DateTime(2002, 08, 22)), "Античная классика", 3) };
            //m2.AddArticle(artic_arr_1);



            //Console.WriteLine("До сортировки");
            //foreach (Article item in m2.ListArtic)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.WriteLine("..............................................");

            //Console.WriteLine("Сортировка по названию: ");
            //m2.SortArcodingToName();
            //foreach (Article item in m2.ListArtic)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Console.WriteLine("..............................................");
            //Console.WriteLine("Сортировка по фамилии автора: ");
            //m2.SortArcodingToAuthor();
            //foreach (Article item in m2.ListArtic)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Console.WriteLine("..............................................");
            //Console.WriteLine("Сортировка по рейтингу: ");
            //m2.SortArcodingToRating();
            //foreach (Article item in m2.ListArtic)
            //{
            //    Console.WriteLine(item.ToString());
            //}


            //Console.WriteLine("-----------------------------------------------------------");
            //MagazineCollection<string> magazineCollection = new MagazineCollection<string>(MagazineCollection<string>.GenerateKey);
            //magazineCollection.AddMagazines(m1, m2, m3);
            //Console.WriteLine(magazineCollection.ToString());
            //Console.WriteLine($"Максимальное значение рейтинга {magazineCollection.MaxRating}");
            //Console.WriteLine("-----------------------------------------------------------");
            //Console.WriteLine("Журналы, выпускаемые раз в месяц");
            //foreach (KeyValuePair<string, Magazine> item in magazineCollection.FrequencyGroup(Frequency.Monthly))
            //{
            //    Console.WriteLine(item.Value);
            //}
            //Console.WriteLine("-----------------------------------------------------------");
            //foreach (var item in magazineCollection.NGroup)
            //{
            //    Console.WriteLine($"Частота выпуска журналов в данной группе равна {item.Key}");
            //    Console.WriteLine("-------------------------------------------------------");
            //    foreach (Magazine j in item.ToDictionary(x => x.Key, x => x.Value).Values)
            //    {
            //        Console.WriteLine(j.ToShortString());
            //        Console.WriteLine("-----------------------------------------------------------");
            //    }

            //}

            //int n;
            //Console.WriteLine("Введите количество элементов");
            //while (true)
            //{
            //    bool flag = int.TryParse(Console.ReadLine(), out n);
            //    if (!flag || n < 1)
            //    {
            //        Console.WriteLine("Некорректный ввод, попробуйте снова");
            //    }
            //    else
            //        break;
            //}

            //TestCollection<Edition, Magazine> testCollection = new TestCollection<Edition, Magazine>(n, TestCollection<Edition, Magazine>.GenerateElement);
            //testCollection.TestLists();
            //Console.WriteLine();
            //testCollection.TestDictsKeys();
            //Console.WriteLine();
            //testCollection.TestDictsValues();

            //MagazineCollection<string> firstMac = new MagazineCollection<string>(MagazineCollection<string>.GenerateKey);
            //MagazineCollection<string> secondMac = new MagazineCollection<string>(MagazineCollection<string>.GenerateKey);

            //Magazine number_1 = new Magazine("World", Frequency.Monthly, new DateTime(2002,2,23), 1000);
            ////Magazine number_2 = new Magazine("My Family", Frequency.Weekly, new DateTime(2020,3, 9), 1500);
            ////Magazine number_3 = new Magazine("My Life", Frequency.Yearly, new DateTime(2022,1, 01), 20);

            ////Listener listener = new Listener();

            ////firstMac.MagazineChanged += listener.MagazineCollectionChanged;
            ////secondMac.MagazineChanged += listener.MagazineCollectionChanged;

            ////firstMac.Name = "Yoy and I";
            ////firstMac.AddMagazines(number_1,number_3);
            //number_1.AddArticle(new Article[2] { new Article(), new Article(new Person("Maria", "Murinova", new DateTime(1902, 5, 4)), "MyMy", 3) });
            ////secondMac.Name = "All okas";
            ////secondMac.AddMagazines(number_2,number_1);
            ////// Изменение св-в эл-в входящих в кол-цию
            ////number_1.Name_magazine = "I love food";
            ////number_2.Date = new DateTime(1999,9,9);
            ////number_3.Number = 5;
            ////// Замена одного из элемента в кол-ции
            ////firstMac.Replace(number_2, number_1);
            ////Console.WriteLine("Данные объекта Listener: ");
            ////Console.WriteLine(listener.ToString());

            //Magazine number_1copy = number_1.DeepCopy();
            //Console.WriteLine("Первый объект ");
            //Console.WriteLine(number_1);
            //Console.WriteLine("Скопированный объект");
            //Console.WriteLine(number_1copy);

            //Console.WriteLine("Введите название файла: ");
            //string file = Console.ReadLine();
            //if (File.Exists(file))
            //{
            //    number_1.Load(file);
            //}
            //else
            //{
            //    Console.WriteLine("Файла с таким именем не существует,но теперь он создан!");
            //}

            //Console.WriteLine(number_1);

            //number_1.AddFromConsole();
            //number_1.Save(file);
            //Console.WriteLine(number_1);

            //Magazine.Load(file, number_1);
            //number_1.AddFromConsole();
            //Magazine.Save(file, number_1);
            //Console.WriteLine(number_1);
            //программно задать матрицу 3-го порядка и правую часть

            const int n = 3;
            double[] max_1  = new double[n] { 6, 4, 5 };
            double[] max_2 = new double[n] { 7, -3, 4 };
            double[] max_3 = new double[n];
            // задаем матрицу 3-го порядка и правую часть с несовпадающими эл-тами в строках и столбцах.
            Matrix ob = new Matrix(n, max_1);
            double[] ans = ob.Solve(max_2); 
            Console.WriteLine("----------------Матрица-----------------");
            Console.WriteLine(ob);
            Console.WriteLine("----------------------------------------");
            foreach (double i in max_2)
                Console.WriteLine(i);
            //Решаем систему линейных уравнений и выводим матрицу, правую часть и решение в С#
            Console.WriteLine("C#");
            foreach (double i in ans)
                Console.WriteLine(i);
            fixed (double* result = max_3) Solve_VR(3, max_1, max_2, result);

            //Решаем систему линейных уравнений и выводим матрицу, правую часть и решение в С++
            Console.WriteLine("C++");
            for (int i = 0; i < max_3.Length; i++)
                Console.WriteLine(max_3[i]);
            TimeList t = new TimeList();
            //Создать один объект типа TimesList и предлогаем пользователю ввести имя файла
            Console.WriteLine("Введите имя файла");
            string filename = Console.ReadLine();
            if (File.Exists(filename))
            {
                Console.WriteLine("Файл найден и считан...");
                t.Load(filename);
                Console.WriteLine(t);
            }
            else
            {
                Console.WriteLine("Файла с таким именем не существует");
                File.Create(filename);
            }

            static double Time_VR(int n, int k)
            {
                Stopwatch sw = new Stopwatch();
                sw.Restart();
                Matrix matrix = new Matrix(n);
                double[] right = new double[n];

                for (int i = 0; i < n; i++)
                    right[i] = (i + 1) * 10;

                for (int i = 0; i < k; i++)
                    matrix.Solve(right);
                sw.Stop();
                return sw.Elapsed.TotalSeconds;
            }

        }
    }
}
