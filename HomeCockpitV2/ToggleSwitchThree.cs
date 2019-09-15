using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace HomeCockpitV2
{
    class ToggleSwitchThree : IInput<int>
    {
        public readonly int _id;

        private byte _regA;
        private int _bitA;

        private readonly byte _regB;
        private int _bitB;

        private readonly int[] positionArray = new[] {-2, -1, 0, 1};

        private int _position;
        private int _lastPosition = -2;
        public ToggleSwitchThree(int id, byte regA, int bitA, byte regB, int bitB)
        {
            this._id = id;
            _regA = regA;
            _bitA = bitA;
            _regB = regB;
            _bitB = bitB;
        }


        public void Setup()
        {
            throw new NotImplementedException();
        }

        public void ChangeSettings()
        {
            throw new NotImplementedException();
        }

        public void HandleInput(ref byte[] data)
        {
            _position = Bit.GetBitAsInt(data[_regA], _bitA) | (Bit.GetBitAsInt(data[_regB], _bitB) << 1);
        }

        public int GetDataForSim()
        {
            if (_lastPosition == _position) return -2;
            _lastPosition = _position;
            return positionArray[_position];
        }
    }
}
