using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseBackIn : JActionEase
    {
        #region Constructors

        public JEaseBackIn (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseBackInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseBackOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseBackInState : JActionEaseState
    {
        public JEaseBackInState (JEaseBackIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.BackIn (time));
        }
    }

    #endregion Action state
}