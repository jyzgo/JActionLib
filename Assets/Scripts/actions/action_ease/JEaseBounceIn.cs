using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseBounceIn : JActionEase
    {
        #region Constructors

        public JEaseBounceIn (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseBounceInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseBounceOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseBounceInState : JActionEaseState
    {
        public JEaseBounceInState (JEaseBounceIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.BounceIn (time));
        }
    }

    #endregion Action state
}