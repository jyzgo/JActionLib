using UnityEngine;

namespace JUnity.Actions
{
    public class JTargetedAction : JFiniteTimeAction
    {
        public JFiniteTimeAction TargetedAction { get; private set; }
        public GameObject ForcedTarget { get; private set; }


        #region Constructors

        public JTargetedAction (GameObject target, JFiniteTimeAction action) : base (action.Duration)
        {
            ForcedTarget = target;
            TargetedAction = action;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JTargetedActionState (this, target);
        }

        public override JFiniteTimeAction Reverse()
        {
            return new JTargetedAction (ForcedTarget, TargetedAction.Reverse ());
        }
    }

    public class JTargetedActionState : JFiniteTimeActionState
    {
        protected JFiniteTimeAction TargetedAction { get; set; }

        protected JFiniteTimeActionState ActionState { get; set; }

        protected GameObject ForcedTarget { get; set; }

        public JTargetedActionState (JTargetedAction action, GameObject target)
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