using System;
using System.Collections.Generic;

namespace Decorator
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            DecoratedChristmasTree christmasTree = new DecoratedChristmasTree();
            GlowingChristmasTree glowind = new GlowingChristmasTree("yellow-red lights");
            

            // Link decorators
            glowind.SetTree(christmasTree);
            glowind.Decorate();
            glowind.SwitchGarland();
            glowind.SwitchGarland();
            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class ChristmasTree
    {
        public abstract void Decorate();
    }

    // "ConcreteComponent"
    class DecoratedChristmasTree : ChristmasTree
    {
        public List<string> Decorations = new List<string>();
        public override void Decorate()
        {
            Console.WriteLine("Add Christmas tree decorations");
        }
        public void AddDecorations(string decoration)
        {
            Decorations.Add(decoration);
        }
    }
    // "Decorator"
    abstract class ChristmasTreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public void SetTree(ChristmasTree tree)
        {
            this.tree = tree;
        }
        public override void Decorate()
        {
            if (tree != null)
            {
                tree.Decorate();
            }
        }
    }

    // "ConcreteDecoratorA"
    class GlowingChristmasTree : ChristmasTreeDecorator
    {
        private bool IsGlowing = false;
        public string Garlands { get; private set; }
        public GlowingChristmasTree(string garlands)
        {
            Garlands = garlands;
        }
        public override void Decorate()
        {
            base.Decorate();
            Console.WriteLine($"Add {Garlands}");
        }
        public void SwitchGarland()
        {
            IsGlowing = IsGlowing ? false : true;
            Console.WriteLine($"The garland is turn {(IsGlowing ? "On" : "Off")}");
        }
    }
}
