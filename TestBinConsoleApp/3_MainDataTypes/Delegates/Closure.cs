using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinConsoleApp._3_MainDataTypes.Delegates {
	delegate void SomeMethod();
	class Closure {
		public static void Show() { 
		List<SomeMethod> delList = new List<SomeMethod>();
		for( int i = 0; i< 10; i++ ) {
			delList.Add( delegate { Console.WriteLine( i ); } );
		    //delList.Add( () => Console.WriteLine( i ) );
			}

		foreach( var del in delList ) {
			del();
		}
		}
	}
}
