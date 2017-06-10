using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseBounceIn : MTActionEase
    {
        #region Constructors

        public MTEaseBounceIn (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseBounceInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseBounceOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseBounceInState : MTActionEaseState
    {
        public MTEaseBounceInState (MTEaseBounceIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.BounceIn (time));
        }
    }

    #endregion Action state
}