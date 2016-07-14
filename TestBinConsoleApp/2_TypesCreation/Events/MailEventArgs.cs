using System;

namespace TestBinConsoleApp.TypesCreation.Events {
	//Step 1 proect type for storing additional information
	//derived from EventArgs
	class MailEventArgs : EventArgs{
		private readonly string m_to, m_from, m_subject;

		public MailEventArgs(string to, string from, string subject) {
			m_to = to; m_from = from; m_subject = subject;
		}

		public string To { get { return m_to; } }
		public string From { get { return m_from; } }
		public string Subject { get { return m_subject; } }


	}
}
