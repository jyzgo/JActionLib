using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseBounceInOut : MTActionEase
    {
        #region Constructors

        public MTEaseBounceInOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseBounceInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseBounceInOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseBounceInOutState : MTActionEaseState
    {
        public MTEaseBounceInOutState (MTEaseBounceInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.BounceInOut (time));
        }
    }

    #endregion Action state
}