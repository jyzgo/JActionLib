using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseCubicOut : MTActionEase
	{
		public MTEaseCubicOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseCubicOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseCubicIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseCubicOutState : MTActionEaseState
	{
		public MTEaseCubicOutState (MTEaseCubicOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.CubicOut (time));
		}
	}

}