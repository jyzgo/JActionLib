using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseQuartInOut : MTActionEase
	{
		public MTEaseQuartInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseQuartInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseQuartInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseQuartInOutState : MTActionEaseState
	{
		public MTEaseQuartInOutState (MTEaseQuartInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.QuartInOut (time));
		}
	}

}