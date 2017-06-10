//using System.Diagnostics;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTRepeatForever : JFiniteTimeAction
    {
        public JFiniteTimeAction InnerAction { get; private set; }


        #region Constructors

        public MTRepeatForever (params JFiniteTimeAction[] actions)
        {
            Debug.Assert (actions != null);
            InnerAction = new MTSequence (actions);

        }

        public MTRepeatForever (JFiniteTimeAction action)
        {
            Debug.Assert (action != null);
            InnerAction = action;
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTRepeatForeverState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTRepeatForever (InnerAction.Reverse () as JFiniteTimeAction);
        }
    }

    public class MTRepeatForeverState : JFiniteTimeActionState
    {

        private JFiniteTimeAction InnerAction { get; set; }

        private JFiniteTimeActionState InnerActionState { get; set; }

        public MTRepeatForeverState (MTRepeatForever action, GameObject target)
            : base (action, target)
        { 
            InnerAction = action.InnerAction;
            InnerActionState = (JFiniteTimeActionState)InnerAction.StartAction (target);
        }

        protected internal override void Step (float dt)
        {
            InnerActionState.Step (dt);

            if (InnerActionState.IsDone)
            {
                float diff = InnerActionState.Elapsed - InnerActionState.Duration;
                InnerActionState = (JFiniteTimeActionState)InnerAction.StartAction (Target);
                InnerActionState.Step (0f);
                InnerActionState.Step (diff);
            }
        }

        public override bool IsDone {
            get { return false; }
        }

    }
}