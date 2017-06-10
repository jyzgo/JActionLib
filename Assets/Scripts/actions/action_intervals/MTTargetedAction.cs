using UnityEngine;

namespace JUnity.Actions
{
    public class MTTargetedAction : JFiniteTimeAction
    {
        public JFiniteTimeAction TargetedAction { get; private set; }
        public GameObject ForcedTarget { get; private set; }


        #region Constructors

        public MTTargetedAction (GameObject target, JFiniteTimeAction action) : base (action.Duration)
        {
            ForcedTarget = target;
            TargetedAction = action;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTTargetedActionState (this, target);
        }

        public override JFiniteTimeAction Reverse()
        {
            return new MTTargetedAction (ForcedTarget, TargetedAction.Reverse ());
        }
    }

    public class MTTargetedActionState : JFiniteTimeActionState
    {
        protected JFiniteTimeAction TargetedAction { get; set; }

        protected JFiniteTimeActionState ActionState { get; set; }

        protected GameObject ForcedTarget { get; set; }

        public MTTargetedActionState (MTTargetedAction action, GameObject target)
            : base (action, target)
        {   
            ForcedTarget = action.ForcedTarget;
            TargetedAction = action.TargetedAction;

            ActionState = (JFiniteTimeActionState)TargetedAction.StartAction (ForcedTarget);
        }

        protected internal override void Stop ()
        {
            ActionState.Stop ();
        }

        public override void Update (float time)
        {
            ActionState.Update (time);
        }


    }

}