using UnityEngine;

namespace JUnity.Actions
{
    public class MTActionInstant : JFiniteTimeAction
    {

        #region Constructors

        protected MTActionInstant ()
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTActionInstantState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTActionInstant ();
        }
    }

    public class MTActionInstantState : JFiniteTimeActionState
    {

        public MTActionInstantState (MTActionInstant action, GameObject target)
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