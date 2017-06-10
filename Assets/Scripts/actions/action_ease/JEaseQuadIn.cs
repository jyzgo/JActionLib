using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseQuadIn : JActionEase
	{
		public JEaseQuadIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseQuadInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseQuadOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseQuadInState : JActionEaseState
	{
		public JEaseQuadInState (JEaseQuadIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.QuadIn (time));
		}
	}

}