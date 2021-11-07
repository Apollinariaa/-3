using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Person
    {
        string name;
        string surname;
        DateTime birthday;

        public Person(string nameValue, string surnameValue, DateTime birthdayValue) // конструктор c тремя параметрами типа string, string, DateTime для инициализации всех полей класса
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;
        }

        /* public Person() // вариант первый констр без параметров
         {
             name = "Иван";
             surname = "Иванов";
             birthday = new DateTime(2000, 1, 1);


         } */

        public Person() : this("Иван", "Иванов", new DateTime(2000, 1, 1)) // способ 2 работы с конструктором
        {
        }

        public string Name  //свойство типа string для доступа к полю с именем
        {
            get //получить
            {
                return name;
            }
            set   //  установить значение 
            {
                name = value;
            }
        }

        public string Surname // свойство типа string для доступа к полю с фамилией
        {
            get //получить
            {
                return surname;
            }
            set   //  установить значение 
            {
                surname = value;
            }
        }

        public DateTime Birthday // свойство типа DateTime для доступа к полю с датой рождения
        {
            get //получить
            {
                return birthday;
            }
            set   //  установить значение 
            {
                birthday = value;
            }

        }
        public int Year   //свойство типа int c методами get и set для получения информации(get) и изменения(set) года рождения
        {
            get //получить
            {
                return Birthday.Year;
            }
            set   //  установить значение 
            {
                Birthday = new DateTime(value, Birthday.Month, Birthday.Day);
            }

        }

        public override string ToString()  // перегруженную(override) версию виртуального метода string ToString() для формирования строки со значениями всех полей класса;

        {
            return "\n" + "Имя автора: " + Name + "\n" + "Фамилия автора: " + Surname + "\n" + "Дата рождения: " + Birthday.ToShortDateString();
        }

        public virtual string ToShortString()  //виртуальный метод string ToShortString(), который возвращает строку, содержащую только имя и фамилию
        {
            return Name + " " + Surname;
        }

        public override bool Equals(object obj)
        {
            if ((obj==null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            else
            {
                Person p = (Person)obj;
                return this.Name == p.Name && this.Surname == p.Surname && this.Birthday == p.Birthday;
            }

        }
        //сравнивает обьекты по полям. если обьект пустой или типы переданного и текущего обьекта не совпадают то возращает False.
        //если это не так то он создает новый обьект текущего класса и возвращает результат сравнения всех полей этого объекта с полями текущего объекта

        public static bool operator ==(Person left, Person right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Birthday);
        }// возвращает числовое значение, соответсв данному обьекту

        public virtual object DeepCopy()
        {
            return new Person(Name, Surname, new DateTime(Birthday.Year, Birthday.Month, Birthday.Day));
        }
        //возращает полную копию текущего обьекта (ссылки разные, а значения полей одинаковые )
    }
}
