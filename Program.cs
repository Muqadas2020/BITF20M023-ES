using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7
{
    //*********************************ADAPTER DESIGN PATTREN****************************************//
    // Example 1: Class Adapter
    class Adaptee
    {
        public string SpecificRequest()
        {
            return "Specific request";
        }
    }

    class Adapter : Adaptee
    {
        public string Request()
        {
            return SpecificRequest();
        }
    }

    // Example 2: Object Adapter
    class Adapter1
    {
        private Adaptee adaptee;

        public Adapter1(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public string Request1()
        {
            return adaptee.SpecificRequest();
        }
    }
    //*********************************COMPOSITE DESIGN PATTREN****************************************//
    // Example 1: Tree structure
    abstract class Component
    {
        public abstract string Operation();
    }

    class Leaf : Component
    {
        public override string Operation()
        {
            return "Leaf";
        }
    }

    class Composite : Component
    {
        private List<Component> children = new List<Component>();

        public void Add(Component component)
        {
            children.Add(component);
        }

        public override string Operation()
        {
            StringBuilder result = new StringBuilder("Composite(");
            foreach (var child in children)
            {
                result.Append(child.Operation() + " + ");
            }
            result.Remove(result.Length - 3, 3); // Remove the last " + "
            result.Append(")");
            return result.ToString();
        }
    }

    // Example 2: Graphic objects
    abstract class Graphic
    {
        public abstract string Draw();
    }

    class Circle : Graphic
    {
        public override string Draw()
        {
            return "Circle";
        }
    }

    class Square : Graphic
    {
        public override string Draw()
        {
            return "Square";
        }
    }

    class Picture : Graphic
    {
        private List<Graphic> graphics = new List<Graphic>();

        public void Add(Graphic graphic)
        {
            graphics.Add(graphic);
        }

        public override string Draw()
        {
            StringBuilder result = new StringBuilder("Picture(");
            foreach (var graphic in graphics)
            {
                result.Append(graphic.Draw() + " + ");
            }
            result.Remove(result.Length - 3, 3); // Remove the last " + "
            result.Append(")");
            return result.ToString();
        }
    }

    

    //*********************************PROXY DESIGN PATTREN****************************************//
 

    interface ISubject
    {
        void Request();
    }

    class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject handles request.");
        }
    }

    class Proxy : ISubject
    {
        private RealSubject realSubject;

        public void Request()
        {
            // Lazy initialization
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }

            realSubject.Request();
        }
    }

 

    interface IImage
    {
        void Display();
    }

    class RealImage : IImage
    {
        private string filename;

        public RealImage(string filename)
        {
            this.filename = filename;
            LoadImageFromDisk();
        }

        private void LoadImageFromDisk()
        {
            Console.WriteLine("Loading image from disk: " + filename);
        }

        public void Display()
        {
            Console.WriteLine("Displaying image: " + filename);
        }
    }

    class ProxyImage : IImage
    {
        private RealImage realImage;
        private string filename;

        public ProxyImage(string filename)
        {
            this.filename = filename;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(filename);
            }
            realImage.Display();
        }
    }

    


    //*********************************FLYWEIGHT DESIGN PATTREN****************************************//


    class Character
    {
        private char symbol;

        public Character(char symbol)
        {
            this.symbol = symbol;
        }

        public void Display(int fontSize)
        {
            Console.WriteLine($"Character: {symbol}, Font Size: {fontSize}");
        }
    }

    class CharacterFactory
    {
        private Dictionary<char, Character> characters = new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            if (!characters.ContainsKey(key))
            {
                characters[key] = new Character(key);
            }
            return characters[key];
        }
    }
    //example2
    abstract class Glyph
    {
        public abstract void Draw();
    }

    class Character1 : Glyph
    {
        private char symbol;

        public Character1(char symbol)
        {
            this.symbol = symbol;
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing character: {symbol}");
        }
    }

    class Row : Glyph
    {
        private List<Glyph> children = new List<Glyph>();

        public void AddChild(Glyph child)
        {
            children.Add(child);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a row of glyphs");
            foreach (var child in children)
            {
                child.Draw();
            }
        }
    }




    //********************************* Facade DESIGN PATTREN****************************************//


    // example 1
    class SubsystemA
    {
        public void OperationA()
        {
            Console.WriteLine("SubsystemA Operation of Facade design pattren");
        }
    }

    // example 2
    class SubsystemB
    {
        public void OperationB()
        {
            Console.WriteLine("SubsystemB Operation of Facade design pattren");
        }
    }

    // Facade
    class Facade
    {
        private SubsystemA subsystemA;
        private SubsystemB subsystemB;

        public Facade()
        {
            subsystemA = new SubsystemA();
            subsystemB = new SubsystemB();
        }

        public void Operation()
        {
            Console.WriteLine(" In Facade Operation");
            subsystemA.OperationA();
            subsystemB.OperationB();
        }
    }


    //*********************************BRIDGE DESIGN PATTREN****************************************//
  

    // Implementor
    interface IImplementor
    {
        void OperationImpl();
    }

    // example 1
    class ConcreteImplementorA : IImplementor
    {
        public void OperationImpl()
        {
            Console.WriteLine("ConcreteImplementorA Operation of Bridge Design Pattren");
        }
    }

    // example2
    class ConcreteImplementorB : IImplementor
    {
        public void OperationImpl()
        {
            Console.WriteLine("ConcreteImplementorB Operation of Bridge Design Pattren");
        }
    }

    // Abstraction
    abstract class Abstraction
    {
        protected IImplementor implementor;

        public Abstraction(IImplementor implementor)
        {
            this.implementor = implementor;
        }

        public abstract void Operation();
    }

    // Refined Abstraction 1
    class RefinedAbstractionA : Abstraction
    {
        public RefinedAbstractionA(IImplementor implementor) : base(implementor) { }

        public override void Operation()
        {
            Console.WriteLine("RefinedAbstractionA Operation");
            implementor.OperationImpl();
        }
    }

    // Refined Abstraction 2
    class RefinedAbstractionB : Abstraction
    {
        public RefinedAbstractionB(IImplementor implementor) : base(implementor) { }

        public override void Operation()
        {
            Console.WriteLine("RefinedAbstractionB Operation");
            implementor.OperationImpl();
        }
    }


    //*********************************DECORATOR DESIGN PATTREN****************************************//
   

    // Component
    interface IComponent
    {
        void Operation();
    }

    // Concrete Component
    class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteComponent Operation of decorater design pattren");
        }
    }

    // Decorator
    abstract class Decorator : IComponent
    {
        protected IComponent component;

        public Decorator(IComponent component)
        {
            this.component = component;
        }

        public virtual void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // Concrete Decorator 1
    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent component) : base(component) { }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA Operation of decorate design pattren");
        }
    }

    // Concrete Decorator 2
    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent component) : base(component) { }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorB Operation of decorator design pattren");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adapter Design Pattern");
            Console.WriteLine("_______________________________");
            Adapter1 adapter1 = new Adapter1(new Adaptee());
            string adapter_result1 = adapter1.Request1();
            Console.WriteLine(adapter_result1);
            Adapter adapter2 = new Adapter();
            string adapter_result2 = adapter2.Request();
            Console.WriteLine(adapter_result2);
            Console.WriteLine("\n");


            Console.WriteLine("Composite Design Pattern");
            Console.WriteLine("_______________________________");
            Component leaf = new Leaf();
            Component composite = new Composite();
            ((Composite)composite).Add(new Leaf());
            ((Composite)composite).Add(new Leaf());
            string composite_result1 = composite.Operation();
            Console.WriteLine(composite_result1);
            Graphic circle = new Circle();
            Graphic square = new Square();
            Picture picture = new Picture();
            picture.Add(circle);
            picture.Add(square);
            string composite_result2 = picture.Draw();
            Console.WriteLine(composite_result2);
            Console.WriteLine("\n");


            Console.WriteLine("Proxy Design Pattern");
            Console.WriteLine("_______________________________");
            ISubject proxy = new Proxy();
            proxy.Request();
            IImage image = new ProxyImage("sample.jpg");
            image.Display();
            Console.WriteLine("\n");


            Console.WriteLine("Flyweight Design Pattern");
            Console.WriteLine("_______________________________");
            CharacterFactory factory = new CharacterFactory();
            Character charA = factory.GetCharacter('A');
            charA.Display(12);
            Character charB = factory.GetCharacter('B');
            charB.Display(16);
            Character charA2 = factory.GetCharacter('A'); 
            charA2.Display(20);
            Row document = new Row();
            document.AddChild(new Character1('H'));
            document.AddChild(new Character1('i'));
            document.AddChild(new Character1('!'));
            document.Draw();
            Console.WriteLine("\n");


            Console.WriteLine("Facade Design Pattern");
            Console.WriteLine("_______________________________");
            Facade facade = new Facade();
            facade.Operation();
            Console.WriteLine("\n");

            Console.WriteLine("Bridge Design Pattern");
            Console.WriteLine("_______________________________");
            IImplementor implementorA = new ConcreteImplementorA();
            IImplementor implementorB = new ConcreteImplementorB();
            Abstraction abstractionA = new RefinedAbstractionA(implementorA);
            abstractionA.Operation();
            Abstraction abstractionB = new RefinedAbstractionB(implementorB);
            abstractionB.Operation();
            Console.WriteLine("\n");

            Console.WriteLine("Decorator Design Pattern");
            Console.WriteLine("_______________________________");
            IComponent component = new ConcreteComponent();
            Decorator decoratorA = new ConcreteDecoratorA(component);
            Decorator decoratorB = new ConcreteDecoratorB(decoratorA);
            decoratorB.Operation();

            Console.WriteLine("\n");

            
        }
    }
}
