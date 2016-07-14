using System;

namespace TestBinConsoleApp.TypesCreation.Events {
	sealed class Fax {

		public Fax(MailManager mm) {
			mm.NewMail += FaxMessage;
			
		}

		private void FaxMessage(object sender, MailEventArgs e ) {
			Console.WriteLine( "Faxing:" );
			Console.WriteLine(e.To +" "+e.From+" "+e.Subject );
		}

		public void Unsubscribe(MailManager mm) {
			mm.NewMail -= FaxMessage;
			
		    
		}
	}
}
