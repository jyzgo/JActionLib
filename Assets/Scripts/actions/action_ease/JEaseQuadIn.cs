using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseQuadIn : MTActionEase
	{
		public MTEaseQuadIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseQuadInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseQuadOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseQuadInState : MTActionEaseState
	{
		public MTEaseQuadInState (MTEaseQuadIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.QuadIn (time));
		}
	}

}