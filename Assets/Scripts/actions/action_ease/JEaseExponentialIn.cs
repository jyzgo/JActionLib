using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseExponentialIn : MTActionEase
    {
        #region Constructors

        public MTEaseExponentialIn (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseExponentialInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseExponentialOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseExponentialInState : MTActionEaseState
    {
        public MTEaseExponentialInState (MTEaseExponentialIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.ExpoIn (time));
        }
    }

    #endregion Action state
}