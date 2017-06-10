using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseBounceOut : MTActionEase
    {
        #region Constructors

        public MTEaseBounceOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseBounceOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseBounceIn ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseBounceOutState : MTActionEaseState
    {
        public MTEaseBounceOutState (MTEaseBounceOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.BounceOut (time));
        }
    }

    #endregion Action state
}