using System;
using UnityEngine; 


namespace JUnity.Actions
{
    public class JEaseSineInOut : JActionEase
    {
        #region Constructors

        public JEaseSineInOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseSineInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseSineInOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseSineInOutState : JActionEaseState
    {
        public JEaseSineInOutState (JEaseSineInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.SineInOut (time));
        }
    }

    #endregion Action state
}