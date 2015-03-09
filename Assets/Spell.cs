using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UnityEngine;

namespace InputControl
{
    interface TargetableSpell {
        void setTarget(Vector3 target);
    }
}
