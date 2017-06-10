using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseCubicInOut : JActionEase
	{
		public JEaseCubicInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseCubicInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseCubicInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseCubicInOutState : JActionEaseState
	{
		public JEaseCubicInOutState (JEaseCubicInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.CubicInOut (time));
		}
	}

}