using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using TestBinConsoleApp.TypesCreation.Events;
using TestBinConsoleApp.TypesCreation.Generics;
using TestBinConsoleApp.TypesCreation.Interfaces;
using TestBinConsoleApp._3_MainDataTypes.Delegates;
using  TestBinConsoleApp._3_MainDataTypes.Strings;

namespace TestBinConsoleApp {

	
	enum Colors{red, green};
	static class ExtensionMethods {

		public static void Extend( this Program.Base a ) {
			Console.WriteLine("Extension method for class A");
		}
	}
	public class Program {

		struct Point {

			public Point(int x, int y) {
				this.x = x;
				this.y = y;
			}

			readonly int x;
			readonly int y;
			public static Point operator+(Point ms1, Point ms2) {
				int a = ms1.x + ms2.x;
				int b = ms1.y + ms2.y;
				return new Point(a,b);
			}

			public override string ToString() {
				return $"{x},{y}";
			}

		}
	 
		public  class Base   {
			public void M1() { }
			 public virtual void Do() {
				 Console.WriteLine( "A.DO()" );
			 }
			public virtual void Make() {
				Do();
				Console.WriteLine( "A.Make" );
			}
		}

		public class Derived : Base {
			public void M2() {}
			public new void Do() {
				Console.WriteLine( "B.DO()" );
			}

			public override void Make() {
				Do();
				Console.WriteLine( "B.Make()" );
			}

		}
		
		public static Derived Destroy( out  Derived b , params int[] a ) {

			b = null;
			return b;
		}
		
		public class Indexers {

			public string name { get; set; }
			public int age { get; set; }
			public int this[bool b] { get { return 1; } }
			public string this[bool b, bool b2] { get { return "1"; } }
			

		}

		class A {

			public Colors abc(Colors c) {
				c = new Colors();
				 
				return c;
			}

		}

		class B :A {

			public void abc() {
				Console.WriteLine( "B" );
			}

		}

		static void Main( string[] args ) {

			IFactory f = new ConcreteFactoryA();
			f.Create().Show();
			f = new ConcreteFactoryB();
			f.Create().Show();


			List<Person> list = new List<Person>();
			Person p1 = new PersonBuilder().Build();
			Person p2 = new PersonBuilder().WithAge( 3 ).Build();
			Person p3 = new PersonBuilder().WithName("Sania").Build();
			Person p4 = new PersonBuilder().WithAge( 15 ).WithName("Rostik").Build();
			list.Add( p1 );
			list.Add( p2 );
			list.Add( p3 );
			list.Add( p4 );
			foreach( var item in list ) {
				Console.WriteLine(item.Name + " "+ item.Age );
			}


			Singleton s =  Singleton.GetInstance;
			Singleton s2 = Singleton.GetInstance;
			Console.WriteLine(s.Equals(s2).ToString());

			Beverage b1 = new Cofee( "Coffe" );
			Console.WriteLine( b1.Name + " "+ b1.GetCost());
			b1 = new Milk( b1 );
			Console.WriteLine( b1.Name + " " + b1.GetCost() );
			b1 = new Lemon( b1 );
			Console.WriteLine( b1.Name + " " + b1.GetCost() );
			Beverage b2 = new Tea( "Tea" );
			Console.WriteLine( b2.Name + " " + b2.GetCost() );
			b2 = new Lemon( b2 );
			Console.WriteLine( b2.Name + " " + b2.GetCost() );

			Car c = new Car( new PetrolEngine() );
			c.Move();
			c.Movable = new ElectricEngine();
			c.Move();

			NewWorker newWorker = new NewWorker();
			OldWorker oldWorker = new OldWorker();
			
			Worker worker = new Worker();
			worker.Work( newWorker );
			WorkerAdapter workerAdapter = new WorkerAdapter( oldWorker );
			worker.Work(workerAdapter);


			Adapter a = new Adapter( new One() );
		 
			Two t = new Two();
			Two t2 = t.Clone();
			Console.WriteLine( object.Equals( t,t2 ).ToString());

				//	Closure.Show();

			Console.Read();
		}
	}
}
