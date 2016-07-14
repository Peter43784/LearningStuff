using System;


namespace TestBinConsoleApp.TypesCreation.Events {
	sealed class SMS {
		public void Subscribe(MailManager mm ) {
			mm.NewMail += SmsMessage;
		}
		private void SmsMessage(object sender, MailEventArgs e) {
			Console.WriteLine( "SMS:" );
			Console.WriteLine( e.To + " " + e.From + " " + e.Subject );
		}
		public void UnSubscribe( MailManager mm ) {
			mm.NewMail -= SmsMessage;
		}


	}
}
