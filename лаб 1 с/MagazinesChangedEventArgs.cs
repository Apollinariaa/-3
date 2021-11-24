using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class MagazinesChangedEventArgs<TKey> : System.EventArgs
    {
        public string CollectionName { get; set; }
        public Update EventType { get; set; }
        public string PropertyName { get; set; }

        public TKey ChangedKey { get; set; }

        public MagazinesChangedEventArgs(string CollectionValue, Update EventTypeValue, string PropertyValue, TKey Changedkey)
        {
            CollectionName = CollectionValue;
            EventType = EventTypeValue;
            PropertyName = PropertyValue;
            ChangedKey = Changedkey; 
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append($"Changes in collection: {CollectionName}\n");
            s.Append($"Changes type: {EventType}");
            s.Append($"Changes in property {PropertyName}");
            s.Append($"Changed elem with key {ChangedKey}");
            return s.ToString();
        }
    }
}
