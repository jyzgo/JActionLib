using System;

using UnityEngine;

namespace JUnity.Actions
{
	public class JRotateRoundTo : JFiniteTimeAction
	{

		#region Constructors

		public new float Duration{ get; private set; }

		public float Radius{ get; private set; }

		public float StartAngle{ get; private set; }

		public float AngleDuration{ get; private set; }

		public Vector3 Center{ get; private set; }

		public JRotateRoundTo (float duration, float radius, Vector3 center, float startAngle, float angleDuration) : base (duration)
		{
			Duration = duration;
			Center = center;
			Radius = radius;
			StartAngle = startAngle;
			AngleDuration = angleDuration;
		}

		#endregion Constructors

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JRotateRoundToState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			throw new NotImplementedException ();
		}
	}


	public class JRotateRoundToState : JFiniteTimeActionState
	{

		public JRotateRoundToState (JRotateRoundTo action, GameObject target)
			: base (action, target)
		{ 
			FromAngle = action.StartAngle;
			ToAngle = action.AngleDuration;
			Radius = action.Radius;
			InTime = action.Duration;
			Center = action.Center;
		}

		Vector3 Center;
		float FromAngle;
		float ToAngle;
		float Radius;
		float InTime;
		float curTime = 0f;

		public override void Update (float time)
		{
			if(Target != null){
				Vector3 pos = Vector3.zero;
				pos.x = Mathf.Cos ((curTime / InTime * ToAngle + FromAngle) * Mathf.Deg2Rad) * Radius + Center.x;
				pos.y = Mathf.Sin ((curTime / InTime * ToAngle + FromAngle) * Mathf.Deg2Rad) * Radius + Center.y;

				Target.transform.localPosition = pos;

				Vector3 dir = pos - Center;

				Target.transform.localRotation = Quaternion.Euler (0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

				curTime += Time.deltaTime;
			}
		}

	}
}