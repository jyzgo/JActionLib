using System;
using System.Collections.Generic;

using UnityEngine;

namespace JUnity.Actions
{
	public class JDestroy : JActionInstant
	{

		
		#region Constructors
		

		float _delayTime = 0f;
		public JDestroy (float delayTime = 0f)
		{
			_delayTime = delayTime;
		}
		
		#endregion Constructors
		
		
		protected internal override JActionState StartAction(GameObject target)
		{
			return new JDestroyState (this, target,_delayTime);
			
		}
		
		
		public override JFiniteTimeAction Reverse ()
		{
			return new JDestroy (_delayTime);
		}
	}
	
	public class JDestroyState : JActionInstantState
	{
		float _delayTime = 0f;
		
		public JDestroyState (JDestroy action, GameObject target,float delayTime = 0f)
			: base (action, target)
		{   
			_delayTime = delayTime;
		}
		
		public override void Update (float time)
		{
			if (Target && Target.gameObject) 
			{
                GameObject.Destroy(Target);	
			}
		}
		
	}
	
}