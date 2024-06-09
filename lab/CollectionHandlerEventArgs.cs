using System;

namespace lab
{
    public class CollectionHandlerEventArgs<T> : EventArgs
    {
        public string CollectionName { get; }
        public string TypeOfChange { get; }
        public T Value { get; }

        public CollectionHandlerEventArgs (string collectionName, string typeOfChange, T value) 
        {
            CollectionName = collectionName;
            TypeOfChange = typeOfChange;
            Value = value;
        }
    }
}
