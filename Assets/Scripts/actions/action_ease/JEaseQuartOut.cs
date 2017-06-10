using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseQuartOut : MTActionEase
	{
		public MTEaseQuartOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseQuartOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseQuartIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseQuartOutState : MTActionEaseState
	{
		public MTEaseQuartOutState (MTEaseQuartOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.QuartOut (time));
		}
	}

}