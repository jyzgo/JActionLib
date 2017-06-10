using System;
using UnityEngine; 


namespace JUnity.Actions
{
    public class MTEaseSineInOut : MTActionEase
    {
        #region Constructors

        public MTEaseSineInOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseSineInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseSineInOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseSineInOutState : MTActionEaseState
    {
        public MTEaseSineInOutState (MTEaseSineInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.SineInOut (time));
        }
    }

    #endregion Action state
}