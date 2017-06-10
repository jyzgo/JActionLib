using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseBackInOut : MTActionEase
    {
        #region Constructors

        public MTEaseBackInOut(JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseBackInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse()
        {
            return new MTEaseBackInOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseBackInOutState : MTActionEaseState
    {
        public MTEaseBackInOutState (MTEaseBackInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.BackInOut (time));
        }
    }

    #endregion Action state
}