using System;
using System.Collections.Generic;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTParallel : JFiniteTimeAction
    {
        public JFiniteTimeAction[] Actions { get; private set; }

        #region Constructors

        public MTParallel (params JFiniteTimeAction[] actions) : base ()
        {
            // Can't call base(duration) because max action duration needs to be determined here
            float maxDuration = 0.0f;


            for (int i = 0; i < actions.Length; ++i) 
            {
                var action = actions[i];
                if (action.Duration > maxDuration)
                {
                    maxDuration = action.Duration;
                }
            }


            Duration = maxDuration;

            Actions = actions;

            for (int i = 0; i < Actions.Length; i++)
            {
                var actionDuration = Actions [i].Duration;
                if (actionDuration < Duration)
                {
                    Actions [i] = new MTSequence (Actions [i], new MTDelayTime (Duration - actionDuration));
                }
            }
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTParallelState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            JFiniteTimeAction[] rev = new JFiniteTimeAction[Actions.Length];
            for (int i = 0; i < Actions.Length; i++)
            {
                rev [i] = Actions [i].Reverse ();
            }

            return new MTParallel (rev);
        }

    }

    public class MTParallelState : JFiniteTimeActionState
    {

        protected JFiniteTimeAction[] Actions { get; set; }

        protected JFiniteTimeActionState[] ActionStates { get; set; }

        public MTParallelState (MTParallel action, GameObject target)
            : base (action, target)
        {   
            Actions = action.Actions;
            ActionStates = new JFiniteTimeActionState[Actions.Length];

            for (int i = 0; i < Actions.Length; i++)
            {
                ActionStates [i] = (JFiniteTimeActionState)Actions [i].StartAction (target);
            }
        }

        protected internal override void Stop ()
        {
            for (int i = 0; i < Actions.Length; i++)
            {
                ActionStates [i].Stop ();
            }
            base.Stop ();
        }

        public override void Update (float time)
        {
            for (int i = 0; i < Actions.Length; i++)
            {
                ActionStates [i].Update (time);
            }
        }
    }
}