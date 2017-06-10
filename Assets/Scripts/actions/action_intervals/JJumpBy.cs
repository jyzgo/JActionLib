using UnityEngine;

namespace JUnity.Actions
{
    public class JJumpBy : JFiniteTimeAction
    {   
        #region Properties

        public uint Jumps { get; protected set; }
        public float Height { get; protected set; }
        public Vector3 Position { get; protected set; }

        #endregion Properties


        #region Constructors

        public JJumpBy (float duration, Vector3 position, float height, uint jumps) : base (duration)
        {
            Position = position;
            Height = height;
            Jumps = jumps;
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JJumpByState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JJumpBy (Duration, new Vector3 (-Position.x, -Position.y,-Position.z), Height, Jumps);
        }
    }

    public class JJumpByState : JFiniteTimeActionState
    {
        protected Vector3 Delta;
        protected float Height;
        protected uint Jumps;
        protected Vector3 StartPosition;
        protected Vector3 P;

        public JJumpByState (JJumpBy action, GameObject target)
            : base (action, target)
        { 
			Delta = action.Position;
            Height = action.Height;
            Jumps = action.Jumps;
			P = StartPosition = target.transform.localPosition;
        }

        public override void Update (float time)
        {
            if (Target != null)
            {
                // Is % equal to fmodf()???
                float frac = (time * Jumps) % 1f;
                float y = Height * 4f * frac * (1f - frac);
                y += Delta.y * time;
                float x = Delta.x * time;

				float z = Delta.z * time;


				Vector3 currentPos = Target.transform.localPosition;

                Vector3 diff = currentPos - P;
                StartPosition = diff + StartPosition;


				Vector3 newPos = StartPosition + new Vector3 (x, y,z);
				Target.transform.localPosition = newPos;

                P = newPos;
            }
        }
    }

}