using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseCubicOut : JActionEase
	{
		public JEaseCubicOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseCubicOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseCubicIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseCubicOutState : JActionEaseState
	{
		public JEaseCubicOutState (JEaseCubicOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.CubicOut (time));
		}
	}

}