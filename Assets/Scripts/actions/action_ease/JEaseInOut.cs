using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseInOut : JEaseRateAction
    {
        #region Constructors

        public JEaseInOut (JFiniteTimeAction action, float rate) : base (action, rate)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseInOut ((JFiniteTimeAction)InnerAction.Reverse (), Rate);
        }
    }


    #region Action state

    public class JEaseInOutState : JEaseRateActionState
    {
        public JEaseInOutState (JEaseInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            float actionRate = Rate;
            time *= 2;

            if (time < 1)
            {
                InnerActionState.Update (0.5f * (float)Math.Pow (time, actionRate));
            }
            else
            {
                InnerActionState.Update (1.0f - 0.5f * (float)Math.Pow (2 - time, actionRate));
            }        
        }
    }

    #endregion Action state
}