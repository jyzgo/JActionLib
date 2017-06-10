using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseQuartIn : JActionEase
	{
		public JEaseQuartIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseQuartInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseQuartOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseQuartInState : JActionEaseState
	{
		public JEaseQuartInState (JEaseQuartIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.QuartIn (time));
		}
	}

}