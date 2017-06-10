using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseQuadOut : MTActionEase
	{
		public MTEaseQuadOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseQuadOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseQuadIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseQuadOutState : MTActionEaseState
	{
		public MTEaseQuadOutState (MTEaseQuadOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.QuadOut (time));
		}
	}

}