using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseCircIn : MTActionEase
	{
		public MTEaseCircIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseCircInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseCircOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseCircInState : MTActionEaseState
	{
		public MTEaseCircInState (MTEaseCircIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.CircIn (time));
		}
	}

}