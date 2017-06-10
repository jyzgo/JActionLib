using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseBackIn : MTActionEase
    {
        #region Constructors

        public MTEaseBackIn (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseBackInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseBackOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseBackInState : MTActionEaseState
    {
        public MTEaseBackInState (MTEaseBackIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.BackIn (time));
        }
    }

    #endregion Action state
}