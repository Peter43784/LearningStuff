using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinConsoleApp.TypesCreation.Generics {
	public interface IInvariance<T> { }
	interface ICovariance<out T> { }

	interface IContrvariance<in T> {
	}
	class InVariance<T> : IInvariance<T> where T : class {
		public static void Swap<T>(ref T o1, ref T o2) {
			T temp = o1;
			o1 = o2;
			o2 = temp;
		}
	}

	class Covariance< T> : ICovariance<T> {
		// will not compile without constraints(T:class)
		//T temp = null;
		T temp = default(T);
	}

	class Contrvariance<T> : IContrvariance<T> where T: class, new() {

		public Contrvariance() {
				
		}

	}
}
