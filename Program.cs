//Muqadas Arshad
//BITF20M023
//Assgnment-08
using System;
using System.Collections;
using System.Collections.Generic;
namespace Assignment_8
{
    //**********************************Template Method*******************************//
    // Abstract class defining the template method
    abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
        }

        // Abstract methods to be implemented by concrete classes
        protected abstract void Operation1();
        protected abstract void Operation2();
    }

    // Concrete class implementing the template method
    class ConcreteClassA : AbstractClass
    {
        protected override void Operation1()
        {
            Console.WriteLine("ConcreteClassA: Operation1 for template method design pattren.");
        }

        protected override void Operation2()
        {
            Console.WriteLine("ConcreteClassA: Operation2 for template method design pattren.");
        }
    }

    class ConcreteClassB : AbstractClass
    {
        protected override void Operation1()
        {
            Console.WriteLine("ConcreteClassB: Operation1 for template method design pattren.");
        }

        protected override void Operation2()
        {
            Console.WriteLine("ConcreteClassB: Operation2 for template method design pattren.");
        }
    }


//***************************************Mediator Design Pattren***************************************************//

// Mediator interface
    interface IMediator
    {
        void SendMessage(string message, Colleague colleague);
    }

    // Colleague interface
    abstract class Colleague
    {
        protected IMediator mediator;

        public Colleague(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Send(string message);
        public abstract void Receive(string message);
    }

    // Concrete Mediator
    class ConcreteMediator : IMediator
    {
        private Dictionary<string, Colleague> colleagues = new Dictionary<string, Colleague>();

        public void AddColleague(string name, Colleague colleague)
        {
            colleagues[name] = colleague;
        }

        public void SendMessage(string message, Colleague colleague)
        {
            foreach (var col in colleagues.Values)
            {
                if (col != colleague)
                    col.Receive(message);
            }
        }
    }

    // Concrete Colleague
    class ConcreteColleagueA : Colleague
    {
        public ConcreteColleagueA(IMediator mediator) : base(mediator) { }

        public override void Send(string message)
        {
            Console.WriteLine("ColleagueA sends message: " + message);
            mediator.SendMessage(message, this);
        }

        public override void Receive(string message)
        {
            Console.WriteLine("ColleagueA receives message: " + message);
        }
    }

    class ConcreteColleagueB : Colleague
    {
        public ConcreteColleagueB(IMediator mediator) : base(mediator) { }

        public override void Send(string message)
        {
            Console.WriteLine("ColleagueB sends message: " + message);
            mediator.SendMessage(message, this);
        }

        public override void Receive(string message)
        {
            Console.WriteLine("ColleagueB receives message: " + message);
        }
    }

    //***********************************Chain of Repository Design Pattren*****************************************//
   

// Handler interface
    interface IHandler
    {
        IHandler SetNextHandler(IHandler handler);
        void HandleRequest(int request);
    }

    // Concrete Handler
    class ConcreteHandler : IHandler
    {
        private IHandler nextHandler;

        public IHandler SetNextHandler(IHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public void HandleRequest(int request)
        {
            if (request <= 10)
            {
                Console.WriteLine("Handled by ConcreteHandler of Chain of Repository Design pattren: " + request);
            }
            else if (nextHandler != null)
            {
                Console.WriteLine("Pass the request to the next handler");
                nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("End of the chain.sorry!The Request is not handled.");
            }
        }
    }


    // Handler interface
    interface IHandler_2
    {
        IHandler_2 SetNextHandler_2(IHandler_2 handler);
        void HandleRequest_2(string request);
    }

    // Concrete Handler
    class ConcreteHandler_2 : IHandler_2
    {
        private IHandler_2 nextHandler;

        public IHandler_2 SetNextHandler_2(IHandler_2 handler)
        {
            nextHandler = handler;
            return handler;
        }

        public void HandleRequest_2(string request)
        {
            if (request.Contains("specific"))
            {
                Console.WriteLine("Handled by ConcreteHandler: " + request);
            }
            else if (nextHandler != null)
            {
                Console.WriteLine("Pass the request to the next handler of Chain of Repository of Design pattren.");
                nextHandler.HandleRequest_2(request);
            }
            else
            {
                Console.WriteLine("End of the chain.Sorry!The Request is not handled.");
            }
        }
    }

    //***************************************Observer Design Pattren*****************************************************//


    // Observer interface
    interface IObserver
    {
        void Update(string message);
    }

    // Subject interface
    interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string message);
    }

    // Concrete Observer
    class ConcreteObserver : IObserver
    {
        private string name;

        public ConcreteObserver(string name)
        {
            this.name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"Name: {name} \n The Message {name} Received is: {message}");
        }
    }

    // Concrete Subject
    class ConcreteSubject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }


