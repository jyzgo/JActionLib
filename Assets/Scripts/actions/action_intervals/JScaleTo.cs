using UnityEngine;

namespace JUnity.Actions
{
    public class JScaleTo : JFiniteTimeAction
    {
        public float EndScaleX { get; private set; }
        public float EndScaleY { get; private set; }
		public float EndScaleZ { get; private set; }


        #region Constructors

		public JScaleTo (float duration, float scale) : this (duration, scale, scale,scale)
        {
		}

		public JScaleTo (float duration, Vector3 scale) : this (duration, scale.x, scale.y, scale.z)
		{
		}

		public JScaleTo (float duration, float scaleX, float scaleY,float scaleZ) : base (duration)
        {
            EndScaleX = scaleX;
            EndScaleY = scaleY;
			EndScaleZ = scaleZ;
        }

        #endregion Constructors

        public override JFiniteTimeAction Reverse()
        {
            throw new System.NotImplementedException ();
        }

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JScaleToState (this, target);
        }
    }

    public class JScaleToState : JFiniteTimeActionState
    {
        protected float DeltaX;
        protected float DeltaY;
		protected float DeltaZ;

        protected float EndScaleX;
        protected float EndScaleY;
		protected float EndScaleZ;

        protected float StartScaleX;
        protected float StartScaleY;
		protected float StartScaleZ;

        public JScaleToState (JScaleTo action, GameObject target)
            : base (action, target)
        { 
			if(target == null)
			{
				return;
			}
			StartScaleX = target.transform.localScale.x;
			StartScaleY = target.transform.localScale.y;
			StartScaleZ = target.transform.localScale.z;

            EndScaleX = action.EndScaleX;
            EndScaleY = action.EndScaleY;
			EndScaleZ = action.EndScaleZ;

            DeltaX = EndScaleX - StartScaleX;
            DeltaY = EndScaleY - StartScaleY;
			DeltaZ = EndScaleZ - StartScaleZ;
        }

        public override void Update (float time)
        {
            if (Target != null)
            {
               	var ScaleX = StartScaleX + DeltaX * time;
                var ScaleY = StartScaleY + DeltaY * time;
				var ScaleZ = StartScaleZ + DeltaZ * time;
				Target.transform.localScale = new Vector3 (ScaleX, ScaleY, ScaleZ);
            }
        }
    }
}