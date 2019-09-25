using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCockpitV2
{
   public class Bit
    {
        public static bool IsBitSet(int b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

        public static int GetBitAsInt(byte b, int bitNumber)
        {
            return Convert.ToInt32(IsBitSet(b, bitNumber));
        }
    }
}
