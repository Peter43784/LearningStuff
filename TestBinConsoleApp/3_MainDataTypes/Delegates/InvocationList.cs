using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinConsoleApp._3_MainDataTypes.Delegates {
	public delegate String GetStatus();

	internal sealed  class InvocationListTest {

		private static string GetComponentStatusReport(GetStatus status) {
			if (status == null) return null;
			StringBuilder report = new StringBuilder();
			Delegate[] arrayOfDelegates = status.GetInvocationList();
			foreach( GetStatus getStatus  in arrayOfDelegates ) {
				try {
					report.AppendFormat( $"{getStatus()}{Environment.NewLine}" );
				} 
				catch( InvalidOperationException e ) {
					object component = getStatus.Target;
					report.AppendFormat(
						$"Failed to get status from {( component?.GetType().ToString() ?? "" )+"."}" +
						$"{getStatus.Method.Name}{Environment.NewLine} " +
						$"Error: {e.Message}{Environment.NewLine}"
						);

				}
			}
			return report.ToString();
		}
		public  static void ShowComponentStatusReport() {
			GetStatus getStatus = null;
			getStatus += new Light().SwitchPosition;
			getStatus += new Fan().Speed;
			getStatus += new Speeker().Volume;
			Console.WriteLine( GetComponentStatusReport( getStatus ) );	
		}
	}
	internal sealed class Light { 
		public string SwitchPosition() {
			return "The light is off";
		}
	}
	internal sealed class Fan {
		public string Speed() {
			throw new InvalidOperationException("The fan is broken");
		}
	}
	internal sealed class Speeker {
		public string Volume() {
			return "the volume is loud";
		}
	}
	
}
