using UnityEngine;

namespace JUnity.Actions
{
	public class JScaleBy : JScaleTo
	{
		#region Constructors


        public JScaleBy (float duration, float scale) : base (duration, scale)
		{
		}

		public JScaleBy (float duration, float scaleX, float scaleY,float scaleZ) : base (duration, scaleX, scaleY,scaleZ)
		{
		}

		#endregion Constructors

		protected internal override JActionState StartAction(GameObject target)
		{
			return new JScaleByState (this, target);

		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JScaleBy (Duration, 1 / EndScaleX, 1 / EndScaleY , 1/EndScaleZ);
		}

	}

    public class JScaleByState : JScaleToState
	{

		public JScaleByState (JScaleTo action, GameObject target)
			: base (action, target)
		{ 
			DeltaX = StartScaleX * EndScaleX - StartScaleX;
			DeltaY = StartScaleY * EndScaleY - StartScaleY;
			DeltaZ = StartScaleZ * EndScaleZ - StartScaleZ;
		}

	}

}