using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseBackOut : MTActionEase
    {
        #region Constructors

        public MTEaseBackOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseBackOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseBackIn ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTEaseBackOutState : MTActionEaseState
    {
        public MTEaseBackOutState (MTEaseBackOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.BackOut (time));
        }
    }

    #endregion Action state
}