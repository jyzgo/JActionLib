using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseExponentialInOut : MTActionEase
    {
        #region Constructors

        public MTEaseExponentialInOut (JFiniteTimeAction action) : base(action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseExponentialInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseExponentialInOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseExponentialInOutState : MTActionEaseState
    {
        public MTEaseExponentialInOutState (MTEaseExponentialInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.ExpoInOut (time));
        }
    }

    #endregion Action state
}