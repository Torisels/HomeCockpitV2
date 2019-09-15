using System;
using System.Collections.Generic;

namespace HomeCockpitV2
{
    class RotarySwitch : IInput<int>
    {
        public readonly int ElementId;

        private readonly Dictionary<byte, int> _registerDictionary;
        //private readonly int _positions;
        private int _lastPos = -1;
        private int _currentPos = -1;
        public RotarySwitch(Dictionary<byte, int> registerDictionary, int elementId)
        {
            _registerDictionary = registerDictionary;
            ElementId = elementId;
            // _positions = registerDictionary.Count;
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
            ushort counter = 0;
            foreach (var pair in _registerDictionary)
            {
                if (!Bit.IsBitSet(pair.Key, pair.Value))
                {
                    _currentPos = counter;
                }

                counter++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns -11 if position was not changed or current position in case everything went fine.</returns>
        public int GetDataForSim()
        {
            if (_currentPos == _lastPos) return -11;
            _lastPos = _currentPos;
            return _currentPos;
        }
    }
}