// Observer interface
    interface IObserver_2
    {
        void Update_2(int value);
    }

    // Subject interface
    interface ISubject_2
    {
        void AddObserver_2(IObserver_2 observer);
        void RemoveObserver_2(IObserver_2 observer);
        void NotifyObservers_2(int value);
    }

    // Concrete Observer
    class ConcreteObserver_2 : IObserver_2
    {
        private string name;

        public ConcreteObserver_2(string name)
        {
            this.name = name;
        }

        public void Update_2(int value)
        {
            Console.WriteLine($"Namee: {name}\n The received value of {name} is: {value}");
        }
    }

    // Concrete Subject
    class ConcreteSubject_2 : ISubject_2
    {
        private List<IObserver_2> observers = new List<IObserver_2>();

        public void AddObserver_2(IObserver_2 observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver_2(IObserver_2 observer)
        {
            observers.Remove(observer);
        }

        private int state;

        public void SetState_2(int state)
        {
            this.state = state;
            NotifyObservers_2(state);
        }

        public void NotifyObservers_2(int value)
        {
            foreach (var observer in observers)
            {
                observer.Update_2(value);
            }
        }
    }

    //**********************************Strategy Design Pattren**********************************************//


    // Strategy interface
    interface IStrategy
    {
        void Execute();
    }

    // Concrete Strategies
    class ConcreteStrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Executing strategy A of strategy design pattren example1.");
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Executing strategy B of strategy design pattren example1.");
        }
    }

    // Context
    class Context
    {
        private IStrategy strategy;

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            strategy.Execute();
        }
    }



