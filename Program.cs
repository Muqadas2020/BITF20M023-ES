//MUQADAS ARSHAD
//BITF20M023
//ASSIGNMENT # 6
using System;

namespace Assignment_6
{
    //********************************* SINGLETON PATTREN *********************************//
    public class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public void PrintMessage()
        {
            Console.WriteLine("New Singleton instance is created.");
        }
    }

    //************************************ FACTORY PATTREN ******************************//
    public interface IProduct
    {
        void Create();
    }

    public class ConcreteProductA : IProduct
    {
        public void Create()
        {
            Console.WriteLine("Product A is created.");
        }
    }

    public class ConcreteProductB : IProduct
    {
        public void Create()
        {
            Console.WriteLine("Product B is created.");
        }
    }

    public interface IFactory
    {
        IProduct CreateProduct();
    }

    public class ConcreteFactoryA : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteFactoryB : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ConcreteProductB();
        }
    }

    //**********************ABSTRACT FACTORY DESIGN PATTREN************************//
    public interface IAbstractProductA
    {
        void CreateProductA();
    }

    public interface IAbstractProductB
    {
        void CreateProductB();
    }

    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    public class ConcreteProductA1 : IAbstractProductA
    {
        public void CreateProductA()
        {
            Console.WriteLine("Product A1 is created here.");
        }
    }

    public class ConcreteProductB1 : IAbstractProductB
    {
        public void CreateProductB()
        {
            Console.WriteLine("Product B1 is created here.");
        }
    }

    public class ConcreteProductA2 : IAbstractProductA
    {
        public void CreateProductA()
        {
            Console.WriteLine("Product A2 is created here.");
        }
    }

    public class ConcreteProductB2 : IAbstractProductB
    {
        public void CreateProductB()
        {
            Console.WriteLine("Product B2 is created here.");
        }
    }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }
    // ***************************BUILDER DESIGN PATTREN****************************//
    class Pizza
    {
        public string type1 { get; set; }
        public string type2 { get; set; }
        

        public void Display()
        {
            Console.WriteLine($"Type1: {type1}");
            Console.WriteLine($"Type2: {type2}");
            
        }
    }

    // Builder
    interface IPizzaBuilder
    {
        void BuildType1();
        void BuildType2();
    
        Pizza GetPizza();
    }

    // Concrete Builder
    class MargheritaPizzaBuilder : IPizzaBuilder
    {
        private Pizza pizza = new Pizza();

        public void BuildType1()
        {
            pizza.type1= "crust";
        }

        public void BuildType2()
        {
            pizza.type2 = "sauce";
        }

        public Pizza GetPizza()
        {
            return pizza;
        }
    }

    // Director
    class PizzaDirector
    {
        public void Construct(IPizzaBuilder builder)
        {
            builder.BuildType1();
            builder.BuildType2();
        }
    }

    //*************************PROTOTYPE DESIGN PATTERN***************************//
    interface ICloneable<T>
    {
        T Clone();
    }

    public class Prototype
    {
    }

    // Concrete Prototype
    class ConcretePrototype : ICloneable<ConcretePrototype>
    {
        public int Id { get; set; }

        public ConcretePrototype Clone()
        {
            return (ConcretePrototype)this.MemberwiseClone();
        }

        public static explicit operator ConcretePrototype(Prototype v)
        {
            throw new NotImplementedException();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SINGLETON DESIGN PATTREN");
            Console.WriteLine("______________________________");
            //example1
            Singleton singleton1 = Singleton.Instance;
            singleton1.PrintMessage();
            //example2
            Singleton singleton2 = Singleton.Instance;
            singleton2.PrintMessage();
            Console.WriteLine("\n");

            Console.WriteLine("FACTORY DESIGN PATTREN");
            Console.WriteLine("______________________________");
            //example1
            IFactory factoryA = new ConcreteFactoryA();
            IProduct productA = factoryA.CreateProduct();
            productA.Create();
            //example2
            IFactory factoryB = new ConcreteFactoryB();
            IProduct productB = factoryB.CreateProduct();
            productB.Create();
            Console.WriteLine("\n");


            Console.WriteLine("ABSTRACT FACTORY DESIGN PATTREN");
            Console.WriteLine("______________________________");
            //example1
            IAbstractFactory factory1 = new ConcreteFactory1();
            IAbstractProductA productA1 = factory1.CreateProductA();
            IAbstractProductB productB1 = factory1.CreateProductB();
            productA1.CreateProductA();
            productB1.CreateProductB();
            //example2
            IAbstractFactory factory2 = new ConcreteFactory2();
            IAbstractProductA productA2 = factory2.CreateProductA();
            IAbstractProductB productB2 = factory2.CreateProductB();
            productA2.CreateProductA();
            productB2.CreateProductB();
            Console.WriteLine("\n");

            
            Console.WriteLine("BUILDER DESIGN PATTERN");
            Console.WriteLine("______________________________");
            ////example1
            PizzaDirector director = new PizzaDirector();
            IPizzaBuilder margheritaBuilder = new MargheritaPizzaBuilder();
            director.Construct(margheritaBuilder);
            Pizza margheritaPizza = margheritaBuilder.GetPizza();
            Console.WriteLine("Margherita Pizza:");
            margheritaPizza.Display();
            ////example2
            PizzaDirector director1 = new PizzaDirector();
            IPizzaBuilder margheritaBuilder1 = new MargheritaPizzaBuilder();
            director1.Construct(margheritaBuilder1);
            Pizza margheritaPizza1 = margheritaBuilder1.GetPizza();
            Console.WriteLine("Cheese Pizza:");
            margheritaPizza1.Display();
            Console.WriteLine("\n");


            Console.WriteLine("PROTOTYPE DESIGN PATTERN");
            Console.WriteLine("______________________________");
            //example1
            ConcretePrototype prototype = new ConcretePrototype { Id = 1 };
            ConcretePrototype clonedPrototype = (ConcretePrototype)prototype.Clone();
            clonedPrototype.Id = 2;
            Console.WriteLine($"Original Prototype ID IS: {prototype.Id}");
            Console.WriteLine($"Cloned Prototype ID IS: {clonedPrototype.Id}");
            //example2
            ConcretePrototype prototype1 = new ConcretePrototype { Id = 3 };
            ConcretePrototype clonedPrototype1 = (ConcretePrototype)prototype.Clone();
            clonedPrototype1.Id = 4;
            Console.WriteLine($"Original Prototype ID IS: {prototype1.Id}");
            Console.WriteLine($"Cloned Prototype ID IS: {clonedPrototype1.Id}");
            Console.WriteLine("\n");
            Console.ReadLine();
        }
    }
}
