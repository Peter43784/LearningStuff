using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestBinConsoleApp {

	#region Factory Method
	interface IProduct {

	  void Show();
	}

	class ConcreteProductA : IProduct {
		 public void Show() {
			Console.WriteLine("Product A");
		}
	}
	class ConcreteProductB : IProduct {
		public   void Show() {
			Console.WriteLine("Product B");
		}
	}

	interface IFactory {
		  IProduct Create();
		
	}
	class ConcreteFactoryA : IFactory {
		public IProduct Create() {
			return new ConcreteProductA();
		}
	}
	class ConcreteFactoryB : IFactory {
		public IProduct Create() {
			return new ConcreteProductB();
		}
	}
	#endregion

	#region Singleton
	class Singleton {
		private Singleton() { }
		private static Singleton instance;
		private static object obj = new object();
		public static Singleton GetInstance {
			get {
				if( instance == null ) {
					lock( obj ) {
						if( instance == null ) {
							instance = new Singleton();
						}
						
					}
				}
				return instance;
			}
		}
	}
	#endregion

	#region Builder
	class Person {
		public string Name { get; set; }
		public int Age { get; set; }
 
	}

	class PersonBuilder {
		private string _name;
		private int _age;
 

		public Person Build() {
			return new Person { Age = _age, Name = _name};
		}

		 public PersonBuilder WithName(string name ) {
			_name = name;
			return this;
		}

		public PersonBuilder WithAge(int age) {
			_age = age;
			return this;
		}

	}
	#endregion

    #region Decorator
	abstract class Beverage {

		public string Name { get; set; }

		public Beverage(string name) {
			Name = name;
		}
		public abstract int GetCost();
	}
	class Cofee: Beverage {

		public Cofee( string name ) : base( name ) {}

		public override int GetCost() {
			return 12;
		}
	}

	class Tea : Beverage {
		public Tea( string name ) : base( name ) {}

		public override int GetCost() {
			return 5;
		}
	}

	abstract class BeverageDecorator : Beverage {
		protected Beverage _beverage;

		public BeverageDecorator( string name, Beverage beverage ) : base( name ) {
			_beverage = beverage;
		}
	}

	class Milk : BeverageDecorator {


		public Milk( Beverage beverage ) : base(beverage.Name +  " Milk", beverage ) {}

		public override int GetCost() {
			return _beverage.GetCost() + 5;
		}

	}
	class Lemon : BeverageDecorator {


		public Lemon(Beverage beverage ) : base( beverage.Name + " Lemon", beverage ) { }

		public override int GetCost() {
			return _beverage.GetCost() + 2;
		}

	}

	#endregion

	#region Strategy
	interface IMovable {
		void Move();
	}
	class PetrolEngine : IMovable {
		public void Move() {
			Console.WriteLine( "Petrol engine is on" );
		}
	}

	class ElectricEngine : IMovable {
		public void Move() {
			Console.WriteLine( "Electric engine is on" );
		}

	}

	class Car {

		 
		public Car(IMovable movable) {
			Movable = movable;
		}

		public IMovable Movable { private get; set; }
		public void Move() {
			Movable.Move();
		}
	}

	#endregion

	#region Adapter

	interface INewInterface {
		void Do();
	}

	class NewWorker : INewInterface {
		public void Do() {
			Console.WriteLine( "Hello from new interface" );
		}
	}

	class Worker {

		public void Work(INewInterface newInterface ) {
			newInterface.Do();
		}

	}
	class WorkerAdapter : INewInterface {

		IOldInterface _oldInterface;
		public WorkerAdapter(IOldInterface oldInterface) {
			_oldInterface = oldInterface;	
		}
		public void Do() {
			 _oldInterface.AnotherDo();
		}
	}

	interface IOldInterface {

		void AnotherDo();

	}

	class OldWorker : IOldInterface {
		public void AnotherDo() {
			Console.WriteLine( "Hello from old interface" );
		}
	}
	#endregion


	interface IInterface {

	    int M1();
		void M2();
		string M3();

	}

	class One : IInterface {
		public int M1() {
			throw new NotImplementedException();
		}

		public void M2() {
			throw new NotImplementedException();
		}

		public string M3() {
			throw new NotImplementedException();
		}

		 
	}

	interface ITwo {

		int MTwo2();

	}

	class Two : ITwo {
		public int MTwo2() {
			return 2;
		}
		public Two Clone() {
			return (Two)this.MemberwiseClone();
		}
	}

	class Adapter : ITwo {

		IInterface _instance;
		public Adapter( IInterface instance) {
			_instance = instance;
		}

		public int MTwo2() {
			return _instance.M1();
		}

	}

}
	
