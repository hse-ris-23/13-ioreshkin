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
        journal.AddEntry("���������", new CollectionHandlerEventArgs<Control>("���������", "��������� ��������", new Control()));

        Assert.AreNotEqual("������ ����", journal.Print());
    }

    [TestMethod]
    public void EmptyJournal_ReturnMessage()
    {
        Journal<Control> journal = new Journal<Control>();

        Assert.AreEqual("������ ����", journal.Print());
    }
}