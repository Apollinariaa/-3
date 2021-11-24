using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace lab1
{

    enum Frequency { Weekly, Monthly, Yearly }

    class Magazine: Edition, IRateAndCopy, IEnumerable, System.ComponentModel.INotifyPropertyChanged
    {
        Frequency frequency;
        List<Person> members;
        List<Article> listArtic;

        public Magazine(string name_magazineValue, Frequency frequencyValue, DateTime dateValue, int numberValue): base(name_magazineValue, dateValue, numberValue)
        {
            frequency = frequencyValue;
            listArtic = new List<Article>();
            members = new List<Person>();

        }

        public Magazine() : this("Здорово жить", Frequency.Monthly, new DateTime(2021, 9, 5), 1000)
        {
        }

        public Frequency Frequency
        {
            get  //получить
            {
                return frequency;
            }
            set // установить значение
            {
                frequency = value;
            }
        }

        public List<Person> Members
        {
            get  //получить
            {
                return members;
            }
            set  // установить значение
            {
                members = new List<Person>(value);
            }
        }

        public List<Article> ListArtic
        {
            get  //получить
            {
                return listArtic;
            }
            set  // установить значение
            {
                listArtic = new List<Article>(value);
            }
        }

        public double Rating    // типа double (только с методом get), в котором вычисляется среднее значение рейтинга в списке статей;
        {
            get
            {
                if (listArtic.Count > 0) // проверка на то, что listArtic 
                {
                    double avg = 0;
                    //1 способ
                    for (int i = 0; i < listArtic.Count; i++)
                    {
                        avg += ((Article)listArtic[i]).Rating;
                    }
                    avg /= listArtic.Count;

                    //2
                    //foreach (Article item in listArtic)
                    //{
                    //    avg += item.rating;
                    //}
                    //avg /= listArtic.Length;
                    return avg;
                }
                return 0;
            }
        }

        public bool this[Frequency e]
        {
            get
            {
                return frequency == e;
            }
        }

        public void AddArticle(params Article[] articles)   //метод void AddArticles (params Article[]) для добавления элементов в список статей в журнале
        {
            listArtic.AddRange(articles);
        }

        public void AddMembers(params Person[] mems)   //метод void AddArticles (params Article[]) для добавления элементов в список участников в журнале
        {
            members.AddRange(mems);
        }

        public override string ToString()  // перегруженную(override) версию виртуального метода string ToString() для формирования строки со значениями всех полей класса;

        {
            string text = string.Empty;
            for (int i = 0; i < listArtic.Count; i++)
            {
                text += "\n\n" + (i + 1) + ") " + listArtic[i].ToString() + "\n";
            }

            string text_2 = "Список редакторов: \n";
            for (int i = 0; i < Members.Count; i++)
            {
                text_2 += "\n\n" + (i + 1) + ") " + Members[i].ToString() + "\n";
            }

            return "Название журнала: " + name_magazine + "\n" + "Переодичность выхода журнала: " + frequency + "\n" + "Дата выхода журнала: " + date + "\n" + "Тираж журнала: " + number + "\n" + "Список статей в журнале: " + text + "\n" +  text_2 + "\n";
        }

        public virtual string ToShortString()  //виртуальный метод string ToShortString().
        {
            return "Название: " + name_magazine + "\n" + "Частота выпуска: " + frequency + "\n" + "Дата выхода журнала: " + date + "\n" + "Тираж: " + number + "\n" + "Средний рейтинг статей: " + Rating;
        }

        public override object DeepCopy()
        {
            Magazine m = new Magazine(name_magazine, frequency, new DateTime(date.Year, date.Month, date.Day), number);
            foreach (Person item in members)
            {
                m.AddMembers((Person)item.DeepCopy()); // переписываем всех участников по одному 
            }
            foreach (Article item in listArtic) 
            {
                m.AddArticle((Article)item.DeepCopy());  // переписываем все статьи по одному 
            }
            return m;
        } // виртуальный метод

        public Edition edition
        {
            get 
            {
                return new Edition(name_magazine, new DateTime(date.Year, date.Month, date.Day), number);
            }
            set
            {
                name_magazine = value.Name_magazine;
                date = new DateTime(value.Date.Year, value.Date.Month, value.Date.Day);
                number = value.Number;
            } // возращение соответсвующего объекта базового класса и установка полей из базового класса по образцу
        }

        public IEnumerable GetRating (double number)
        {
            foreach (Article item in ListArtic)
            {
                if (item.Rating > number)
                {
                    yield return item;  // yield - возвращает один эл-т и приостанавливает работу 
                }
            }
        } // итератор, возращающий статьи, имеющие рейтинг выше заданного 

        public IEnumerable GetNameArticle(string str)
        {
            foreach (Article item in ListArtic)
            {
                if (item.name_article.Contains(str))
                {
                    yield return item;
                }
            }
        } // возращает статьи, в названии которых содержится переданная подстрока


        public IEnumerable GetInRedactors()
        {
            foreach (Article item in ListArtic)
            {
                if (Members.Contains(item.person))
                {
                    yield return item;
                }
            }
        } //возвращает статьи, авторы которых являются редакторами журнала 

        public IEnumerable GetNoArtics()
        {
            ArrayList temp = new ArrayList();
            foreach (Article item in ListArtic)
            {
                temp.Add(item.person);
            }
            foreach (Person item in Members)
            {
                if (!temp.Contains(item))
                {
                    yield return item;
                }
            }
        } // возращает редакторов журнала, у которых нет статей 

        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(ListArtic, Members);
        } // реализация интерфейса IEnumerable с использованием вспомогательного класса MagazineEnumerator

        public void SortArcodingToName() // сортировка по названию
        {
            listArtic.Sort((x, y) => x.CompareTo(y));
        }

        public void SortArcodingToAuthor()
        {
            listArtic.Sort((x, y) => x.Compare(x, y));
        }

        public void SortArcodingToRating()
        {
            listArtic.Sort(new ArticleComparer());
        }
    }
}
