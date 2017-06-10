using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseExponentialOut : MTActionEase
    {
        #region Constructors

        public MTEaseExponentialOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseExponentialOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseExponentialIn ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseExponentialOutState : MTActionEaseState
    {
        public MTEaseExponentialOutState (MTEaseExponentialOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.ExpoOut (time));
        }
    }

    #endregion Action state
}