using UnityEngine;

namespace JUnity.Actions
{
    public class MTActionEase : JFiniteTimeAction
    {
        protected internal JFiniteTimeAction InnerAction { get; private set; }


        #region Constructors

        public MTActionEase(JFiniteTimeAction action) : base (action.Duration)
        {
            InnerAction = action;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTActionEaseState (this, target);
        }

        public override JFiniteTimeAction Reverse()
        {
            return new MTActionEase ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class MTActionEaseState : JFiniteTimeActionState
    {
        protected JFiniteTimeActionState InnerActionState { get; private set; }

        public MTActionEaseState (MTActionEase action, GameObject target) : base (action, target)
        {
            InnerActionState = (JFiniteTimeActionState)action.InnerAction.StartAction (target);
        }

        protected internal override void Stop ()
        {
            InnerActionState.Stop ();
            base.Stop ();
        }

        public override void Update (float time)
        {
            InnerActionState.Update (time);
        }
    }

    #endregion Action state
}