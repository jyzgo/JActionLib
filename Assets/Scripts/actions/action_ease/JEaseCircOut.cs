using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseCircOut : MTActionEase
	{
		public MTEaseCircOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseCircOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseCircIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseCircOutState : MTActionEaseState
	{
		public MTEaseCircOutState (MTEaseCircOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.CircOut (time));
		}
	}

}