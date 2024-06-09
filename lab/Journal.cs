using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class Journal<T> 
    {
        List<JournalEntry<T>> entries = new List<JournalEntry<T>>();

        public void AddEntry(object sourse, CollectionHandlerEventArgs<T> args) 
        {
            entries.Add(new JournalEntry<T>(args.CollectionName, args.TypeOfChange, args.Value));
        }

        public string Print()
        {
            if (entries.Count == 0)
            {
                return "Журнал пуст";
            }

            StringBuilder sb = new StringBuilder();
            foreach (JournalEntry<T> entry in entries)
            {
                sb.Append(entry.ToString());
            }
            return sb.ToString();
        }
    }
}
