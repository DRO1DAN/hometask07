using System;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            ChristmasTree christmasTree = new ChristmasTree();
            OrnamentDecorator ornaments = new OrnamentDecorator();
            GarlandDecorator garland = new GarlandDecorator();

            ornaments.SetTree(christmasTree);
            garland.SetTree(ornaments);

            garland.Display();

            Console.Read();
        }
    }

    abstract class Tree
    {
        public abstract void Display();
    }

    class ChristmasTree : Tree
    {
        public override void Display()
        {
            Console.WriteLine("Christmas Tree");
        }
    }

    abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        public void SetTree(Tree tree)
        {
            this.tree = tree;
        }

        public override void Display()
        {
            if (tree != null)
            {
                tree.Display();
            }
        }
    }

    class OrnamentDecorator : TreeDecorator
    {
        private string ornaments = "Ornaments";

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Decorated with " + ornaments);
        }
    }

    class GarlandDecorator : TreeDecorator
    {
        public override void Display()
        {
            base.Display();
            AddGarland();
        }

        private void AddGarland()
        {
            Console.WriteLine("Garland lights are shining!");
        }
    }
}
