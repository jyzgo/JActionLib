using UnityEngine;

namespace JUnity.Actions
{
    public class JRotateBy : JFiniteTimeAction
    {
        public float AngleX { get; private set; }
        public float AngleY { get; private set; }
		public float AngleZ { get;private set;}


        #region Constructors

		public JRotateBy (float duration, float deltaAngleX, float deltaAngleY,float deltaAngleZ) : base (duration)
        {
            AngleX = deltaAngleX;
            AngleY = deltaAngleY;
			AngleZ = deltaAngleZ;
        }

		public JRotateBy (float duration, float deltaAngle) : this (duration, deltaAngle, deltaAngle,deltaAngle)
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JRotateByState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
			return new JRotateBy (Duration, -AngleX, -AngleY,-AngleZ);
        }
    }

    public class JRotateByState : JFiniteTimeActionState
    {

        protected float AngleX { get; set; }

        protected float AngleY { get; set; }

		protected float AngleZ { get;set;}

        protected float StartAngleX { get; set; }

        protected float StartAngleY { get; set; }

		protected float StartAngleZ { get; set;}

        public JRotateByState (JRotateBy action, GameObject target)
            : base (action, target)
        { 
            AngleX = action.AngleX;
            AngleY = action.AngleY;
			AngleZ = action.AngleZ;

			StartAngleX = target.transform.localRotation.x;
			StartAngleY = target.transform.localRotation.y;
			StartAngleZ = target.transform.localRotation.z;

        }

        public override void Update (float time)
        {
            // XXX: shall I add % 360
            if (Target != null)
            {
				var RotationX = StartAngleX + AngleX * time;
                var RotationY = StartAngleY + AngleY * time;
				var RotationZ = StartAngleZ + AngleZ * time;

				Target.transform.Rotate (new Vector3 (RotationX, RotationY, RotationZ));
            }
        }

    }

}