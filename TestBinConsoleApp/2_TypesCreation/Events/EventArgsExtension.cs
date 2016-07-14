

using System;
using System.Threading;

namespace TestBinConsoleApp.TypesCreation.Events {
	public static class EventArgsExtension {
		public static void Raise<TEventArgs>(this TEventArgs e, object sender, ref  EventHandler<TEventArgs> eventDelegate ) {
			Volatile.Read( ref eventDelegate )?.Invoke( sender, e );

		}
	}
}
