using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseCubicInOut : MTActionEase
	{
		public MTEaseCubicInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseCubicInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseCubicInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseCubicInOutState : MTActionEaseState
	{
		public MTEaseCubicInOutState (MTEaseCubicInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.CubicInOut (time));
		}
	}

}