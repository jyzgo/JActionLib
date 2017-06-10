using UnityEngine;

namespace JUnity.Actions
{
    public class JSpeed : JAction
    {
        public float Speed { get; private set; }

        protected internal JFiniteTimeAction InnerAction { get; private set; }


        #region Constructors

        public JSpeed (JFiniteTimeAction action, float speed)
        {
            InnerAction = action;
            Speed = speed;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JSpeedState (this, target);
        }

        public virtual JFiniteTimeAction Reverse ()
        {
            return (JFiniteTimeAction)(JAction)new JSpeed ((JFiniteTimeAction)InnerAction.Reverse(), Speed);
        }
    }


    #region Action state

    internal class JSpeedState : JActionState
    {
        #region Properties

        public float Speed { get; private set; }

        protected JFiniteTimeActionState InnerActionState { get; private set; }

        public override bool IsDone 
        {
            get { return InnerActionState.IsDone; }
        }

        #endregion Properties


        public JSpeedState (JSpeed action, GameObject target) : base (action, target)
        {
            InnerActionState = (JFiniteTimeActionState)action.InnerAction.StartAction (target);
            Speed = action.Speed;
        }

        protected internal override void Stop ()
        {
            InnerActionState.Stop ();
            base.Stop ();
        }

        protected internal override void Step (float dt)
        {
            InnerActionState.Step (dt * Speed);
        }
    }

    #endregion Action state
}