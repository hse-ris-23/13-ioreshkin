using lab;
using ClassLibraryLab10;

namespace TestProject;

[TestClass]
public class JournalTest
{
    [TestMethod]
    public void AddEntry()
    {
        Journal<Control> journal = new Journal<Control>();
        journal.AddEntry("Коллекция", new CollectionHandlerEventArgs<Control>("Коллекция", "Изменение элемента", new Control()));

        Assert.AreNotEqual("Журнал пуст", journal.Print());
    }

    [TestMethod]
    public void EmptyJournal_ReturnMessage()
    {
        Journal<Control> journal = new Journal<Control>();

        Assert.AreEqual("Журнал пуст", journal.Print());
    }
}