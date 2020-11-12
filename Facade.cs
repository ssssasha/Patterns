using System;

namespace Facade
{
    class MainApp
    {
        public static void Main()
        {
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            CLR clr = new CLR();

            VisualStudioFacade vs = new VisualStudioFacade(textEditor, compiller, clr);

            Programmer programmer = new Programmer();
            programmer.CreateApplication(vs);

            Console.Read();
        }
    }


    // "Subsystem ClassA" 
    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Написання коду");
        }
        public void Save()
        {
            Console.WriteLine("Збереження коду");
        }
    }

    // Subsystem ClassB" 
    class Compiller
    {
        public void Compile()
        {
            Console.WriteLine("Компіляція програми");
        }
    }


    // Subsystem ClassC" 
    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Виконання програми");
        }
        public void Finish()
        {
            Console.WriteLine("Завершення роботи програми");
        }
    }

    // "Facade" 
    class VisualStudioFacade
    {
        TextEditor textEditor;
        Compiller compiller;
        CLR clr;
        public VisualStudioFacade(TextEditor te, Compiller compil, CLR clr)
        {
            this.textEditor = te;
            this.compiller = compil;
            this.clr = clr;
        }
        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiller.Compile();
            clr.Execute();
        }
        public void Stop()
        {
            clr.Finish();
        }
    }

    class Programmer
    {
        public void CreateApplication(VisualStudioFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }

}
