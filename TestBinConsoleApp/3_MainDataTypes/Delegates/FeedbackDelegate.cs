using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestBinConsoleApp._3_MainDataTypes.Delegates {
	delegate void Feedback( int value);
	class FeedbackDelegate {
		private static void Counter( int from, int to, Feedback fb ) {
			for( int i = from; i < to; i++ ) {
				fb?.Invoke( i );
			}
		}
		#region outputMethods
		private static void FeedbackToConsole( int value ) {
			Console.WriteLine( "Console: " + value );
		}
		private static void FeedbackToMsgBox(int value ){
			Console.WriteLine( "MessageBox: " + value );
			}
		private void FeedbackToFile(int value ) {
			using( StreamWriter sw = new StreamWriter( "Status",true ) ) {
				sw.WriteLine(value);
			}
		}
     #endregion
		public static void StaticDelegateDemo() {
			Console.WriteLine( "---------------Static Delegate Demo--------------------" );
			Counter( 1,3,null );
			Counter( 1, 3, new Feedback( FeedbackToMsgBox ) );
			Counter( 1,3, FeedbackToConsole );
		
		}
		public static void InstanceDelegateDemo() {
			Console.WriteLine( "---------------Instance Delegate Demo--------------------" );
			FeedbackDelegate f = new FeedbackDelegate();
			Counter( 1, 3, new Feedback( f.FeedbackToFile ) );
			Console.WriteLine(  );
		}
		public static void ChainDelegateDemo1(FeedbackDelegate f) {
			Console.WriteLine( "---------------Chain Delegate Demo 1	--------------------" );
			Feedback fb1 = new Feedback(FeedbackToConsole);
			Feedback fb2 = FeedbackToMsgBox;
			Feedback fb3 = f.FeedbackToFile;

			Feedback fbChain = null;
			fbChain = (Feedback)Delegate.Combine( fbChain, fb1 );
			fbChain += fb2;
			fbChain += fb3;
			Counter( 1,2,fbChain );

			Console.WriteLine(  );
			fbChain = (Feedback)Delegate.Remove( fbChain, new Feedback( FeedbackToConsole ) );
			fbChain -= fb2;
			Counter( 1,2,fbChain );

		}
	}
}
