using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCockpitV2
{
    class Board
    {
        public List<RotaryEncoder> RotaryEncoders = new List<RotaryEncoder>();
        public List<RotarySwitch> RotarySwitches = new List<RotarySwitch>();
        public List<ToggleSwitchThree> ToggleSwitchThrees = new List<ToggleSwitchThree>();
        public List<MomentarySwitchTwo> MomentarySwitches= new List<MomentarySwitchTwo>();

    }
}