// Strategy interface
    interface IStrategy_2
    {
        void DoOperation_2();
    }

    // Concrete Strategies
    class ConcreteStrategyAdd_2 : IStrategy_2
    {
        public void DoOperation_2()
        {
            Console.WriteLine("Addition Operation of Strategy Design Pattren example2.");
        }
    }

    class ConcreteStrategyMultiply_2 : IStrategy_2
    {
        public void DoOperation_2()
        {
            Console.WriteLine("Multiplication Operation of Strategy Design Pattren example2.");
        }
    }

    // Context
    class Context_2
    {
        private IStrategy_2 strategy;

        public Context_2(IStrategy_2 strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy_2(IStrategy_2 strategy)
        {
            this.strategy = strategy;
        }

        public void ExecuteOperation_2()
        {
            strategy.DoOperation_2();
        }
    }
    //***********************************Command Design Pattren*****************************************//
    // Command interface
    interface ICommand
    {
        void Execute();
    }

    // Receiver
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Receiver is performing an action for command design pattren example1.");
        }
    }

    // Concrete Command
    class ConcreteCommand : ICommand
    {
        private Receiver receiver;

        public ConcreteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.Action();
        }
    }

    // Invoker
    class Invoker
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

    // Command interface
    interface ICommand_2
    {
        void Execute_2();
    }

    // Receiver
    class Light
    {
        public void TurnOn_2()
        {
            Console.WriteLine("Light is ON for command design pattren example2.");
        }

        public void TurnOff_2()
        {
            Console.WriteLine("Light is OFF for command design pattren example2.");
        }
    }

    // Concrete Command
    class TurnOnCommand_2 : ICommand_2
    {
        private Light light;

        public TurnOnCommand_2(Light light)
        {
            this.light = light;
        }

        public void Execute_2()
        {
            light.TurnOn_2();
        }
    }

    class TurnOffCommand_2 : ICommand_2
    {
        private Light light;

        public TurnOffCommand_2(Light light)
        {
            this.light = light;
        }

        public void Execute_2()
        {
            light.TurnOff_2();
        }
    }

    // Invoker
    class RemoteControl_2
    {
        private ICommand_2 command;

        public void SetCommand_2(ICommand_2 command)
        {
            this.command = command;
        }

        public void PressButton_2()
        {
            command.Execute_2();
        }
    }

    //************************************State Design Pattren*******************************************//

    // State interface
    interface IState
    {
        void Handle(State_context context);
    }

    // Concrete States
    class ConcreteStateA : IState
    {
        public void Handle(State_context context)
        {
            Console.WriteLine("Handling request in State A for State Design Pattren example1.");
            context.State = new ConcreteStateB();
        }
    }

    class ConcreteStateB : IState
    {
        public void Handle(State_context context)
        {
            Console.WriteLine("Handling request in State B for State Design Pattren example1.");
            context.State = new ConcreteStateA();
        }
    }

    // Context
    class State_context
    {
        private IState state;

        public State_context(IState state)
        {
            this.state = state;
        }

        public IState State
        {
            get { return state; }
            set
            {
                Console.WriteLine("State transition");
                state = value;
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }


    // State interface
    interface IState_2
    {
        void DoAction(State_Context_2 context);
    }

    // Concrete States
    class StartState : IState_2
    {
        public void DoAction(State_Context_2 context)
        {
            Console.WriteLine("Player is in start state of state design pattren example2.");
            context.State = this;
        }

        public override string ToString()
        {
            return "Start State of example2";
        }
    }

    class StopState : IState_2
    {
        public void DoAction(State_Context_2 context)
        {
            Console.WriteLine("Player is in stop state of state design pattren example2.");
            context.State = this;
        }

        public override string ToString()
        {
            return "Stop State of example2.";
        }
    }

    // Context
    class State_Context_2
    {
        private IState_2 state;

        public State_Context_2()
        {
            state = null;
        }

        public IState_2 State
        {
            get { return state; }
            set
            {
                Console.WriteLine("State transition");
                state = value;
            }
        }

        public void Request()
        {
            state.DoAction(this);
        }
    }

    //************************************Visitor Design pattren***********************************//

    // Element interface
    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    // Concrete Elements
    class ConcreteElementA : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }

        public void OperationA()
        {
            Console.WriteLine("Operation A in ConcreteElementA of Visitor Design Pattren example1.");
        }
    }

    class ConcreteElementB : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }

        public void OperationB()
        {
            Console.WriteLine("Operation B in ConcreteElementB of Visitor Design Pattren example1.");
        }
    }

    // Visitor interface
    interface IVisitor
    {
        void VisitConcreteElementA(ConcreteElementA elementA);
        void VisitConcreteElementB(ConcreteElementB elementB);
    }

    // Concrete Visitor
    class ConcreteVisitor : IVisitor
    {
        public void VisitConcreteElementA(ConcreteElementA elementA)
        {
            Console.WriteLine("Visitor is visiting ConcreteElementA of Visitor Design Pattren example1.");
            elementA.OperationA();
        }

        public void VisitConcreteElementB(ConcreteElementB elementB)
        {
            Console.WriteLine("Visitor is visiting ConcreteElementB of Visitor Design Pattren example1.");
            elementB.OperationB();
        }
    }

    // Object Structure
    class ObjectStructure
    {
        private List<IElement> elements = new List<IElement>();

        public void Attach(IElement element)
        {
            elements.Add(element);
        }

        public void Detach(IElement element)
        {
            elements.Remove(element);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var element in elements)
            {
                element.Accept(visitor);
            }
        }
    }


    //***************************************Interpreter Design Pattern:******************************************//

