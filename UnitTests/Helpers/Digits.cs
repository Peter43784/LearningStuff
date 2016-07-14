using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
    static class Digits
    {
        public static Dictionary<int,List<string>> CorrespondingCollectioType { get; }
        private static readonly string firstLine = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo____o...oo..ooo.oooo____o...oo..ooo.oooo";
        private static readonly string secondLine = "o..o................____________________________________________________________";
        private static readonly string thirdLine = ".oo.........................................____________________________________";
        private static readonly string fourthLine = "................................................................________________";

        static Digits()
        {
            for (int i = 0, j = 0; i < firstLine.Length; i += 4, j++)
            {
                List<string> s = new List<string>();
                s.Add(firstLine.Substring(i,4));
                s.Add(secondLine.Substring(i, 4));
                s.Add(thirdLine.Substring(i, 4));
                s.Add(fourthLine.Substring(i, 4));

                CorrespondingCollectioType.Add(j, s);
            }
        }


    }
}
