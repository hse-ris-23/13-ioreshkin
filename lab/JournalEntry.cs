using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class JournalEntry<T>
    {
        public string CollectionName { get; }
        public string TypeOfChange { get; }
        public T Value { get; }

        public JournalEntry(string collectionName, string typeOfChange, T value)
        {
            CollectionName = collectionName;
            TypeOfChange = typeOfChange;
            Value = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Журнал: {CollectionName}\n");
            sb.Append($"Тип изменения: {TypeOfChange}\n");
            sb.Append($"Новый элемент: {Value}\n");

            return sb.ToString();
        }
    }
}
