using ClassLibraryLab10;
using System;

namespace lab
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyObservableCollection<Control> collection1 = new MyObservableCollection<Control>("Коллекция 1");
            MyObservableCollection<Control> collection2 = new MyObservableCollection<Control>("Коллекция 2");

            Journal<Control> collection1Journal = new Journal<Control>();
            Journal<Control> collection2Journal = new Journal<Control>();

            collection1.addItem += collection1Journal.AddEntry;
            collection1.changeItem += collection1Journal.AddEntry;

            collection1.changeItem += collection2Journal.AddEntry;
            collection2.changeItem += collection2Journal.AddEntry;

            Control control1 = new Control();
            control1.RandomInit();
            Control control2 = new Control();
            control2.RandomInit();
            Control control3 = new Control();
            control3 = (Control)control1.Clone();
            control3.Y = 44;

            Control control4 = new Control();
            control4.RandomInit();
            Control control5 = new Control();
            control5.RandomInit();
            Control control6 = new Control();
            control6 = (Control)control4.Clone();
            control6.Y = 666;

            collection1.Add(control1);
            collection1.Add(control2);
            collection1[0] = control3;

            collection2.Add(control4);
            collection2.Add(control5);
            collection2[0] = control6;

            Console.WriteLine("Журнал 1:");
            Console.WriteLine(collection1Journal.Print());
            Console.WriteLine("Журнал 2:");
            Console.WriteLine(collection2Journal.Print());
        }
    }
}
