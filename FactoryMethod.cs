using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new BrickDeveloper("Yourcity");
            House house2 = dev.Build();

            dev = new WoodDeveloper("Private developer");
            House house = dev.Build();

            Console.ReadLine();
        }
    }
    
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
        
        abstract public House Build();
    }
    
    class BrickDeveloper : Developer
    {
        public BrickDeveloper(string n) : base(n)
        { }

        public override House Build()
        {
            return new PanelHouse();
        }
    }
   
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        { }

        public override House Build()
        {
            return new WoodHouse();
        }
    }

    abstract class House
    { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Brick house built");
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Wooden house built");
        }
    }
}
