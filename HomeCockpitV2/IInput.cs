using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCockpitV2
{
    internal interface IInput<T>
    {
        void Setup();
        void ChangeSettings();
        void HandleInput(ref byte[] data);
        T GetDataForSim();
    }
}
