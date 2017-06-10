using System;
//using System.Diagnostics;

using UnityEngine;

namespace JUnity.Actions
{
    public class JSpawn : JFiniteTimeAction
    {
        public JFiniteTimeAction ActionOne { get; protected set; }
        public JFiniteTimeAction ActionTwo { get; protected set; }


        #region Constructors

        protected JSpawn (JFiniteTimeAction action1, JFiniteTimeAction action2)
            : base (Math.Max (action1.Duration, action2.Duration))
        {
            InitJSpawn (action1, action2);
        }

        public JSpawn (params JFiniteTimeAction[] actions)
        {
            JFiniteTimeAction prev = actions [0];
            JFiniteTimeAction next = null;

            if (actions.Length == 1)
            {
                next = new JExtraAction ();
            }
            else
            {
                // We create a nested set of JSpawnActions out of all of the actions
                for (int i = 1; i < actions.Length - 1; i++)
                {
                    prev = new JSpawn (prev, actions [i]);
                }

                next = actions [actions.Length - 1];
            }

            // Can't call base(duration) because we need to determine max duration
            // Instead call base's init method here
            if (prev != null && next != null)
            {
                Duration = Math.Max (prev.Duration, next.Duration);
                InitJSpawn (prev, next);
            }
        }

        private void InitJSpawn (JFiniteTimeAction action1, JFiniteTimeAction action2)
        {
            Debug.Assert (action1 != null);
            Debug.Assert (action2 != null);

            float d1 = action1.Duration;
            float d2 = action2.Duration;

            ActionOne = action1;
            ActionTwo = action2;

            if (d1 > d2)
            {
                ActionTwo = new JSequence (action2, new JDelayTime (d1 - d2));
            }
            else if (d1 < d2)
            {
                ActionOne = new JSequence (action1, new JDelayTime (d2 - d1));
            }
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JSpawnState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JSpawn (ActionOne.Reverse (), ActionTwo.Reverse ());
        }
    }

    public class JSpawnState : JFiniteTimeActionState
    {

        protected JFiniteTimeAction ActionOne { get; set; }

        private JFiniteTimeActionState ActionStateOne { get; set; }

        protected JFiniteTimeAction ActionTwo { get; set; }

        private JFiniteTimeActionState ActionStateTwo { get; set; }

        public JSpawnState (JSpawn action, GameObject target)
            : base (action, target)
        { 
            ActionOne = action.ActionOne;
            ActionTwo = action.ActionTwo;

            ActionStateOne = (JFiniteTimeActionState)ActionOne.StartAction (target);
            ActionStateTwo = (JFiniteTimeActionState)ActionTwo.StartAction (target);
        }

        protected internal override void Stop ()
        {
            ActionStateOne.Stop ();
            ActionStateTwo.Stop ();

            base.Stop ();
        }

        public override void Update (float time)
        {
            if (ActionOne != null)
            {
                ActionStateOne.Update (time);
            }

            if (ActionTwo != null)
            {
                ActionStateTwo.Update (time);
            }
        }

    }

}
