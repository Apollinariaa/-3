using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace lab1
{
    delegate TKey KeySelector<TKey>(Magazine mg);

    delegate void MagazineChangedHandler<TKey>
        (object source, MagazinesChangedEventArgs<TKey> args);

    class MagazineCollection<TKey>
    {
        Dictionary<TKey, Magazine> dictionary;
        KeySelector<TKey> ks;

        public string Name { get; set; }

        public event MagazineChangedHandler<TKey> MagazineChanged;
        public MagazineCollection(KeySelector<TKey> keySelector)
        {
            ks = keySelector;
            dictionary = new Dictionary<TKey, Magazine>();
        }
        public string AddName
        {
            get; set;
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
                TKey key_value = ks(mg);
                dictionary.Add(key_value, mg);
            }
        }

        public void AddMagazines(params Magazine[] mgs)
        {
            foreach (Magazine mg in mgs)
            {
                var key_value = ks(mg);
                if (!dictionary.ContainsKey(key_value))
                {
                    dictionary.Add(key_value, mg);
                    MagazineChanged?.Invoke(this, new MagazinesChangedEventArgs<TKey>(Name, Update.Add, "Niiii", key_value));
                }    
                    
                    
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

        private void MagazinePropertyChanged(Update Date, string Name, TKey Key)
        {
            MagazineChanged?.Invoke(this, new MagazinesChangedEventArgs<TKey>(AddName, Date, Name, Key));
        }

        public bool Replace(Magazine n, Magazine nw)
        {
            var k = dictionary.FirstOrDefault(m => m.Value == n).Key;
            if (k != null)
            {
                dictionary[k] = nw;
                MagazinePropertyChanged(Update.Replace, "None", k);
                n.PropertyChanged -= PropertyChang;
                nw.PropertyChanged += PropertyChang;
                return true;
            }
            return false;
        }

        private void PropertyChang(object subject, EventArgs e)
        {
            var t = (PropertyChangedEventArgs)e;
            var mg = (Magazine)subject;
            var key = ks(mg);
            MagazinePropertyChanged(Update.Property, t.PropertyName, key);
        }

    }
}
