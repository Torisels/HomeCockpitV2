using System;

namespace HomeCockpitV2
{
    class MomentarySwitchTwo : IInput<int>
    {
        private int _currentState = -1;
        private int _previousState = -1;

        private readonly byte _register;
        private readonly int _bit;

        public MomentarySwitchTwo(byte register, int bit)
        {
            _register = register;
            _bit = bit;
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
            _currentState = !Bit.IsBitSet(_register, _bit) ? 1 : 0;
        }

        public int GetDataForSim()
        {
            if (_currentState == _previousState) return -1;
            _previousState = _currentState;
            return _currentState;
        }
    }
}
