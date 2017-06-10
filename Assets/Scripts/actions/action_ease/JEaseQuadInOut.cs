using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseQuadInOut : MTActionEase
	{
		public MTEaseQuadInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseQuadInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseQuadInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseQuadInOutState : MTActionEaseState
	{
		public MTEaseQuadInOutState (MTEaseQuadInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.QuadInOut (time));
		}
	}

}