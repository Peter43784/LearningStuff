using System;
using System.Threading;

namespace TestBinConsoleApp.TypesCreation.Events {
	class MailManager {
		//Step 2 member definition
		public event EventHandler<MailEventArgs> NewMail;
		//TODO investigate this
		public delegate void MailDelegate();
		//Step 3 member responsible for notification
		protected virtual void OnNewMail(MailEventArgs e ) {
			e.Raise( this, ref NewMail);
			//The same is here:
			//Volatile.Read( ref NewMail )?.Invoke( this, e );
		}

		//Step 4 Method which transform inpeut information into an event
		public void MailReceived(string from, string to, string subject ) {
			MailEventArgs e = new MailEventArgs( to,from,subject );
			OnNewMail( e );
		}
	}
}
