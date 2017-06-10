using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseSineOut : MTActionEase
    {
        #region Constructors

        public MTEaseSineOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseSineOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseSineIn ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseSineOutState : MTActionEaseState
    {
        public MTEaseSineOutState (MTEaseSineOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.SineOut (time));
        }
    }

    #endregion Action state
}