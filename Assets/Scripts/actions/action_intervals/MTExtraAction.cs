using System;
//using System.Diagnostics;

using UnityEngine;

namespace JUnity.Actions
{
    // Extra action for making a MTSequence or MTSpawn when only adding one action to it.
    internal class MTExtraAction : JFiniteTimeAction
    {
        public override JFiniteTimeAction Reverse ()
        {
            return new MTExtraAction ();
        }

        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTExtraActionState (this, target);

        }

        #region Action State

        public class MTExtraActionState : JFiniteTimeActionState
        {

            public MTExtraActionState (MTExtraAction action, GameObject target)
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