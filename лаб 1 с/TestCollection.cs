using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace lab1
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);//указатель  на функцию, которая удовлет. условиям: возвр пару ключ и значение , принимает j

    class TestCollection<TKey, TValue>
    {
        List<TKey> TKeyList; 
        List<string> StringList;
        Dictionary<TKey, TValue> keyValuePairs;
        Dictionary<string, TValue> stringValuePairs;
        GenerateElement<TKey, TValue> key; // указатель на функцию, которая будет генерировать эл-т

        public TestCollection(int n, GenerateElement<TKey, TValue> key_value)
        {
            TKeyList = new List<TKey>();
            StringList = new List<string>();
            keyValuePairs = new Dictionary<TKey, TValue>();
            stringValuePairs = new  Dictionary<string, TValue>();
            key = key_value;
            for (int i = 0; i < n; i++)
            {
                KeyValuePair<TKey, TValue> pair = key(i);
                TKeyList.Add(pair.Key);
                StringList.Add(pair.Value.ToString());
                keyValuePairs.Add(pair.Key, pair.Value);
                stringValuePairs.Add(pair.Value.ToString(), pair.Value);
            }
        }
        public static KeyValuePair<Edition, Magazine> GenerateElement(int j)
        {
            Magazine mg = new Magazine();
            mg.Name_magazine += $"{j}";
            Edition key = mg.edition;
            return new KeyValuePair<Edition, Magazine>(key, mg);
        }

        public void TestLists()
        {
            bool f;
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("-------------------------------Тест List<Edition>-------------------------------");
            sw.Start();
            f = TKeyList.Contains(TKeyList[0]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = TKeyList.Contains(TKeyList[TKeyList.Count - 1]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = TKeyList.Contains(TKeyList[TKeyList.Count / 2]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            var empty = key(TKeyList.Count + 1).Key;
            f = TKeyList.Contains(empty);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");


            Console.WriteLine("-------------------------------Тест List<string>-------------------------------");
            sw.Reset();
            sw.Start();
            f = StringList.Contains(StringList[0]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = StringList.Contains(StringList[StringList.Count - 1]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = StringList.Contains(StringList[StringList.Count / 2]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            string name = "dfssdfs";
            sw.Reset();
            sw.Start();
            f = StringList.Contains(name);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");
        }

        public void TestDictsKeys()
        {
            bool f;
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("-------------------------------Тест Dictionary<keyValuePairs>-------------------------------");
            sw.Start();
            f = keyValuePairs.ContainsKey(TKeyList[0]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = keyValuePairs.ContainsKey(TKeyList[TKeyList.Count - 1]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = keyValuePairs.ContainsKey(TKeyList[TKeyList.Count / 2]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            var empty = key(keyValuePairs.Count + 1).Key;
            f = keyValuePairs.ContainsKey(empty);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");


            Console.WriteLine("-------------------------------Тест Dictionary<stringValuePairs>-------------------------------");
            sw.Reset();
            sw.Start();
            f = stringValuePairs.ContainsKey(StringList[0]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = stringValuePairs.ContainsKey(StringList[StringList.Count - 1]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = stringValuePairs.ContainsKey(StringList[StringList.Count / 2]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            string name = "dfssdfs";
            sw.Reset();
            sw.Start();
            f = stringValuePairs.ContainsKey(name);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");
        }

        public void TestDictsValues()
        {
            bool f;
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("-------------------------------Тест Dictionary<keyValuePairs>-------------------------------");
            sw.Start();
            f = keyValuePairs.ContainsValue(keyValuePairs[TKeyList[0]]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = keyValuePairs.ContainsValue(keyValuePairs[TKeyList[TKeyList.Count - 1]]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = keyValuePairs.ContainsValue(keyValuePairs[TKeyList[TKeyList.Count / 2]]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            var empty = key(keyValuePairs.Count + 1).Value;
            f = keyValuePairs.ContainsValue(empty);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");


            Console.WriteLine("-------------------------------Тест Dictionary<stringValuePairs>-------------------------------");
            sw.Reset();
            sw.Start();
            f = stringValuePairs.ContainsValue(stringValuePairs[StringList[0]]);
            sw.Stop();
            Console.WriteLine($"Время поиска первого элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = stringValuePairs.ContainsValue(stringValuePairs[StringList[StringList.Count - 1]]);
            sw.Stop();
            Console.WriteLine($"Время поиска последнего элемента элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            f = stringValuePairs.ContainsValue(stringValuePairs[StringList[StringList.Count / 2]]);
            sw.Stop();
            Console.WriteLine($"Время поиска центрального элемента: {sw.Elapsed}.");
            sw.Reset();
            sw.Start();
            var none = key(stringValuePairs.Count + 1).Value;
            f = stringValuePairs.ContainsValue(none);
            sw.Stop();
            Console.WriteLine($"Время поиска несуществующего элемента: {sw.Elapsed}.");
        }

    }
}
