using System;
//using System.Diagnostics;

using UnityEngine;

namespace JUnity.Actions
{
    // Extra action for making a JSequence or JSpawn when only adding one action to it.
    internal class JExtraAction : JFiniteTimeAction
    {
        public override JFiniteTimeAction Reverse ()
        {
            return new JExtraAction ();
        }

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JExtraActionState (this, target);

        }

        #region Action State

        public class JExtraActionState : JFiniteTimeActionState
        {

            public JExtraActionState (JExtraAction action, GameObject target)
                : base (action, target)
            {
            }

            protected internal override void Step (float dt)
            {
            }

            public override void Update (float time)
            {
            }
        }

        #endregion Action State
    }
}