using System;

using UnityEngine;

namespace MTUnity.Actions
{
    public class MTRotateTo : MTFiniteTimeAction
    {
        public float DistanceAngleX { get; private set; }
        public float DistanceAngleY { get; private set; }
		public float DistanceAngleZ { get; private set; }


        #region Constructors

		public MTRotateTo (float duration, float deltaAngleX, float deltaAngleY,float deltaAngleZ) : base (duration)
        {
            DistanceAngleX = deltaAngleX;
            DistanceAngleY = deltaAngleY;
			DistanceAngleZ = deltaAngleZ;
        }

		public MTRotateTo (float duration, float deltaAngle) : this (duration, deltaAngle, deltaAngle,deltaAngle)
        {
        }

        #endregion Constructors

        protected internal override MTActionState StartAction(GameObject target)
        {
            return new MTRotateToState (this, target);
        }

        public override MTFiniteTimeAction Reverse()
        {
            throw new NotImplementedException();
        }
    }


    public class MTRotateToState : MTFiniteTimeActionState
    {
        protected float DiffAngleY;
        protected float DiffAngleX;
		protected float DiffAngleZ;

        protected float DistanceAngleX { get; set; }

        protected float DistanceAngleY { get; set; }

		protected float DistanceAngleZ { get ; set;}

        protected float StartAngleX;
        protected float StartAngleY;
		protected float StartAngleZ;

        public MTRotateToState (MTRotateTo action, GameObject target)
            : base (action, target)
        { 
            DistanceAngleX = action.DistanceAngleX;
            DistanceAngleY = action.DistanceAngleY;
			DistanceAngleZ = action.DistanceAngleZ;

            // Calculate X
			StartAngleX = Target.transform.localRotation.x;
            if (StartAngleX > 0)
            {
                StartAngleX = StartAngleX % 360.0f;
            }
            else
            {
                StartAngleX = StartAngleX % -360.0f;
            }

            DiffAngleX = DistanceAngleX - StartAngleX;
            if (DiffAngleX > 180)
            {
                DiffAngleX -= 360;
            }
            if (DiffAngleX < -180)
            {
                DiffAngleX += 360;
            }

            //Calculate Y: It's duplicated from calculating X since the rotation wrap should be the same
			StartAngleY = Target.transform.localRotation.y;

            if (StartAngleY > 0)
            {
                StartAngleY = StartAngleY % 360.0f;
            }
            else
            {
                StartAngleY = StartAngleY % -360.0f;
            }

            DiffAngleY = DistanceAngleY - StartAngleY;
            if (DiffAngleY > 180)
            {
                DiffAngleY -= 360;
            }

            if (DiffAngleY < -180)
            {
                DiffAngleY += 360;
            }

			StartAngleZ = Target.transform.localRotation.z;

			if (StartAngleZ > 0)
			{
				StartAngleZ = StartAngleZ % 360.0f;
			}
			else
			{
				StartAngleZ = StartAngleZ % -360.0f;
			}

			DiffAngleZ = DistanceAngleZ - StartAngleY;
			if (DiffAngleY > 180)
			{
				DiffAngleY -= 360;
			}

			if (DiffAngleY < -180)
			{
				DiffAngleY += 360;
			}
        }

        public override void Update (float time)
        {
            if (Target != null)
            {
                var RotationX = StartAngleX + DiffAngleX * time;
                var RotationY = StartAngleY + DiffAngleY * time;
				var RotationZ = StartAngleZ + DiffAngleZ * time;
				Target.transform.Rotate (RotationX, RotationY, RotationZ);
            }
        }

    }
}