using System;
using lab_4;
using ClassLibraryLab10;
using lab_3;

namespace lab
{
    public class MyObservableCollection<T>:MyCollection<T> where T: class, IInit, ICloneable, IComparable, new() 
    {
        static int index;

        public string Name { get; }
        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs<T> args);
        public event CollectionHandler addItem;
        public event CollectionHandler changeItem;

        public MyObservableCollection()
        {
            Name = "Новая коллекция";
        }

        public MyObservableCollection(string name)
        {
            Name = name;
        }

        public T this[int searchedIndex]
        {
            get
            {
                index = 0;
                Node<T> result = Find(root, searchedIndex);
                if (result == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return result.Data;
            }
            set
            {
                index = 0;
                Node<T> toChange = Find(root, searchedIndex);
                if (toChange == null)
                {
                    throw new ArgumentOutOfRangeException(); 
                }

                if (Set(toChange, value))
                {
                    OnChange(this, new CollectionHandlerEventArgs<T>(Name, "Изменение элемента", toChange.Data));
                }
            }
        }

        public void Fill(int count)
        {
            for (int i = 0; i < count; i++)
            {
                T newItem = new T();
                newItem.RandomInit();

                Add(newItem);
            }
        }

        public void OnAddItem(object source, CollectionHandlerEventArgs<T> args)
        {
            if (addItem != null)
            {
                addItem(source, args);
            }
        }

        public void OnChange(object source, CollectionHandlerEventArgs<T> args)
        {
            if (changeItem != null)
            {
                changeItem(source, args);
            }
        }

        public new bool Add(T data)
        {
            bool result = base.Add(data);
            if (result)
            {
                OnAddItem(this, new CollectionHandlerEventArgs<T>(Name, "Добавление элемента", data));
                return true;
            }
            return false;
        }

        Node<T> Find(Node<T> node, int searchedindex, Node<T> result = null)
        {
            if (node.Left != nil)
            {
                result = Find(node.Left, searchedindex, result);
            }

            if (result != null)
            {
                return result;
            }

            if (index == searchedindex)
            {
                return node;
            }

            index++;

            if (node.Right != nil)
            {
                result = Find(node.Right, searchedindex, result);
            }

            return result;
        }

        bool Set(Node<T> toChange, T newItem)
        {
            Node<T> tmp = root;

            while (tmp != nil)
            {
                if (tmp.Data.CompareTo(toChange.Data) == 0)
                {
                    tmp = new Node<T>(newItem, tmp.Color, nil);
                    toChange.Data = tmp.Data;
                    return true;
                }
                else if (tmp.Data.CompareTo(toChange.Data) < 0)
                {
                    tmp = tmp.Right;
                }
                else
                {
                    tmp = tmp.Left;
                }
            }
            return false;
        }


    }
}
