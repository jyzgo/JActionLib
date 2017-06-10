using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseQuintInOut : MTActionEase
	{
		public MTEaseQuintInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseQuintInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseQuintInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseQuintInOutState : MTActionEaseState
	{
		public MTEaseQuintInOutState (MTEaseQuintInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.QuintInOut (time));
		}
	}

}