using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class MagazineEnumerator : IEnumerator
    {
        List<Article> artics;
        List<Person> members;
        int index = -1;

        public MagazineEnumerator(List<Article> array_artics, List<Person> array_members)
        {
            artics = new List<Article>(array_artics);
            members = new List<Person>(array_members);
        }

        public MagazineEnumerator()
        {
            artics = new List<Article>();
            members = new List<Person>();
        }

        public object Current
        {
            get
            {
                if (index == -1 || index >= artics.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return artics[index];
            }
        } //вывод эл-та массива Artics, имеющего индекс равный полю индекс , если значения этого поля в заданном промежутке 

        public bool MoveNext()
        {
            index++;
            while (members.Contains(((Article)artics[index]).person) && index < artics.Count -1) //пропускаем все статьи, авторы которых являются редакторами журнала, пока не найдем нужного или пока не закончится массив 
            {
                index++;
            }
            if (!members.Contains(((Article)artics[index]).person)) // подходит ли нам текущий эл-т
                return true;
            return false;
        } // переход к следующему эл-ту 

        public void Reset() // установка текущей позиции на место перед началом массива 
        {
            index = -1;
        }
    }
}
