using lab;
using ClassLibraryLab10;

namespace TestProject;

[TestClass]
public class CollectionHandlerEventArgsTest
{
    [TestMethod]
    public void Constructor()
    {
        string name = "Коллекция";
        string typeOfChange = "Изменение элемента";
        Control control = new Control();
        control.RandomInit();

        CollectionHandlerEventArgs<Control> args = new CollectionHandlerEventArgs<Control>(name, typeOfChange, control);

        Assert.AreEqual(name, args.CollectionName);
        Assert.AreEqual(typeOfChange, args.TypeOfChange);
        Assert.AreEqual(control, args.Value);
    }
}

