//using System.Diagnostics;

using UnityEngine;

namespace JUnity.Actions
{
    public class JRepeatForever : JFiniteTimeAction
    {
        public JFiniteTimeAction InnerAction { get; private set; }


        #region Constructors

        public JRepeatForever (params JFiniteTimeAction[] actions)
        {
            Debug.Assert (actions != null);
            InnerAction = new JSequence (actions);

        }

        public JRepeatForever (JFiniteTimeAction action)
        {
            Debug.Assert (action != null);
            InnerAction = action;
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JRepeatForeverState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JRepeatForever (InnerAction.Reverse () as JFiniteTimeAction);
        }
    }

    public class JRepeatForeverState : JFiniteTimeActionState
    {

        private JFiniteTimeAction InnerAction { get; set; }

        private JFiniteTimeActionState InnerActionState { get; set; }

        public JRepeatForeverState (JRepeatForever action, GameObject target)
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