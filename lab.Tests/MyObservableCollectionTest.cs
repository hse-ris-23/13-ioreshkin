using lab;
using ClassLibraryLab10;

namespace TestProject
{
    [TestClass]
    public class MyObservableCollectionTest
    {
        [TestMethod]
        public void EmptyContrucor()
        {
            MyObservableCollection<Control> collection = new MyObservableCollection<Control>();

            Assert.AreEqual("Новая коллекция", collection.Name);
        }

        [TestMethod]
        public void NameConstructor()
        {
            string name = "Коллекция 1";

            MyObservableCollection<Control> collection = new MyObservableCollection<Control>(name);

            Assert.AreEqual(name, collection.Name);
        }

        [TestMethod]
        public void IndexatorGet()
        {
            MyObservableCollection<Control> collection = new MyObservableCollection<Control>("Коллекция 1");
            Control control = new Control();
            control.RandomInit();

            collection.Add(control);

            Assert.AreEqual(control, collection[0]);
        }

        [TestMethod]
        public void IndexatorSet()
        {
            MyObservableCollection<Control> collection = new MyObservableCollection<Control>("Коллекция 1");
            Control control = new Control();
            control.RandomInit();

            collection.Add(control);

            Control changedControl = new Control();
            changedControl = (Control)control.Clone();
            changedControl.Y = 44;

            collection[0] = changedControl;


            Assert.AreEqual(changedControl, collection[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexatorGet_IndexOutOfRange_ThrowArgumentOutOfRangeException()
        {
            MyObservableCollection<Control> collection = new MyObservableCollection<Control>("Коллекция 1");

            Control control = collection[5];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexatorSet_IndexOutOfRange_ThrowArgumentOutOfRangeException()
        {
            MyObservableCollection<Control> collection = new MyObservableCollection<Control>("Коллекция 1");

            collection[5] = new Control();
        }

        [TestMethod]
        public void Fill()
        {
            MyObservableCollection<Control> collection = new MyObservableCollection<Control>();

            collection.Fill(5);

            Assert.IsNotNull(collection[4]);
        }

        [TestMethod]
        public void OnAddItem()
        {
            MyObservableCollection<Control> collection = new MyObservableCollection<Control>("Коллекция 1");
            Journal<Control> journal = new Journal<Control>();

            collection.addItem += journal.AddEntry;

            Control control = new Control();
            control.RandomInit();

            collection.Add(control);

            Assert.AreNotEqual("Журнал пуст", journal.Print());
        }

        [TestMethod]
        public void OnChangeItem()
        {
            MyObservableCollection<Control> collection = new MyObservableCollection<Control>("Коллекция 1");
            Journal<Control> journal = new Journal<Control>();

            collection.changeItem += journal.AddEntry;

            Control control = new Control();
            control.RandomInit();

            collection.Add(control);

            Control changedControl = new Control();
            changedControl = (Control)control.Clone();
            changedControl.Y = 44;

            collection[0] = changedControl;

            Assert.AreNotEqual("Журнал пуст", journal.Print());
        }


    }


}
