using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class Edition
    {
        protected string name_magazine;
        protected DateTime date;
        protected int number;

        public Edition(string name_magazineValue, DateTime dateValue, int numberValue)
        {
            name_magazine = name_magazineValue;
            date = dateValue;
            number = numberValue;

        }

        public Edition() : this("Здорово жить", new DateTime(2021, 9, 5), 1000)
        {
        }

        public string Name_magazine  //свойство типа string для доступа к полю с названием журнала
        {
            get  //получить 
            {
                return name_magazine;
            }

            set // установить значение
            {
                name_magazine = value;
            }
        }

        public DateTime Date
        {
            get  //получить
            {
                return date;
            }
            set  // установить значение
            {
                date = value;
            }
        }

        public int Number
        {
            get  //получить
            {
                return number;
            }
            set  // установить значение
            {
                if (value < 0)
                {
                    throw new ArgumentException("ОШИБКА_АОАОА_ОШИБКА\nЧисло должно быть больше нуля");
                }
                number = value;
            }
        }  // проверка на ошибки 

        public virtual object DeepCopy() // виртуальный метод 
        {
            return new Edition(name_magazine, new DateTime(date.Year, date.Month, date.Day), number);
        }

        public override bool Equals(object obj)
        {
            if ((obj==null) || !(this.GetType().Equals(obj.GetType())))
            {
                return false;
            }

            else
            {
                Edition e = (Edition)obj;
                return (this.name_magazine == e.name_magazine) && (this.date == e.date) && (this.number == e.number);
            }
        } 

        public static bool operator == (Edition left , Edition right)
        {
            return left.Equals(right);
        } 

        public static bool operator !=(Edition left, Edition right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()  // виртуальный метод
        {
            return HashCode.Combine(name_magazine, date, number);
        }  

    }
}
