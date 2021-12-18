using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    [Serializable]
    class Article: IRateAndCopy, IComparable, IComparer<Article>
    {
        public Person person { get; set; }
        public string name_article { get; set; }
        public double rating { get; set; }

        public double Rating
        {
            get
            {
                return rating;
            }
        }

        public Article(Person personValue, string name_articleValue, double ratingValue)
        {
            person = new Person(personValue.Name, personValue.Surname, personValue.Birthday);
            name_article = name_articleValue;
            rating = ratingValue;
        }

        public Article() : this(new Person(), "Современная молодёжь", 3.2)
        {
        }

        public override string ToString()  // перегруженную(override) версию виртуального метода string ToString() для формирования строки со значениями всех полей класса;

        {
            return "Автор: " + person.ToString() + "\n\n" + "Название статьи: " + name_article + "\n" + "Рейтинг: " + rating;
            //return $"Автор:{person.ToShortString()}\nНазвание статьи \"{name_article}\"\nРейтинг: {rating}";
        }

        public object DeepCopy()  // Виртуальный метод 
        {
            return new Article((Person)person.DeepCopy(), name_article, rating);
        }

        public int CompareTo(object obj) //сравнение по названию
        {
            return String.Compare(name_article, ((Article)obj).name_article);
        }

        public int Compare([AllowNull] Article x, [AllowNull] Article y) // сравнение по фамилии автора
        {
            return String.Compare(x.person.Surname, y.person.Surname);
        }
    }
}
