using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseCircInOut : MTActionEase
	{
		public MTEaseCircInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseCircInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseCircInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseCircInOutState : MTActionEaseState
	{
		public MTEaseCircInOutState (MTEaseCircInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.CircInOut (time));
		}
	}

}