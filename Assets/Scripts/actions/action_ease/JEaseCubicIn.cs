using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseCubicIn : MTActionEase
	{
		public MTEaseCubicIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseCubicInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseCubicOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseCubicInState : MTActionEaseState
	{
		public MTEaseCubicInState (MTEaseCubicIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.CubicIn (time));
		}
	}

}