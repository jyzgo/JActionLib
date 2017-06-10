using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseQuintOut : MTActionEase
	{
		public MTEaseQuintOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseQuintOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseQuintIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseQuintOutState : MTActionEaseState
	{
		public MTEaseQuintOutState (MTEaseQuintOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.QuintOut (time));
		}
	}

}