// Context
    class Interpreter
    {
        public string Input { get; set; }
        public int Output { get; set; }
    }

    // Abstract Expression
    interface IExpression
    {
        void Interpret(Interpreter interpt);
    }

    // Terminal Expression
    class TerminalExpression : IExpression
    {
        public void Interpret(Interpreter interpt)
        {
            if (int.TryParse(interpt.Input, out int tempOutput))
            {
                interpt.Output = tempOutput;
            }
            else
            {
                Console.WriteLine("Failed to parse input");
            }
        }
    }

    // Non-terminal Expression
    class NonTerminalExpression : IExpression
    {
        private IExpression leftExpression;
        private IExpression rightExpression;

        public NonTerminalExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public void Interpret(Interpreter context)
        {
            leftExpression.Interpret(context);
            rightExpression.Interpret(context);
            context.Output = context.Output * 2; // Example operation
        }
    }

    

    // Context
    class Interpter_2
    {
        public string Input { get; set; }
        public bool Output { get; set; }
    }

    // Abstract Expression
    interface IExpression_2
    {
        void Interpret_2(Interpter_2 intrep);
    }

    // Terminal Expression
    class TerminalExpression_2 : IExpression_2
    {
        public void Interpret_2(Interpter_2 intrep)
        {
            intrep.Output = intrep.Input.ToLower() == "true";
        }
    }

    // Non-terminal Expression
    class NonTerminalExpression_2 : IExpression_2
    {
        private IExpression_2 expression;

        public NonTerminalExpression_2(IExpression_2 expression)
        {
            this.expression = expression;
        }

        public void Interpret_2(Interpter_2 intrep)
        {
            expression.Interpret_2(intrep);
            intrep.Output = !intrep.Output; // Example operation
        }
    }

    //**************************************Iterator Design Pattern***************************************//

// Aggregate interface
interface IAggregate
    {
        IIterator CreateIterator();
    }

    // Iterator interface
    interface IIterator
    {
        bool HasNext();
        object Next();
    }

    // Concrete Aggregate
    class ConcreteAggregate : IAggregate
    {
        private ArrayList items = new ArrayList();

        public void AddItem(object item)
        {
            items.Add(item);
        }

        public IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public object this[int index]
        {
            get { return items[index]; }
        }
    }

    // Concrete Iterator
    class ConcreteIterator : IIterator
    {
        private ConcreteAggregate aggregate;
        private int current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public bool HasNext()
        {
            return current < aggregate.Count;
        }

        public object Next()
        {
            if (HasNext())
            {
                return aggregate[current++];
            }
            else
            {
                throw new InvalidOperationException("End of iteration");
            }
        }
    }

