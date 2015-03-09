using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InputControl {
    internal interface PlayerInput {
        void applyToPlayer(RTSMovement player);
    }
}