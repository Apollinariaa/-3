using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace lab1
{
    class ArticleComparer : IComparer<Article>
    {
        public int Compare([AllowNull] Article x, [AllowNull] Article y) // сравнение по рейтингу
        {
            return y.rating.CompareTo(x.rating);
        }
    }
}
