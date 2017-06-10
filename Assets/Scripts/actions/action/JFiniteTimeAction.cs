using System;
using UnityEngine;

namespace JUnity.Actions
{
    public abstract class JFiniteTimeAction : JAction
    {
        float duration;

        #region Properties

        public virtual float Duration 
        {
            get 
            {
                return duration;
            }
            set 
            {
                float newDuration = value;

                // Prevent division by 0
                if (newDuration == 0)
                {
                    newDuration = float.Epsilon;
                }

                duration = newDuration;
            }
        }

        #endregion Properties


        #region Constructors

        protected JFiniteTimeAction() 
            : this (0)
        {
        }

        protected JFiniteTimeAction (float duration)
        {
            Duration = duration;
        }

        #endregion Constructors


        public abstract JFiniteTimeAction Reverse();

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JFiniteTimeActionState (this, target);
        }
    }

    public class JFiniteTimeActionState : JActionState
    {
        bool firstTick;

        #region Properties

        public virtual float Duration { get; set; }
        public float Elapsed { get; private set; }

        public override bool IsDone 
        {
            get { return Elapsed >= Duration; }
        }

        #endregion Properties


        public JFiniteTimeActionState (JFiniteTimeAction action, GameObject target)
            : base (action, target)
        { 
            Duration = action.Duration;
            Elapsed = 0.0f;
            firstTick = true;
        }

        protected internal override void Step(float dt)
        {
            if (firstTick)
            {
                firstTick = false;
                Elapsed = 0f;
            }
            else
            {
                Elapsed += dt;
            }

            Update (Math.Max (0f,
                Math.Min (1, Elapsed / Math.Max (Duration, float.Epsilon)
                )
            )
            );
        }

    }
}