// Aggregate interface
interface IAggregate2<T>
    {
        IIterator2<T> CreateIterator2();
    }

    // Iterator interface
    interface IIterator2<T>
    {
        bool HasNext2();
        T Next2();
    }

    // Concrete Aggregate
    class ConcreteAggregate2<T> : IAggregate2<T>
    {
        private List<T> items = new List<T>();

        public void AddItem2(T item)
        {
            items.Add(item);
        }

        public IIterator2<T> CreateIterator2()
        {
            return new ConcreteIterator2<T>(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public T this[int index]
        {
            get { return items[index]; }
        }
    }

    // Concrete Iterator
    class ConcreteIterator2<T> : IIterator2<T>
    {
        private ConcreteAggregate2<T> aggregate;
        private int current = 0;

        public ConcreteIterator2(ConcreteAggregate2<T> aggregate)
        {
            this.aggregate = aggregate;
        }

        public bool HasNext2()
        {
            return current < aggregate.Count;
        }

        public T Next2()
        {
            if (HasNext2())
            {
                return aggregate[current++];
            }
            else
            {
                throw new InvalidOperationException("End of iteration");
            }
        }
    }

    //**************************************Memento Design Pattern*********************************//
   

    // Memento
    class Memento
    {
        public string State { get; private set; }

        public Memento(string state)
        {
            State = state;
        }
    }

    // Originator
    class Originator
    {
        public string State { get; set; }

        public Memento CreateMemento()
        {
            return new Memento(State);
        }

        public void RestoreMemento(Memento memento)
        {
            State = memento.State;
        }
    }

    // Caretaker
    class Caretaker
    {
        public Memento Memento { get; set; }
    }


    // Memento2
    class Memento2
    {
        public int Balance { get; private set; }

        public Memento2(int balance)
        {
            Balance = balance;
        }
    }

    // Originator
    class BankAccount
    {
        private int balance;

        public int Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                Console.WriteLine("Balance: " + balance);
            }
        }

        public Memento2 CreateMemento()
        {
            return new Memento2(balance);
        }

        public void RestoreMemento(Memento2 memento2)
        {
            balance = memento2.Balance;
            Console.WriteLine("Balance after restoring: " + balance);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Template Method Design Pattren:");
            Console.WriteLine("_______________________________");
            AbstractClass classA = new ConcreteClassA();
            classA.TemplateMethod();
            AbstractClass classB = new ConcreteClassB();
            classB.TemplateMethod();
            Console.WriteLine("\n");


            Console.WriteLine("Mediator design pattern:");
            Console.WriteLine("________________________");
            ConcreteMediator mediator = new ConcreteMediator();
            ConcreteColleagueA colleagueA = new ConcreteColleagueA(mediator);
            ConcreteColleagueB colleagueB = new ConcreteColleagueB(mediator);
            mediator.AddColleague("ColleagueA", colleagueA);
            mediator.AddColleague("ColleagueB", colleagueB);
            colleagueA.Send("Hello, ColleagueB!");
            colleagueB.Send("Hi, ColleagueA!");
            Console.WriteLine("\n");


            Console.WriteLine("Chain of repository Design Pattren:");
            Console.WriteLine("___________________________________");
            IHandler handler1 = new ConcreteHandler();
            IHandler handler2 = new ConcreteHandler();
            handler1.SetNextHandler(handler2);
            handler1.HandleRequest(5);
            handler1.HandleRequest(15);
            IHandler_2 handler3 = new ConcreteHandler_2();
            IHandler_2 handler4 = new ConcreteHandler_2();
            handler3.SetNextHandler_2(handler4);
            handler3.HandleRequest_2("Handle specific request of Chain of Repository design pattren.");
            handler3.HandleRequest_2("Handle general request of Chain of Repository design pattren.");
            Console.WriteLine("\n");


            Console.WriteLine("Observer Design Pattren:");
            Console.WriteLine("________________________");
            ConcreteSubject subject = new ConcreteSubject();
            ConcreteObserver observer1 = new ConcreteObserver("Observer_1");
            ConcreteObserver observer2 = new ConcreteObserver("Observer_2");
            subject.AddObserver(observer1);
            subject.AddObserver(observer2);
            subject.NotifyObservers("Hello! Observers of Observer Design Pattren.");
            ConcreteSubject_2 subject_2 = new ConcreteSubject_2();
            ConcreteObserver_2 observer3 = new ConcreteObserver_2("Observer_3");
            ConcreteObserver_2 observer4 = new ConcreteObserver_2("Observer_4");
            subject_2.AddObserver_2(observer3);
            subject_2.AddObserver_2(observer4);
            subject_2.SetState_2(10);
            Console.WriteLine("\n");


            Console.WriteLine("Strategy Design Pattren:");
            Console.WriteLine("________________________");
            Context context = new Context(new ConcreteStrategyA());
            context.ExecuteStrategy();
            context.SetStrategy(new ConcreteStrategyB());
            context.ExecuteStrategy();
            Context_2 context_2 = new Context_2(new ConcreteStrategyAdd_2());
            context_2.ExecuteOperation_2();
            context_2.SetStrategy_2(new ConcreteStrategyMultiply_2());
            context_2.ExecuteOperation_2();
            Console.WriteLine("\n");

            Console.WriteLine("Command Design Pattren:");
            Console.WriteLine("_______________________");
            Receiver receiver = new Receiver();
            ICommand command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
            Light light = new Light();
            ICommand_2 turnOnCommand = new TurnOnCommand_2(light);
            ICommand_2 turnOffCommand = new TurnOffCommand_2(light);
            RemoteControl_2 remote_2 = new RemoteControl_2();
            remote_2.SetCommand_2(turnOnCommand);
            remote_2.PressButton_2();
            remote_2.SetCommand_2(turnOffCommand);
            remote_2.PressButton_2();
            Console.WriteLine("\n");


            Console.WriteLine("State Design Pattren:");
            Console.WriteLine("_____________________");
            State_context state = new State_context(new ConcreteStateA());
            state.Request();
            state.Request();
            state.Request();
            State_Context_2 state_2 = new State_Context_2();
            StartState startState = new StartState();
            startState.DoAction(state_2);
            Console.WriteLine(state_2.State.ToString());
            StopState stopState = new StopState();
            stopState.DoAction(state_2);
            Console.WriteLine(state_2.State.ToString());
            Console.WriteLine("\n");


            Console.WriteLine("Visitor Design Pattren:");
            Console.WriteLine("_______________________");
            ObjectStructure objectStructure = new ObjectStructure();
            ConcreteElementA elementA = new ConcreteElementA();
            ConcreteElementB elementB = new ConcreteElementB();
            objectStructure.Attach(elementA);
            objectStructure.Attach(elementB);
            ConcreteVisitor visitor = new ConcreteVisitor();
            objectStructure.Accept(visitor);
            
            Console.WriteLine("\n");


            Console.WriteLine("Interpreter Design Pattern:");
            Console.WriteLine("___________________________");
            Interpreter interpreter = new Interpreter { Input = "10" };
            IExpression expression = new NonTerminalExpression(new TerminalExpression(), new TerminalExpression());
            expression.Interpret(interpreter);
            Console.WriteLine($"Result 1: {interpreter.Output}");
            Interpter_2 intrep = new Interpter_2 { Input = "False" };
            IExpression_2 expression2 = new NonTerminalExpression_2(new TerminalExpression_2());
            expression2.Interpret_2(intrep);
            Console.WriteLine($"Result 2: {intrep.Output}");
            Console.WriteLine("\n");


            Console.WriteLine("Iterator Design Pattern:");
            Console.WriteLine("________________________");
            ConcreteAggregate aggregate = new ConcreteAggregate();
            aggregate.AddItem("Item 1");
            aggregate.AddItem("Item 2");
            aggregate.AddItem("Item 3");
            IIterator iterator = aggregate.CreateIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
            ConcreteAggregate2<string> aggregate2 = new ConcreteAggregate2<string>();
            aggregate2.AddItem2("Item 4");
            aggregate2.AddItem2("Item 5");
            aggregate2.AddItem2("Item 6");
            IIterator2<string> iterator2 = aggregate2.CreateIterator2();
            while (iterator2.HasNext2())
            {
                Console.WriteLine(iterator2.Next2());
            }
            Console.WriteLine("\n");


            Console.WriteLine("Memento Design Pattern:");
            Console.WriteLine("_______________________");
            Originator originator = new Originator();
            originator.State = "State1";
            Caretaker caretaker = new Caretaker();
            caretaker.Memento = originator.CreateMemento();
            originator.State = "State2";
            Console.WriteLine("Current State: " + originator.State);
            originator.RestoreMemento(caretaker.Memento);
            Console.WriteLine("Restored State: " + originator.State);
            BankAccount account = new BankAccount();
            account.Balance = 100;
            Memento2 memento = account.CreateMemento();
            account.Balance = 50;
            account.RestoreMemento(memento);
            Console.WriteLine("\n");
        }
    }
}
