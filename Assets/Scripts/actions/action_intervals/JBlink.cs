using UnityEngine;

namespace JUnity.Actions
{
    public class JBlink : JFiniteTimeAction
    {
        public uint Times { get; private set; }


        #region Constructors

        public JBlink (float duration, uint numOfBlinks) : base (duration)
        {
            Times = numOfBlinks;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JBlinkState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JBlink (Duration, Times);
        }
    }

    public class JBlinkState : JFiniteTimeActionState
    {

        protected uint Times { get; set; }

        protected bool OriginalState { get; set; }

        public JBlinkState (JBlink action, GameObject target)
            : base (action, target)
        { 
            Times = action.Times;
			OriginalState = target.getVisible();
        }

        public override void Update (float time)
        {
            if (Target != null && !IsDone)
            {
                float slice = 1.0f / Times;
                // float m = fmodf(time, slice);
                float m = time % slice;
				Target.setVisible( m > (slice / 2));
            }
        }

        protected internal override void Stop ()
        {
			Target.setVisible(OriginalState);
            base.Stop ();
        }

    }
}