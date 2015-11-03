using UnityEngine;

namespace MTUnity.Actions
{
	public class MTScaleParticleTo : MTFiniteTimeAction
	{
		public float EndScale { get; private set; }
				
		
		#region Constructors
		
		public MTScaleParticleTo (float duration, float scale) 
		{
			EndScale = scale;
		}
		

		
		#endregion Constructors
		
		public override MTFiniteTimeAction Reverse()
		{
			throw new System.NotImplementedException ();
		}
		
		protected internal override MTActionState StartAction(GameObject target)
		{
			return new MTScaleToParticleState (this, target);
		}
	}
	
	public class MTScaleToParticleState : MTFiniteTimeActionState
	{
		protected float DeltaX;

		
		protected float EndScaleX;

		
		protected float StartScaleX;

		
		public MTScaleToParticleState (MTScaleParticleTo action, GameObject target)
			: base (action, target)
		{ 
			StartScaleX = 1f;// target.transform.localScale.x;

			
			EndScaleX = action.EndScale;

			
			DeltaX = EndScaleX - StartScaleX;

		}
		
		public override void Update (float time)
		{
			if (Target != null)
			{
				var Scale = StartScaleX + DeltaX * time;
				Target.SetParticleScale(Scale);
			}
		}
	}
}