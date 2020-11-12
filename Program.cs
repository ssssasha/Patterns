using System;

namespace FactoryMethod
{
    public abstract class Developer
    {
        public abstract House Create(int type);
    }

    public class TypeOFHouseDeveloper : Developer
    {
        

        public override House Create(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: return new BrickHouse();
                //повертає об'єкт B, якщо type==2  
                case 2: return new WoodHouse();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class House { } //абстрактний клас продукт

    //конкретні продукти з різною реалізацією
    public class BrickHouse : House 
    {
     
    }

    public class WoodHouse : House { }

    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Developer developer = new TypeOFHouseDeveloper();
            for (int i = 1; i <= 2; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var product = developer.Create(i);
                Console.WriteLine("Where id = {0}, Created {1} ", i, product.GetType());
            }
            Console.ReadKey();
        }
    }
}
