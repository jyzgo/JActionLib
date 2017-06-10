using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseBackOut : JActionEase
    {
        #region Constructors

        public JEaseBackOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseBackOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseBackIn ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseBackOutState : JActionEaseState
    {
        public JEaseBackOutState (JEaseBackOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.BackOut (time));
        }
    }

    #endregion Action state
}