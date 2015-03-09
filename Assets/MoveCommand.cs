using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace InputControl {
    internal class MoveCommand : PlayerInput {
        private DateTime time;
        private Vector3 location;

        public MoveCommand(Vector3 location) {
            this.time = new DateTime();
            this.location = location;
        }

        public void applyToPlayer(RTSMovement player) {
            player.setTarget(location);
        }

        public override string ToString() {
            return "Move command: " + location;
        }
    }
}