using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinConsoleApp.TypesCreation.Interfaces {
	class Parent : IMyInterface {
		public void Show() {
			Console.WriteLine(	"Parent" );
		}
	}
	class Child : Parent, IMyInterface {

		public new void Show() {
			Console.WriteLine( "Child" );
		}

	}

	class SimpleType : IMyInterface {
		void IMyInterface.Show() {
			Console.WriteLine( "Simple type" );
		}
		 
	}
}
