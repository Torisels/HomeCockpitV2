using System;
using System.Linq;

namespace HomeCockpitV2
{
    class MomentarySwitchTwo : IInput<int>
    {
        public readonly int ElementId;



        private int _currentState = -1;
        private int _previousState = -1;

        private readonly int _register;
        private readonly int _bit;

        public MomentarySwitchTwo(int pin, int elementId)
        {
            _register = Globals.PinToBitRegisterPairs[pin].Register;
            _bit = Globals.PinToBitRegisterPairs[pin].Bit;
            ElementId = elementId;
        }

        public void Setup()
        {
            throw new NotImplementedException();
        }

        public void ChangeSettings()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns nothing
        /// </summary>
        /// <param name="data">Main data buffer</param>
        public void HandleInput(ref byte[] data)
        {
            _currentState = !Bit.IsBitSet(_register, _bit) ? 1 : 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns -1 on no change. Otherwise 0 or 1 respectively for input pull-up pins</returns>
        public int GetDataForSim()
        {
            if (_currentState == _previousState) return -1;
            _previousState = _currentState;
            return _currentState;
        }
    }
}
