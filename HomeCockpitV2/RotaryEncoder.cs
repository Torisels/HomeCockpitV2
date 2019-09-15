using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCockpitV2
{
    class RotaryEncoder : IInput<int>
    {
        //db reference
        private string _name = "RotaryEncoder";

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
            tick(data);
        }

   
        public int GetDataForSim()
        {
            return getDelta();
        }

        public int getPos()
        {
            return _positionExt;
        }

        public void tick(byte[] registers)
        {
            var thisState = Bit.GetBitAsInt(registers[_register1], _bit1) | (Bit.GetBitAsInt(registers[_register2], _bit2) << 1);

            if (_oldState != thisState)
            {

                _position += _knobdir[thisState | (_oldState << 2)];


                if (thisState == LATCH_STATE)
                {
                    int _tempPos = _position >> 2;
                    //Console.WriteLine(_tempPos);
//                    if (_tempPos > _positionExt)
//                        //Form1.Connector.SendEvent((PMDG.PMDGEvents)_eventId, PMDG.MOUSE_FLAG_LEFTSINGLE);
//                    else if (_tempPos < _positionExt)
//                        //Form1.Connector.SendEvent((PMDG.PMDGEvents)_eventId, PMDG.MOUSE_FLAG_RIGHTSINGLE);
                    _positionExt = _tempPos;
                }
                _oldState = thisState;
            }
        }

        public int getDelta()
        {
            int ret = 0;

            if (_positionExtPrev > _positionExt)
            {
                ret = -1;
                _positionExtPrev = _positionExt;
            }
            else if (_positionExtPrev < _positionExt)
            {
                ret = 1;
                _positionExtPrev = _positionExt;
            }
            else
            {
                ret = 0;
                _positionExtPrev = _positionExt;
            }

            return ret;
        }
    }
}
