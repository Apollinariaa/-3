using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    enum Update {Add,Replace, Property};

    class ListEntry
    {
        public string CollectionName { get; set; }
        public Update EventType { get; set; }
        public string ChangedPropertyName { get; set; }
        public string TextedElementKey { get; set; }

        public ListEntry(string CollectionValue, Update EventTypeValue, string ChangedPropertyValue, string TextedElementkey)
        {
            CollectionName = CollectionValue;
            EventType = EventTypeValue;
            ChangedPropertyName = ChangedPropertyValue;
            TextedElementKey = TextedElementkey;
        }

        public override string ToString()
        {
            return $"Collection name: {CollectionName}\n" + $"Event type: {EventType}\n" + $"Property caused elements changing: {ChangedPropertyName}\n" + $"Changed element key: {TextedElementKey}\n";
        }
    }
}
