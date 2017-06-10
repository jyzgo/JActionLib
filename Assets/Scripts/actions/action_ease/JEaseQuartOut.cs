using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseQuartOut : JActionEase
	{
		public JEaseQuartOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseQuartOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseQuartIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseQuartOutState : JActionEaseState
	{
		public JEaseQuartOutState (JEaseQuartOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.QuartOut (time));
		}
	}

}