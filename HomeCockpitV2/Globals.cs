using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCockpitV2
{
    public class Globals
    {
        public static BitRegisterPair[] PinToBitRegisterPairs;

        private static DataBase _db;

        public static void Initialize()
        {
            _db = new DataBase();
            PinToBitRegisterPairs = _db.GetBitRegisterPairs();
        }

    }
}
