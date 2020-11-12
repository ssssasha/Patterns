using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            TrianglePrototype prototype = new Triangle(8,5,4,1);
            TrianglePrototype clone = prototype.Clone();
            prototype.GetInfo();
            clone.GetPerimeter();
        }
    }
    abstract class TrianglePrototype
    {
        public int Id { get; private set; }
        public TrianglePrototype(int id)
        {
            this.Id = id;
        }
        public abstract TrianglePrototype Clone();
        public abstract void GetPerimeter();
        public abstract void GetInfo();
    }

    class  Triangle: TrianglePrototype
    {
        int sideA;
        int sideB;
        int sideC;
        public Triangle(int sideA, int sideB, int sideC,int id)
        : base(id)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }
        public override TrianglePrototype Clone()
        {
            return new Triangle(this.sideA, this.sideB, this.sideC, Id);
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Triangle with sides {sideA} {sideB} {sideC}");
        }
        public override void GetPerimeter()
        {
            Console.WriteLine($"Perimeter: {sideA + sideB + sideC}");
        }
    }

}
