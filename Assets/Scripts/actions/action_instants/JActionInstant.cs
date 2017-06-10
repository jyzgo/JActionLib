using UnityEngine;

namespace JUnity.Actions
{
    public class JActionInstant : JFiniteTimeAction
    {

        #region Constructors

        protected JActionInstant ()
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JActionInstantState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JActionInstant ();
        }
    }

    public class JActionInstantState : JFiniteTimeActionState
    {

        public JActionInstantState (JActionInstant action, GameObject target)
            : base (action, target)
        {
        }

        public override bool IsDone 
        {
            get { return true; }
        }

        protected internal override void Step (float dt)
        {
            Update (1);
        }

        public override void Update (float time)
        {
            // ignore
        }
    }

}