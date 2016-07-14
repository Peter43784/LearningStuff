using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinConsoleApp._3_MainDataTypes.Strings {
	class MyEnCoding {
		public static byte[] Encode(string s) {
			Encoding enUTF8 = Encoding.UTF8;
			byte[] encodedBytes = enUTF8.GetBytes( s );
			return encodedBytes;
		}
		public static string Decode( byte[] b ) {
			Encoding enUTF8 = Encoding.UTF8;
			string decStr = enUTF8.GetString( b );
			return decStr;
		}
	}
}
