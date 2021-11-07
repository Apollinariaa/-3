using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab1
{
    delegate TKey KeySelector<TKey>(Magazine mg);
    class MagazineCollection<TKey>
    {
        Dictionary<TKey, Magazine> dictionary;
        KeySelector<TKey> key;

        public MagazineCollection(KeySelector<TKey> keySelector)
        {
            key = keySelector;
            dictionary = new Dictionary<TKey, Magazine>();
        }

        public static string GenerateKey(Magazine mg)
        {
            return mg.Name_magazine;
        }

        public void AddDefaults()
        {
            if (dictionary.Count == 0)
            {
                Magazine mg = new Magazine();
                TKey key_value = key(mg);
                dictionary.Add(key_value, mg);
            }
        }

        public void AddMagazines(params Magazine[] mgs)
        {
            foreach (Magazine mg in mgs)
            {
                TKey key_value = key(mg);
                if (!dictionary.ContainsKey(key_value))
                    dictionary.Add(key_value, mg);
                else
                    dictionary[key_value] = mg;
            }
        }

        public override string ToString()
        {
            string text = "Журналы коллекции:\n";
            foreach (KeyValuePair<TKey, Magazine> item in dictionary)
            {
                text += $"Ключ: {item.Key}\n";
                text += (item.Value.ToString() + "\n\n");
                text += "-------------------------------------------------------------\n";
            }

            return text;
        }

        public virtual string ToShortString()
        {
            string text = "Журналы коллекции:\n";
            foreach (KeyValuePair<TKey, Magazine> item in dictionary)
            {
                text += $"Ключ: {item.Key}\n";
                text += (item.Value.ToShortString() + "\n\n");
                text += "-------------------------------------------------------------\n";
            }

            return text;
        }

        public double MaxRating
        {
            get
            {
                if (dictionary.Count == 0)
                    return -1;
                return dictionary.Max(x => x.Value.Rating);
            }
        }

        public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            return dictionary.Where(x => x.Value.Frequency == value);
        }

        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> NGroup
        {
            get
            {
                return dictionary.GroupBy(x => x.Value.Frequency);
            }
        }
    }
}
