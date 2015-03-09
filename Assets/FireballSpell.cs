using UnityEngine;

namespace InputControl {
    class FireballSpell {
        private Vector3 target;

        public void applyToPlayer(RTSMovement player) {
        }

        public void setTarget(Vector3 target) {
            this.target = target;
        }
    }
}