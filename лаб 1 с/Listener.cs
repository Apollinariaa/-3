using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class Listener
    {
        private List<ListEntry> changes = new List<ListEntry>();

        // обработчик событий MagazineAdded и MagazineReplaced
        public void MagazineCollectionChanged(object subject, EventArgs s)
        {
            var e = s as MagazinesChangedEventArgs<string>;
            changes.Add(new ListEntry(e.CollectionName, e.EventType, e.PropertyName, e.ChangedKey));
        }

        public override string ToString() 
        {
            StringBuilder str = new StringBuilder();
            foreach (ListEntry change in changes)
            {
                str.Append(change + "\n");
            }

            return str.ToString();
        }
    }
}
