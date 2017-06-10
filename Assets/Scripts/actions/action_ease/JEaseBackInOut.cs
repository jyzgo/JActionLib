using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseBackInOut : JActionEase
    {
        #region Constructors

        public JEaseBackInOut(JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseBackInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse()
        {
            return new JEaseBackInOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseBackInOutState : JActionEaseState
    {
        public JEaseBackInOutState (JEaseBackInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.BackInOut (time));
        }
    }

    #endregion Action state
}