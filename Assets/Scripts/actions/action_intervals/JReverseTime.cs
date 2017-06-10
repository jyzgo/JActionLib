//using System.Diagnostics;

using UnityEngine;

namespace JUnity.Actions
{
    public class JReverseTime : JFiniteTimeAction
    {
        public JFiniteTimeAction Other { get; private set; }


        #region Constructors

        public JReverseTime (JFiniteTimeAction action) : base (action.Duration)
        {
            Other = action;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JReverseTimeState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return Other;
        }
    }

    public class JReverseTimeState : JFiniteTimeActionState
    {

        protected JFiniteTimeAction Other { get; set; }

        protected JFiniteTimeActionState OtherState { get; set; }

        public JReverseTimeState (JReverseTime action, GameObject target)
            : base (action, target)
        {   
            Other = action.Other;
            OtherState = (JFiniteTimeActionState)Other.StartAction (target);
        }

        protected internal override void Stop ()
        {
            OtherState.Stop ();
        }

        public override void Update (float time)
        {
            if (Other != null)
            {
                OtherState.Update (1 - time);
            }
        }

    }

}