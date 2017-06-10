using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseQuartIn : MTActionEase
	{
		public MTEaseQuartIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseQuartInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseQuartOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseQuartInState : MTActionEaseState
	{
		public MTEaseQuartInState (MTEaseQuartIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.QuartIn (time));
		}
	}

}