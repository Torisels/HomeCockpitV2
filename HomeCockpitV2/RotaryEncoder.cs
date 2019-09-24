using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCockpitV2
{
    class RotaryEncoder : IInput<int>
    {
        //key variables
        private int _oldState = 3;
        private int _position = 0;
        private int _positionExt = 0;
        private int _positionExtPrev = 0;
        
        //register_1 vars
        private int _register1;
        private int _bit1;
        private int _register2;
        private int _bit2;

        //constants for proper functioning
        private const int LATCH_STATE = 3;
        private readonly sbyte[] _knobdir ={
            0, -1,  1,  0,
            1,  0,  0, -1,
            -1,  0,  0,  1,
            0,  1, -1,  0  };

        public readonly int SimId;

        public RotaryEncoder(int simId, int register_1, int bit_1, int register2, int bit2)
        {
            SimId = simId;
            _register1 = register_1;
            _bit1 = bit_1;
            _register2 = register2;
            _bit2 = bit2;
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
            Tick(data);
        }

   
        public int GetDataForSim()
        {
            return GetDelta();
        }

        public int getPos()
        {
            return _positionExt;
        }

        private void Tick(byte[] inputData)
        {
            var thisState = Bit.GetBitAsInt(inputData[_register1], _bit1) | (Bit.GetBitAsInt(inputData[_register2], _bit2) << 1);

            if (_oldState != thisState)
            {

                _position += _knobdir[thisState | (_oldState << 2)];

                if (thisState == LATCH_STATE)
                {
                    _positionExt = _position >> 2;
                }
                _oldState = thisState;
            }
        }

        private int GetDelta()
        {
            int ret = 0;

            if (_positionExtPrev > _positionExt)
            {
                ret = -1;
            }
            else if (_positionExtPrev < _positionExt)
            {
                ret = 1;
            }
            _positionExtPrev = _positionExt;
            return ret;
        }
    }
}
